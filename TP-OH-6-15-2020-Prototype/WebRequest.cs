﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TP_OH_6_15_2020_Prototype
{
    public class WebRequest
    {
        public static readonly HttpClient HttpClient;

        static WebRequest()
        {
            HttpClient = new HttpClient();
        }
    }
}