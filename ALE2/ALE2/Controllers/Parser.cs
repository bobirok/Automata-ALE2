using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ALE2
{
    public class Parser
    {
        private List<Letter> _alphabet;
        private List<State> _states;
        private List<Transition> _transitions;
        private const char lambda = '_';

        public Parser(List<Letter> alphabet, List<State> states, List<Transition> transitions)
        {
            this._alphabet = alphabet;
            this._states = states;
            this._transitions = transitions;
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

        public void ParseFinalStates(string finalStatesString)
        {
            try
            {
                string finalState;
                for (int i = 0; i < finalStatesString.Length; i++)
                {
                    finalState = "";
                    while (i < finalStatesString.Length && !IsEscapableChar(finalStatesString[i]))
                    {
                        finalState += finalStatesString[i];
                        i++;
                    }
                    this._states.Find(_ => _.data == finalState).isFinalState = true;
                }
            } catch(NullReferenceException)
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
                if(IsEscapableChar(transitionString[k])) continue; 
                if(isStateChar(transitionString[k]) && transition.initialState == null && transition.destinationState == null)
                {
                    while(k < transitionString.Length && !IsEscapableChar(transitionString[k]))
                    {
                        initalStateString += transitionString[k];
                        k++;
                    }
                    transition.initialState = this._states.Find(_ => _.data == initalStateString);
                } else if(isStateChar(transitionString[k]) && transition.initialState != null && transition.destinationState == null)
                {
                    while (k < transitionString.Length && !IsEscapableChar(transitionString[k]))
                    {
                        finalStateString += transitionString[k];
                        k++;
                    }
                    transition.destinationState = this._states.Find(_ => _.data == finalStateString);
                } else if(isLetterChar(transitionString[k]) && transition.connectingLetter == null)
                {
                    letter = transitionString[k];
                    transition.connectingLetter = this._alphabet.Find(_ => _.data == letter);
                } else if(isEpsilon(transitionString[k])) {
                    Letter epsilonLetter = new Letter(lambda);
                    transition.connectingLetter = epsilonLetter;
                    this._alphabet.Add(epsilonLetter);
                    letter = epsilonLetter.data;
                }
            }

            this.addOutgoingLetterToState(initalStateString, letter);

            this._transitions.Add(transition);
        }

        public bool WordExists(string word, State currentState)
        {
            if (word.Length == 0) 
            {
                if(currentState.isFinalState)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            if (!this.stateContainsLetter(currentState, word[0]) || word[0] == lambda)
            {
                if (this.stateContainsLetter(currentState, lambda))
                {
                    List<Transition> possibleTransitions = this._transitions.FindAll(_ => _.initialState.data == currentState.data
                        && _.connectingLetter.data == lambda);

                    return this.handleMultipleWordTransitions(word, possibleTransitions);
                }
                return false;
            }
            if (!currentState.outgoingLetters.Any(_ => _.data == word[0])) {
               
                return false; 
            }
            else
            {
                List<Transition> possibleTransitions = this._transitions.FindAll(_ => (_.initialState.data == currentState.data 
                    && _.connectingLetter.data == word[0]) || (_.initialState.data == currentState.data && _.connectingLetter.data == lambda));
                if (possibleTransitions.Count > 1)
                {
                    return this.handleMultipleWordTransitions(word, possibleTransitions);
                }
                else
                {
                    currentState = possibleTransitions[0].destinationState;
                    return WordExists(word.Substring(1), currentState);
                }
            }
        }

        public bool ParseFinite(string finiteString)
        {
            string expectedFiniteAsString = "";

            for (int i = 0; i < finiteString.Length; i++)
            {
                if(!IsEscapableChar(finiteString[i])) { expectedFiniteAsString += finiteString[i]; }
            }

            return expectedFiniteAsString.Contains("y") ? true : false;
        }

        public bool IsEscapableChar(char charToCheck)
        {
            if (charToCheck == ' ' || charToCheck == ',' || charToCheck == '-' || charToCheck == '>' || charToCheck == ':')
            {
                return true;
            }

            return false;
        }

        private bool handleMultipleWordTransitions(string word, List<Transition> transitions)
        {
            foreach (Transition transition in transitions)
            {
                if (WordExists(word.Substring(1), transition.destinationState))
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
            if(charToCheck >= 'A' && charToCheck <= 'Z')
            {
                return true;
            }

            return false;
        }

        private bool isLetterChar(char charToCheck)
        {
            if((charToCheck >= 'a' && charToCheck <= 'z') || (charToCheck >= '0' && charToCheck <= '9'))
            {
                return true;
            }

            return false;
        }

        private bool isEpsilon(char charToCheck)
        {
            if(charToCheck == '_')
            {
                return true;
            }

            return false;
        }

        private bool stateContainsLetter(State currentState, char letterToCheck)
        {
            if(currentState.outgoingLetters.Any(_ => _.data == letterToCheck))
            {
                return true;
            }

            return false;
        }
    }
}
