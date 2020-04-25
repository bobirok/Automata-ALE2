using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    public class Word
    {
        public string word { get; }
        public bool existsInAutomata { get; }

        public Word(string word, bool existsInAutomata)
        {
            this.word = word;
            this.existsInAutomata = existsInAutomata;
        }
    }
}
