using ALE2.Interfaces;
using ALE2.Models;
using System.Collections.Generic;
using System.Linq;

namespace ALE2.Controllers
{
    public class StackController : IStackController
    {
        private const char epsilon = '_';
        private List<Transition> _transitions;
        private Stack _stack;

        public StackController(List<Transition> transitions, Stack stack)
        {
            this._transitions = transitions;
            this._stack = stack;
        }

        public bool WordWithStackExists(string word, State currentState, Stack stack)
        {
            if (word.Length == 0)
            {
                if (currentState.isFinalState && stack.IsEmpty())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            List<Transition> possibleTransitions = this._transitions.FindAll(_ =>
                ((_.initialState.Equals(currentState) &&
                (_.connectingLetter.data == word[0] || _.connectingLetter.data == epsilon))));

            this.prioritiseTransitions(possibleTransitions, word[0]);

            return handleTransitions(word, possibleTransitions, stack.CopyStack());
        }

        private bool handleTransitions(string word, List<Transition> possibleTransitions, Stack stack)
        {
            foreach (Transition transition in possibleTransitions)
            {
                if (transition.transitionStackElement != null &&
                        (stack.elements.Count > 0 &&
                        transition.transitionStackElement.outLetter.data != epsilon &&
                        !(transition.transitionStackElement.outLetter.Equals(stack.GetCurrentTopStack())) ||
                        (transition.transitionStackElement.outLetter.data != epsilon &&
                        stack.elements.Count == 0) ||
                        (transition.transitionStackElement.inLetter.data != epsilon &&
                        !this._stack.possibleElements.Any(_ => _.Equals(transition.transitionStackElement.inLetter))))) continue;

                if (stack.elements.Count > 0 ||
                        (transition.transitionStackElement != null &&
                        transition.transitionStackElement.outLetter.data == epsilon))
                {
                    if (transition.transitionStackElement != null)
                    {
                        if (transition.transitionStackElement.outLetter.data != epsilon)
                        {
                            stack.PopStack();
                        }
                    }
                }

                if (transition.transitionStackElement != null)
                {
                    stack.PushToStack(transition.transitionStackElement.inLetter);
                }

                if (WordWithStackExists(word.Substring(1), transition.destinationState, stack.CopyStack())) return true;
                else
                {
                    if (transition.transitionStackElement != null)
                    {
                        stack.PushToStack(transition.transitionStackElement.outLetter);

                        if (transition.transitionStackElement.inLetter.data != epsilon)
                        {
                            stack.PopStack();
                        }
                    }
                }
            }

            return false;
        }

        private List<Transition> prioritiseTransitions(List<Transition> possibleTransitions, char currentSymbol)
        {
            List<Transition> firstPriority = possibleTransitions.FindAll(_ =>
                _.transitionStackElement != null &&
                this._stack.elements.Count > 0 &&
                (!this._stack.IsEmpty() ? _.transitionStackElement.outLetter.Equals(this._stack.GetCurrentTopStack()) : false) &&
                _.connectingLetter.data == currentSymbol);

            List<Transition> secondPriority = possibleTransitions.FindAll(_ =>
                _.transitionStackElement != null &&
                _.transitionStackElement.outLetter.data == epsilon &&
                _.connectingLetter.data == currentSymbol);

            List<Transition> thirdPriority = possibleTransitions.FindAll(_ =>
                _.transitionStackElement != null &&
                this._stack.elements.Count > 0 &&
                _.connectingLetter.data == epsilon &&
                (!this._stack.IsEmpty() ? _.transitionStackElement.outLetter.Equals(this._stack.GetCurrentTopStack()) : false)); ;

            List<Transition> fourthPriority = possibleTransitions.FindAll(_ =>
                _.connectingLetter.data == epsilon &&
                (_.transitionStackElement == null || _.transitionStackElement.outLetter.data == epsilon));

            return firstPriority.Concat(secondPriority).Concat(thirdPriority).Concat(fourthPriority).ToList();
        }

    }
}
