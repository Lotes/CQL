using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.TypeSystem;
using CQL.TypeSystem.Implementation;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// A method call consists of a THIS expression (its value should contain a member function closure) 
    /// and zero to several parameter expressions.
    /// </summary>
    public class FunctionCallExpression: IExpression<FunctionCallExpression>
    {
        /// <summary>
        /// The evaluated THIS expression must evaluate to a member function closure.
        /// </summary>
        /// <seealso cref="IMemberFunctionClosure"/>
        public IExpression ThisExpression;

        /// <summary>
        /// Contains the expressions of the member function call parameters.
        /// </summary>
        public IEnumerable<IExpression> Parameters { get; private set; }

        /// <summary>
        /// Creates a member function call expression.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="this"></param>
        /// <param name="parameters"></param>
        public FunctionCallExpression(IParserLocation context, IExpression @this, IEnumerable<IExpression> parameters)
        {
            ThisExpression = @this;
            Parameters = parameters.ToArray();
            Location = context;
        }

        /// <summary>
        /// Contains the position of the member function call if parsed from a user query.
        /// </summary>
        public IParserLocation Location { get; private set; }

        /// <summary>
        /// After validation, this property will contain the return type of the member function call.
        /// </summary>
        public Type SemanticType { get; private set; }
       
        /// <summary>
        /// Deep equals for this syntax node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as FunctionCallExpression;
            if (other == null)
                return false;
            return this.ThisExpression.StructurallyEquals(other.ThisExpression)
                && this.Parameters.StructurallyEquals(other.Parameters);
        }

        /// <summary>
        /// Creates a user-readable string, representing the member function call.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{ThisExpression.ToString()}({string.Join(", ", Parameters.Select(p => p.ToString()))})";
        }

        /// <summary>
        /// Validates this function call, by checking the signature, parameter count.
        /// Sets the semantic type to the return type of the found function.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public FunctionCallExpression Validate(IScope<Type> context)
        {
            ThisExpression = ThisExpression.Validate(context);
            MethodSignature methodSignature;
            GlobalFunctionSignature functionSignature;
            if (ThisExpression.SemanticType.IfMethodClosureTryGetMethodType(out methodSignature))
            {
                var parameterIndex = 0;
                if (methodSignature.ParameterTypes.Length != Parameters.Count())
                    throw new LocateableException(Location, "Parameter count mismatch!");
                Parameters = Parameters.Select(p =>
                {
                    p = p.Validate(context);
                    var formalType = methodSignature.ParameterTypes[parameterIndex];
                    parameterIndex++;
                    if (p.SemanticType != formalType)
                    {
                        var chain = context.TypeSystem.GetImplicitlyCastChain(p.SemanticType, formalType);
                        p = chain.ApplyCast(p, context, () => new LocateableException(p.Location, "Parameter " + parameterIndex + " type mismatch: can not convert."));
                    }
                    return p;
                }).ToArray();
                SemanticType = methodSignature.ReturnType;
                return this;
            }
            else if (ThisExpression.SemanticType.IfFunctionClosureTryGetFunctionType(out functionSignature))
            {
                var parameterIndex = 0;
                if (functionSignature.ParameterTypes.Length != Parameters.Count())
                    throw new InvalidOperationException("Parameter count mismatch!");
                Parameters = Parameters.Select(p =>
                {
                    p = p.Validate(context);
                    var formalType = functionSignature.ParameterTypes[parameterIndex];
                    parameterIndex++;
                    if (p.SemanticType != formalType)
                    {
                        var chain = context.TypeSystem.GetImplicitlyCastChain(p.SemanticType, formalType);
                        p = chain.ApplyCast(p, context, () => new InvalidOperationException("Parameter " + parameterIndex + " type mismatch: can not convert."));
                    }
                    return p;
                }).ToArray();
                SemanticType = functionSignature.ReturnType;
                return this;
            }
            else
                throw new LocateableException(Location, "Closure expected!");
        }

        IExpression IExpression.Validate(IScope<Type> context)
        {
            return Validate(context);
        }

        /// <summary>
        /// Evaluates the THIS expression first. If the result is a function closure, the closure will be invoked with the evaluated parameters.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Evaluate(IScope<object> context)
        {
            var @this = this.ThisExpression.Evaluate(context);
            if(@this is IMemberFunctionClosure)
                return ((IMemberFunctionClosure)@this).Invoke(Parameters.Select(p => p.Evaluate(context)).ToArray());
            if (@this is IGlobalFunctionClosure)
                return ((IGlobalFunctionClosure)@this).Invoke(Parameters.Select(p => p.Evaluate(context)).ToArray());
            throw new LocateableException(Location, "Closure expected!");
        }
    }
}
