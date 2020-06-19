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
    public class EventTimingModel
    {
        public int eventTimingID { get; set; }
        public int eventIDFK { get; set; }
        public DateTime startTimeOfEvent { get; set; }
        public DateTime endTimeOfEvent { get; set; }
    }
}