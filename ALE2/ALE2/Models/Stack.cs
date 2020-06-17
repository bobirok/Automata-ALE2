using System.Collections.Generic;

namespace ALE2.Models
{
    public class Stack
    {
        public List<Letter> elements { get; }
        public List<Letter> possibleElements { get; set; }

        public Stack()
        {
            this.elements = new List<Letter>();
            this.possibleElements = new List<Letter>();
        }

        public void PushToStack(Letter letter)
        {
            if (letter.data != '_')
            {
                this.elements.Add(letter);
            }
        }

        public bool IsEmpty()
        {
            return this.elements.Count == 0;
        }

        public Letter GetCurrentTopStack()
        {
            return this.elements[elements.Count - 1];
        }

        public void PopStack()
        {
            if (this.elements.Count > 0)
            {
                this.elements.RemoveAt(this.elements.Count - 1);
            }
        }

        public Stack CopyStack()
        {
            Stack copyStack = new Stack();

            foreach (Letter letter in this.elements)
            {
                copyStack.PushToStack(letter.CopyLetter());
            }

            foreach (Letter letter in this.possibleElements)
            {
                copyStack.possibleElements.Add(letter.CopyLetter());
            }

            return copyStack;
        }
    }
}
