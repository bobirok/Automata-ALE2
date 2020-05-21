﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    public class ParserController
    {
        public Parser _parser { get; }
        private List<Word> _words;
        private List<State> _states;
        public bool expectedDfa { get; set; }
        public bool expectedFinite { get; set; }

        public ParserController(List<Letter> alphabet, List<State> states, List<Transition> transitions, 
                List<Word> words)
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
                    this._parser.ParseAlphabet(alphabet);
                } else if (lines[i].Contains("states"))
                {
                    string states = lines[i].Substring(8);
                    this._parser.ParseStates(states);
                } else if (lines[i].Contains("final"))
                {
                    string final = lines[i].Substring(7);
                    this._parser.ParseFinalStates(final);
                } else if (lines[i].Contains("transitions"))
                {
                    i++;
                    while (!lines[i].Contains("end"))
                    {
                        this._parser.ParseTransition(lines[i]);
                        i++;
                    }
                } else if(lines[i].Contains("dfa"))
                {
                    string dfa = lines[i].Substring(5);
                    this.expectedDfa = this.parseExpectedValue(dfa[0]);
                } else if(lines[i].Contains("words"))
                {
                    i++;
                    this.handleLineWord(lines, i);
                } else if(lines[i].Contains("finite"))
                {
                    string finite = lines[i].Substring(6);
                    this.expectedFinite = this._parser.ParseFinite(finite);
                }
            }
        }

        private void handleLineWord(string[] lines, int i)
        {
            while (!lines[i].Contains("end"))
            {
                int endIndex = lines[i].IndexOf(',');
                string word = lines[i].Substring(0, endIndex);
                bool wordExists = this._parser.WordExists(word, this._states[0]);

                while (_parser.IsEscapableChar(lines[i][endIndex]))
                {
                    endIndex++;
                }
                char givenWordExpectedExistanceInChar = lines[i][endIndex];

                bool expectedWordExistance = this.parseExpectedValue(givenWordExpectedExistanceInChar);

                this._words.Add(new Word(word, wordExists, expectedWordExistance));

                i++;
            }
        }

        private bool parseExpectedValue(char expectedInChar)
        {
            if(expectedInChar == 'y')
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}