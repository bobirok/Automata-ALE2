using ALE2.Interfaces;
using ALE2.Models;
using System.Collections.Generic;
using System.Linq;

namespace ALE2.Controllers
{
    public class FiniteController : IFiniteController
    {
        public List<Trace> traces { get; private set; }

        private List<Transition> _transitions;

        public FiniteController(List<Trace> traces, List<Transition> transitions)
        {
            this.traces = traces;
            this._transitions = transitions;
        }

        public List<Word> ExtractAllWordsFromAutomata()
        {
            List<Word> words = new List<Word>();

            if (this.AutomataIsFinite())
            {
                this.markAllStatesAsNotProcessed();

                foreach (Trace trace in this.traces)
                {
                    string wordAsString = "";
                    Word word = new Word(this.extractWordFromTrace(trace, trace.initialState, wordAsString, new List<Transition>()), true, true);
                    if (!words.Any(_ => _.Equals(word))) words.Add(word);
                }
            }

            return words;
        }

        public void InstantiateTraces(State initialState, State currentState, List<Transition> listOfTransitions)
        {
            if (currentState.isFinalState)
            {
                Trace trace = new Trace(listOfTransitions.Select(_ => _.CopyTransition()).ToList(), initialState);
                trace.transitionIsFinishable = true;
                this.traces.Add(trace);
            }

            List<Transition> possibleTransitions = this._transitions.FindAll(_ => _.initialState.Equals(currentState));

            if (possibleTransitions.Count == 0) { return; }

            foreach (Transition transition in possibleTransitions)
            {
                if (listOfTransitions.Any(_ => _.Equals(transition)))
                {
                    continue;
                }

                List<Transition> transitions = listOfTransitions.Concat(new List<Transition> { transition }).Select(_ => _.CopyTransition()).ToList();

                InstantiateTraces(initialState, transition.destinationState, transitions);
            }
        }

        public bool AutomataIsFinite()
        {
            this.markAllStatesAsNotProcessed();

            this.traces = this.traces.FindAll(_ => _.transitionIsFinishable);

            foreach (Trace trace in this.traces)
            {
                trace.visitedStates.Clear();

                if (!this.traceIsFinite(trace, trace.initialState, new List<Transition>(), new List<Transition>())) { return false; }
            }

            return true;
        }

        private bool traceIsFinite(Trace trace, State currentState,
            List<Transition> traceCycleTransitions, List<Transition> processedTransitions)
        {
            if (trace.transitionsInTrace.All(_ => _.connectingLetter.data == '_')) { return true; }

            trace.visitedStates.Add(currentState);

            List<Transition> possibleTransitions = trace.transitionsInTrace
                .FindAll(_ => _.initialState.data == currentState.data);

            if (possibleTransitions.Count == 0)
            {
                if (traceCycleTransitions.All(_ => _.connectingLetter.data == '_'))
                {
                    return currentState.isFinalState;
                }
                else
                {
                    return false;
                }
            }

            foreach (Transition transition in possibleTransitions)
            {
                if (processedTransitions.Any(_ => _.Equals(transition))) { continue; }

                processedTransitions.Add(transition);

                if (transition.initialState.Equals(transition.destinationState))
                {
                    traceCycleTransitions.Add(transition);
                    if (transition.destinationState.isFinalState) return transition.connectingLetter.data == '_';
                }

                else if (trace.visitedStates.Any(_ => _.data == transition.destinationState.data))
                {
                    int cycleInitialIndex = processedTransitions.FindIndex(_ => _.initialState.Equals(transition.destinationState));

                    int cycleDestinationIndex = processedTransitions.FindLastIndex(_ => _.destinationState.Equals(transition.destinationState));

                    for (int i = cycleInitialIndex; i <= cycleDestinationIndex; i++)
                    {
                        traceCycleTransitions.Add(trace.transitionsInTrace[i]);
                        continue;
                    }
                }

                return traceIsFinite(trace, transition.destinationState, traceCycleTransitions, processedTransitions);
            }

            return false;
        }

        private string extractWordFromTrace(Trace trace, State currentState, string wordAsString, List<Transition> processedTransitions)
        {
            List<Transition> possibleTransitions = trace.transitionsInTrace.FindAll(_ => _.initialState.data == currentState.data &&
                !processedTransitions.Any(x => x.Equals(_)));

            foreach (Transition possibleTransition in possibleTransitions)
            {
                processedTransitions.Add(possibleTransition);

                if (possibleTransition.connectingLetter.data != '_')
                {
                    wordAsString += possibleTransition.connectingLetter.data;
                }

                return extractWordFromTrace(trace, possibleTransition.destinationState, wordAsString, processedTransitions);
            }
            return wordAsString;
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
