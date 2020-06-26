namespace TP_OH_AdminControlPanel
{
    partial class MainEntryRemovals
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
            this.eventHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.removalCB = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // eventHeader
            // 
            this.eventHeader.AutoSize = true;
            this.eventHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventHeader.Location = new System.Drawing.Point(12, 9);
            this.eventHeader.Name = "eventHeader";
            this.eventHeader.Size = new System.Drawing.Size(114, 25);
            this.eventHeader.TabIndex = 3;
            this.eventHeader.Text = "Removing:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Item To Remove:";
            // 
            // removalCB
            // 
            this.removalCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.removalCB.FormattingEnabled = true;
            this.removalCB.Location = new System.Drawing.Point(113, 47);
            this.removalCB.Name = "removalCB";
            this.removalCB.Size = new System.Drawing.Size(675, 21);
            this.removalCB.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(768, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(545, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "^Note: Removal of Events/Rewards/Quizes during the event is HIGHLY discouraged. C" +
    "onsider Editing if Possible.\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(497, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "^^Note: Removing Rewards will also mean it is NO LONGER CLAIMABLE. PROCEED WITH C" +
    "AUTION\r\n";
            // 
            // MainEntryRemovals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 208);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.removalCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eventHeader);
            this.Name = "MainEntryRemovals";
            this.Text = "MainEntryRemovals";
            this.Load += new System.EventHandler(this.MainEntryRemovals_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label eventHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox removalCB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}