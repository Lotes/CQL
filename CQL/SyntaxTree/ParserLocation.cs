using Antlr4.Runtime;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// Positional helper, containing all information to address an expression in the query text.
    /// </summary>
    public class ParserLocation : IParserLocation
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="stopIndex"></param>
        public ParserLocation(int startIndex, int stopIndex)
        {
            StartIndex = startIndex;
            StopIndex = stopIndex;
        }

        /// <summary>
        /// Default instance with invalid position (0,0).
        /// </summary>
        public static readonly IParserLocation EmptyContext = new ParserLocation(0, 0);
        /// <summary>
        /// Starting character index.
        /// </summary>
        public int StartIndex { get; private set; }
        /// <summary>
        /// Stopping character index.
        /// </summary>
        public int StopIndex { get; private set; }
        /// <summary>
        /// Implicit conversion form parser context to ParserLocation.
        /// </summary>
        /// <param name="ctx"></param>
        public static implicit operator ParserLocation(ParserRuleContext ctx)
        {
            return new ParserLocation(ctx.Start.StartIndex, ctx.Stop.StopIndex);
        }
    }
}