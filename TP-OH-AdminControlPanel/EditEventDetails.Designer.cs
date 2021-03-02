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
            this.eventHeader = new System.Windows.Forms.Label();
            this.evtNameTb = new System.Windows.Forms.TextBox();
            this.evtDescTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.evtCredits = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.evtQRCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.currentTimingLbl = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.courseCB = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.addTimingBtn = new System.Windows.Forms.Button();
            this.removeTimingBtn = new System.Windows.Forms.Button();
            this.editTimingBtn = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.viewFullTimingBtn = new System.Windows.Forms.Button();
            this.helperText = new System.Windows.Forms.Label();
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
            // eventHeader
            // 
            this.eventHeader.AutoSize = true;
            this.eventHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventHeader.Location = new System.Drawing.Point(12, 9);
            this.eventHeader.Name = "eventHeader";
            this.eventHeader.Size = new System.Drawing.Size(188, 25);
            this.eventHeader.TabIndex = 2;
            this.eventHeader.Text = "Edit Event Details:";
            // 
            // evtNameTb
            // 
            this.evtNameTb.Location = new System.Drawing.Point(119, 37);
            this.evtNameTb.Name = "evtNameTb";
            this.evtNameTb.Size = new System.Drawing.Size(511, 20);
            this.evtNameTb.TabIndex = 3;
            // 
            // evtDescTb
            // 
            this.evtDescTb.Location = new System.Drawing.Point(119, 99);
            this.evtDescTb.Multiline = true;
            this.evtDescTb.Name = "evtDescTb";
            this.evtDescTb.Size = new System.Drawing.Size(511, 114);
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
            this.evtCredits.Size = new System.Drawing.Size(511, 20);
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
            this.evtQRCode.Size = new System.Drawing.Size(511, 20);
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
            // currentTimingLbl
            // 
            this.currentTimingLbl.AutoSize = true;
            this.currentTimingLbl.Location = new System.Drawing.Point(14, 335);
            this.currentTimingLbl.Name = "currentTimingLbl";
            this.currentTimingLbl.Size = new System.Drawing.Size(83, 13);
            this.currentTimingLbl.TabIndex = 12;
            this.currentTimingLbl.Text = "Current Timings:";
            // 
            // timeLabel
            // 
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(14, 357);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(186, 255);
            this.timeLabel.TabIndex = 13;
            this.timeLabel.Text = "<CurrentTimings>";
            // 
            // courseCB
            // 
            this.courseCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.courseCB.FormattingEnabled = true;
            this.courseCB.Location = new System.Drawing.Point(119, 63);
            this.courseCB.Name = "courseCB";
            this.courseCB.Size = new System.Drawing.Size(511, 21);
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
            // addTimingBtn
            // 
            this.addTimingBtn.Location = new System.Drawing.Point(206, 357);
            this.addTimingBtn.Name = "addTimingBtn";
            this.addTimingBtn.Size = new System.Drawing.Size(143, 42);
            this.addTimingBtn.TabIndex = 16;
            this.addTimingBtn.Text = "Add Timings";
            this.addTimingBtn.UseVisualStyleBackColor = true;
            this.addTimingBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // removeTimingBtn
            // 
            this.removeTimingBtn.Location = new System.Drawing.Point(206, 405);
            this.removeTimingBtn.Name = "removeTimingBtn";
            this.removeTimingBtn.Size = new System.Drawing.Size(143, 42);
            this.removeTimingBtn.TabIndex = 17;
            this.removeTimingBtn.Text = "Remove Timings";
            this.removeTimingBtn.UseVisualStyleBackColor = true;
            this.removeTimingBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // editTimingBtn
            // 
            this.editTimingBtn.Location = new System.Drawing.Point(206, 453);
            this.editTimingBtn.Name = "editTimingBtn";
            this.editTimingBtn.Size = new System.Drawing.Size(143, 42);
            this.editTimingBtn.TabIndex = 18;
            this.editTimingBtn.Text = "Edit Timings";
            this.editTimingBtn.UseVisualStyleBackColor = true;
            this.editTimingBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(416, 357);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(214, 81);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Save Changes";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // viewFullTimingBtn
            // 
            this.viewFullTimingBtn.Location = new System.Drawing.Point(206, 501);
            this.viewFullTimingBtn.Name = "viewFullTimingBtn";
            this.viewFullTimingBtn.Size = new System.Drawing.Size(143, 42);
            this.viewFullTimingBtn.TabIndex = 20;
            this.viewFullTimingBtn.Text = "View Full Timings";
            this.viewFullTimingBtn.UseVisualStyleBackColor = true;
            this.viewFullTimingBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // helperText
            // 
            this.helperText.AutoSize = true;
            this.helperText.Location = new System.Drawing.Point(384, 335);
            this.helperText.Name = "helperText";
            this.helperText.Size = new System.Drawing.Size(246, 13);
            this.helperText.TabIndex = 21;
            this.helperText.Text = "Use Edit Function to add timings to this new event.";
            // 
            // EditEventDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 621);
            this.Controls.Add(this.helperText);
            this.Controls.Add(this.viewFullTimingBtn);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.editTimingBtn);
            this.Controls.Add(this.removeTimingBtn);
            this.Controls.Add(this.addTimingBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.courseCB);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.currentTimingLbl);
            this.Controls.Add(this.evtQRCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.evtCredits);
            this.Controls.Add(this.evtDescTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.evtNameTb);
            this.Controls.Add(this.eventHeader);
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
        private System.Windows.Forms.Label eventHeader;
        private System.Windows.Forms.TextBox evtNameTb;
        private System.Windows.Forms.TextBox evtDescTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown evtCredits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox evtQRCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label currentTimingLbl;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.ComboBox courseCB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button addTimingBtn;
        private System.Windows.Forms.Button removeTimingBtn;
        private System.Windows.Forms.Button editTimingBtn;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button viewFullTimingBtn;
        private System.Windows.Forms.Label helperText;
    }
}