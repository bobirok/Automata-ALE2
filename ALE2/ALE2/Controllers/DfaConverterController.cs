using ALE2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2.Controllers
{
    public class DfaConverterController
    {
        private AutomataTable _automataTable;

        public DfaConverterController(AutomataTable automataTable)
        {
            this._automataTable = automataTable;
        }

        public void convertNfaToTableFormat(List<Transition> transitions, List<State> states, List<Letter> alphabet)
        {
            foreach (State state in states)
            {
                AutomataRow row = new AutomataRow();
                AutomataCell initialStateCell = new AutomataCell(null);
                initialStateCell.statesInCell.Add(state);
                row.cells.Add(initialStateCell);

                foreach (Letter letter in alphabet)
                {
                    if(row.cells.Any(_ => _.belongsTo != null && _.belongsTo.data == letter.data))
                    {
                        continue;
                    }

                    List<Transition> possibleTransitions = transitions.FindAll(_ => _.initialState.data == state.data
                                                           && _.connectingLetter.data == letter.data);

                    List<State> destinationState = possibleTransitions.Select(_ => _.destinationState).ToList();

                    AutomataCell statesToLetterCell = new AutomataCell(letter);
                    statesToLetterCell.statesInCell = destinationState;

                    row.cells.Add(statesToLetterCell);
                }

                _automataTable.rows.Add(row);
            }
        }
    }
}
