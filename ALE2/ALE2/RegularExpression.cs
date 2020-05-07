using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    public class RegularExpression
    {
        public Letter letter { get; }
        public RegularExpression left { get; set; }
        public RegularExpression right { get; set;}

        public List<Transition> transitions { get; set; } = new List<Transition>();

        public State initial { get; set; }
        public State final { get; set; }

        public RegularExpression(Letter letter) 
        {
            this.letter = letter;
        }
    }
}
