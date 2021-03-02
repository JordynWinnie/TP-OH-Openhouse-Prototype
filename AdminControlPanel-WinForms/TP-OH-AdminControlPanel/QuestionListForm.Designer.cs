namespace TP_OH_AdminControlPanel
{
    partial class QuestionListForm
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
            this.questionListDGV = new System.Windows.Forms.DataGridView();
            this.questionlbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.questionListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // questionListDGV
            // 
            this.questionListDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.questionListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionListDGV.Location = new System.Drawing.Point(13, 49);
            this.questionListDGV.Name = "questionListDGV";
            this.questionListDGV.Size = new System.Drawing.Size(1182, 654);
            this.questionListDGV.TabIndex = 0;
            // 
            // questionlbl
            // 
            this.questionlbl.AutoSize = true;
            this.questionlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionlbl.Location = new System.Drawing.Point(12, 9);
            this.questionlbl.Name = "questionlbl";
            this.questionlbl.Size = new System.Drawing.Size(144, 25);
            this.questionlbl.TabIndex = 2;
            this.questionlbl.Text = "Question List:";
            // 
            // QuestionListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 715);
            this.Controls.Add(this.questionlbl);
            this.Controls.Add(this.questionListDGV);
            this.Name = "QuestionListForm";
            this.Text = "QuestionListForm";
            this.Load += new System.EventHandler(this.QuestionListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.questionListDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView questionListDGV;
        private System.Windows.Forms.Label questionlbl;
    }
}