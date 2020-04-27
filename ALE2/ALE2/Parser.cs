using System.Collections.Generic;
using System.Linq;

namespace ALE2
{
    public class Parser
    {
        private List<Letter> _alphabet;
        private List<State> _states;
        private List<Transition> _transitions;

        public Parser(List<Letter> alphabet, List<State> states, List<Transition> transitions)
        {
            this._alphabet = alphabet;
            this._states = states;
            this._transitions = transitions;
        }

        public void parseAlphabet(string alphabetString)
        {
            for (int i = 0; i < alphabetString.Length; i++)
            {
                if (!isEscapableChar(alphabetString[i]))
                {
                    Letter letter = new Letter(alphabetString[i]);
                    this._alphabet.Add(letter);
                }
            }
        }

        public void parseStates(string statesString)
        {
            for (int i = 0; i < statesString.Length; i++)
            {
                string uniqueStateString = "";
                while (i < statesString.Length && !isEscapableChar(statesString[i]))
                {
                    uniqueStateString += statesString[i];
                    i++;
                }
                State state = new State(uniqueStateString);
                this._states.Add(state);
            }
        }

        public void parseFinalStates(string finalStatesString)
        {
            this._states.Find(_ => _.data == finalStatesString).isFinalState = true;
        }

        public void parseTransition(string transitionString)
        {
            string initalStateString = "", finalStateString = "";
            char letter;
            int i = 0;

            while (transitionString[i] != ',')
            {
                initalStateString += transitionString[i];
                i++;
            }

            i++;

            letter = transitionString[i];

            i++;

            while (isEscapableChar(transitionString[i]))
            {
                i++;
            }

            while (i < transitionString.Length)
            {
                finalStateString += transitionString[i];
                i++;
            }

            this.addOutgoingLetterToState(initalStateString, letter);

            Transition transition = this.initializeTransition(initalStateString, finalStateString, letter);

            this._transitions.Add(transition);
        }

        public bool wordExists(string word, State currentState)
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
            if (!currentState.outgoingLetters.Any(_ => _.data == word[0])) { return false; }
            else
            {
                List<Transition> possibleTransitions = this._transitions.FindAll(_ => _.initialState.data == currentState.data 
                    && _.connectingLetter.data == word[0]);
                if (possibleTransitions.Count > 1)
                {
                    //foreach (Transition transition in possibleTransitions)
                    //{
                    //    if(wordExists(word.Substring(1), transition.destinationState))
                    //    {
                    //        return true;
                    //    }
                    //}
                    //return false;
                    return this.handleMultipleWordTransitions(word, possibleTransitions);
                }
                else
                {
                    currentState = possibleTransitions[0].destinationState;
                    return wordExists(word.Substring(1), currentState);
                }
            }
        }

        private bool handleMultipleWordTransitions(string word, List<Transition> transitions)
        {
            foreach (Transition transition in transitions)
            {
                if (wordExists(word.Substring(1), transition.destinationState))
                {
                    return true;
                }
            }
            return false;
        }

        private Transition initializeTransition(string initialStateString, string destinationStateString, char letterString)
        {
            State initialState = this._states.Find(_ => _.data == initialStateString);
            State destinationState = this._states.Find(_ => _.data == destinationStateString);
            Letter letter = this._alphabet.Find(_ => _.data == letterString);
            return new Transition(initialState, destinationState, letter);
        }

        private void addOutgoingLetterToState(string stateString, char letterChar)
        {
            State state = this._states.Find(_ => _.data == stateString);
            Letter letter = this._alphabet.Find(_ => _.data == letterChar);

            state.outgoingLetters.Add(letter);
        }

        private bool isEscapableChar(char charToCheck)
        {
            if (charToCheck == ' ' || charToCheck == ',' || charToCheck == '-' || charToCheck == '>')
            {
                return true;
            }

            return false;
        }
    }
}
