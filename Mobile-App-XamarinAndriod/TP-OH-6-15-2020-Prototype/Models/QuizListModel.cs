using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TP_OH_6_15_2020_Prototype.Models
{
    internal class QuizListModel
    {
        public int quizID { get; set; }
        public string quizName { get; set; }
        public string quizDescription { get; set; }
        public int quizQuestionCount { get; set; }
        public int quizCredits { get; set; }
    }
}