using System;

namespace ALE2.Models
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
