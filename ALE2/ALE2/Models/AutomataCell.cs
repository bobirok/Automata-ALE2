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
    }
}
