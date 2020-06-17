using ALE2.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ALE2
{
    public class DfaController : IDfaController
    {
        public bool IsDfa(List<State> states, List<Letter> alphabet)
        {
            if (states.Exists(_ => _.outgoingLetters.Exists(x => x.data == '_'))) { return false; }

            foreach (State state in states)
            {
                if (state.outgoingLetters.Intersect(alphabet).ToList().Count != alphabet.Count)
                {
                    return false;
                }

                if (state.outgoingLetters.Count != state.outgoingLetters.Distinct().Count())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
