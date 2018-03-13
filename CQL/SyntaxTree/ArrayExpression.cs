using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.TypeSystem;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// Represents an array literal.
    /// </summary>
    public class ArrayExpression: IExpression<ArrayExpression>
    {
        /// <summary>
        /// Expressions of all elements.
        /// </summary>
        public IEnumerable<IExpression> Elements { get; private set; }

        /// <summary>
        /// Creates a ArrayExpression.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="elements"></param>
        public ArrayExpression(IParserLocation context, IEnumerable<IExpression> elements)
        {
            Elements = elements.ToArray();
            Location = context;
            SemanticType = null;
        }

        /// <summary>
        /// Position of the literal in the user query test.
        /// </summary>
        public IParserLocation Location { get; private set; }

        /// <summary>
        /// Validated type of the array.
        /// </summary>
        public Type SemanticType { get; private set; }

        /// <summary>
        /// Deep equals.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as ArrayExpression;
            if (other == null)
                return false;
            return this.Elements.StructurallyEquals(other.Elements);
        }

        /// <summary>
        /// Outputs user friendly string representing this expression.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[{string.Join(", ", Elements.Select(e => e.ToString()))}]";
        }

        IExpression IExpression.Validate(IValidationScope context)
        {
            return Validate(context);
        }

        /// <summary>
        /// Validates expression. Trys to align types.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public ArrayExpression Validate(IValidationScope context)
        {
            var elements = Elements.Select(e => e.Validate(context)).ToArray();
            //Attention! The array has at least one element.
            var elementType = Elements.First().SemanticType;
            for(var index=1; index<elements.Length; index++)
                if(elements[index].SemanticType != elementType)
                    elementType = context.AlignTypes(ref elements[index-1], ref elements[index], () => new LocateableException(Location, "Could not unify type of this array!"));
            Elements = elements;
            elementType = Elements.Select(e => e.SemanticType).GetCommonBaseClass();
            SemanticType = elementType.MakeArrayType();
            return this;
        }

        /// <summary>
        /// Evaluates the value of this array expression.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Evaluate(IEvaluationScope context)
        {
            var values = Elements.Select(elem => elem.Evaluate(context)).ToArray();
            var result = (Array)Activator.CreateInstance(SemanticType, values.Length);
            for (var index = 0; index < values.Length; index++)
                result.SetValue(values[index], index);
            return result;
        }
    }
}
