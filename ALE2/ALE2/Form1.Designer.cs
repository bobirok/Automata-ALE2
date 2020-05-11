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
            this.rtbWords = new System.Windows.Forms.RichTextBox();
            this.lblWords = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnParseRE = new System.Windows.Forms.Button();
            this.tbRegularExpression = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAutomata)).BeginInit();
            this.gbDfa.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(24, 54);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(426, 739);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.Location = new System.Drawing.Point(24, 17);
            this.lblFunction.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(101, 25);
            this.lblFunction.TabIndex = 1;
            this.lblFunction.Text = "Function:";
            this.lblFunction.Click += new System.EventHandler(this.label1_Click);
            // 
            // pbAutomata
            // 
            this.pbAutomata.Location = new System.Drawing.Point(532, 98);
            this.pbAutomata.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbAutomata.Name = "pbAutomata";
            this.pbAutomata.Size = new System.Drawing.Size(864, 738);
            this.pbAutomata.TabIndex = 2;
            this.pbAutomata.TabStop = false;
            // 
            // gbDfa
            // 
            this.gbDfa.Controls.Add(this.btnActual);
            this.gbDfa.Controls.Add(this.label2);
            this.gbDfa.Controls.Add(this.btnExpected);
            this.gbDfa.Controls.Add(this.label1);
            this.gbDfa.Location = new System.Drawing.Point(30, 823);
            this.gbDfa.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbDfa.Name = "gbDfa";
            this.gbDfa.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbDfa.Size = new System.Drawing.Size(246, 179);
            this.gbDfa.TabIndex = 3;
            this.gbDfa.TabStop = false;
            this.gbDfa.Text = "DFA";
            // 
            // btnActual
            // 
            this.btnActual.Enabled = false;
            this.btnActual.Location = new System.Drawing.Point(140, 94);
            this.btnActual.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnActual.Name = "btnActual";
            this.btnActual.Size = new System.Drawing.Size(94, 44);
            this.btnActual.TabIndex = 5;
            this.btnActual.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Actual:";
            // 
            // btnExpected
            // 
            this.btnExpected.Enabled = false;
            this.btnExpected.Location = new System.Drawing.Point(140, 29);
            this.btnExpected.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnExpected.Name = "btnExpected";
            this.btnExpected.Size = new System.Drawing.Size(94, 44);
            this.btnExpected.TabIndex = 4;
            this.btnExpected.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expected";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(304, 808);
            this.btnParse.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(150, 44);
            this.btnParse.TabIndex = 4;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // rtbWords
            // 
            this.rtbWords.Location = new System.Drawing.Point(1490, 54);
            this.rtbWords.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rtbWords.Name = "rtbWords";
            this.rtbWords.Size = new System.Drawing.Size(426, 739);
            this.rtbWords.TabIndex = 5;
            this.rtbWords.Text = "";
            // 
            // lblWords
            // 
            this.lblWords.AutoSize = true;
            this.lblWords.Location = new System.Drawing.Point(1484, 17);
            this.lblWords.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWords.Name = "lblWords";
            this.lblWords.Size = new System.Drawing.Size(80, 25);
            this.lblWords.TabIndex = 6;
            this.lblWords.Text = "Words:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnParseRE);
            this.groupBox1.Controls.Add(this.tbRegularExpression);
            this.groupBox1.Location = new System.Drawing.Point(692, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(552, 77);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regular expression";
            // 
            // btnParseRE
            // 
            this.btnParseRE.Location = new System.Drawing.Point(362, 27);
            this.btnParseRE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnParseRE.Name = "btnParseRE";
            this.btnParseRE.Size = new System.Drawing.Size(146, 38);
            this.btnParseRE.TabIndex = 1;
            this.btnParseRE.Text = "Parse";
            this.btnParseRE.UseVisualStyleBackColor = true;
            this.btnParseRE.Click += new System.EventHandler(this.btnParseRE_Click);
            // 
            // tbRegularExpression
            // 
            this.tbRegularExpression.Location = new System.Drawing.Point(6, 31);
            this.tbRegularExpression.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbRegularExpression.Name = "tbRegularExpression";
            this.tbRegularExpression.Size = new System.Drawing.Size(326, 31);
            this.tbRegularExpression.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1952, 977);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblWords);
            this.Controls.Add(this.rtbWords);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.gbDfa);
            this.Controls.Add(this.pbAutomata);
            this.Controls.Add(this.lblFunction);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Automata";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAutomata)).EndInit();
            this.gbDfa.ResumeLayout(false);
            this.gbDfa.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.RichTextBox rtbWords;
        private System.Windows.Forms.Label lblWords;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnParseRE;
        private System.Windows.Forms.TextBox tbRegularExpression;
    }
}

