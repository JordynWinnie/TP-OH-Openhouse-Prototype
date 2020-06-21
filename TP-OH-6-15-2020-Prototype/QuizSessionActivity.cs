using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using TP_OH_6_15_2020_Prototype.Models;

namespace TP_OH_6_15_2020_Prototype
{
    [Activity(Label = "QuizSessionActivity")]
    public class QuizSessionActivity : Activity
    {
        private TextView mainHeaderNameTextView;
        private TextView subHeaderTextView;
        private TextView questionNameTextView;
        private TextView questionHint;
        private LinearLayout answerGroup;
        private TextView answerButton1;
        private TextView answerButton2;
        private TextView answerButton3;
        private TextView answerButton4;
        private ListView leaderBoardListView;
        private TextView miscInfoTextView;
        private Button bottomButton;
        private QuizListModel quizInfo;
        private List<MiscellaneousRequests.LeaderBoard> leaderBoardInfo;
        private List<MiscellaneousRequests.Question> questionList;
        private List<MiscellaneousRequests.Answer> answerList;
        private MiscellaneousRequests.Answer correctAnswer;

        private enum QuizState
        { StartPage, QuizPage, AnswerPage, ResultPage };

        private QuizState quizState { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.quiz_session_layout);
            InitViews();
        }

        private void InitViews()
        {
            //To save time, the QuizSession handles the Question, Answer and Results page all in one Activity:

            mainHeaderNameTextView = FindViewById<TextView>(Resource.Id.quizNameSession);
            subHeaderTextView = FindViewById<TextView>(Resource.Id.quizDescription);

            questionNameTextView = FindViewById<TextView>(Resource.Id.quizQuestion);
            questionHint = FindViewById<TextView>(Resource.Id.questionHint);

            answerGroup = FindViewById<LinearLayout>(Resource.Id.answerLayout);
            answerButton1 = FindViewById<TextView>(Resource.Id.answerOneButton);
            answerButton2 = FindViewById<TextView>(Resource.Id.answerTwoButton);
            answerButton3 = FindViewById<TextView>(Resource.Id.answerThreeButton);
            answerButton4 = FindViewById<TextView>(Resource.Id.answerFourButton);

            leaderBoardListView = FindViewById<ListView>(Resource.Id.leaderBoardListView);
            miscInfoTextView = FindViewById<TextView>(Resource.Id.miscInfoTextView);

            bottomButton = FindViewById<Button>(Resource.Id.startQuizButton);

            answerButton1.Click += AnswerButton1_Click;
            answerButton2.Click += AnswerButton2_Click;
            answerButton3.Click += AnswerButton3_Click;
            answerButton4.Click += AnswerButton4_Click;
            bottomButton.Click += BottomButton_Click;

            quizState = QuizState.StartPage;
            SetQuestionInterfaceVisibility(false);
            LoadQuizInformation();
            LoadLeaderBoardInformation();
            DownloadQuestions();
        }

        private void BottomButton_Click(object sender, EventArgs e)
        {
            switch (quizState)
            {
                case QuizState.StartPage:
                    ChangeQuestion(2);
                    quizState = QuizState.QuizPage;

                    break;

                case QuizState.QuizPage:
                    break;

                case QuizState.AnswerPage:
                    break;

                case QuizState.ResultPage:
                    break;

                default:
                    break;
            }
        }

        private void ChangeQuestion(int questionID)
        {
            SetQuestionInterfaceVisibility(true);
            SetMenuInterfaceVisibility(false);

            var question = (from x in questionList
                            select x).ToList();

            var answers = (from x in answerList
                           where x.questionID == question[questionID].questionID
                           select x).ToList();

            questionNameTextView.Text = question[questionID].questionString;
            questionHint.Text = question[questionID].questionHint;

            correctAnswer = (from x in answerList
                             where x.isCorrectAnswer == true
                             select x).First();

            switch (answers.Count)
            {
                case 2:
                    answerButton3.Visibility = ViewStates.Invisible;
                    answerButton4.Visibility = ViewStates.Invisible;

                    answerButton1.Text = answers[0].answerString;
                    answerButton2.Text = answers[1].answerString;

                    break;

                case 3:
                    answerButton4.Visibility = ViewStates.Invisible;

                    answerButton1.Text = answers[0].answerString;
                    answerButton2.Text = answers[1].answerString;
                    answerButton3.Text = answers[2].answerString;

                    break;

                case 4:
                    answerButton1.Text = answers[0].answerString;
                    answerButton2.Text = answers[1].answerString;
                    answerButton3.Text = answers[2].answerString;
                    answerButton4.Text = answers[3].answerString;
                    break;

                default:
                    break;
            }
        }

        private void SetMenuInterfaceVisibility(bool visibility)
        {
            if (visibility)
            {
                mainHeaderNameTextView.Visibility = ViewStates.Visible;
                subHeaderTextView.Visibility = ViewStates.Visible;
                miscInfoTextView.Visibility = ViewStates.Visible;
                bottomButton.Visibility = ViewStates.Visible;
                leaderBoardListView.Visibility = ViewStates.Visible;
            }
            else
            {
                mainHeaderNameTextView.Visibility = ViewStates.Invisible;
                subHeaderTextView.Visibility = ViewStates.Invisible;
                miscInfoTextView.Visibility = ViewStates.Invisible;
                bottomButton.Visibility = ViewStates.Invisible;
                leaderBoardListView.Visibility = ViewStates.Invisible;
            }
        }

        private void AnswerButton4_Click(object sender, EventArgs e)
        {
        }

        private void AnswerButton3_Click(object sender, EventArgs e)
        {
        }

        private void AnswerButton2_Click(object sender, EventArgs e)
        {
        }

        private void AnswerButton1_Click(object sender, EventArgs e)
        {
        }

        private async void LoadLeaderBoardInformation()
        {
            var leaderBoardRequest = await WebRequest.HttpClient.GetAsync("http://10.0.2.2:54888/QuizTables/ReturnLeaderBoardForQuiz?quizID=1");
            leaderBoardInfo = JsonConvert.DeserializeObject<List<MiscellaneousRequests.LeaderBoard>>(await leaderBoardRequest.Content.ReadAsStringAsync());
            var leaderBoardString = new List<string>();

            if (leaderBoardInfo.Count == 0)
            {
                leaderBoardString.Add("No one's here yet! Be the first!");
            }
            else
            {
                for (int i = 0; i < leaderBoardInfo.Count; i++)
                {
                    leaderBoardString.Add($"{i + 1}. {leaderBoardInfo[i].username} ({leaderBoardInfo[i].score})");
                }
            }

            leaderBoardListView.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, leaderBoardString);
        }

        private async void LoadQuizInformation()
        {
            //TODO: implement ID shift:
            var quizInfoRequest = await WebRequest.HttpClient.GetAsync("http://10.0.2.2:54888/QuizTables/GetQuizList?quizID=1");
            quizInfo = JsonConvert.DeserializeObject<QuizListModel>(await quizInfoRequest.Content.ReadAsStringAsync());
            mainHeaderNameTextView.Text = quizInfo.quizName;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(quizInfo.quizDescription);
            sb.AppendLine("\n");
            sb.AppendLine("Current Leaderboard:");
            subHeaderTextView.Text = sb.ToString();

            miscInfoTextView.Text = $"Number of questions: {quizInfo.quizQuestionCount} | Credits to Earn: {quizInfo.quizCredits}";
        }

        private async void DownloadQuestions()
        {
            bottomButton.Text = "Downloading Questions...";
            bottomButton.Enabled = false;

            var questionDownloadRequest = await WebRequest.HttpClient.GetAsync("http://10.0.2.2:54888/QuizTables/GetQuizQuestions?quizID=1");
            var answerDownloadRequest = await WebRequest.HttpClient.GetAsync("http://10.0.2.2:54888/QuizTables/GetQuizAnswers?quizID=1");
            questionList = JsonConvert.DeserializeObject<List<MiscellaneousRequests.Question>>(await questionDownloadRequest.Content.ReadAsStringAsync());
            answerList = JsonConvert.DeserializeObject<List<MiscellaneousRequests.Answer>>(await answerDownloadRequest.Content.ReadAsStringAsync());

            bottomButton.Text = "Take Quiz";
            bottomButton.Enabled = true;
        }

        private void SetQuestionInterfaceVisibility(bool visibility)
        {
            if (visibility)
            {
                questionNameTextView.Visibility = ViewStates.Visible;
                questionHint.Visibility = ViewStates.Visible;
                answerGroup.Visibility = ViewStates.Visible;
            }
            else
            {
                questionNameTextView.Visibility = ViewStates.Invisible;
                questionHint.Visibility = ViewStates.Invisible;
                answerGroup.Visibility = ViewStates.Invisible;
            }
        }
    }
}