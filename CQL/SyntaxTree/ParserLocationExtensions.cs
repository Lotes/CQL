namespace CQL.SyntaxTree
{
    public static class ParserLocationExtensions
    {
        public static int GetLength(this IParserLocation loc)
        {
            return loc.StopIndex - loc.StartIndex + 1;
        }
    }
}