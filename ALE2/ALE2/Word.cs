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
        public bool expectedWordExistance { get; }

        public Word(string word, bool existsInAutomata, bool expectedWordExistance)
        {
            this.word = word;
            this.existsInAutomata = existsInAutomata;
            this.expectedWordExistance = expectedWordExistance;
        }
    }
}
