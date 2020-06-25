namespace TP_OH_AdminControlPanel
{
    partial class TimingControllerForm
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
            this.headerLbl = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.startTimeLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.endTimeLbl = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.removeTimingCb = new System.Windows.Forms.ComboBox();
            this.removeTimingLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // headerLbl
            // 
            this.headerLbl.AutoSize = true;
            this.headerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLbl.Location = new System.Drawing.Point(12, 9);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(161, 25);
            this.headerLbl.TabIndex = 2;
            this.headerLbl.Text = "Current Events:";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(131, 80);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(216, 20);
            this.startDatePicker.TabIndex = 3;
            // 
            // startTimeLbl
            // 
            this.startTimeLbl.AutoSize = true;
            this.startTimeLbl.Location = new System.Drawing.Point(14, 86);
            this.startTimeLbl.Name = "startTimeLbl";
            this.startTimeLbl.Size = new System.Drawing.Size(103, 13);
            this.startTimeLbl.TabIndex = 4;
            this.startTimeLbl.Text = "Start Time Of Event:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(534, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Commit Changes (Instantly Updates Database)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // endTimeLbl
            // 
            this.endTimeLbl.AutoSize = true;
            this.endTimeLbl.Location = new System.Drawing.Point(14, 116);
            this.endTimeLbl.Name = "endTimeLbl";
            this.endTimeLbl.Size = new System.Drawing.Size(100, 13);
            this.endTimeLbl.TabIndex = 6;
            this.endTimeLbl.Text = "End Time Of Event:";
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(131, 116);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(216, 20);
            this.endDatePicker.TabIndex = 7;
            // 
            // endTimePicker
            // 
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endTimePicker.Location = new System.Drawing.Point(353, 116);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.ShowUpDown = true;
            this.endTimePicker.Size = new System.Drawing.Size(156, 20);
            this.endTimePicker.TabIndex = 9;
            // 
            // startTimePicker
            // 
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimePicker.Location = new System.Drawing.Point(353, 80);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(156, 20);
            this.startTimePicker.TabIndex = 8;
            // 
            // removeTimingCb
            // 
            this.removeTimingCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.removeTimingCb.FormattingEnabled = true;
            this.removeTimingCb.Location = new System.Drawing.Point(131, 53);
            this.removeTimingCb.Name = "removeTimingCb";
            this.removeTimingCb.Size = new System.Drawing.Size(378, 21);
            this.removeTimingCb.TabIndex = 10;
            // 
            // removeTimingLbl
            // 
            this.removeTimingLbl.AutoSize = true;
            this.removeTimingLbl.Location = new System.Drawing.Point(14, 61);
            this.removeTimingLbl.Name = "removeTimingLbl";
            this.removeTimingLbl.Size = new System.Drawing.Size(84, 13);
            this.removeTimingLbl.TabIndex = 11;
            this.removeTimingLbl.Text = "Remove Timing:";
            // 
            // TimingControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 253);
            this.Controls.Add(this.removeTimingLbl);
            this.Controls.Add(this.removeTimingCb);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.endTimeLbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.startTimeLbl);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.headerLbl);
            this.Name = "TimingControllerForm";
            this.Text = "TimingControllerForm";
            this.Load += new System.EventHandler(this.TimingControllerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLbl;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label startTimeLbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label endTimeLbl;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.ComboBox removeTimingCb;
        private System.Windows.Forms.Label removeTimingLbl;
    }
}