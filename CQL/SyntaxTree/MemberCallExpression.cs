using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;

namespace CQL.SyntaxTree
{
    public class MemberCallExpression : IExpression<MemberCallExpression>
    {
        private MethodInfo getter;

        public MemberCallExpression(IParserLocation location, IExpression @this, IdDelimiter delimiter, string memberName)
        {
            Location = location;
            SemanticType = null;
            ThisExpression = @this;
            MemberName = memberName;
            Delimiter = delimiter;
        }

        public IdDelimiter Delimiter { get; private set; }
        public string MemberName { get; private set; }
        public IExpression ThisExpression { get; private set; }
        public IParserLocation Location { get; private set; }
        public Type SemanticType { get; private set; }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as MemberCallExpression;
            if (other == null)
                return false;
            return this.ThisExpression.StructurallyEquals(other.ThisExpression)
                && this.MemberName == other.MemberName;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return Validate(context);
        }

        public MemberCallExpression Validate(IContext context)
        {
            var @this = ThisExpression.Validate(context);
            var property = @this.GetType().GetProperty(MemberName);
            getter = property.GetMethod;
            return this;
        }

        public object Evaluate<TSubject>(TSubject subject)
        {
            var @this = ThisExpression.Evaluate(subject);
            return getter.Invoke(@this, new object[0]);
        }

        public override string ToString()
        {
            var delimiter = "";
            switch(Delimiter)
            {
                case IdDelimiter.Dollar: delimiter = "$"; break;
                case IdDelimiter.Dot: delimiter = "."; break;
                case IdDelimiter.Hash: delimiter = "#"; break;
                case IdDelimiter.SingleArrow: delimiter = "->"; break;
                case IdDelimiter.Slash: delimiter = "/"; break;
            }
            return $"{ThisExpression.ToString()}{delimiter}{MemberName}";
        }
    }
}
