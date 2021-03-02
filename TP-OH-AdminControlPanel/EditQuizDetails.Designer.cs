namespace TP_OH_AdminControlPanel
{
    partial class EditQuizDetails
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
            this.label4 = new System.Windows.Forms.Label();
            this.quizCredits = new System.Windows.Forms.NumericUpDown();
            this.quizDescriptionTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.quizNameTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.quizGroupBox = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.quizCredits)).BeginInit();
            this.quizGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Quiz Credits:";
            // 
            // quizCredits
            // 
            this.quizCredits.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.quizCredits.Location = new System.Drawing.Point(117, 158);
            this.quizCredits.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.quizCredits.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.quizCredits.Name = "quizCredits";
            this.quizCredits.Size = new System.Drawing.Size(511, 20);
            this.quizCredits.TabIndex = 13;
            this.quizCredits.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // quizDescriptionTb
            // 
            this.quizDescriptionTb.Location = new System.Drawing.Point(117, 38);
            this.quizDescriptionTb.Multiline = true;
            this.quizDescriptionTb.Name = "quizDescriptionTb";
            this.quizDescriptionTb.Size = new System.Drawing.Size(511, 114);
            this.quizDescriptionTb.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Quiz Description:";
            // 
            // quizNameTb
            // 
            this.quizNameTb.Location = new System.Drawing.Point(117, 12);
            this.quizNameTb.Name = "quizNameTb";
            this.quizNameTb.Size = new System.Drawing.Size(511, 20);
            this.quizNameTb.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Quiz Name:";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 278);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(613, 42);
            this.saveBtn.TabIndex = 15;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // quizGroupBox
            // 
            this.quizGroupBox.Controls.Add(this.button5);
            this.quizGroupBox.Controls.Add(this.button4);
            this.quizGroupBox.Controls.Add(this.button3);
            this.quizGroupBox.Controls.Add(this.button2);
            this.quizGroupBox.Location = new System.Drawing.Point(15, 184);
            this.quizGroupBox.Name = "quizGroupBox";
            this.quizGroupBox.Size = new System.Drawing.Size(613, 78);
            this.quizGroupBox.TabIndex = 16;
            this.quizGroupBox.TabStop = false;
            this.quizGroupBox.Text = "Question Management";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(412, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(125, 40);
            this.button5.TabIndex = 3;
            this.button5.Text = "View All Questions";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(281, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 40);
            this.button4.TabIndex = 2;
            this.button4.Text = "Change Question";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(150, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 40);
            this.button3.TabIndex = 1;
            this.button3.Text = "Remove Question";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 40);
            this.button2.TabIndex = 0;
            this.button2.Text = "Add Question";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EditQuizDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 347);
            this.Controls.Add(this.quizGroupBox);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.quizCredits);
            this.Controls.Add(this.quizDescriptionTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.quizNameTb);
            this.Controls.Add(this.label1);
            this.Name = "EditQuizDetails";
            this.Text = "EditQuizDetails";
            this.Load += new System.EventHandler(this.EditQuizDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quizCredits)).EndInit();
            this.quizGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown quizCredits;
        private System.Windows.Forms.TextBox quizDescriptionTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox quizNameTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.GroupBox quizGroupBox;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}