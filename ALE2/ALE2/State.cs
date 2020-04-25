using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    public class State
    {
        public string data { get; }
        public bool isFinalState { get; set; }
        public List<Letter> outgoingLetters { get; }

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
    }
}
