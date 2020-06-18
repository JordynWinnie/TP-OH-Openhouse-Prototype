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
    public class UserModel
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int credits { get; set; }
        public bool isAdmin { get; set; }
    }
}