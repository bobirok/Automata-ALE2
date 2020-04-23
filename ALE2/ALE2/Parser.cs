using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (!isEscapableChar(statesString[i]))
                {
                    State state = new State(statesString[i].ToString());
                    this._states.Add(state);
                }
            }
        }

        public void parseFinalStates(string finalStatesString)
        {
            for (int i = 0; i < finalStatesString.Length; i++)
            {
                if (!isEscapableChar(finalStatesString[i]))
                {
                    this._states.Find(x => x._data == finalStatesString[i].ToString())
                        .isFinalState = true;
                }
            }
        }

        public void parseTransition(string transitionString)
        {
            string initalStateString = "";
            string finalStateString = "";
            char letter = ' ';
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

            Transition transition = this.initializeTransition(initalStateString, finalStateString, letter);

            this._transitions.Add(transition);
        }

        private Transition initializeTransition(string initialStateString, string destinationStateString, char letterString)
        {
            State initialState = new State(initialStateString);
            State destinationState = new State(destinationStateString);
            Letter letter = new Letter(letterString);
            return new Transition(initialState, destinationState, letter);
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
