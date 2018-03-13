using System;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// Position of a AST node in the query text.
    /// </summary>
    public interface IParserLocation
    {
        /// <summary>
        /// Index of the first character.
        /// </summary>
        int StartIndex { get; }
        /// <summary>
        /// Index of the last character.
        /// </summary>
        int StopIndex { get; }
    }
}