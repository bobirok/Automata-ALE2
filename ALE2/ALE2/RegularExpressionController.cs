using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    public class RegularExpressionController
    {
        private static int stateCounter = 0;
        private List<Transition> _transitions = new List<Transition>();
        private State front, tail;

        public List<Transition> getNdfaFromRegularExpression(RegularExpression re)
        {
            if (isLetterChar(re.letter.data))
            {
                Transition letterTransition = letterRule(re.letter);

                this._transitions.Add(letterTransition);

                return this._transitions;
            }
            else if (re.letter.data == '|')
            {
                Transition t1 = getNdfaFromRegularExpression(re.left)[0];
                Transition t2 = getNdfaFromRegularExpression(re.right)[0];

                this._transitions = this._transitions.Concat(this.orRule(t1, t2)).ToList();

                return this._transitions;
            }
            else if (re.letter.data == '.')
            {
                Transition t1 = getNdfaFromRegularExpression(re.left)[0];
                Transition t2 = getNdfaFromRegularExpression(re.right)[1];

                this._transitions = this._transitions.Concat(this.andRule(t1, t2)).ToList();

                return this._transitions;
            }
            else
            {
                Transition t1 = getNdfaFromRegularExpression(re.left)[0];

                this._transitions = this._transitions.Concat(this.starRule(t1)).ToList();

                return this._transitions;
            }
        }

        public List<State> ExtractStatesFromTransitions(List<Transition> transitions)
        {
            List<State> states = new List<State>();

            foreach (Transition transition in transitions)
            {
                states.Add(transition.initialState);
                states.Add(transition.destinationState);
            }

            return states.GroupBy(_ => _.data).Select(_ => _.First()).ToList();
        }

        public List<Letter> ExtractAlphabetFromTransitions(List<Transition> transitions)
        {
            List<Letter> alphabet = new List<Letter>();

            foreach (Transition transition in transitions)
            {
                alphabet.Add(transition.connectingLetter);
            }

            return alphabet.GroupBy(_ => _.data).Select(_ => _.First()).ToList();
        }

        private Transition letterRule(Letter letter)
        {
            State s1 = new State("S" + stateCounter++.ToString());
            State s2 = new State("S" + stateCounter++.ToString());
            s2.isFinalState = true;

            if(this.front == null & this.tail == null)
            {
                this.front = s1;
                this.tail = s2;
            }

            return new Transition(s1, s2, letter);
        }

        private List<Transition> andRule(Transition t1, Transition t2)
        {
            t1.destinationState.isFinalState = false;
            t2.initialState = t1.destinationState;
            this.front = t1.initialState;
            this.tail = t2.destinationState;
            return new List<Transition>();
        }

        private List<Transition> orRule(Transition t1, Transition t2)
        {
            State s1 = new State("S" + stateCounter++.ToString());
            State s2 = new State("S" + stateCounter++.ToString());

            s2.isFinalState = true;

            Transition newTransition1 = new Transition(s1, t1.initialState, new Letter('_'));
            Transition newTransition2 = new Transition(s1, t2.initialState, new Letter('_'));

            Transition newTransition3 = new Transition(t1.destinationState, s2, new Letter('_'));
            Transition newTransition4 = new Transition(t2.destinationState, s2, new Letter('_'));

            t1.destinationState.isFinalState = false;
            t2.destinationState.isFinalState = false;

            return new List<Transition> { newTransition1, newTransition2, newTransition3, newTransition4 };
        }

        private List<Transition> starRule(Transition t1)
        {
            State s1 = new State("S" + stateCounter++.ToString());
            State s2 = new State("S" + stateCounter++.ToString());

            s2.isFinalState = true;
            //t1.destinationState.isFinalState = false;
            s2.isFinalState = false;

            Transition newTransition1 = new Transition(s1, this.front, new Letter('_'));
            Transition newTransition2 = new Transition(s1, s2, new Letter('_'));
            Transition newTransition3 = new Transition(this.tail, this.front, new Letter('_'));
            Transition newTransition4 = new Transition(this.tail, s2, new Letter('_'));

            this.front = s1;
            this.tail = s2;

            return new List<Transition> { newTransition1, newTransition2, newTransition3, newTransition4 };
        }

        private bool isLetterChar(char charToCheck)
        {
            if ((charToCheck >= 'a' && charToCheck <= 'z') || charToCheck == '_')
            {
                return true;
            }

            return false;
        }
    }
}
