namespace TP_OH_AdminControlPanel
{
    partial class QRCodeGeneration
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
            this.label2 = new System.Windows.Forms.Label();
            this.eventCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.qrCodePhoto = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodePhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Generate QR Code for Event:";
            // 
            // eventCB
            // 
            this.eventCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventCB.FormattingEnabled = true;
            this.eventCB.Location = new System.Drawing.Point(133, 54);
            this.eventCB.Name = "eventCB";
            this.eventCB.Size = new System.Drawing.Size(655, 21);
            this.eventCB.TabIndex = 3;
            this.eventCB.SelectedIndexChanged += new System.EventHandler(this.eventCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Event To Generate:";
            // 
            // qrCodePhoto
            // 
            this.qrCodePhoto.Location = new System.Drawing.Point(108, 99);
            this.qrCodePhoto.Name = "qrCodePhoto";
            this.qrCodePhoto.Size = new System.Drawing.Size(600, 600);
            this.qrCodePhoto.TabIndex = 5;
            this.qrCodePhoto.TabStop = false;
            this.qrCodePhoto.Click += new System.EventHandler(this.qrCodePhoto_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 714);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(369, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Get The users to use \"Scan QR Code\" on their device to validate your event";
            // 
            // QRCodeGeneration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 756);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.qrCodePhoto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eventCB);
            this.Controls.Add(this.label2);
            this.Name = "QRCodeGeneration";
            this.Text = "QRCodeGeneration";
            this.Load += new System.EventHandler(this.QRCodeGeneration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qrCodePhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox eventCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox qrCodePhoto;
        private System.Windows.Forms.Label label3;
    }
}