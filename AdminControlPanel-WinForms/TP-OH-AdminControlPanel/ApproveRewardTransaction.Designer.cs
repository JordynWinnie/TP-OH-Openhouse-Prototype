namespace TP_OH_AdminControlPanel
{
    partial class ApproveRewardTransaction
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
            this.externalAPICallback = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.approvalCB = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "External Party API callback link:";
            // 
            // eventHeader
            // 
            this.eventHeader.AutoSize = true;
            this.eventHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventHeader.Location = new System.Drawing.Point(12, 9);
            this.eventHeader.Name = "eventHeader";
            this.eventHeader.Size = new System.Drawing.Size(300, 25);
            this.eventHeader.TabIndex = 3;
            this.eventHeader.Text = "Approve Transaction (DEMO):";
            // 
            // externalAPICallback
            // 
            this.externalAPICallback.AutoSize = true;
            this.externalAPICallback.Location = new System.Drawing.Point(177, 91);
            this.externalAPICallback.Name = "externalAPICallback";
            this.externalAPICallback.Size = new System.Drawing.Size(376, 13);
            this.externalAPICallback.TabIndex = 4;
            this.externalAPICallback.TabStop = true;
            this.externalAPICallback.Text = "http://localhost:54888/AwardRedemptions/ConfirmRewardRedemption?guid=";
            this.externalAPICallback.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.externalAPICallback_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Transaction To Approve:";
            // 
            // approvalCB
            // 
            this.approvalCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.approvalCB.FormattingEnabled = true;
            this.approvalCB.Location = new System.Drawing.Point(149, 50);
            this.approvalCB.Name = "approvalCB";
            this.approvalCB.Size = new System.Drawing.Size(619, 21);
            this.approvalCB.TabIndex = 6;
            this.approvalCB.SelectedIndexChanged += new System.EventHandler(this.approvalCB_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(751, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Force Approval";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ApproveRewardTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 179);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.approvalCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.externalAPICallback);
            this.Controls.Add(this.eventHeader);
            this.Controls.Add(this.label1);
            this.Name = "ApproveRewardTransaction";
            this.Text = "ApproveRewardTransaction";
            this.Load += new System.EventHandler(this.ApproveRewardTransaction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label eventHeader;
        private System.Windows.Forms.LinkLabel externalAPICallback;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox approvalCB;
        private System.Windows.Forms.Button button1;
    }
}