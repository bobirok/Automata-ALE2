using ALE2.Interfaces;
using ALE2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ALE2.Controllers
{
    public class Parser : IParser
    {
        private List<Letter> _alphabet;
        private List<State> _states;
        private List<Transition> _transitions;
        private Stack _stack;
        private const char epsilon = '_';

        public Parser(List<Letter> alphabet, List<State> states, List<Transition> transitions, Stack stack)
        {
            this._alphabet = alphabet;
            this._states = states;
            this._transitions = transitions;
            this._stack = stack;
        }

        public void ParseAlphabet(string alphabetString)
        {
            for (int i = 0; i < alphabetString.Length; i++)
            {
                if (!IsEscapableChar(alphabetString[i]))
                {
                    this._alphabet.Add(new Letter(alphabetString[i]));
                }
            }
        }

        public void ParseStates(string statesString)
        {
            for (int i = 0; i < statesString.Length; i++)
            {
                string uniqueStateString = "";
                while (i < statesString.Length && !IsEscapableChar(statesString[i]))
                {
                    uniqueStateString += statesString[i];
                    i++;
                }
                this._states.Add(new State(uniqueStateString));
            }
        }

        public void ParseStack(string stackString)
        {
            for (int i = 0; i < stackString.Length; i++)
            {
                if (!IsEscapableChar(stackString[i]) && stackString[i] != epsilon)
                {
                    this._stack.possibleElements.Add(new Letter(stackString[i]));
                }
            }
        }

        public void ParseFinalStates(string finalStatesString)
        {
            try
            {
                string finalState;
                for (int i = 0; i < finalStatesString.Length; i++)
                {
                    finalState = "";

                    if (IsEscapableChar(finalStatesString[i])) continue;

                    while (i < finalStatesString.Length && !IsEscapableChar(finalStatesString[i]))
                    {
                        finalState += finalStatesString[i];
                        i++;
                    }
                    this._states.Find(_ => _.data == finalState).isFinalState = true;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please provide a valid state");
            }
        }

        public void ParseTransition(string transitionString)
        {
            string initalStateString = "", finalStateString = "";
            char letter = ' ';
            Transition transition = new Transition(null, null, null);

            for (int k = 0; k < transitionString.Length; k++)
            {
                if (IsEscapableChar(transitionString[k])) continue;
                if (isStateChar(transitionString[k]) && transition.initialState == null && transition.destinationState == null)
                {
                    while (k < transitionString.Length && !IsEscapableChar(transitionString[k]))
                    {
                        initalStateString += transitionString[k];
                        k++;
                    }
                    transition.initialState = this._states.Find(_ => _.data == initalStateString);
                }
                else if (isStateChar(transitionString[k]) && transition.initialState != null && transition.destinationState == null)
                {
                    while (k < transitionString.Length && !IsEscapableChar(transitionString[k]))
                    {
                        finalStateString += transitionString[k];
                        k++;
                    }
                    transition.destinationState = this._states.Find(_ => _.data == finalStateString);
                }
                else if (isLetterChar(transitionString[k]) && transition.connectingLetter == null)
                {
                    letter = transitionString[k];
                    transition.connectingLetter = this._alphabet.Find(_ => _.data == letter);
                }
                else if (isEpsilon(transitionString[k]))
                {
                    Letter epsilonLetter = new Letter(epsilon);
                    transition.connectingLetter = epsilonLetter;
                    this._alphabet.Add(epsilonLetter);
                    letter = epsilonLetter.data;
                }
                else if (transitionString[k] == '[')
                {
                    char outStackElement = transitionString[k + 1];
                    char inStackElement = transitionString[k + 3];

                    transition.transitionStackElement = new TransitionStackElement(
                        new Letter(inStackElement), new Letter(outStackElement));

                    transitionString = transitionString.Substring(5);
                }
            }

            this.addOutgoingLetterToState(initalStateString, letter);

            this._transitions.Add(transition);
        }

        public bool WordExists(string word, State currentState)
        {
            return this.WordIsAccepted(word, currentState, new List<Transition>());
        }

        public bool IsEscapableChar(char charToCheck)
        {
            if (charToCheck == ' ' || charToCheck == ',' || charToCheck == '-' || charToCheck == '>' || charToCheck == ':')
            {
                return true;
            }

            return false;
        }

        public bool ParseFinite(string finiteString)
        {
            string expectedFiniteAsString = "";

            for (int i = 0; i < finiteString.Length; i++)
            {
                if (!IsEscapableChar(finiteString[i])) { expectedFiniteAsString += finiteString[i]; }
            }

            return expectedFiniteAsString.Contains("y") ? true : false;
        }

        private bool WordIsAccepted(string word, State currentState, List<Transition> processedTransitions)
        {
            if (word.Length == 0)
            {
                return currentState.isFinalState;
            }

            List<Transition> possibleTransitions = this._transitions.FindAll(_ =>
                (_.connectingLetter.data == word[0] || _.connectingLetter.data == epsilon)
                && _.initialState.Equals(currentState));

            return this.handleMultipleWordTransitions(word, possibleTransitions, processedTransitions);
        }

        private bool handleMultipleWordTransitions(string word, List<Transition> transitions, List<Transition> processedTransitions)
        {
            foreach (Transition transition in transitions)
            {
                if (processedTransitions.Any(_ => _.Equals(transition) && transition.connectingLetter.data == epsilon)) continue;

                processedTransitions.Add(transition);

                if (WordIsAccepted(transition.connectingLetter.data == epsilon ? word : word.Substring(1), transition.destinationState, processedTransitions))
                {
                    return true;
                }
            }
            return false;
        }

        private void addOutgoingLetterToState(string stateString, char letterChar)
        {
            State state = this._states.Find(_ => _.data == stateString);
            Letter letter = this._alphabet.Find(_ => _.data == letterChar);

            state.outgoingLetters.Add(letter);
        }

        private bool isStateChar(char charToCheck)
        {
            if (charToCheck >= 'A' && charToCheck <= 'Z')
            {
                return true;
            }

            return false;
        }

        private bool isLetterChar(char charToCheck)
        {
            if ((charToCheck >= 'a' && charToCheck <= 'z') || (charToCheck >= '0' && charToCheck <= '9'))
            {
                return true;
            }

            return false;
        }

        private bool isEpsilon(char charToCheck)
        {
            return charToCheck == '_';
        }
    }
}
