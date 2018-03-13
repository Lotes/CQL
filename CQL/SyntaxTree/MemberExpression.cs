using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.TypeSystem;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// AST node representing a member usage outgoing from a this object.
    /// </summary>
    public class MemberExpression : IExpression<MemberExpression>
    {
        private IProperty validatedProperty = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="this"></param>
        /// <param name="delimiter"></param>
        /// <param name="memberName"></param>
        public MemberExpression(IParserLocation location, IExpression @this, IdDelimiter delimiter, string memberName)
        {
            Location = location;
            SemanticType = null;
            ThisExpression = @this;
            MemberName = memberName;
            Delimiter = delimiter;
        }

        /// <summary>
        /// Delimiter outgoing from the THIS object.
        /// </summary>
        public IdDelimiter Delimiter { get; private set; }
        /// <summary>
        /// Name of the member ofter the delimiter.
        /// </summary>
        public string MemberName { get; private set; }
        /// <summary>
        /// The actual THIS expression looking for member.
        /// </summary>
        public IExpression ThisExpression { get; private set; }
        /// <summary>
        /// Position of this expression in the query text.
        /// </summary>
        public IParserLocation Location { get; private set; }
        /// <summary>
        /// Validated type of the member.
        /// </summary>
        public Type SemanticType { get; private set; }

        /// <summary>
        /// Deep equals.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as MemberExpression;
            if (other == null)
                return false;
            return this.ThisExpression.StructurallyEquals(other.ThisExpression)
                && this.MemberName == other.MemberName;
        }

        IExpression IExpression.Validate(IValidationScope context)
        {
            return Validate(context);
        }

        /// <summary>
        /// Validation, checking whether the member is a valid property.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public MemberExpression Validate(IValidationScope context)
        {
            var @this = ThisExpression.Validate(context);
            var thisType = @this.SemanticType;
            var csharpType = context.TypeSystem.GetTypeByNative(thisType);
            var symbol = csharpType.GetByName(Delimiter, MemberName);
            if (!(symbol is IProperty))
                throw new LocateableException(Location, "Expecting property!");
            validatedProperty = symbol as IProperty;
            SemanticType = validatedProperty.ReturnType;
            return this;
        }

        /// <summary>
        /// Evaluation.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Evaluate(IEvaluationScope context)
        {
            var @this = ThisExpression.Evaluate(context);
            return validatedProperty.Get(@this);
        }

        /// <summary>
        /// Outputs a user-friendly representation of this expression.
        /// </summary>
        /// <returns></returns>
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
