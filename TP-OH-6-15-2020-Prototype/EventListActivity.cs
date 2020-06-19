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
using Java.Sql;
using Newtonsoft.Json;
using TP_OH_6_15_2020_Prototype.Models;

namespace TP_OH_6_15_2020_Prototype
{
    [Activity(Label = "EventListActivity")]
    public class EventListActivity : Activity
    {
        private Spinner courseSpinner;
        private EditText startTimeEditText;
        private EditText endTimeEditText;
        private ListView eventListView;
        private List<CourseModel> generalCourseList;
        private List<EventModel> eventList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.main_events_layout);
            InitViews();
        }

        private async void InitViews()
        {
            courseSpinner = FindViewById<Spinner>(Resource.Id.courseSpinner);
            startTimeEditText = FindViewById<EditText>(Resource.Id.startTimeEditText);
            endTimeEditText = FindViewById<EditText>(Resource.Id.endTimeEditText);
            eventListView = FindViewById<ListView>(Resource.Id.eventListView);

            courseSpinner.ItemSelected += CourseSpinner_ItemSelected;
            startTimeEditText.Click += StartTimeEditText_Click;
            startTimeEditText.Focusable = false;

            endTimeEditText.Click += EndTimeEditText_Click;
            endTimeEditText.Focusable = false;

            var courseListRequest = await WebRequest.HttpClient.GetAsync("http://10.0.2.2:54888/CourseTables/GetCourses");

            generalCourseList = JsonConvert.DeserializeObject<List<CourseModel>>(await courseListRequest.Content.ReadAsStringAsync());

            var courseList = new List<string>();
            courseList.Add("All Courses");

            foreach (var course in generalCourseList)
            {
                courseList.Add(course.courseName);
            }

            courseSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, courseList);
            RefreshEventList();
            eventListView.ItemClick += EventListView_ItemClick;
        }

        private void EndTimeEditText_Click(object sender, EventArgs e)
        {
            var dtd = new TimePickerDialog(this, endTimePicked, DateTime.Now.Hour, DateTime.Now.Minute, true);
            dtd.Show();
        }

        private void endTimePicked(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            endTimeEditText.Text = $"{e.HourOfDay}:{e.Minute}";
            RefreshEventList();
        }

        private void StartTimeEditText_Click(object sender, EventArgs e)
        {
            var dtd = new TimePickerDialog(this, startTimePicked, DateTime.Now.Hour, DateTime.Now.Minute, true);

            dtd.Show();
        }

        private void startTimePicked(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            startTimeEditText.Text = $"{e.HourOfDay}:{e.Minute}";
            RefreshEventList();
        }

        private void EventListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, "Clicked on " + eventList[e.Position].eventName, ToastLength.Short).Show();
        }

        private void CourseSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            RefreshEventList();
        }

        private async void RefreshEventList()
        {
            var eventListRequest = await WebRequest.HttpClient.GetAsync("http://10.0.2.2:54888/EventsTables/GetEvents");
            eventList = JsonConvert.DeserializeObject<List<EventModel>>(await eventListRequest.Content.ReadAsStringAsync());
            string response = await eventListRequest.Content.ReadAsStringAsync();
            var courseSpinnerSelected = courseSpinner.SelectedItem.ToString();

            if (!courseSpinnerSelected.Equals("All Courses"))
            {
                eventList = (from x in eventList
                             where x.courseName.Equals(courseSpinnerSelected)
                             select x).ToList();
            }

            if (!startTimeEditText.Text.Equals(string.Empty))
            {
                var tempEventList = new List<EventModel>();
                var startTimingSelected = DateTime.Parse(startTimeEditText.Text);
                foreach (var item in eventList)
                {
                    foreach (var timing in item.EventTimings)
                    {
                        if (timing.startTimeOfEvent >= startTimingSelected.ToUniversalTime())
                        {
                            tempEventList.Add(item);
                        }
                    }
                }
                eventList = tempEventList;
            }

            if (!endTimeEditText.Text.Equals(string.Empty))
            {
                var tempEventList = new List<EventModel>();
                var endTimingSelected = DateTime.Parse(endTimeEditText.Text);
                foreach (var item in eventList)
                {
                    foreach (var timing in item.EventTimings)
                    {
                        if (timing.endTimeOfEvent <= endTimingSelected.ToUniversalTime())
                        {
                            tempEventList.Add(item);
                        }
                    }
                }
                eventList = tempEventList;
            }
            eventListView.Adapter = new EventListAdapter(eventList, this);
        }
    }
}