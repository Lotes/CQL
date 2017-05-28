using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainCore.CQL.Contexts;
using MainCore.CQL.ErrorHandling;

namespace MainCore.CQL.SyntaxTree
{
    public class Query: ISyntaxTreeNode<Query>
    {
        public IExpression Expression { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="expression">not null</param>
        public Query(ParserRuleContext context, IExpression expression)
        {
            ParserContext = context;
            Expression = expression;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as Query;
            if (other == null)
                return false;
            return this.Expression.StructurallyEquals(other.Expression);
        }

        public override string ToString()
        {
            return Expression.ToString();
        }

        public Query Validate(IContext context)
        {
            Expression = Expression.Validate(context);
            if (Expression.SemanticType != typeof(bool))
                throw new LocateableException(Expression.ParserContext, "Query expression type must be boolean!");
            return this;
        }

        public bool Evaluate<TSubject>(TSubject subject)
        {
            return (bool)Expression.Evaluate(subject);
        }
    }
}
