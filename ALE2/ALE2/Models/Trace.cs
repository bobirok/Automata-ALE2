using System;
using System.Collections.Generic;
using System.Linq;

namespace ALE2.Models
{
    public class Trace
    {
        public bool transitionIsFinishable { get; set; }

        public List<Transition> transitionsInTrace { get; set; }

        public State initialState { get; set; } = null;

        public List<State> visitedStates { get; set; }

        public Trace initialTrace { get; set; }


        public Trace(List<Transition> transitionsInTrace, State initialState)
        {
            this.transitionsInTrace = transitionsInTrace;
            this.initialState = initialState;
            this.visitedStates = new List<State>();
        }

        public Trace CopyTrace()
        {
            Trace trace = new Trace(new List<Transition>(), this.initialState.CopyState());
            foreach (var transition in this.transitionsInTrace)
            {
                trace.transitionsInTrace.Add(transition.CopyTransition());
            }
            trace.transitionIsFinishable = this.transitionIsFinishable;
            trace.initialState = this.initialState;
            foreach (State state in visitedStates)
            {
                trace.visitedStates.Add(state.CopyState());
            }
            return trace;
        }

        public override bool Equals(Object obj)
        {
            Trace trace = obj as Trace;

            foreach (State state in visitedStates)
            {
                if (!((Trace)trace).visitedStates.Any(_ => _.data == state.data)) { return false; }
            }

            foreach (Transition transition in transitionsInTrace)
            {
                if (!((Trace)trace).transitionsInTrace.Any(_ => _.Equals(transition))) { return false; }
            }

            return true;
        }
    }
}
