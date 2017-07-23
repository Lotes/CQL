using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.AutoCompletion
{
    public class AutoCompletionSuggester : IAutoCompletionSuggester
    {
        private class MyTokenStream
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
                if (start+1 >= tokens.Length)
                {
                    return new CommonToken(-1);
                }
                else
                {
                    return tokens[start+1];
                }
            }
            public bool AtCaret()
            {
                var next = Next();
                var nextNext = NextNext();
                return next.Type < 0
                    || (nextNext.Type < 0 && next.StopIndex+1 == nextNext.StartIndex);
            }
            public MyTokenStream Move() { return new MyTokenStream(tokens, start + 1); }
        }

        private string[] ruleNames;
        private IVocabulary vocabulary;
        private ATN atn;

        public AutoCompletionSuggester(string[] ruleNames, IVocabulary vocabulary, ATN atn)
        {
            this.ruleNames = ruleNames;
            this.vocabulary = vocabulary;
            this.atn = atn;
        }

        public IEnumerable<int> GetSuggestions(string code)
        {
            var collector = new HashSet<int>();
            var charStream = new AntlrInputStream(code);
            var lexer = new CQLLexer(charStream);
            var alreadyPassed = Enumerable.Empty<int>();
            var history = Enumerable.Empty<string>();
            Process(atn.states[0], new MyTokenStream(lexer.ToList()), collector, new ParserStack(), alreadyPassed, history);
            return collector;
        }

        private void Process(ATNState state, MyTokenStream tokens, ICollection<int> collector, ParserStack parserStack,
                    IEnumerable<int> alreadyPassed, IEnumerable<string> history)
        {
            var atCaret = tokens.AtCaret();
            var stackRes = parserStack.Process(state);
            if (!stackRes.Item1)
            {
                return;
            }

            foreach (var it in state.Transitions)
            {
                var desc = state.StateNumber.ToString(); // describe(ruleNames, vocabulary, state, it)
                if (it.IsEpsilon)
                {
                    if (!alreadyPassed.Contains(it.target.stateNumber))
                    {
                        Process(it.target, tokens, collector, stackRes.Item2,
                                alreadyPassed.Concat(new[] { it.target.stateNumber }),
                                history.Concat(new[] { desc }));
                    }
                }
                else if (it is AtomTransition)
                {
                    var atomTransition = it as AtomTransition;
                    var nextTokenType = tokens.Next();
                    if (atCaret)
                    {
                        if (ParserStack.IsCompatibleWith(it.target, parserStack))
                        {
                            Console.WriteLine(CQLParser.ruleNames[parserStack.Top.ruleIndex] + " @ " + parserStack.Top.stateNumber);
                            collector.Add(atomTransition.label);
                        }
                    }
                    else
                    {
                        if (nextTokenType.Type == atomTransition.label)
                        {
                            Process(it.target, tokens.Move(), collector, stackRes.Item2, Enumerable.Empty<int>(), history.Concat(new[] { desc }));
                        }
                    }
                }
                else if (it is SetTransition)
                {
                    var setTransition = it as SetTransition;
                    var nextTokenType = tokens.Next();
                    foreach (var sym in setTransition.Label.ToList())
                    {
                        if (atCaret)
                        {
                            if (ParserStack.IsCompatibleWith(it.target, parserStack))
                            {
                                Console.WriteLine(CQLParser.ruleNames[parserStack.Top.ruleIndex]+" @ "+parserStack.Top.stateNumber);
                                collector.Add(sym);
                            }
                        }
                        else
                        {
                            if (nextTokenType.Type == sym)
                            {
                                Process(it.target, tokens.Move(), collector, stackRes.Item2, Enumerable.Empty<int>(), history.Concat(new[] { desc }));
                            }
                        }
                    }
                }
                else
                    throw new InvalidOperationException(it.GetType().FullName);
            }
        }
    }
}
