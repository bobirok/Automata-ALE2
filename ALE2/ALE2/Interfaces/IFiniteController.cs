using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2.Interfaces
{
    public interface IFiniteController
    {
        List<Word> ExtractAllWordsFromAutomata();

        void InstantiateTraces(State initialState, State currentState, List<Transition> listOfTransitions);

        bool AutomataIsFinite();        
    }
}
