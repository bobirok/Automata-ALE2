﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    public class Transition
    {
        public State initialState { get; }
        public State destinationState { get; }
        public Letter connectingLetter { get; }

        public Transition(State initialState, State destinationState, Letter connectionLetter)
        {
            this.initialState = initialState;
            this.destinationState = destinationState;
            this.connectingLetter = connectionLetter;
        }
    }
}
