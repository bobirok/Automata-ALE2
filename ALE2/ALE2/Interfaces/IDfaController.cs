using ALE2.Models;
using System.Collections.Generic;

namespace ALE2.Interfaces
{
    public interface IDfaController
    {
        bool IsDfa(List<State> states, List<Letter> alphabet);
    }
}
