namespace CQL.SyntaxTree
{
    /// <summary>
    /// Extensions for parser locations
    /// </summary>
    public static class ParserLocationExtensions
    {
        /// <summary>
        /// Computes the length of a range.
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public static int GetLength(this IParserLocation loc)
        {
            return loc.StopIndex - loc.StartIndex + 1;
        }
    }
}