using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2.Interfaces
{
    public interface IParser
    {
        void ParseAlphabet(string alphabetString);

        void ParseStates(string statesString);

        void ParseStack(string stackString);

        void ParseFinalStates(string finalStatesString);

        bool ParseFinite(string finiteString);

        void ParseTransition(string transitionString);

        bool WordExists(string word, State currentState);

        bool IsEscapableChar(char charToCheck);
    }
}
