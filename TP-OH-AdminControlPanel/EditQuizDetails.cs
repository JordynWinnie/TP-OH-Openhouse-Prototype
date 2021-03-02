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
    public partial class EditQuizDetails : Form
    {
        public enum ApplicationState { EditQuiz, AddQuiz };

        private int currentQuizID;
        private ApplicationState applicationState;

        private TPOHEntities context = new TPOHEntities();

        public EditQuizDetails(int quizID, ApplicationState appState)
        {
            currentQuizID = quizID;
            applicationState = appState;
            InitializeComponent();
        }

        private void EditQuizDetails_Load(object sender, EventArgs e)
        {
            switch (applicationState)
            {
                case ApplicationState.EditQuiz:

                    var quiz = context.QuizTables.Where(x => x.quizID == currentQuizID).First();
                    quizNameTb.Text = quiz.quizName;
                    quizDescriptionTb.Text = quiz.quizDescription;
                    quizCredits.Value = (int)quiz.quizCredits;
                    break;

                case ApplicationState.AddQuiz:
                    quizGroupBox.Visible = false;
                    break;

                default:
                    break;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            switch (applicationState)
            {
                case ApplicationState.EditQuiz:
                    var quiz = context.QuizTables.Where(x => x.quizID == currentQuizID).First();
                    quiz.quizName = quizNameTb.Text;
                    quiz.quizDescription = quizDescriptionTb.Text;
                    quiz.quizCredits = (int)quizCredits.Value;
                    break;

                case ApplicationState.AddQuiz:
                    var insertQuiz = new QuizTable
                    {
                        quizName = quizNameTb.Text,
                        quizDescription = quizDescriptionTb.Text,
                        quizCredits = (int)quizCredits.Value
                    };

                    context.QuizTables.Add(insertQuiz);
                    break;

                default:
                    break;
            }

            context.SaveChanges();
            MessageBox.Show("Changes saved");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            (new QuestionManagement(currentQuizID, QuestionManagement.ApplicationState.AddQuestion)).ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            (new QuestionManagement(currentQuizID, QuestionManagement.ApplicationState.RemoveQuestion)).ShowDialog();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            (new QuestionManagement(currentQuizID, QuestionManagement.ApplicationState.ModifyQuestion)).ShowDialog();
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            (new QuestionListForm(currentQuizID)).ShowDialog();
            Show();
        }
    }
}