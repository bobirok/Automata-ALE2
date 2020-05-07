using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALE2
{
    public class RegularExpressionController
    {
        private static int stateCounter = 0;
        public State front { get; set; }
        public State tail { get; set; }

        public RegularExpressionController()
        {
            stateCounter = 0;
        }

        
        public RegularExpression GetNdfaFromRegularExpression(ref string formula)
        {
            if(isLetterChar(formula[0]))
            {
                Letter letter = new Letter(formula[0]);

                return this.letterRule(letter);
            } else if(formula[0] == '.')
            {
                formula = formula.Substring(1);
                RegularExpression firstRegularExpression = this.GetNdfaFromRegularExpression(ref formula);

                formula = formula.Substring(1);
                RegularExpression secondRegularExpression = this.GetNdfaFromRegularExpression(ref formula);

                return this.andRule(firstRegularExpression, secondRegularExpression);
            } else if(formula[0] == '|')
            {
                formula = formula.Substring(1);
                RegularExpression firstRegularExpression = this.GetNdfaFromRegularExpression(ref formula);

                formula = formula.Substring(1);
                RegularExpression secondRegularExpression = this.GetNdfaFromRegularExpression(ref formula);

                return this.orRule(firstRegularExpression, secondRegularExpression);
            } else if(formula[0] == '*')
            {
                formula = formula.Substring(1);
                RegularExpression firstRegularExpression = this.GetNdfaFromRegularExpression(ref formula);

                return starRule(firstRegularExpression);
            } else
            {
                formula = formula.Substring(1);
                return GetNdfaFromRegularExpression(ref formula);
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

        private RegularExpression letterRule(Letter letter)
        {
            RegularExpression letterRegularExpression = new RegularExpression(letter);
            State initialState = new State("S" + stateCounter++.ToString());
            State finalState = new State("S" + stateCounter++.ToString());
            finalState.isFinalState = true;
            Transition transition = new Transition(initialState, finalState, letter);
            letterRegularExpression.transitions.Add(transition);
            letterRegularExpression.initial = initialState;
            letterRegularExpression.final = finalState;
            return letterRegularExpression;
        }

        private RegularExpression andRule(RegularExpression firstRegularExpression, RegularExpression secondRegularExpression)
        {
            firstRegularExpression.final.isFinalState = false;

            RegularExpression andRegularExpression = new RegularExpression(new Letter('.'));

            List<Transition> initialTransitions = secondRegularExpression.transitions.FindAll(_ => _.initialState == secondRegularExpression.initial);

            foreach (Transition transition in initialTransitions)
            {
                transition.initialState = firstRegularExpression.final;
            }

            andRegularExpression.initial = firstRegularExpression.initial;
            andRegularExpression.final = secondRegularExpression.final;

            andRegularExpression.transitions = andRegularExpression.transitions.Concat(firstRegularExpression.transitions).ToList();
            andRegularExpression.transitions = andRegularExpression.transitions.Concat(secondRegularExpression.transitions).ToList();

            return andRegularExpression;
        }

        private RegularExpression orRule(RegularExpression firstRegularExpression, RegularExpression secondRegularExpression)
        {
            firstRegularExpression.final.isFinalState = false;
            secondRegularExpression.final.isFinalState = false;
            State s1 = new State("S" + stateCounter++.ToString());
            State s2 = new State("S" + stateCounter++.ToString());

            s2.isFinalState = true;

            Transition newTransition1 = new Transition(s1, firstRegularExpression.initial, new Letter('_'));
            Transition newTransition2 = new Transition(s1, secondRegularExpression.initial, new Letter('_'));

            Transition newTransition3 = new Transition(firstRegularExpression.final, s2, new Letter('_'));
            Transition newTransition4 = new Transition(secondRegularExpression.final, s2, new Letter('_'));

            RegularExpression orRegularExpression = new RegularExpression(new Letter('|'));
            orRegularExpression.initial = s1;
            orRegularExpression.final = s2;
            orRegularExpression.transitions = orRegularExpression.transitions.Concat(firstRegularExpression.transitions).ToList();
            orRegularExpression.transitions = orRegularExpression.transitions.Concat(secondRegularExpression.transitions).ToList();
            orRegularExpression.transitions.AddRange(new List<Transition> { newTransition1, newTransition2, newTransition3, newTransition4 });

            return orRegularExpression;
        }

        private RegularExpression starRule(RegularExpression firstRegularExpression)
        {
            State s1 = new State("S" + stateCounter++.ToString());
            State s2 = new State("S" + stateCounter++.ToString());

            firstRegularExpression.final.isFinalState = false;

            s2.isFinalState = true;

            Transition newTransition1 = new Transition(s1, firstRegularExpression.initial, new Letter('_'));
            Transition newTransition2 = new Transition(s1, s2, new Letter('_'));
            Transition newTransition3 = new Transition(firstRegularExpression.final, firstRegularExpression.initial, new Letter('_'));
            Transition newTransition4 = new Transition(firstRegularExpression.final, s2, new Letter('_'));

            RegularExpression starRegularExpression = new RegularExpression(new Letter('*'));
            starRegularExpression.initial = s1;
            starRegularExpression.final = s2;

            starRegularExpression.transitions = starRegularExpression.transitions.Concat(firstRegularExpression.transitions).ToList();
            starRegularExpression.transitions.AddRange(new List<Transition> { newTransition1, newTransition2, newTransition3, newTransition4 });

            return starRegularExpression;
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
