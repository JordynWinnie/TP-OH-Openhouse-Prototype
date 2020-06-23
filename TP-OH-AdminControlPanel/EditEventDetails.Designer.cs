namespace TP_OH_AdminControlPanel
{
    partial class EditEventDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.evtNameTb = new System.Windows.Forms.TextBox();
            this.evtDescTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.evtCredits = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.evtQRCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.courseCB = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.evtCredits)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Event Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Edit Event Details:";
            // 
            // evtNameTb
            // 
            this.evtNameTb.Location = new System.Drawing.Point(119, 37);
            this.evtNameTb.Name = "evtNameTb";
            this.evtNameTb.Size = new System.Drawing.Size(607, 20);
            this.evtNameTb.TabIndex = 3;
            // 
            // evtDescTb
            // 
            this.evtDescTb.Location = new System.Drawing.Point(119, 99);
            this.evtDescTb.Multiline = true;
            this.evtDescTb.Name = "evtDescTb";
            this.evtDescTb.Size = new System.Drawing.Size(607, 114);
            this.evtDescTb.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Event Description:";
            // 
            // evtCredits
            // 
            this.evtCredits.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.evtCredits.Location = new System.Drawing.Point(119, 238);
            this.evtCredits.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.evtCredits.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.evtCredits.Name = "evtCredits";
            this.evtCredits.Size = new System.Drawing.Size(607, 20);
            this.evtCredits.TabIndex = 7;
            this.evtCredits.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Event Credits:";
            // 
            // evtQRCode
            // 
            this.evtQRCode.Location = new System.Drawing.Point(119, 289);
            this.evtQRCode.Name = "evtQRCode";
            this.evtQRCode.Size = new System.Drawing.Size(607, 20);
            this.evtQRCode.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "QR Code String:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Current Timings:";
            // 
            // timeLabel
            // 
            this.timeLabel.Location = new System.Drawing.Point(14, 380);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(563, 210);
            this.timeLabel.TabIndex = 13;
            this.timeLabel.Text = "<CurrentTimings>";
            // 
            // courseCB
            // 
            this.courseCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.courseCB.FormattingEnabled = true;
            this.courseCB.Location = new System.Drawing.Point(119, 63);
            this.courseCB.Name = "courseCB";
            this.courseCB.Size = new System.Drawing.Size(607, 21);
            this.courseCB.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Course:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(583, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 42);
            this.button1.TabIndex = 16;
            this.button1.Text = "Add Timings";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(583, 428);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 42);
            this.button2.TabIndex = 17;
            this.button2.Text = "Remove Timings";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(583, 476);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 42);
            this.button3.TabIndex = 18;
            this.button3.Text = "Edit Timings";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // EditEventDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 621);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.courseCB);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.evtQRCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.evtCredits);
            this.Controls.Add(this.evtDescTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.evtNameTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditEventDetails";
            this.Text = "EditEventDetails";
            this.Load += new System.EventHandler(this.EditEventDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.evtCredits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox evtNameTb;
        private System.Windows.Forms.TextBox evtDescTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown evtCredits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox evtQRCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.ComboBox courseCB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}