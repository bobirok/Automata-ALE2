using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2.Models
{
    public class AutomataRow
    {
        public List<AutomataCell> cells { get; private set; }

        public AutomataRow()
        {
            this.cells = new List<AutomataCell>();
        }

        public List<string> AsString()
        {
            List<string> rowAsString = new List<string>();

            foreach (AutomataCell cell in cells)
            {
                rowAsString.Add(cell.AsString());
            }

            return rowAsString;
        }

        public bool Equals(AutomataRow row)
        {
            foreach (var cell in row.cells)
            {
                if(!this.cells.Any(_ => _.Equals(cell))) { return false; }
            }

            return true;
        }
    }
}
