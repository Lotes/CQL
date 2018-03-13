using Antlr4.Runtime;
using CQL.Contexts;
using CQL.ErrorHandling;
using System;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// Base class of all abstract syntax tree nodes (AST).
    /// </summary>
    public interface ISyntaxTreeNode
    {
        /// <summary>
        /// String position of the node in the input text (from...to).
        /// </summary>
        IParserLocation Location { get; }
        /// <summary>
        /// Deep equals of a AST node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        bool StructurallyEquals(ISyntaxTreeNode node);
    }

    /// <summary>
    /// Actual generic base of all AST nodes.
    /// </summary>
    /// <typeparam name="TSelf"></typeparam>
    public interface ISyntaxTreeNode<TSelf>: ISyntaxTreeNode
    {
        /// <summary>
        /// The validation checks the node for validaty and may replace it by conversion nodes.
        /// The result returns an extended AST.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        TSelf Validate(IValidationScope context);
    }
}