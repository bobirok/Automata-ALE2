using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    public class State
    {
        public string _data { get; }
        public bool isFinalState { get; set; }

        public State(string data)
        {
            this._data = data;
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
