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
    [Activity(Label = "AwardListActivity")]
    public class AwardListActivity : Activity
    {
        private ListView rewardListView;
        private TextView currentBalanceTextView;
        private List<AwardListModel> awardList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.award_redemption_layout);
            rewardListView = FindViewById<ListView>(Resource.Id.rewardListView);
            currentBalanceTextView = FindViewById<TextView>(Resource.Id.balanceTextView);

            DownloadAwards();
        }

        private async void DownloadAwards()
        {
            var awardRequest = await WebRequest.HttpClient.GetAsync("http://10.0.2.2:54888/AwardsTables/GetListOfAwards");
            var userBalanceRequest = await WebRequest.HttpClient.GetAsync($"http://10.0.2.2:54888/Users/GetUserInfo?userid={MainMenuActivity.UserId}");
            awardList = JsonConvert.DeserializeObject<List<AwardListModel>>(await awardRequest.Content.ReadAsStringAsync());
            var userBalance = JsonConvert.DeserializeObject<UserModel>(await userBalanceRequest.Content.ReadAsStringAsync());
            rewardListView.Adapter = new AwardListAdapter(this, awardList);
            currentBalanceTextView.Text = $"Your Current Balance: {userBalance.credits}";
        }
    }
}