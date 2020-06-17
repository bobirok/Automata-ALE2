using System.Collections.Generic;
using System.Linq;

namespace ALE2.Models
{
    public class AutomataTable
    {
        public List<AutomataRow> rows { get; set; }

        public AutomataTable()
        {
            this.rows = new List<AutomataRow>();
        }
    }
}
