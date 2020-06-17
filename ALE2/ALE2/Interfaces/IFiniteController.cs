using System.Collections.Generic;

namespace ALE2.Interfaces
{
    public interface IFiniteController
    {
        List<Word> ExtractAllWordsFromAutomata();

        void InstantiateTraces(State initialState, State currentState, List<Transition> listOfTransitions);

        bool AutomataIsFinite();
    }
}
