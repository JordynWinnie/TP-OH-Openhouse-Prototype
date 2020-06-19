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
    [Activity(Label = "DetailedEventViewActivity")]
    public class DetailedEventViewActivity : Activity
    {
        private TextView eventNameTextView;
        private TextView offeredByTextView;
        private EditText informationEditText;
        private Button joinEventButton;

        private EventModel detailsResponse;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.event_detailed_view_layout);
            InitView();
        }

        private async void InitView()
        {
            eventNameTextView = FindViewById<TextView>(Resource.Id.eventNameTextViewDetailed);
            offeredByTextView = FindViewById<TextView>(Resource.Id.offeredByTextViewDetailed);
            informationEditText = FindViewById<EditText>(Resource.Id.eventInformationEditTextDetailed);
            joinEventButton = FindViewById<Button>(Resource.Id.joinEventButtonDetailed);

            var eventId = Intent.GetIntExtra("eventid", -1);
            var detailsRequest = await WebRequest.HttpClient.GetAsync($"http://10.0.2.2:54888/EventsTables/GetEvents?id={eventId}");

            detailsResponse = JsonConvert.DeserializeObject<EventModel>(await detailsRequest.Content.ReadAsStringAsync());

            eventNameTextView.Text = detailsResponse.eventName;
            offeredByTextView.Text = "Offered by: " + detailsResponse.courseName;
            StringBuilder sb = new StringBuilder();
            sb.Append(detailsResponse.eventDescription);
            sb.AppendLine("\n");
            sb.AppendLine("Event Timings:");
            var dates = from x in detailsResponse.EventTimings
                        group x by x.startTimeOfEvent.Date into y
                        select y;

            foreach (var eventTime in dates)
            {
                sb.AppendLine(eventTime.Key.ToLocalTime().ToShortDateString());

                foreach (var item in eventTime)
                {
                    sb.AppendLine("\t\t" + item.startTimeOfEvent.ToLocalTime().ToShortTimeString() + " - " + item.endTimeOfEvent.ToLocalTime().ToShortTimeString());
                }
                sb.AppendLine("\n");
            }

            informationEditText.Text = sb.ToString();
        }
    }
}