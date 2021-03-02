namespace TP_OH_AdminControlPanel
{
    partial class EditRewardDetails
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
            this.redemptionLimit = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.rewardNameTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rewardDescriptionTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.requiredCredits = new System.Windows.Forms.NumericUpDown();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rewardHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.redemptionLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requiredCredits)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Redemption Limit:";
            // 
            // redemptionLimit
            // 
            this.redemptionLimit.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.redemptionLimit.Location = new System.Drawing.Point(116, 229);
            this.redemptionLimit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.redemptionLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.redemptionLimit.Name = "redemptionLimit";
            this.redemptionLimit.Size = new System.Drawing.Size(348, 20);
            this.redemptionLimit.TabIndex = 19;
            this.redemptionLimit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Reward Description";
            // 
            // rewardNameTb
            // 
            this.rewardNameTb.Location = new System.Drawing.Point(116, 41);
            this.rewardNameTb.Name = "rewardNameTb";
            this.rewardNameTb.Size = new System.Drawing.Size(511, 20);
            this.rewardNameTb.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Reward Name:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(470, 231);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(157, 17);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "Allow Unlimited Redemption";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(613, 46);
            this.button1.TabIndex = 24;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rewardDescriptionTb
            // 
            this.rewardDescriptionTb.Location = new System.Drawing.Point(116, 78);
            this.rewardDescriptionTb.Multiline = true;
            this.rewardDescriptionTb.Name = "rewardDescriptionTb";
            this.rewardDescriptionTb.Size = new System.Drawing.Size(511, 114);
            this.rewardDescriptionTb.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Credits Required";
            // 
            // requiredCredits
            // 
            this.requiredCredits.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.requiredCredits.Location = new System.Drawing.Point(116, 198);
            this.requiredCredits.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.requiredCredits.Name = "requiredCredits";
            this.requiredCredits.Size = new System.Drawing.Size(348, 20);
            this.requiredCredits.TabIndex = 26;
            this.requiredCredits.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(470, 201);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(150, 17);
            this.checkBox2.TabIndex = 27;
            this.checkBox2.Text = "Make Welcome Gift (Free)";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(546, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "^Redemptions are always limited to 1 per person, Redemption limit refers to how m" +
    "any people can claim this reward";
            // 
            // rewardHeader
            // 
            this.rewardHeader.AutoSize = true;
            this.rewardHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rewardHeader.Location = new System.Drawing.Point(12, 9);
            this.rewardHeader.Name = "rewardHeader";
            this.rewardHeader.Size = new System.Drawing.Size(91, 25);
            this.rewardHeader.TabIndex = 29;
            this.rewardHeader.Text = "Reward:";
            // 
            // EditRewardDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 343);
            this.Controls.Add(this.rewardHeader);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.requiredCredits);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.redemptionLimit);
            this.Controls.Add(this.rewardDescriptionTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rewardNameTb);
            this.Controls.Add(this.label1);
            this.Name = "EditRewardDetails";
            this.Text = "EditRewardDetails";
            this.Load += new System.EventHandler(this.EditRewardDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.redemptionLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requiredCredits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown redemptionLimit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox rewardNameTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox rewardDescriptionTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown requiredCredits;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label rewardHeader;
    }
}