using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2.Models
{
    public class AutomataCell
    {
        public List<State> statesInCell { get; set; }
        public Letter belongsTo { get; }

        public AutomataCell(Letter belongsTo)
        {
            this.statesInCell = new List<State>();
            this.belongsTo = belongsTo;
        }

        public void AddStateToCell(State stateToAdd)
        {
            if(!this.statesInCell.Any(_ => _.Equals(stateToAdd)))
            {
                this.statesInCell.Add(stateToAdd);
            }
        }

        public string AsString()
        {
            string cellAsString = "{";

            foreach (State state in statesInCell)
            {
                cellAsString += state.data;
            }

            return cellAsString += "}";
        }

        public bool Equals(AutomataCell cell)
        {
            return this.statesInCell.SequenceEqual(cell.statesInCell);
        }
    }
}
