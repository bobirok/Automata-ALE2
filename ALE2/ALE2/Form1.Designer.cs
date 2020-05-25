namespace ALE2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblFunction = new System.Windows.Forms.Label();
            this.pbAutomata = new System.Windows.Forms.PictureBox();
            this.gbDfa = new System.Windows.Forms.GroupBox();
            this.btnActual = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExpected = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnParse = new System.Windows.Forms.Button();
            this.lblWords = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnParseRE = new System.Windows.Forms.Button();
            this.tbRegularExpression = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewFiniteWords = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFiniteActual = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFiniteExpected = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCheckWord = new System.Windows.Forms.TextBox();
            this.btnCheckWord = new System.Windows.Forms.Button();
            this.btnLoadFromFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbAutomata)).BeginInit();
            this.gbDfa.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiniteWords)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 28);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(217, 404);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.Location = new System.Drawing.Point(12, 9);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(51, 13);
            this.lblFunction.TabIndex = 1;
            this.lblFunction.Text = "Function:";
            this.lblFunction.Click += new System.EventHandler(this.label1_Click);
            // 
            // pbAutomata
            // 
            this.pbAutomata.Location = new System.Drawing.Point(266, 51);
            this.pbAutomata.Name = "pbAutomata";
            this.pbAutomata.Size = new System.Drawing.Size(432, 381);
            this.pbAutomata.TabIndex = 2;
            this.pbAutomata.TabStop = false;
            this.pbAutomata.Click += new System.EventHandler(this.pbAutomata_Click);
            // 
            // gbDfa
            // 
            this.gbDfa.Controls.Add(this.btnActual);
            this.gbDfa.Controls.Add(this.label2);
            this.gbDfa.Controls.Add(this.btnExpected);
            this.gbDfa.Controls.Add(this.label1);
            this.gbDfa.Location = new System.Drawing.Point(266, 438);
            this.gbDfa.Name = "gbDfa";
            this.gbDfa.Size = new System.Drawing.Size(123, 83);
            this.gbDfa.TabIndex = 3;
            this.gbDfa.TabStop = false;
            this.gbDfa.Text = "DFA";
            // 
            // btnActual
            // 
            this.btnActual.Enabled = false;
            this.btnActual.Location = new System.Drawing.Point(70, 49);
            this.btnActual.Name = "btnActual";
            this.btnActual.Size = new System.Drawing.Size(47, 23);
            this.btnActual.TabIndex = 5;
            this.btnActual.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Actual:";
            // 
            // btnExpected
            // 
            this.btnExpected.Enabled = false;
            this.btnExpected.Location = new System.Drawing.Point(70, 15);
            this.btnExpected.Name = "btnExpected";
            this.btnExpected.Size = new System.Drawing.Size(47, 23);
            this.btnExpected.TabIndex = 4;
            this.btnExpected.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expected";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(15, 440);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(214, 49);
            this.btnParse.TabIndex = 4;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // lblWords
            // 
            this.lblWords.AutoSize = true;
            this.lblWords.Location = new System.Drawing.Point(701, 20);
            this.lblWords.Name = "lblWords";
            this.lblWords.Size = new System.Drawing.Size(41, 13);
            this.lblWords.TabIndex = 6;
            this.lblWords.Text = "Words:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnParseRE);
            this.groupBox1.Controls.Add(this.tbRegularExpression);
            this.groupBox1.Location = new System.Drawing.Point(346, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(276, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regular expression";
            // 
            // btnParseRE
            // 
            this.btnParseRE.Location = new System.Drawing.Point(181, 14);
            this.btnParseRE.Margin = new System.Windows.Forms.Padding(2);
            this.btnParseRE.Name = "btnParseRE";
            this.btnParseRE.Size = new System.Drawing.Size(73, 20);
            this.btnParseRE.TabIndex = 1;
            this.btnParseRE.Text = "Parse";
            this.btnParseRE.UseVisualStyleBackColor = true;
            this.btnParseRE.Click += new System.EventHandler(this.btnParseRE_Click);
            // 
            // tbRegularExpression
            // 
            this.tbRegularExpression.Location = new System.Drawing.Point(3, 16);
            this.tbRegularExpression.Margin = new System.Windows.Forms.Padding(2);
            this.tbRegularExpression.Name = "tbRegularExpression";
            this.tbRegularExpression.Size = new System.Drawing.Size(165, 20);
            this.tbRegularExpression.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.word,
            this.expected,
            this.actual});
            this.dataGridView1.Location = new System.Drawing.Point(704, 78);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 20;
            this.dataGridView1.Size = new System.Drawing.Size(354, 144);
            this.dataGridView1.TabIndex = 8;
            // 
            // word
            // 
            this.word.HeaderText = "Word";
            this.word.MinimumWidth = 10;
            this.word.Name = "word";
            this.word.Width = 120;
            // 
            // expected
            // 
            this.expected.HeaderText = "Expected";
            this.expected.MinimumWidth = 10;
            this.expected.Name = "expected";
            this.expected.Width = 75;
            // 
            // actual
            // 
            this.actual.HeaderText = "Actual";
            this.actual.MinimumWidth = 10;
            this.actual.Name = "actual";
            this.actual.Width = 75;
            // 
            // dataGridViewFiniteWords
            // 
            this.dataGridViewFiniteWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiniteWords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridViewFiniteWords.Location = new System.Drawing.Point(703, 297);
            this.dataGridViewFiniteWords.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewFiniteWords.Name = "dataGridViewFiniteWords";
            this.dataGridViewFiniteWords.RowHeadersWidth = 82;
            this.dataGridViewFiniteWords.RowTemplate.Height = 20;
            this.dataGridViewFiniteWords.Size = new System.Drawing.Size(354, 133);
            this.dataGridViewFiniteWords.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Word";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Expected";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Actual";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 75;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFiniteActual);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnFiniteExpected);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(408, 438);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 83);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Finite";
            // 
            // btnFiniteActual
            // 
            this.btnFiniteActual.Enabled = false;
            this.btnFiniteActual.Location = new System.Drawing.Point(70, 49);
            this.btnFiniteActual.Name = "btnFiniteActual";
            this.btnFiniteActual.Size = new System.Drawing.Size(47, 23);
            this.btnFiniteActual.TabIndex = 5;
            this.btnFiniteActual.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Actual:";
            // 
            // btnFiniteExpected
            // 
            this.btnFiniteExpected.Enabled = false;
            this.btnFiniteExpected.Location = new System.Drawing.Point(70, 15);
            this.btnFiniteExpected.Name = "btnFiniteExpected";
            this.btnFiniteExpected.Size = new System.Drawing.Size(47, 23);
            this.btnFiniteExpected.TabIndex = 4;
            this.btnFiniteExpected.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Expected";
            // 
            // tbCheckWord
            // 
            this.tbCheckWord.Location = new System.Drawing.Point(704, 51);
            this.tbCheckWord.Name = "tbCheckWord";
            this.tbCheckWord.Size = new System.Drawing.Size(134, 20);
            this.tbCheckWord.TabIndex = 11;
            // 
            // btnCheckWord
            // 
            this.btnCheckWord.Location = new System.Drawing.Point(844, 49);
            this.btnCheckWord.Name = "btnCheckWord";
            this.btnCheckWord.Size = new System.Drawing.Size(75, 23);
            this.btnCheckWord.TabIndex = 12;
            this.btnCheckWord.Text = "Check";
            this.btnCheckWord.UseVisualStyleBackColor = true;
            this.btnCheckWord.Click += new System.EventHandler(this.btnCheckWord_Click);
            // 
            // btnLoadFromFile
            // 
            this.btnLoadFromFile.Location = new System.Drawing.Point(15, 492);
            this.btnLoadFromFile.Name = "btnLoadFromFile";
            this.btnLoadFromFile.Size = new System.Drawing.Size(214, 28);
            this.btnLoadFromFile.TabIndex = 13;
            this.btnLoadFromFile.Text = "Load from file";
            this.btnLoadFromFile.UseVisualStyleBackColor = true;
            this.btnLoadFromFile.Click += new System.EventHandler(this.btnLoadFromFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 522);
            this.Controls.Add(this.btnLoadFromFile);
            this.Controls.Add(this.btnCheckWord);
            this.Controls.Add(this.tbCheckWord);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridViewFiniteWords);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblWords);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.gbDfa);
            this.Controls.Add(this.pbAutomata);
            this.Controls.Add(this.lblFunction);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Automata";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAutomata)).EndInit();
            this.gbDfa.ResumeLayout(false);
            this.gbDfa.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiniteWords)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.PictureBox pbAutomata;
        private System.Windows.Forms.GroupBox gbDfa;
        private System.Windows.Forms.Button btnActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExpected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Label lblWords;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnParseRE;
        private System.Windows.Forms.TextBox tbRegularExpression;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn word;
        private System.Windows.Forms.DataGridViewTextBoxColumn expected;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual;
        private System.Windows.Forms.DataGridView dataGridViewFiniteWords;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFiniteActual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFiniteExpected;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCheckWord;
        private System.Windows.Forms.Button btnCheckWord;
        private System.Windows.Forms.Button btnLoadFromFile;
    }
}

