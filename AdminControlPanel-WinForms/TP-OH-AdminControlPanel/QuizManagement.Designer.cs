namespace TP_OH_AdminControlPanel
{
    partial class QuizManagement
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
            this.currentQuizesDGV = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.currentQuizesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current Quizes:";
            // 
            // currentQuizesDGV
            // 
            this.currentQuizesDGV.AllowUserToAddRows = false;
            this.currentQuizesDGV.AllowUserToDeleteRows = false;
            this.currentQuizesDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.currentQuizesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currentQuizesDGV.Location = new System.Drawing.Point(12, 37);
            this.currentQuizesDGV.Name = "currentQuizesDGV";
            this.currentQuizesDGV.ReadOnly = true;
            this.currentQuizesDGV.Size = new System.Drawing.Size(775, 146);
            this.currentQuizesDGV.TabIndex = 2;
            this.currentQuizesDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.currentQuizesDGV_CellDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Add New Quiz:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(775, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add New Quiz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Double Click to Edit";
            // 
            // QuizManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentQuizesDGV);
            this.Name = "QuizManagement";
            this.Text = "QuizManagement";
            this.Load += new System.EventHandler(this.QuizManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.currentQuizesDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView currentQuizesDGV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}