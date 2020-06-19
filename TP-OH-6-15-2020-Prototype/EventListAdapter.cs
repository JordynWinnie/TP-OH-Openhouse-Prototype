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
    public class EventListAdapter : BaseAdapter<EventModel>
    {
        private List<EventModel> mItems;
        private Context mContext;

        public EventListAdapter(List<EventModel> mItems, Context mContext)
        {
            this.mItems = mItems;
            this.mContext = mContext;
        }

        public override EventModel this[int position]
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

            var eventName = convertView.FindViewById<TextView>(Resource.Id.eventNameTextViewGrid);
            var offeredByTextView = convertView.FindViewById<TextView>(Resource.Id.offeredByTextViewGrid);
            var eventDescTextView = convertView.FindViewById<TextView>(Resource.Id.eventDescTextViewGrid);

            eventName.Text = mItems[position].eventName;
            offeredByTextView.Text = $"Offered by: {mItems[position].courseShortName}";
            eventDescTextView.Text = mItems[position].eventDescription;

            return convertView;
        }
    }
}