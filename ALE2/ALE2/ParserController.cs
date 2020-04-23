using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    public class ParserController
    {
        private Parser _parser;

        public ParserController(List<Letter> alphabet, List<State> states, List<Transition> transitions)
        {
            this._parser = new Parser(alphabet, states, transitions);
        }

        public void Parse(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("alphabet: "))
                {
                    string alphabet = lines[i].Substring(10);
                    this._parser.parseAlphabet(alphabet);
                } else if (lines[i].Contains("states"))
                {
                    string states = lines[i].Substring(8);
                    this._parser.parseStates(states);
                } else if (lines[i].Contains("final"))
                {
                    string final = lines[i].Substring(7);
                    this._parser.parseFinalStates(final);
                } else if (lines[i].Contains("transitions"))
                {
                    i++;
                    while (!lines[i].Contains("end"))
                    {
                        this._parser.parseTransition(lines[i]);
                        i++;
                    }
                }
            }
        }
    }
}
