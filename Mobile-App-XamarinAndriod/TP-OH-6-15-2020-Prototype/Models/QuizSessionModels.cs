namespace TP_OH_6_15_2020_Prototype.Models
{
    internal class QuizSessionModels
    {
        internal class LeaderBoard
        {
            public string username { get; set; }
            public int score { get; set; }
        }

        internal class Question
        {
            public int questionID { get; set; }
            public string questionString { get; set; }
            public string questionHint { get; set; }

            public string? questionTrivia { get; set; }
        }

        internal class Answer
        {
            public int questionID { get; set; }
            public string answerString { get; set; }
            public bool isCorrectAnswer { get; set; }
        }
    }
}