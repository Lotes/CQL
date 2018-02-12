using Antlr4.Runtime;
using System;

namespace CQL.SyntaxTree
{
    public interface IParserLocation
    {
        int StartIndex { get; }
        int StopIndex { get; }
    }

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

    public static class ParserLocationExtensions
    {
        public static int GetLength(this IParserLocation loc)
        {
            return loc.StopIndex - loc.StartIndex + 1;
        }
    }
}