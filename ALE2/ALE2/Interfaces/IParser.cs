using ALE2.Models;

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
