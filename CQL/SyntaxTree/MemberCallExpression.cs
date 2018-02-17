using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;
using CQL.TypeSystem;

namespace CQL.SyntaxTree
{
    public class MemberCallExpression : IExpression<MemberCallExpression>
    {
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

        IExpression IExpression.Validate(IScope<Type> context)
        {
            return Validate(context);
        }

        public MemberCallExpression Validate(IScope<Type> context)
        {
            var @this = ThisExpression.Validate(context);
            var thisType = @this.SemanticType;
            var csharpType = context.TypeSystem.GetTypeByNative(thisType);
            var symbol = csharpType.GetByName(Delimiter, MemberName);
            if (!(symbol is IProperty))
                throw new InvalidOperationException("Expecting property!");
            var property = symbol as IProperty;
            SemanticType = property.ReturnType;
            return this;
        }

        public object Evaluate(IScope<object> context)
        {
            var @this = ThisExpression.Evaluate(context);
            var thisType = @this.GetType();
            var csharpType = context.TypeSystem.GetTypeByNative(thisType);
            var symbol = csharpType.GetByName(Delimiter, MemberName);
            if (!(symbol is IProperty))
                throw new InvalidOperationException("Expecting property!");
            var property = symbol as IProperty;
            return property.Get(@this);
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
