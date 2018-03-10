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
    public class MethodCallExpression: IExpression<MethodCallExpression>
    {
        public IExpression ThisExpression;

        public IEnumerable<IExpression> Parameters { get; private set; }

        public MethodCallExpression(IParserLocation context, IExpression @this, IEnumerable<IExpression> parameters)
        {
            ThisExpression = @this;
            Parameters = parameters.ToArray();
            Location = context;
        }
        public IParserLocation Location { get; private set; }

        public Type SemanticType { get; private set; }
       
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as MethodCallExpression;
            if (other == null)
                return false;
            return this.ThisExpression.StructurallyEquals(other.ThisExpression)
                && this.Parameters.StructurallyEquals(other.Parameters);
        }

        public override string ToString()
        {
            return $"{ThisExpression.ToString()}({string.Join(", ", Parameters.Select(p => p.ToString()))})";
        }

        public MethodCallExpression Validate(IScope<Type> context)
        {
            ThisExpression = ThisExpression.Validate(context);
            MethodSignature methodSignature;
            GlobalFunctionSignature functionSignature;
            if (ThisExpression.SemanticType.IfMethodClosureTryGetMethodType(out methodSignature))
            {
                var parameterIndex = 0;
                if (methodSignature.ParameterTypes.Length != Parameters.Count())
                    throw new InvalidOperationException("Parameter count mismatch!");
                Parameters = Parameters.Select(p =>
                {
                    p = p.Validate(context);
                    var formalType = methodSignature.ParameterTypes[parameterIndex];
                    parameterIndex++;
                    if (p.SemanticType != formalType)
                    {
                        var chain = context.TypeSystem.GetImplicitlyCastChain(p.SemanticType, formalType);
                        p = chain.ApplyCast(p, context, () => new InvalidOperationException("Parameter " + parameterIndex + " type mismatch: can not convert."));
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

        public object Evaluate(IScope<object> context)
        {
            var @this = this.ThisExpression.Evaluate(context);
            if(@this is IMemberFunctionClosure)
                return ((IMemberFunctionClosure)@this).Invoke(Parameters.Select(p => p.Evaluate(context)).ToArray());
            if (@this is IGlobalFunctionClosure)
                return ((IGlobalFunctionClosure)@this).Invoke(Parameters.Select(p => p.Evaluate(context)).ToArray());
            throw new InvalidOperationException("Closure expected!");
        }
    }
}
