using ALE2.Models;
using System.Collections.Generic;

namespace ALE2.Interfaces
{
    public interface IStackController
    {
        bool WordWithStackExists(string word, State currentState, Stack stack, List<Transition> processedTransitions);
    }
}
