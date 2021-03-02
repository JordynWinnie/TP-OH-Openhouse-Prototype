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
    public partial class QuestionManagement : Form
    {
        public enum ApplicationState { AddQuestion, ModifyQuestion, RemoveQuestion, ListQuestions }

        private int currentQuizID;
        private ApplicationState applicationState;

        private TPOHEntities context = new TPOHEntities();
        private List<QuestionsTable> questionList;

        public QuestionManagement(int quizID, ApplicationState appState)
        {
            currentQuizID = quizID;
            applicationState = appState;
            InitializeComponent();
        }

        private void QuestionManagement_Load(object sender, EventArgs e)
        {
            questionList = context.QuestionsTables.Where(x => x.quizIDFK == currentQuizID).ToList();

            foreach (var question in questionList)
            {
                questionCb.Items.Add(question.questionString);
            }

            switch (applicationState)
            {
                case ApplicationState.AddQuestion:
                    questionCb.Visible = false;
                    questionLbl.Visible = false;

                    break;

                case ApplicationState.ModifyQuestion:

                    break;

                case ApplicationState.RemoveQuestion:
                    questionGroup.Visible = false;
                    break;

                case ApplicationState.ListQuestions:
                    break;

                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (applicationState)
            {
                case ApplicationState.AddQuestion:
                    var newQuestionID = context.QuestionsTables.OrderByDescending(x => x.questionID).Select(x => x.questionID).First() + 1;
                    var insertQuestion = new QuestionsTable
                    {
                        questionID = newQuestionID,
                        quizIDFK = currentQuizID,
                        questionString = questionStringTb.Text,
                        questionHint = questionHintTb.Text,
                        questionTrivia = questionTriviaTb.Text
                    };
                    context.QuestionsTables.Add(insertQuestion);

                    if (!answerOption1Tb.Text.Equals(string.Empty))
                    {
                        var insertAnswer = new AnswersTable
                        {
                            questionID = newQuestionID,
                            answerString = answerOption1Tb.Text,
                            isCorrectAnswer = optionRadio1.Checked
                        };
                        context.AnswersTables.Add(insertAnswer);
                    }

                    if (!answerOption2Tb.Text.Equals(string.Empty))
                    {
                        var insertAnswer = new AnswersTable
                        {
                            questionID = newQuestionID,
                            answerString = answerOption2Tb.Text,
                            isCorrectAnswer = optionRadio2.Checked
                        };
                        context.AnswersTables.Add(insertAnswer);
                    }

                    if (!answerOption3Tb.Text.Equals(string.Empty))
                    {
                        var insertAnswer = new AnswersTable
                        {
                            questionID = newQuestionID,
                            answerString = answerOption3Tb.Text,
                            isCorrectAnswer = optionRadio3.Checked
                        };
                        context.AnswersTables.Add(insertAnswer);
                    }

                    if (!answerOption4Tb.Text.Equals(string.Empty))
                    {
                        var insertAnswer = new AnswersTable
                        {
                            questionID = newQuestionID,
                            answerString = answerOption4Tb.Text,
                            isCorrectAnswer = optionRadio4.Checked
                        };
                        context.AnswersTables.Add(insertAnswer);
                    }

                    break;

                case ApplicationState.ModifyQuestion:
                    var questionID = questionList[questionCb.SelectedIndex].questionID;
                    var questionToModify = context.QuestionsTables.Where(x => x.questionID == questionID).First();

                    questionToModify.questionString = questionStringTb.Text;
                    questionToModify.questionHint = questionHintTb.Text;
                    questionToModify.questionTrivia = questionTriviaTb.Text;

                    var answersToDelete = context.AnswersTables.Where(x => x.questionID == questionID);

                    foreach (var answer in answersToDelete)
                    {
                        context.AnswersTables.Remove(answer);
                    }

                    if (!answerOption1Tb.Text.Equals(string.Empty))
                    {
                        var insertAnswer = new AnswersTable
                        {
                            questionID = questionID,
                            answerString = answerOption1Tb.Text,
                            isCorrectAnswer = optionRadio1.Checked
                        };
                        context.AnswersTables.Add(insertAnswer);
                    }

                    if (!answerOption2Tb.Text.Equals(string.Empty))
                    {
                        var insertAnswer = new AnswersTable
                        {
                            questionID = questionID,
                            answerString = answerOption2Tb.Text,
                            isCorrectAnswer = optionRadio2.Checked
                        };
                        context.AnswersTables.Add(insertAnswer);
                    }

                    if (!answerOption3Tb.Text.Equals(string.Empty))
                    {
                        var insertAnswer = new AnswersTable
                        {
                            questionID = questionID,
                            answerString = answerOption3Tb.Text,
                            isCorrectAnswer = optionRadio3.Checked
                        };
                        context.AnswersTables.Add(insertAnswer);
                    }

                    if (!answerOption4Tb.Text.Equals(string.Empty))
                    {
                        var insertAnswer = new AnswersTable
                        {
                            questionID = questionID,
                            answerString = answerOption4Tb.Text,
                            isCorrectAnswer = optionRadio4.Checked
                        };
                        context.AnswersTables.Add(insertAnswer);
                    }
                    break;

                case ApplicationState.RemoveQuestion:
                    var questionToRemoveID = questionList[questionCb.SelectedIndex].questionID;
                    var questionToRemove = context.QuestionsTables.Where(x => x.questionID == questionToRemoveID).First();

                    var answersToRemove = context.AnswersTables.Where(x => x.questionID == questionToRemoveID);

                    foreach (var answer in answersToRemove)
                    {
                        context.AnswersTables.Remove(answer);
                    }
                    context.QuestionsTables.Remove(questionToRemove);

                    break;

                case ApplicationState.ListQuestions:
                    break;

                default:
                    break;
            }

            context.SaveChanges();
            MessageBox.Show("Changes saved");
        }

        private void questionCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAllOptions();

            switch (applicationState)
            {
                case ApplicationState.ModifyQuestion:
                    var question = questionList[questionCb.SelectedIndex];
                    questionStringTb.Text = question.questionString;
                    questionHintTb.Text = question.questionHint;
                    questionTriviaTb.Text = question.questionTrivia;

                    var answersList = question.AnswersTables.ToList();
                    var correctAnswer = answersList.Where(x => x.isCorrectAnswer == true).First();

                    switch (answersList.IndexOf(correctAnswer) + 1)
                    {
                        case 1:
                            optionRadio1.Checked = true;
                            break;

                        case 2:
                            optionRadio2.Checked = true;
                            break;

                        case 3:
                            optionRadio3.Checked = true;
                            break;

                        case 4:
                            optionRadio4.Checked = true;
                            break;
                    }

                    switch (question.AnswersTables.Count)
                    {
                        case 2:
                            answerOption1Tb.Text = answersList[0].answerString;
                            answerOption2Tb.Text = answersList[1].answerString;
                            break;

                        case 3:
                            answerOption1Tb.Text = answersList[0].answerString;
                            answerOption2Tb.Text = answersList[1].answerString;
                            answerOption3Tb.Text = answersList[2].answerString;
                            break;

                        case 4:
                            answerOption1Tb.Text = answersList[0].answerString;
                            answerOption2Tb.Text = answersList[1].answerString;
                            answerOption3Tb.Text = answersList[2].answerString;
                            answerOption4Tb.Text = answersList[3].answerString;
                            break;

                        default:
                            break;
                    }

                    break;

                case ApplicationState.RemoveQuestion:
                    break;

                default:
                    break;
            }
        }

        private void ClearAllOptions()
        {
            answerOption1Tb.Text = string.Empty;
            answerOption2Tb.Text = string.Empty;
            answerOption3Tb.Text = string.Empty;
            answerOption4Tb.Text = string.Empty;

            optionRadio1.Checked = false;
            optionRadio2.Checked = false;
            optionRadio3.Checked = false;
            optionRadio4.Checked = false;

            optionRadio1.Enabled = true;
            optionRadio2.Enabled = true;
            optionRadio3.Enabled = true;
            optionRadio4.Enabled = true;
        }
    }
}