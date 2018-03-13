using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.AutoCompletion
{
    /// <summary>
    /// Helper class for handling the token stream.
    /// </summary>
    public class MyTokenStream
    {
        private IToken[] tokens;
        private int start;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="tokens"></param>
        /// <param name="start"></param>
        public MyTokenStream(IEnumerable<IToken> tokens, int start = 0)
        {
            this.tokens = tokens.ToArray();
            this.start = start;
        }

        /// <summary>
        /// Reads the next token. If the end is reached the type will be -1.
        /// </summary>
        /// <returns></returns>
        public IToken Next()
        {
            if (start >= tokens.Length)
            {
                return new CommonToken(-1);
            }
            else
            {
                return tokens[start];
            }
        }
        /// <summary>
        /// Same as Next(). But returns the token ofter the next token.
        /// </summary>
        /// <returns></returns>
        public IToken NextNext()
        {
            if (start + 1 >= tokens.Length)
            {
                return new CommonToken(-1);
            }
            else
            {
                return tokens[start + 1];
            }
        }
        /// <summary>
        /// Returns true, if the cursor is at the caret.
        /// </summary>
        /// <returns></returns>
        public bool AtCaret()
        {
            var next = Next();
            var nextNext = NextNext();
            return next.Type < 0
                || (nextNext.Type < 0 && next.Type == CQLLexer.ID && next.StopIndex + 1 == nextNext.StartIndex);
        }
        /// <summary>
        /// Forks a stream from current position.
        /// </summary>
        /// <returns></returns>
        public MyTokenStream Move() { return new MyTokenStream(tokens, start + 1); }
    }
}
