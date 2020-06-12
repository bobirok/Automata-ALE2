using ALE2.Interfaces;
using ALE2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (currentState.isFinalState && stack.isEmpty())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (!this.stateContainsLetter(currentState, word[0]) || word[0] == epsilon)
            {
                if (this.stateContainsLetter(currentState, epsilon))
                {
                    List<Transition> possibleTransitions = this._transitions.FindAll(_ => _.initialState.data == currentState.data
                        && _.connectingLetter.data == epsilon);

                    return this.handleMultipleWordTransitions(word, possibleTransitions, stack);
                }
                return false;
            }
            if (!currentState.outgoingLetters.Any(_ => _.data == word[0]))
            {
                return false;
            }
            else
            {
                List<Transition> possibleTransitions = this._transitions.FindAll(_ => (_.initialState.data == currentState.data
                    && _.connectingLetter.data == word[0]) || (_.initialState.data == currentState.data && 
                    _.connectingLetter.data == epsilon));

                if (possibleTransitions.Count > 1)
                {
                    return this.handleMultipleWordTransitions(word, possibleTransitions, stack);
                }
                else
                {
                    if ((stack.elements.Count > 0 &&
                        !possibleTransitions[0].transitionStackElement.outLetter
                        .Equals(stack.getCurrentTopStack())) ||
                        (possibleTransitions[0].transitionStackElement.outLetter.data != epsilon &&
                        stack.elements.Count == 0) ||
                        (possibleTransitions[0].transitionStackElement.inLetter.data != epsilon &&
                        !stack.possibleElements.Any(_ => _.Equals(possibleTransitions[0].transitionStackElement.inLetter))))
                    {
                        return false;
                    }
                    else
                    {

                        if (stack.elements.Count > 0 &&
                            possibleTransitions[0].transitionStackElement.outLetter.data != epsilon)
                        {
                            stack.popStack();
                        }

                        stack.pushToStack(possibleTransitions[0].transitionStackElement.inLetter);

                        currentState = possibleTransitions[0].destinationState;

                        return WordWithStackExists(word.Substring(1), currentState, stack);
                    }
                }
            }
        }

        private bool handleMultipleWordTransitions(string word, List<Transition> transitions, Stack stack)
        {
            transitions = prioritiseTransitions(transitions, word[0]);

            foreach (Transition transition in transitions)
            {
                Stack copyStack = stack.copyStack();

                if (transition.transitionStackElement != null)
                {
                    if (copyStack.elements.Count > 0 &&
                        transition.transitionStackElement.outLetter.data != '_' &&
                        !transition.transitionStackElement.outLetter.Equals(copyStack.getCurrentTopStack()) ||
                        (transition.transitionStackElement.outLetter.data != epsilon &&
                        copyStack.elements.Count == 0) ||
                        (transition.transitionStackElement.inLetter.data != epsilon &&
                        !this._stack.possibleElements.Any(_ => _.Equals(transition.transitionStackElement.inLetter)))) continue;

                    if (transition.transitionStackElement.outLetter.data != epsilon)
                    {
                        copyStack.popStack();
                    }

                    copyStack.pushToStack(transition.transitionStackElement.inLetter);
                }
                if (WordWithStackExists(word.Substring(1), transition.destinationState, copyStack))
                {
                    return true;
                }
            }
            return false;
        }

        private bool stateContainsLetter(State currentState, char letterToCheck)
        {
            if (currentState.outgoingLetters.Any(_ => _.data == letterToCheck))
            {
                return true;
            }

            return false;
        }

        private List<Transition> prioritiseTransitions(List<Transition> possibleTransitions, char currentSymbol)
        {
            List<Transition> firstPriority = possibleTransitions.FindAll(_ => 
                _.transitionStackElement != null &&
                this._stack.elements.Count > 0 &&
                (!this._stack.isEmpty() ? _.transitionStackElement.outLetter.Equals(this._stack.getCurrentTopStack()) : false) && 
                _.connectingLetter.data == currentSymbol);

            List<Transition> secondPriority = possibleTransitions.FindAll(_ =>
                _.transitionStackElement != null &&
                _.transitionStackElement.outLetter.data == epsilon &&
                _.connectingLetter.data == currentSymbol);

            List<Transition> thirdPriority = possibleTransitions.FindAll(_ =>
                _.transitionStackElement != null &&
                this._stack.elements.Count > 0 &&
                _.connectingLetter.data == epsilon &&
                (!this._stack.isEmpty() ? _.transitionStackElement.outLetter.Equals(this._stack.getCurrentTopStack()) : false));;

            List<Transition> fourthPriority = possibleTransitions.FindAll(_ =>
                _.connectingLetter.data == epsilon &&
                (_.transitionStackElement == null || _.transitionStackElement.outLetter.data == epsilon));

            return firstPriority.Concat(secondPriority).Concat(thirdPriority).Concat(fourthPriority).ToList();
        }

    }
}
