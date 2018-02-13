using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.TypeSystem;

namespace CQL.SyntaxTree
{
    public class FunctionCallExpression: IExpression<FunctionCallExpression>
    {
        public readonly IExpression ThisExpression;
        public IEnumerable<IExpression> Parameters { get; private set; }

        public FunctionCallExpression(IParserLocation context, IExpression @this, IEnumerable<IExpression> parameters)
        {
            ThisExpression = @this;
            Parameters = parameters.ToArray();
            Location = context;
        }
        public IParserLocation Location { get; private set; }

        public Type SemanticType { get; private set; }
       
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as FunctionCallExpression;
            if (other == null)
                return false;
            return this.ThisExpression.StructurallyEquals(other.ThisExpression)
                && this.Parameters.StructurallyEquals(other.Parameters);
        }

        public override string ToString()
        {
            return $"{ThisExpression.ToString()}({string.Join(", ", Parameters.Select(p => p.ToString()))})";
        }

        public FunctionCallExpression Validate(IContext<Type> context)
        {
            function = null;//TODO context.Get(Name) as IFunction;
            if (function == null)
                throw new LocateableException(Location, "Unsupported function!");
            if (function.Arity != Parameters.Count())
                throw new LocateableException(Location, $"This function expects exactly {function.Arity} parameters, not {Parameters.Count()}!");

            var actuals = Parameters.ToArray();
            var formals = function.Parameters.ToArray();
            for (var index=0; index<function.Arity; index++)
            {
                var actual = actuals[index].Validate(context);
                var formal = formals[index];
                if (!formal.ParameterType.IsAssignableFrom(actual.SemanticType))
                {
                    var chain = context.TypeSystem.GetImplicitlyCastChain(actual.SemanticType, formal.ParameterType);
                    actuals[index] = chain.ApplyCast(actual, context, 
                        () => new LocateableException(Location, $"The {index + 1}. parameter type does not match the function signature."));
                }
            }
            this.Parameters = actuals;

            this.SemanticType = function.ResultType;
            return this;
        }

        IExpression IExpression.Validate(IContext<Type> context)
        {
            return Validate(context);
        }

        public object Evaluate(IContext<object> context)
        {
            //TODO
        }
    }
}
