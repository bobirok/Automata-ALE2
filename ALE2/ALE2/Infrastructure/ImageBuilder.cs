using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows.Forms;

namespace ALE2
{
    [ExcludeFromCodeCoverage]
    public class ImageBuilder
    {
        public void BuildGraphVizImage(PictureBox pbAutomata, List<State> states, List<Transition> transitions)
        {
            this.generateDotFile(states, transitions);
            Process dot = new Process();
            dot.StartInfo.FileName = "dot.exe";
            dot.StartInfo.Arguments = "-Tpng -oabc.png abc.dot";
            dot.Start();
            dot.WaitForExit();
            pbAutomata.ImageLocation = "abc.png";
        }

        private void generateDotFile(List<State> states, List<Transition> transitions)
        {
            string dot = "digraph myAutomaton {\n" +
                         "rankdir=LR;\n" +
                this.buildStatesString(states)
                + "\n" + this.buildTransitionsString(transitions) + "}";

            File.WriteAllText("abc.dot", dot);
        }

        private string buildStatesString(List<State> states)
        {
            string statesDot = "\" \"" + " [shape=none]\n";
            foreach (State state in states)
            {
                statesDot += "\"" + state.data + "\"" + " " +
                             "[shape=" + state.GetShapeString() + "]\n";
            }

            return statesDot;
        }

        private string buildTransitionsString(List<Transition> transitions)
        {
            string transitionsDot = "";

            if (transitions.Count > 0)
            {
                transitionsDot = "\" \"" + " -> " + "\"" + transitions[0].initialState.data + "\"";
            }
            foreach (Transition transition in transitions)
            {
                transitionsDot += "\"" + transition.initialState.data + "\""
                                  + " -> " + "\"" + transition.destinationState.data + "\""
                                  + "[label=" + "\"" + transition.connectingLetter.data + getTransitionStackElement(transition) + "\"" + "]\n";
            }

            return transitionsDot;
        }

        private string getTransitionStackElement(Transition transition)
        {
            if (transition.transitionStackElement == null)
            {
                return "";
            }

            return " [" + transition.transitionStackElement.outLetter.data + "," + transition.transitionStackElement.inLetter.data + "]";
        }
    }
}
