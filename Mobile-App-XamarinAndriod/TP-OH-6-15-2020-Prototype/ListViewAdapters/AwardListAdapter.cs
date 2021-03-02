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
    internal class AwardListAdapter : BaseAdapter<AwardListModel>
    {
        private Context mContext;
        private List<AwardListModel> mItems;

        public AwardListAdapter(Context mContext, List<AwardListModel> mItems)
        {
            this.mContext = mContext;
            this.mItems = mItems;
        }

        public override AwardListModel this[int position] { get { return mItems[position]; } }

        public override int Count { get { return mItems.Count; } }

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

            var awardName = convertView.FindViewById<TextView>(Resource.Id.eventNameTextViewGrid);
            var awardInformation = convertView.FindViewById<TextView>(Resource.Id.offeredByTextViewGrid);
            var awardDescription = convertView.FindViewById<TextView>(Resource.Id.eventDescTextViewGrid);
            var leadingText = convertView.FindViewById<TextView>(Resource.Id.leadingMessageTextView);

            awardName.Text = mItems[position].awardName;
            awardInformation.Text = $"Credits Required: {mItems[position].creditsRequired} | Amount Left: {mItems[position].Limit}";
            awardDescription.Text = mItems[position].awardDescription;
            leadingText.Text = "Click to see more!";

            return convertView;
        }
    }
}