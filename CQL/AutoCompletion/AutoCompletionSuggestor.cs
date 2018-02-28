using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using CQL.Contexts;
using CQL.Contexts.Implementation;
using CQL.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.AutoCompletion
{
    public class AutoCompletionSuggester : IAutoCompletionSuggester
    {
        private string[] ruleNames;
        private IVocabulary vocabulary;
        private ATN atn;
        private IScope<object> context;
        private Dictionary<int, Func<IVariable<object>, bool>> lookupPredicateByRuleId = new Dictionary<int, Func<IVariable<object>, bool>>()
        {
            { CQLParser.RULE_typeName, symbol => symbol is IType },
            { CQLParser.RULE_primeVar, symbol => symbol is IVariable<object> },
            { CQLParser.RULE_member, symbol => symbol is IVariable<object> }
        };
        private Dictionary<int, SuggestionType> lookupSuggestionByRuleId = new Dictionary<int, SuggestionType>()
        {
            { CQLParser.RULE_typeName, SuggestionType.Type },
            { CQLParser.RULE_primeVar, SuggestionType.Variable },
            { CQLParser.RULE_member, SuggestionType.Variable }
        };
        private Dictionary<int, IEnumerable<Token>> suggestionsByTokenType;

        public AutoCompletionSuggester(IScope<object> context)
        {
            this.context = context;
            this.ruleNames = CQLParser.ruleNames;
            this.vocabulary = CQLParser.DefaultVocabulary;
            this.atn = CQLParser._ATN;

            suggestionsByTokenType = new Dictionary<int, IEnumerable<Token>>();
            for (var index = 0; index < CQLLexer.DefaultVocabulary.MaxTokenType; index++)
            {
                var name = CQLLexer.DefaultVocabulary.GetDisplayName(index);
                if (name == null || name.Contains("LITERAL"))
                    continue;
                if (name.StartsWith("'") && name.EndsWith("'"))
                    name = name.Substring(1, name.Length - 2);
                suggestionsByTokenType[index] = new[] { new Token(name, "") };
            }
        }

        public IEnumerable<Suggestion> GetSuggestions(string code)
        {
            var collector = new HashSet<Suggestion>();
            var charStream = new AntlrInputStream(code);
            var lexer = new CQLLexer(charStream);
            Process(atn.states[0], new MyTokenStream(lexer.ToList()), collector, new ParserStack(), new HashSet<int>());
            return collector;
        }

        private void Process(ATNState state, MyTokenStream tokens, ICollection<Suggestion> collector, ParserStack parserStack, HashSet<int> alreadyPassed)
        {
            var atCaret = tokens.AtCaret();
            var stackRes = parserStack.Process(state);
            if (!stackRes.Item1)
            {
                return;
            }

            foreach (var it in state.Transitions)
            {
                if (it.IsEpsilon)
                {
                    var stateNo = it.target.StateNumber;
                    if (!alreadyPassed.Contains(stateNo))
                    {
                        Process(it.target, tokens, collector, stackRes.Item2, alreadyPassed);
                        alreadyPassed.Add(stateNo);
                    }
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
                            Process(it.target, tokens.Move(), collector, stackRes.Item2, new HashSet<int>());
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
                                Process(it.target, tokens.Move(), collector, stackRes.Item2, new HashSet<int>());
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
                case CQLLexer.ID:
                    var ruleId = parserStack.Top.ruleIndex;
                    var allVariables = new List<IVariable<object>>();
                    var currentScope = context;
                    while(currentScope != null)
                    {
                        allVariables.AddRange(currentScope);
                        currentScope = currentScope.Parent;
                    }
                    var nameables = allVariables.Where(v => v.Name.ToUpper().StartsWith(token.Text.ToUpper()))
                        .Where(lookupPredicateByRuleId[ruleId])
                        .OrderBy(n => n.Name)
                        .ToArray();
                    var type = lookupSuggestionByRuleId[ruleId];
                    var length = token.Type < 0 ? 0 : token.Text.Length;
                    if (type == SuggestionType.Function)
                        foreach (var nameable in nameables.OfType<IVariable<object>>())
                            collector.Add(new Suggestion(type, token.Column, length, nameable.Name + "(???)", ""));
                    else
                        foreach(var nameable in nameables)
                            collector.Add(new Suggestion(type, token.Column, length, nameable.Name, ""));
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
