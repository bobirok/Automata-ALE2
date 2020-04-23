using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    public class Transition
    {
        public State _initialState { get; }
        public State _destinationState { get; }
        public Letter _connectingLetter { get; }

        public Transition(State initialState, State destinationState, Letter connectionLetter)
        {
            this._initialState = initialState;
            this._destinationState = destinationState;
            this._connectingLetter = connectionLetter;
        }
    }
}
