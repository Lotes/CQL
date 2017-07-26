using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using MainCore.CQL.Contexts;
using MainCore.CQL.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.AutoCompletion
{
    public class AutoCompletionSuggester : IAutoCompletionSuggester
    {
        private string[] ruleNames;
        private IVocabulary vocabulary;
        private ATN atn;
        private IContext context;
        private Dictionary<int, Func<INameable, bool>> lookupPredicateByRuleId = new Dictionary<int, Func<INameable, bool>>()
        {
            { CQLParser.RULE_typeName, symbol => symbol is QType },
            { CQLParser.RULE_functionName, symbol => symbol is IFunction },
            { CQLParser.RULE_variableName, symbol => symbol is Field || symbol is Constant }
        };
        private Dictionary<int, SuggestionType> lookupSuggestionByRuleId = new Dictionary<int, SuggestionType>()
        {
            { CQLParser.RULE_typeName, SuggestionType.Type },
            { CQLParser.RULE_functionName, SuggestionType.Function },
            { CQLParser.RULE_variableName, SuggestionType.Variable }
        };
        private Dictionary<int, IEnumerable<INameable>> suggestionsByTokenType;

        public AutoCompletionSuggester(IContext context)
        {
            this.context = context;
            this.ruleNames = CQLParser.ruleNames;
            this.vocabulary = CQLParser.DefaultVocabulary;
            this.atn = CQLParser._ATN;

            suggestionsByTokenType = new Dictionary<int, IEnumerable<INameable>>();
            for (var index = 0; index < CQLLexer.DefaultVocabulary.MaxTokenType; index++)
            {
                var name = CQLLexer.DefaultVocabulary.GetDisplayName(index);
                if (name != null && !name.Contains("LITERAL"))
                    suggestionsByTokenType[index] = new[] { new Token(name, "") };
            }
        }

        public IEnumerable<Suggestion> GetSuggestions(string code)
        {
            var collector = new HashSet<Suggestion>();
            var charStream = new AntlrInputStream(code);
            var lexer = new CQLLexer(charStream);
            Process(atn.states[0], new MyTokenStream(lexer.ToList()), collector, new ParserStack());
            return collector;
        }

        private void Process(ATNState state, MyTokenStream tokens, ICollection<Suggestion> collector, ParserStack parserStack)
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
                    Process(it.target, tokens, collector, stackRes.Item2);
                }
                else if (it is AtomTransition)
                {
                    var atomTransition = it as AtomTransition;
                    var nextToken = tokens.Next();
                    if (atCaret)
                    {
                        if (ParserStack.IsCompatibleWith(it.target, parserStack))
                        {
                            AddSymbol(collector, parserStack, atomTransition.label, nextToken);
                        }
                    }
                    else
                    {
                        if (nextToken.Type == atomTransition.label)
                        {
                            Process(it.target, tokens.Move(), collector, stackRes.Item2);
                        }
                    }
                }
                else if (it is SetTransition)
                {
                    var setTransition = it as SetTransition;
                    var nextToken = tokens.Next();
                    foreach (var sym in setTransition.Label.ToList())
                    {
                        if (atCaret)
                        {
                            if (ParserStack.IsCompatibleWith(it.target, parserStack))
                            {
                                AddSymbol(collector, parserStack, sym, nextToken);
                            }
                        }
                        else
                        {
                            if (nextToken.Type == sym)
                            {
                                Process(it.target, tokens.Move(), collector, stackRes.Item2);
                            }
                        }
                    }
                }
                else
                    throw new InvalidOperationException(it.GetType().FullName);
            }
        }

        private void AddSymbol(ICollection<Suggestion> collector, ParserStack parserStack, int currentTokenType, IToken token)
        {
            switch(currentTokenType)
            {
                case CQLLexer.MULTI_ID:
                    var ruleId = parserStack.Top.ruleIndex;
                    var nameables = context
                        .GetByPrefix(token.Type < 0 ? "" : token.Text)
                        .Where(lookupPredicateByRuleId[ruleId])
                        .OrderBy(n => n.Name)
                        .ToArray();
                    var type = lookupSuggestionByRuleId[ruleId];
                    if (type == SuggestionType.Function)
                        foreach (var nameable in nameables.OfType<IFunction>())
                            collector.Add(new Suggestion(type, token.Column, token.Text.Length, nameable.Name + "("+string.Join(", ", nameable.Parameters.Select(p => p.Name))+")", nameable.Usage));
                    else
                        foreach(var nameable in nameables)
                            collector.Add(new Suggestion(type, token.Column, token.Text.Length, nameable.Name, nameable.Usage));
                    break;
                default:
                    if(suggestionsByTokenType.ContainsKey(currentTokenType))
                        foreach(var suggestion in suggestionsByTokenType[currentTokenType])
                            collector.Add(new Suggestion(SuggestionType.Token, token.Column, 0, suggestion.Name, suggestion.Usage));
                    break;
            }
        }
    }
}
