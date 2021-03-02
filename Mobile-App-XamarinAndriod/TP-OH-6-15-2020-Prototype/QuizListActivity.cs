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
using Newtonsoft.Json;
using TP_OH_6_15_2020_Prototype.Models;

namespace TP_OH_6_15_2020_Prototype
{
    [Activity(Label = "QuizListActivity")]
    public class QuizListActivity : Activity
    {
        private ListView quizListView;
        private List<QuizListModel> quizList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.quiz_main_layout);
            InitView();
        }

        private async void InitView()
        {
            quizListView = FindViewById<ListView>(Resource.Id.quizListView);

            //Do network request:
            var quizRequest = await WebRequest.HttpClient.GetAsync("http://10.0.2.2:54888/QuizTables/GetQuizList");
            quizList = JsonConvert.DeserializeObject<List<QuizListModel>>(await quizRequest.Content.ReadAsStringAsync());

            quizListView.Adapter = new QuizListAdapter(quizList, this);

            quizListView.ItemClick += QuizListView_ItemClick; ;
        }

        private void QuizListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(QuizSessionActivity));
            intent.PutExtra("quizId", quizList[e.Position].quizID);
            StartActivity(intent);
        }
    }
}