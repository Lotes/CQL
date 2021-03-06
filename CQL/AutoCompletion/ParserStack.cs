﻿using Antlr4.Runtime.Atn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.AutoCompletion
{
    /// <summary>
    /// The parser stack is a helper class. It helps to find the right rule state.
    /// Different states have different suggestions.
    /// </summary>
    public class ParserStack
    {
        /// <summary>
        /// Checks whether the ATNState is compatiple with the given stack.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="parserStack"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="states"></param>
        public ParserStack(IEnumerable<ATNState> states = null)
        {
            if (states == null)
                states = Enumerable.Empty<ATNState>();
            this.states = states;
        }

        /// <summary>
        /// Tip of the stack.
        /// </summary>
        public ATNState Top { get { return states.LastOrDefault(); } }

        /// <summary>
        /// One step of reading in ATNState.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
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
                    if (states.Last() is StarLoopEntryState last && last.loopBackState == loopState.loopBackState)
                    {
                        return new Tuple<bool, ParserStack>(true, new ParserStack(states.Take(states.Count() - 1)));
                    }
                }
                return new Tuple<bool, ParserStack>(true, this);
            }
            if (state is RuleStopState)
            {
                var ruleState = state as RuleStopState;
                if (states.Any())
                {
                    if (states.Last() is RuleStartState last && last.stopState == ruleState)
                    {
                        return new Tuple<bool, ParserStack>(true, new ParserStack(states.Take(states.Count() - 1)));
                    }
                }
                return new Tuple<bool, ParserStack>(true, this);
            }
            if (remainingTypes.Any(t => t == currentType))
            {
                return new Tuple<bool, ParserStack>(true, this);
            }

            throw new InvalidOperationException(currentType.FullName);
        }
    }

}
