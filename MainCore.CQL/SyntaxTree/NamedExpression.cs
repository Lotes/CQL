using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public class NamedExpression
    {
        public readonly IExpression Expression;
        public readonly string Name;

        public NamedExpression(IExpression expression, string name)
        {
            Expression = expression;
            Name = name;
        }

        public override string ToString()
        {
            return Expression.ToString() + (string.IsNullOrEmpty(Name) ? "" : " AS \""+Name.Escape()+"\"");
        }
    }
}
