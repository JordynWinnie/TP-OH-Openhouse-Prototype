using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    [Activity(Label = "ITCourseListActivity")]
    public class ITCourseListActivity : Activity
    {
        private ListView courseListView;
        private List<CourseModel> courseList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.course_information_list_layout);
            courseListView = FindViewById<ListView>(Resource.Id.ITcoursesListView);

            DownloadCourseList();
        }

        private async void DownloadCourseList()
        {
            var courseRequest = await WebRequest.HttpClient.GetAsync("http://10.0.2.2:54888/CourseTables/GetCourses");
            courseList = JsonConvert.DeserializeObject<List<CourseModel>>(await courseRequest.Content.ReadAsStringAsync());

            var tempCourseList = new List<string>();
            foreach (var course in courseList)
            {
                tempCourseList.Add($"{course.courseShortName}: {course.courseName} ({course.courseCode})");
            }

            courseListView.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, tempCourseList);
            courseListView.ItemClick += CourseListView_ItemClick;
        }

        private void CourseListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var uri = Android.Net.Uri.Parse(courseList[e.Position].courseInfoLink);
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }
    }
}