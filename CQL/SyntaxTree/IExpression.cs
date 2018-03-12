using CQL.Contexts;
using CQL.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// An expression is a syntax node that can be validated and evaluated. During the validation 
    /// process, the syntax tree could be extended with further nodes and annotated with (semantic) types.
    /// </summary>
    /// <seealso cref="CQL.SyntaxTree.ISyntaxTreeNode" />
    public interface IExpression: ISyntaxTreeNode
    {
        /// <summary>
        /// Initially is null! After calling the <see cref="IExpression.Validate(IScope{Type})"/> method
        /// the actual type will be set.
        /// </summary>
        Type SemanticType { get; }

        /// <summary>
        /// Validates this node and sets the semantic type.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        IExpression Validate(IScope<Type> context);

        /// <summary>
        /// Evaluates this node to a value of the validated semantic type.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        object Evaluate(IScope<object> context);
    }

    /// <summary>
    /// The generic side of an expression. Subtype from this interface!
    /// </summary>
    /// <typeparam name="TSelf"></typeparam>
    public interface IExpression<TSelf>: IExpression, ISyntaxTreeNode<TSelf>
    {
    }
}
