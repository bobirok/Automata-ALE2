using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2.Interfaces
{
    public interface IDfaController
    {
        bool IsDfa(List<State> states, List<Letter> alphabet);
    }
}
