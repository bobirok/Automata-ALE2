using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    public class FiniteController
    {
        public List<Trace> traces { get; }

        private List<Transition> _transitions;

        private State _lastConnetctionState { get; set; }

        public FiniteController(List<Trace> traces, List<Transition> transitions)
        {
            this.traces = traces;
            this._transitions = transitions;
        }

        public List<Word> ExtractAllWordsFromAutomata()
        {
            List<Word> words = new List<Word>();

            if(this.AutomataIsFinite())
            {
                this.markAllStatesAsNotProcessed();

                foreach (Trace trace in this.traces)
                {
                    string wordAsString = "";
                    words.Add(new Word(this.extractWordFromTrace(trace, trace.initialState, wordAsString), true, true));
                }
            }

            return words;
        }

        public void InstantiateTraces(State initialState, State currentState, List<Transition> listOfTransitions)
        {
            if(currentState.isFinalState)
            {
                this.traces.Add(new Trace(listOfTransitions, initialState));
            }

            List<Transition> possibleTransitions = this._transitions.FindAll(_ => _.initialState.Equals(currentState));

            possibleTransitions = this.removeCyclingTransitions(possibleTransitions, listOfTransitions);

            foreach (Transition transition in possibleTransitions)
            {
                List<Transition> transitions = listOfTransitions.Concat(new List<Transition> { transition }).ToList();

                InstantiateTraces(initialState, transition.destinationState, transitions);
            }
        }

        public bool AutomataIsFinite()
        {
            this.markAllStatesAsNotProcessed();

            foreach (Trace trace in this.traces)
            {
                trace.visitedStates.Clear();

                if (!this.traceIsFinite(trace, trace.initialState)) { return false; }
            }

            return true;
        }

        private bool traceIsFinite(Trace trace, State currentState)
        {
            currentState.MarkAsProcessed();

            trace.visitedStates.Add(currentState);

            if(currentState.outgoingLetters.Count == 0) { return true; }

            if(trace.transitionsInTrace.Any(_ => _.initialState.data == _.destinationState.data)) 
            {
                return false;
            }

            List<Transition> possibleTransitions = trace.transitionsInTrace.FindAll(_ => _.initialState.data == currentState.data);

            if (possibleTransitions.Count == 0) { return currentState.isFinalState; }

            if(trace.visitedStates.Any(_ => _.data == possibleTransitions[0].destinationState.data)) { return false; }

            foreach (Transition transition in possibleTransitions)
            {
                return traceIsFinite(trace, transition.destinationState);
            }

            return false;
        }

        private List<Transition> removeCyclingTransitions(List<Transition> possibleTransitions, List<Transition> listOfTransitions)
        {
            for (int i = possibleTransitions.Count - 1; i >= 0; i--)
            {
                if (listOfTransitions.Any(_ => _.initialState.data == possibleTransitions[i].destinationState.data))
                {
                    listOfTransitions.Add(possibleTransitions[i]);
                    possibleTransitions.RemoveAt(i);
                }
                else if (possibleTransitions[i].initialState.data == possibleTransitions[i].destinationState.data)
                {
                    listOfTransitions.Add(possibleTransitions[i]);
                    possibleTransitions.RemoveAt(i);
                }
            }

            return possibleTransitions;
        }

        private string extractWordFromTrace(Trace trace, State currentState, string wordAsString)
        {
            Transition possibleTransition = trace.transitionsInTrace.Find(_ => _.initialState.data == currentState.data);

            if (possibleTransition == null) { return wordAsString; }

            wordAsString += possibleTransition.connectingLetter.data;

            return extractWordFromTrace(trace, possibleTransition.destinationState, wordAsString);
        }

        private void markAllStatesAsNotProcessed()
        {
            foreach (Trace trace in traces)
            {
                foreach (Transition transition in trace.transitionsInTrace)
                {
                    transition.destinationState.MarkAsUnprocessed();
                    transition.initialState.MarkAsUnprocessed();
                }
            }
        }
    }
}
