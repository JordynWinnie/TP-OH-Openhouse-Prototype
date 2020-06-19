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
    public class EventModel
    {
        public string eventName { get; set; }
        public string eventDescription { get; set; }
        public int creditsToEarn { get; set; }
        public string courseName { get; set; }
        public string courseShortName { get; set; }
        public string courseCode { get; set; }
        public string qrCodeString { get; set; }
        public List<EventTimingModel> EventTimings { get; set; }
    }
}