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
    public partial class QuestionListForm : Form
    {
        private int currentQuizID;

        public QuestionListForm(int quizID)
        {
            currentQuizID = quizID;
            InitializeComponent();
        }

        private TPOHEntities context = new TPOHEntities();

        private void QuestionListForm_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Question","Question Hint", "Question Trivia", "Answers", "Correct Answer"
            };

            foreach (var column in columns)
            {
                questionListDGV.Columns.Add(column, column);
            }

            var quiz = (from x in context.QuizTables
                        where x.quizID == currentQuizID
                        select x).First();

            questionlbl.Text = $"Question list for '{quiz.quizName}':";
            foreach (var question in quiz.QuestionsTables)
            {
                var row = new List<string>()
                {
                    question.questionString, question.questionHint,question.questionTrivia,
                    string.Join(", " ,question.AnswersTables.Select(x=>x.answerString)),
                    question.AnswersTables.Where(x=>x.isCorrectAnswer == true).Select(x=>x.answerString).First()
                };

                questionListDGV.Rows.Add(row.ToArray());
            }
        }
    }
}