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
        public readonly string Name;
        public IEnumerable<IExpression> Parameters { get; private set; }
        private IFunction function = null;

        public FunctionCallExpression(ParserRuleContext context, string name, IEnumerable<IExpression> parameters)
        {
            Name = name;
            Parameters = parameters.ToArray();
            ParserContext = context;
        }
        public ParserRuleContext ParserContext { get; private set; }

        public Type SemanticType { get; private set; }
       
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as FunctionCallExpression;
            if (other == null)
                return false;
            return this.Name == other.Name
                && this.Parameters.StructurallyEquals(other.Parameters);
        }

        public override string ToString()
        {
            return $"{Name}({string.Join(", ", Parameters.Select(p => p.ToString()))})";
        }

        public FunctionCallExpression Validate(IContext context)
        {
            function = context.Get(Name) as IFunction;
            if (function == null)
                throw new LocateableException(ParserContext, "Unsupported function!");
            if (function.Arity != Parameters.Count())
                throw new LocateableException(ParserContext, $"This function expects exactly {function.Arity} parameters, not {Parameters.Count()}!");

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
                        () => new LocateableException(ParserContext, $"The {index + 1}. parameter type does not match the function signature."));
                }
            }
            this.Parameters = actuals;

            this.SemanticType = function.ResultType;
            return this;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return Validate(context);
        }

        public object Evaluate<TSubject>(TSubject subject)
        {
            return function.Invoke(Parameters.Select(p => p.Evaluate(subject)).ToArray());
        }
    }
}
