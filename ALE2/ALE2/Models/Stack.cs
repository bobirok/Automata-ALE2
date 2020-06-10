using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void pushToStack(Letter letter)
        {
            if (letter.data != '_')
            {
                this.elements.Add(letter);
            }
        }

        public bool isEmpty()
        {
            return this.elements.Count == 0;
        }

        public Letter getCurrentTopStack()
        {
            return this.elements[elements.Count - 1];
        }

        public void popStack()
        {
            this.elements.RemoveAt(this.elements.Count - 1);
        }

        public Stack copyStack()
        {
            Stack copyStack = new Stack();

            foreach (Letter letter in this.elements)
            {
                copyStack.pushToStack(letter.CopyLetter());
            }

            return copyStack;
        }
    }
}
