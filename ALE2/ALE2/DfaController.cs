using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    public class DfaController
    {
        public bool isDfa(List<State> states, List<Letter> alphabet)
        {
            foreach (State state in states)
            {
                if(state.outgoingLetters.Intersect(alphabet).ToList().Count != alphabet.Count)
                {
                    return false;
                }

                if(state.outgoingLetters.Count != state.outgoingLetters.Distinct().Count())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
