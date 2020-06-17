using ALE2.Models;
using System.Collections.Generic;

namespace ALE2.Interfaces
{
    public interface IDfaConverterController
    {
        List<Transition> ConvertDfaTableToAutomata(List<State> states, List<Letter> alphabet);

        AutomataTable ProduceDfaTable(List<State> states, List<Letter> alphabet);

        AutomataTable GenerateDfaTableFromNfa(List<AutomataCell> cellsStack, List<Letter> alphabet);
    }
}
