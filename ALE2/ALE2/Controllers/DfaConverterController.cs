using ALE2.Interfaces;
using ALE2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ALE2.Controllers
{
    public class DfaConverterController : IDfaConverterController
    {
        public List<State> states { get; private set; }

        private AutomataTable _automataTable;
        private List<Transition> _transitions;

        public DfaConverterController(AutomataTable automataTable, List<Transition> transitions) 
        {
            this._automataTable = automataTable;
            this._transitions = transitions;
            this.states = new List<State>();
        }

        public List<Transition> convertDfaTableToAutomata(List<State> states, List<Letter> alphabet)
        {
            List<State> statesCopy = states.Select(_ => _.CopyState()).ToList();
            List<State> dfaStates = new List<State>();
            List<Letter> alphabetCopy = alphabet.Select(_ => _.CopyLetter()).ToList();

            AutomataTable table = this.produceDfaTable(statesCopy, alphabetCopy);

            List<Transition> transitions = new List<Transition>();

            List<AutomataCell> cellsWithInitialStates = new List<AutomataCell>();

            foreach (AutomataRow row in table.rows)
            {
                foreach (AutomataCell cell in row.cells)
                {
                    if(!dfaStates.Any(_ => _.data == cell.AsString()))
                    {
                        State cellState = new State(cell.AsString());
                        if(cell.statesInCell.Any(_ => _.isFinalState)) { cellState.isFinalState = true; }
                        dfaStates.Add(cellState);
                    }
                }
            }

            foreach (AutomataRow row in table.rows)
            {
                State initialState = dfaStates.Find(_ => _.data == row.cells[0].AsString());

                foreach (AutomataCell cell in row.cells)
                {
                    if (cell.belongsTo != null)
                    {
                        State destinationState = dfaStates.Find(_ => _.data == cell.AsString());
                        Transition transition = new Transition(initialState, destinationState, cell.belongsTo);
                        if (!transitions.Any(_ => _.Equals(transition)))
                        {
                            transitions.Add(transition);
                        }
                    }
                }
            }

            this.states = dfaStates;

            return transitions;

        }

        public AutomataTable produceDfaTable(List<State> states, List<Letter> alphabet)
        {
            this.convertNfaToTableFormat(states, alphabet);

            List<AutomataCell> stack = new List<AutomataCell>() { this._automataTable.rows[0].cells[0] };

            return generateDfaTableFromNfa(stack, alphabet);
        }

        public AutomataTable generateDfaTableFromNfa(List<AutomataCell> cellsStack, List<Letter> alphabet)
        {
            AutomataTable table = new AutomataTable();

            return recursiveTableCreation(table, cellsStack, alphabet);
        }

        private void convertNfaToTableFormat(List<State> states, List<Letter> alphabet)
        {
            foreach (State state in states)
            {
                AutomataRow row = new AutomataRow();
                AutomataCell initialStateCell = new AutomataCell(null);
                initialStateCell.statesInCell.Add(state);
                row.cells.Add(initialStateCell);

                foreach (Letter letter in alphabet)
                {
                    if (row.cells.Any(_ => _.belongsTo != null && _.belongsTo.data == letter.data))
                    {
                        continue;
                    }

                    List<Transition> possibleTransitions = this._transitions.FindAll(_ => _.initialState.data == state.data
                                                           && _.connectingLetter.data == letter.data);

                    List<State> destinationState = possibleTransitions.Select(_ => _.destinationState).ToList();

                    AutomataCell statesToLetterCell = new AutomataCell(letter);
                    statesToLetterCell.statesInCell = destinationState;

                    row.cells.Add(statesToLetterCell);
                }

                _automataTable.rows.Add(row);
            }
        }

        private AutomataTable recursiveTableCreation(AutomataTable table, List<AutomataCell> cellsStack, List<Letter> alphabet)
        {
            if(cellsStack.Count == 0) { return table; }

            foreach (AutomataCell cell in cellsStack.ToList())
            {
                cellsStack.Remove(cell);

                AutomataRow row = new AutomataRow();
                AutomataCell initialCell = new AutomataCell(null);
                List<State> initialCellStates = new List<State>();

                foreach (State state in cell.statesInCell)
                {
                    initialCellStates.AddRange(getEClosureStates(state, new List<State>()));
                }

                foreach (State state in initialCellStates)
                {
                    initialCell.AddStateToCell(state);
                }

                row.cells.Add(initialCell);

                foreach (Letter letter in alphabet)
                {
                    if (letter.data == '_') { continue; }

                    AutomataCell dataCell = this.createCellForLetter(initialCell, letter);

                    row.cells.Add(dataCell);

                    this.insertCellToStack(table, cellsStack, dataCell, row);
                }

                table.rows.Add(row);

                recursiveTableCreation(table, cellsStack, alphabet);
            }

            return table;
        }

        private AutomataCell createCellForLetter(AutomataCell initialCell, Letter letter)
        {
            AutomataCell dataCell = new AutomataCell(letter);
            List<State> possibleStates = new List<State>();

            this.instantiatePossibleStates(initialCell, letter, possibleStates);

            possibleStates = possibleStates.Distinct().OrderBy(_ => _.data).ToList();

            List<State> statesWithEClosures = new List<State>();

            foreach (State state1 in possibleStates)
            {
                statesWithEClosures.AddRange(getEClosureStates(state1, new List<State>()));
            }

            foreach (State state1 in statesWithEClosures)
            {
                dataCell.AddStateToCell(state1);
            }

            return dataCell;
        }

        private void instantiatePossibleStates(AutomataCell initialCell, Letter letter, List<State> possibleStates)
        {
            foreach (State state in initialCell.statesInCell)
            {
                List<Transition> possibleTransitions = this._transitions.FindAll(
                        _ => _.initialState.data == state.data &&
                        _.connectingLetter.data == letter.data);

                possibleStates.AddRange(possibleTransitions.Select(_ => _.destinationState));
            }
        }

        private void insertCellToStack(AutomataTable table, List<AutomataCell> cellsStack, AutomataCell dataCell, AutomataRow row)
        {
            if (!table.rows.Any(_ => _.cells.Any(x => x.belongsTo == null && x.statesInCell.SequenceEqual(dataCell.statesInCell)))
                        && !row.cells.Any(x => x.belongsTo == null && x.statesInCell.SequenceEqual(dataCell.statesInCell)))
            {
                cellsStack.Insert(cellsStack.Count, dataCell);
            }
        }

        private List<State> getEClosureStates(State current, List<State> states)
        {
           if (!states.Any(_ => _.data == current.data))
           {
                states.Add(current);
           }
            

            List<Transition> possibleTransitions = this._transitions.FindAll(_ => _.initialState.data == current.data &&
                _.connectingLetter.data == '_');

            foreach (Transition transition in possibleTransitions)
            {
                getEClosureStates(transition.destinationState, states);
            }

            return states;
        }
    }
}
