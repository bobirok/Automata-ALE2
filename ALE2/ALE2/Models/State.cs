using System;
using System.Collections.Generic;

namespace ALE2
{
    public class State
    {
        public string data { get; }
        public bool isFinalState { get; set; }
        public List<Letter> outgoingLetters { get; }
        public bool isProcessed { get; set; }

        public State(string data)
        {
            this.data = data;
            this.outgoingLetters = new List<Letter>();
        }

        public string GetShapeString()
        {
            if (this.isFinalState)
            {
                return "doublecircle";
            }

            return "circle";
        }

        public State CopyState()
        {
            State state = new State(this.data);
            foreach (var letter in outgoingLetters)
            {
                state.outgoingLetters.Add(letter.CopyLetter());
            }
            state.isFinalState = this.isFinalState;
            state.isProcessed = this.isProcessed;

            return state;
        }

        public override bool Equals(Object obj)
        {
            State state = obj as State;

            return this.data == state.data;
        }

        public void MarkAsProcessed()
        {
            this.isProcessed = true;
        }

        public void MarkAsUnprocessed()
        {
            this.isProcessed = false;
        }
    }
}
