using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALE2
{
    public partial class Form1 : Form
    {
        private ParserController _parserController;
        private ImageBuilder _imageBuilder = new ImageBuilder();
        private DfaController _dfaController = new DfaController();

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

            List<Letter> alphabet = new List<Letter>();
            List<State> states = new List<State>();
            List<Transition> transitions = new List<Transition>();
            List<Word> words = new List<Word>();

            this._parserController = new ParserController(alphabet, states, transitions, words);

            this._parserController.Parse(lines);

            this._imageBuilder.BuildGraphVizImage(pbAutomata, states, transitions);

            bool actualDfa = this._dfaController.isDfa(states, alphabet);
            this.defineDfaForUser(actualDfa, btnActual);

            bool expectedDfa = this._parserController.expectedDfa;
            this.defineDfaForUser(expectedDfa, btnExpected);

            this.checkForWordsExistance(words);

            pbAutomata.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void defineDfaForUser(bool dfa, Button button)
        {
            if(dfa)
            {
                button.BackColor = Color.Green;
            } else
            {
                button.BackColor = Color.Red;
            }
        }

        private void checkForWordsExistance(List<Word> words)
        {
            rtbWords.Text = "";
            foreach (Word word in words)
            {
                rtbWords.Text += word.word;
                rtbWords.Text += word.existsInAutomata ? " exists" : " does not exist";
                rtbWords.Text += "\n";
            }
        }

        private void btnParseRE_Click(object sender, EventArgs e)
        {
            RegularExpression re0 = new RegularExpression(new Letter('*'));
            RegularExpression re1 = new RegularExpression(new Letter('a'));
            RegularExpression re2 = new RegularExpression(new Letter('b'));
            RegularExpression re3 = new RegularExpression(new Letter('.'));
            re3.left = re1;
            re3.right = re2;
            re0.left = re3;
            RegularExpressionController regularExpressionController = new RegularExpressionController();

            List<Transition> transitions = regularExpressionController.getNdfaFromRegularExpression(re0);
            List<State> states = regularExpressionController.ExtractStatesFromTransitions(transitions);
            List<Letter> alphabet = regularExpressionController.ExtractAlphabetFromTransitions(transitions);

            this._imageBuilder.BuildGraphVizImage(pbAutomata, states, transitions);

            pbAutomata.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
