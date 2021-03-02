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
    internal class AwardListModel
    {
        public string awardName { get; set; }
        public string awardDescription { get; set; }
        public int Limit { get; set; }
        public int awardID { get; set; }
        public int creditsRequired { get; set; }
    }
}