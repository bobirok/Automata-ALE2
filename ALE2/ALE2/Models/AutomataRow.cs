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
    }
}
