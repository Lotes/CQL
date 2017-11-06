using Antlr4.Runtime.Atn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.AutoCompletion
{

    public class ParserStack
    {
        public static bool IsCompatibleWith(ATNState state, ParserStack parserStack)
        {
            var res = parserStack.Process(state);
            if (!res.Item1)
            {
                return false;
            }
            if (state.epsilonOnlyTransitions)
            {
                return state.Transitions.Any(it => IsCompatibleWith(it.target, res.Item2));
            }
            else
            {
                return true;
            }
        }

        private IEnumerable<ATNState> states;
        public ParserStack(IEnumerable<ATNState> states = null)
        {
            if (states == null)
                states = Enumerable.Empty<ATNState>();
            this.states = states;
        }

        public ATNState Top { get { return states.LastOrDefault(); } }

        public Tuple<bool, ParserStack> Process(ATNState state)
        {
            var currentType = state.GetType();
            var startTypes = new[]
            {
                typeof(RuleStartState),
                typeof(StarBlockStartState),
                typeof(BasicBlockStartState),
                typeof(PlusBlockStartState),
                typeof(StarLoopEntryState)
            };
            var remainingTypes = new[]
            {
                typeof(BasicState),
                typeof(BlockEndState),
                typeof(StarLoopbackState),
                typeof(PlusLoopbackState)
            };
            if (startTypes.Any(t => t == currentType))
                return new Tuple<bool, ParserStack>(true, new ParserStack(states.Concat(new[] { state })));
            if (state is BlockEndState)
            {
                var blockState = state as BlockEndState;
                if (states.Any() && states.Last() == blockState.startState)
                    return new Tuple<bool, ParserStack>(true, new ParserStack(states.Take(states.Count() - 1)));
                else
                    return new Tuple<bool, ParserStack>(false, this);
            }
            if (state is LoopEndState)
            {
                var loopState = state as LoopEndState;
                if (states.Any())
                {
                    var last = states.Last() as StarLoopEntryState;
                    if (last != null && last.loopBackState == loopState.loopBackState)
                        return new Tuple<bool, ParserStack>(true, new ParserStack(states.Take(states.Count() - 1)));
                }
                return new Tuple<bool, ParserStack>(true, this);
            }
            if (state is RuleStopState)
            {
                var ruleState = state as RuleStopState;
                if (states.Any())
                {
                    var last = states.Last() as RuleStartState;
                    if (last != null && last.stopState == ruleState)
                        return new Tuple<bool, ParserStack>(true, new ParserStack(states.Take(states.Count() - 1)));
                }
                return new Tuple<bool, ParserStack>(true, this);
            }
            if (remainingTypes.Any(t => t == currentType))
                return new Tuple<bool, ParserStack>(true, this);
            throw new InvalidOperationException(currentType.FullName);
        }
    }

}
