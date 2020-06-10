using ALE2.Controllers;
using ALE2.Interfaces;
using ALE2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALE2
{
    [ExcludeFromCodeCoverage]
    public partial class Form1 : Form
    {
        private IParserController _parserController;
        private ImageBuilder _imageBuilder = new ImageBuilder();
        private IDfaController _dfaController = new DfaController();
        private IFiniteController _finiteController;
        private IDfaConverterController _dfaConverterController;
        private List<State> _states;
        private List<Letter> _alphabet;
        private Stack _stack;
        private List<Transition> _transitions;
        private List<Word> _words;
        private AutomataTable _automataTable = new AutomataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            string[] lines = richTextBox1.Text.Split('\n');

            _alphabet = new List<Letter>();
            _stack = new Stack();
            _states = new List<State>();
            _transitions = new List<Transition>();
            _words = new List<Word>();

            this._parserController = new ParserController(_alphabet, _states, _transitions, _stack, _words);

            this._parserController.Parse(lines);

            this._imageBuilder.BuildGraphVizImage(pbAutomata, _states, _transitions);

            bool actualDfa = this._dfaController.IsDfa(_states, _alphabet);
            this.defineButtonsForUser(actualDfa, btnActual);

            bool expectedDfa = ((ParserController)this._parserController).expectedDfa;
            this.defineButtonsForUser(expectedDfa, btnExpected);

            this.handleDefiningFinite(_transitions, _states, ((ParserController)this._parserController).expectedFinite);

            this.checkForWordsExistance(_words);

            pbAutomata.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void defineButtonsForUser(bool check, Button button)
        {
            if(check)
            {
                button.BackColor = Color.Green;
            } else
            {
                button.BackColor = Color.Red;
            }
        }

        private void checkForWordsExistance(List<Word> words)
        {
            dataGridView1.Rows.Clear();
            foreach (Word word in words)
            {
                dataGridView1.Rows.Add(word.word, word.expectedWordExistance, word.existsInAutomata);
            }
        }

        private void handleDefiningFinite(List<Transition> transitions, List<State> states, bool expectedFinite)
        {
            List<Trace> traces = new List<Trace>();
            List<Transition> transitionss = new List<Transition>();
            this._finiteController = new FiniteController(traces, transitions);
            this._finiteController.InstantiateTraces(states[0], states[0], transitionss);
            bool isFinite = this._finiteController.AutomataIsFinite();
            this.defineButtonsForUser(expectedFinite, btnFiniteExpected);
            this.defineButtonsForUser(isFinite, btnFiniteActual);
            this.loadFiniteWords();
        }

        private void loadFiniteWords()
        {
            List<Word> finiteWords = this._finiteController.ExtractAllWordsFromAutomata();

            dataGridViewFiniteWords.Rows.Clear();

            foreach (Word word in finiteWords)
            {
                dataGridViewFiniteWords.Rows.Add(word.word, word.expectedWordExistance, word.existsInAutomata);
            }
        }

        private void btnParseRE_Click(object sender, EventArgs e)
        {
            string formula = tbRegularExpression.Text;
            IRegularExpressionController regularExpressionController = new RegularExpressionController();

            RegularExpression root = regularExpressionController.GetNdfaFromRegularExpression(ref formula);

            List<Transition> transitions = root.transitions;
            List<State> states = regularExpressionController.ExtractStatesFromTransitions(transitions);
            List<Letter> alphabet = regularExpressionController.ExtractAlphabetFromTransitions(transitions);

            int exchangeTransitionIndex = transitions.FindIndex(_ => _.initialState == root.initial);
            Transition frontTransition = transitions.Find(_ => _.initialState == root.initial);

            transitions[exchangeTransitionIndex] = transitions[0];
            transitions[0] = frontTransition;

            string regularExpressionAsString = regularExpressionController.GetNDfaFromRegularExpressionAsString(transitions);

            richTextBox1.Clear();

            richTextBox1.Text = regularExpressionAsString;

            System.IO.File.WriteAllText("./RegularExpression.txt", regularExpressionAsString);

            this._imageBuilder.BuildGraphVizImage(pbAutomata, states, transitions);

            btnParse_Click(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pbAutomata_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("./abc.png");
        }

        private void btnCheckWord_Click(object sender, EventArgs e)
        {
            string wordAsString = tbCheckWord.Text;
            bool wordExists = ((ParserController)this._parserController)._parser.WordExists(wordAsString, this._states[0]);
            Word word = new Word(wordAsString, wordExists, true);
            dataGridView1.Rows.Add(word.word, word.expectedWordExistance, word.existsInAutomata);
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            string automata = "";
            Stream myStream = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Choose automata";
            theDialog.Filter = "TXT files|*.txt";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = theDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            automata = File.ReadAllText(theDialog.FileName);
                            richTextBox1.Text = automata;
                            btnParse_Click(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnConvertToFinite_Click(object sender, EventArgs e)
        {
            this._automataTable = new AutomataTable();

            this._dfaConverterController = new DfaConverterController(this._automataTable, _transitions);

            List<Transition> dfaTransitions = this._dfaConverterController.convertDfaTableToAutomata(this._states, this._alphabet);

            this._imageBuilder.BuildGraphVizImage(pbAutomata, ((DfaConverterController)_dfaConverterController).states, dfaTransitions);
        }
    }
}
