using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2.Models
{
    public class AutomataTable
    {
        public List<AutomataRow> rows { get; private set; }

        public AutomataTable()
        {
            this.rows = new List<AutomataRow>();
        }
    }
}
