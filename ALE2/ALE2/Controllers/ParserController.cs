using ALE2.Controllers;
using ALE2.Interfaces;
using ALE2.Models;
using System.Collections.Generic;
using System.Linq;

namespace ALE2
{
    public class ParserController : IParserController
    {
        public IParser _parser { get; }
        private IStackController _stackController;
        private List<Word> _words;
        private List<State> _states;
        public bool expectedDfa { get; set; }
        public bool expectedFinite { get; set; }
        private bool isWithStack = false;
        private List<Transition> _transitions;
        private Stack _stack;

        public ParserController(List<Letter> alphabet, List<State> states, List<Transition> transitions,
            Stack stack, List<Word> words)
        {
            this._parser = new Parser(alphabet, states, transitions, stack);
            this._words = words;
            this._states = states;
            this._transitions = transitions;
            this._stack = stack;
        }

        public void Parse(string[] lines)
        {
            if (lines.Any(_ => _.Contains("stack"))) this.isWithStack = true;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("alphabet: "))
                {
                    string alphabet = lines[i].Substring(10);
                    this._parser.ParseAlphabet(alphabet);
                }
                else if (lines[i].Contains("stack"))
                {
                    string stackString = lines[i].Substring(6);
                    this._parser.ParseStack(stackString);
                }
                else if (lines[i].Contains("states"))
                {
                    string states = lines[i].Substring(8);
                    this._parser.ParseStates(states);
                }
                else if (lines[i].Contains("final"))
                {
                    string final = lines[i].Substring(7);
                    this._parser.ParseFinalStates(final);
                }
                else if (lines[i].Contains("transitions"))
                {
                    i++;
                    while (!lines[i].Contains("end"))
                    {
                        this._parser.ParseTransition(lines[i]);
                        i++;
                    }
                }
                else if (lines[i].Contains("dfa"))
                {
                    string dfa = lines[i].Substring(5);
                    this.expectedDfa = this.parseExpectedValue(dfa[0]);
                }
                else if (lines[i].Contains("words"))
                {
                    i++;
                    if (this.isWithStack)
                    {
                        this._stackController = new StackController(_transitions, _stack);
                    }
                    this.handleLineWord(lines, i);
                }
                else if (lines[i].Contains("finite"))
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
                bool wordExists;
                if (!this.isWithStack)
                {
                    wordExists = this._parser.WordExists(word, this._states[0]);
                }
                else
                {
                    wordExists = this._stackController.WordWithStackExists(word, this._states[0], this._stack.CopyStack(), new List<Transition>());
                }

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
            return expectedInChar == 'y';
        }
    }
}
