using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.AutoCompletion
{
    public class MyTokenStream
    {
        private IToken[] tokens;
        private int start;

        public MyTokenStream(IEnumerable<IToken> tokens, int start = 0)
        {
            this.tokens = tokens.ToArray();
            this.start = start;
        }
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
        public bool AtCaret()
        {
            var next = Next();
            var nextNext = NextNext();
            return next.Type < 0
                || (nextNext.Type < 0 && next.Type == CQLLexer.ID && next.StopIndex + 1 == nextNext.StartIndex);
        }
        public MyTokenStream Move() { return new MyTokenStream(tokens, start + 1); }
    }
}
