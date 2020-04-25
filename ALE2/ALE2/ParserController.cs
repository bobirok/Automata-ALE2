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
        private List<Word> _words;
        private List<State> _states;
        public bool expectedDfa { get; set; }

        public ParserController(List<Letter> alphabet, List<State> states, List<Transition> transitions, List<Word> words)
        {
            this._parser = new Parser(alphabet, states, transitions);
            this._words = words;
            this._states = states;
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
                } else if(lines[i].Contains("dfa"))
                {
                    string dfa = lines[i].Substring(5);
                    if(dfa[0] == 'y')
                    {
                        this.expectedDfa = true;
                    } else if(dfa[0] == 'n')
                    {
                        this.expectedDfa = false;
                    }
                } else if(lines[i].Contains("words"))
                {
                    i++;
                    while (!lines[i].Contains("end"))
                    {
                        int endIndex = lines[i].IndexOf(',');
                        string word = lines[i].Substring(0, endIndex);
                        bool wordExists = this._parser.wordExists(word, this._states[0]);
                        this._words.Add(new Word(word, wordExists));
                        i++;
                    }
                }
            }
        }
    }
}
