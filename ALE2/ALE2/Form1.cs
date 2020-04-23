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

            this._parserController = new ParserController(alphabet, states, transitions);

            this._parserController.Parse(lines);

            this._imageBuilder.BuildGraphVizImage(pbAutomata, states, transitions);

            pbAutomata.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
