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
using TP_OH_6_15_2020_Prototype.Models;

namespace TP_OH_6_15_2020_Prototype
{
    internal class QuizListAdapter : BaseAdapter<QuizListModel>
    {
        private List<QuizListModel> mItems;
        private Context mContext;

        public QuizListAdapter(List<QuizListModel> mItems, Context mContext)
        {
            this.mItems = mItems;
            this.mContext = mContext;
        }

        public override QuizListModel this[int position]
        {
            get { return mItems[position]; }
        }

        public override int Count
        {
            get { return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.event_grid_layout, null, false);
            }

            var quizName = convertView.FindViewById<TextView>(Resource.Id.eventNameTextViewGrid);
            var numberOfQuestions = convertView.FindViewById<TextView>(Resource.Id.offeredByTextViewGrid);
            var eventDescTextView = convertView.FindViewById<TextView>(Resource.Id.eventDescTextViewGrid);
            var leadingText = convertView.FindViewById<TextView>(Resource.Id.leadingMessageTextView);

            quizName.Text = mItems[position].quizName;
            numberOfQuestions.Text = $"Number of questions: {mItems[position].quizQuestionCount} | Credits to Earn: {mItems[position].quizCredits}";
            eventDescTextView.Text = mItems[position].quizDescription;
            leadingText.Text = "Click to take this quiz";

            return convertView;
        }
    }
}