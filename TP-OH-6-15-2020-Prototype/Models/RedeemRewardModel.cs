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
    internal class RedeemRewardModel
    {
        public int awardIdFK { get; set; }
        public bool isAwardUsed { get; set; }
        public string awardName { get; set; }
        public Guid UUID { get; set; }
    }
}