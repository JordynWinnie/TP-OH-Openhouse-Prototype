using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_OH_AdminControlPanel
{
    public partial class QuizManagement : Form
    {
        public QuizManagement()
        {
            InitializeComponent();
        }

        private TPOHEntities context = new TPOHEntities();

        private void QuizManagement_Load(object sender, EventArgs e)
        {
            var columns = new List<string>()
            {
                "Quiz Name", "Quiz Description", "Credits", "QuestionCount","quizID"
            };

            foreach (var column in columns)
            {
                currentQuizesDGV.Columns.Add(column, column);
            }
            RefreshData();
        }

        private void RefreshData()
        {
            currentQuizesDGV.Rows.Clear();
            var quizList = context.QuizTables;

            foreach (var quiz in quizList)
            {
                var row = new List<string>()
                {
                    quiz.quizName,
                    quiz.quizDescription,
                    quiz.quizCredits.ToString(),
                    quiz.QuestionsTables.Count.ToString(),
                    quiz.quizID.ToString()
                };
                currentQuizesDGV.Rows.Add(row.ToArray());
            }
        }

        private void currentQuizesDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var quizID = int.Parse(currentQuizesDGV.Rows[e.RowIndex].Cells[4].Value.ToString());
            Hide();
            (new EditQuizDetails(quizID, EditQuizDetails.ApplicationState.EditQuiz)).ShowDialog();
            RefreshData();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            (new EditQuizDetails(-1, EditQuizDetails.ApplicationState.AddQuiz)).ShowDialog();
            RefreshData();
            Show();
        }
    }
}