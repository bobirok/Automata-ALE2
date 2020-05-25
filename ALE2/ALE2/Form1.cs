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
        private ParserController _parserController;
        private ImageBuilder _imageBuilder = new ImageBuilder();
        private DfaController _dfaController = new DfaController();
        private FiniteController _finiteController;
        private List<State> states;
        private List<Letter> alphabet;
        private List<Transition> transitions;
        private List<Word> words;

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

            alphabet = new List<Letter>();
            states = new List<State>();
            transitions = new List<Transition>();
            words = new List<Word>();

            this._parserController = new ParserController(alphabet, states, transitions, words);

            this._parserController.Parse(lines);

            this._imageBuilder.BuildGraphVizImage(pbAutomata, states, transitions);

            bool actualDfa = this._dfaController.IsDfa(states, alphabet);
            this.defineButtonsForUser(actualDfa, btnActual);

            bool expectedDfa = this._parserController.expectedDfa;
            this.defineButtonsForUser(expectedDfa, btnExpected);

            this.handleDefiningFinite(transitions, states, this._parserController.expectedFinite);

            this.checkForWordsExistance(words);

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
            RegularExpressionController regularExpressionController = new RegularExpressionController();

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

            pbAutomata.SizeMode = PictureBoxSizeMode.StretchImage;
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
            bool wordExists = this._parserController._parser.WordExists(wordAsString, this.states[0]);
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
    }
}
