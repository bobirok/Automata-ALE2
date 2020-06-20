using ALE2.Models;
using System;

namespace ALE2.Models
{
    public class Transition
    {
        public State initialState { get; set; }
        public State destinationState { get; set; }
        public Letter connectingLetter { get; set; }
        public TransitionStackElement transitionStackElement { get; set; }

        public Transition(State initialState, State destinationState, Letter connectionLetter)
        {
            this.initialState = initialState;
            this.destinationState = destinationState;
            this.connectingLetter = connectionLetter;
        }

        public Transition CopyTransition()
        {
            return new Transition(this.initialState.CopyState(), this.destinationState.CopyState(), this.connectingLetter.CopyLetter());
        }

        public override bool Equals(Object obj)
        {
            Transition transition = obj as Transition;

            if (!this.destinationState.Equals(transition.destinationState)) { return false; }
            if (!this.initialState.Equals(transition.initialState)) { return false; }
            if (!this.connectingLetter.Equals(transition.connectingLetter)) { return false; }

            return true;
        }
    }
}
