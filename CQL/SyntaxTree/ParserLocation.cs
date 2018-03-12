using Antlr4.Runtime;

namespace CQL.SyntaxTree
{
    public class ParserLocation : IParserLocation
    {
        public ParserLocation(int startIndex, int stopIndex)
        {
            StartIndex = startIndex;
            StopIndex = stopIndex;
        }

        public static readonly IParserLocation EmptyContext = new ParserLocation(0, 0);
        public int StartIndex { get; private set; }
        public int StopIndex { get; private set; }

        public static implicit operator ParserLocation(ParserRuleContext ctx)
        {
            return new ParserLocation(ctx.Start.StartIndex, ctx.Stop.StopIndex);
        }
    }
}