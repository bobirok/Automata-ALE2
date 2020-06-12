using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2.Models
{
    public class AutomataTable
    {
        public List<AutomataRow> rows { get; set; }

        public AutomataTable()
        {
            this.rows = new List<AutomataRow>();
        }

        public bool Equals(AutomataTable table)
        {
            foreach (var row in table.rows)
            {
                if(!this.rows.Any(_ => _.Equals(row))) { return false; }
            }

            return true;
        }
    }
}
