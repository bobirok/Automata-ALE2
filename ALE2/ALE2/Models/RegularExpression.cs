using System.Collections.Generic;

namespace ALE2
{
    public class RegularExpression
    {
        public Letter letter { get; }
        public List<Transition> transitions { get; set; } = new List<Transition>();
        public State initial { get; set; }
        public State final { get; set; }

        public RegularExpression(Letter letter)
        {
            this.letter = letter;
        }
    }
}
