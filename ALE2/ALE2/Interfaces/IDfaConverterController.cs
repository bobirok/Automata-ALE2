using ALE2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2.Interfaces
{
    public interface IDfaConverterController
    {
        List<Transition> convertDfaTableToAutomata(List<State> states, List<Letter> alphabet);

        AutomataTable produceDfaTable(List<State> states, List<Letter> alphabet);

        AutomataTable generateDfaTableFromNfa(List<AutomataCell> cellsStack, List<Letter> alphabet);
    }
}
