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
            ((System.ComponentModel.ISupportInitialize)(this.pbAutomata)).BeginInit();
            this.gbDfa.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 28);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(215, 386);
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
            this.pbAutomata.Location = new System.Drawing.Point(266, 28);
            this.pbAutomata.Name = "pbAutomata";
            this.pbAutomata.Size = new System.Drawing.Size(432, 384);
            this.pbAutomata.TabIndex = 2;
            this.pbAutomata.TabStop = false;
            // 
            // gbDfa
            // 
            this.gbDfa.Controls.Add(this.btnActual);
            this.gbDfa.Controls.Add(this.label2);
            this.gbDfa.Controls.Add(this.btnExpected);
            this.gbDfa.Controls.Add(this.label1);
            this.gbDfa.Location = new System.Drawing.Point(15, 428);
            this.gbDfa.Name = "gbDfa";
            this.gbDfa.Size = new System.Drawing.Size(123, 93);
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
            this.btnParse.Location = new System.Drawing.Point(152, 420);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 4;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // rtbWords
            // 
            this.rtbWords.Location = new System.Drawing.Point(745, 28);
            this.rtbWords.Name = "rtbWords";
            this.rtbWords.Size = new System.Drawing.Size(215, 386);
            this.rtbWords.TabIndex = 5;
            this.rtbWords.Text = "";
            // 
            // lblWords
            // 
            this.lblWords.AutoSize = true;
            this.lblWords.Location = new System.Drawing.Point(742, 9);
            this.lblWords.Name = "lblWords";
            this.lblWords.Size = new System.Drawing.Size(41, 13);
            this.lblWords.TabIndex = 6;
            this.lblWords.Text = "Words:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 522);
            this.Controls.Add(this.lblWords);
            this.Controls.Add(this.rtbWords);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.gbDfa);
            this.Controls.Add(this.pbAutomata);
            this.Controls.Add(this.lblFunction);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Automata";
            ((System.ComponentModel.ISupportInitialize)(this.pbAutomata)).EndInit();
            this.gbDfa.ResumeLayout(false);
            this.gbDfa.PerformLayout();
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
    }
}

