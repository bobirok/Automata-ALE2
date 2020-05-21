using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    public class Letter
    {
        public char data { get; }

        public Letter(char data)
        {
            this.data = data;
        }

        public Letter CopyLetter()
        {
            return new Letter(this.data);
        }

        public override bool Equals(Object obj)
        {
            Letter letter = obj as Letter;

            return this.data == letter.data;
        } 
        
    }
}
