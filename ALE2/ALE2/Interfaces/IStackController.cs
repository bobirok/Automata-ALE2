using ALE2.Models;

namespace ALE2.Interfaces
{
    public interface IStackController
    {
        bool WordWithStackExists(string word, State currentState, Stack stack);
    }
}
