using System.Collections.Generic;
using System.Linq;

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
