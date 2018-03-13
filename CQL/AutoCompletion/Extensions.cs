using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CQL.AutoCompletion
{
    /// <summary>
    /// Auto completion extensions.
    /// </summary>
    public static class Extensions
    {
        private static ConditionalWeakTable<CQLLexer, IEnumerable<IToken>> tokensByLexer = new ConditionalWeakTable<CQLLexer, IEnumerable<IToken>>();

        /// <summary>
        /// Special id for the caret.
        /// </summary>
        public const int TokenType_Caret = -10;

        /// <summary>
        /// Converts lexer processings into a set of resulting tokens.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IEnumerable<IToken> ToList(this CQLLexer @this)
        {
            return tokensByLexer.GetValue(@this, lexer =>
            {
                var res = new LinkedList<IToken>();
                IToken next;
                //try
                {
                    do
                    {
                        next = lexer.NextToken();
                        if (next.Channel == 0)
                        {
                            if (next.Type < 0)
                            {
                                next = new CommonToken(new Tuple<ITokenSource, ICharStream>(next.TokenSource, next.InputStream), TokenType_Caret, 0, next.StartIndex, next.StopIndex);
                            }
                            res.AddLast(next);
                        }
                    } while (next.Type >= 0);
                }
                /*catch (NoViableAltException)
                {
                    res.AddLast(new CommonToken(CQLLexer.Eof));
                }*/
                return res;
            });
        }
    }
}
