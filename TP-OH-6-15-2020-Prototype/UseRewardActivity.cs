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
    [Activity(Label = "UseRewardActivity")]
    public class UseRewardActivity : Activity
    {
        private TextView headerTextView;
        private ListView rewardsListView;
        private List<RedeemRewardModel> rewardList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.generic_information_list);
            headerTextView = FindViewById<TextView>(Resource.Id.genericHeader);
            rewardsListView = FindViewById<ListView>(Resource.Id.ITcoursesListView);

            headerTextView.Text = "Available Rewards:";
            DownloadRewards();
        }

        private async void DownloadRewards()
        {
            var rewardRequest = await WebRequest.HttpClient.GetAsync($"http://10.0.2.2:54888/AwardRedemptions/GetReward?userID={MainMenuActivity.UserId}");
            rewardList = JsonConvert.DeserializeObject<List<RedeemRewardModel>>(await rewardRequest.Content.ReadAsStringAsync());

            rewardList = rewardList.OrderBy(x => x.isAwardUsed).ToList();
            var tempRewardList = new List<string>();

            foreach (var reward in rewardList)
            {
                if (reward.isAwardUsed)
                {
                    tempRewardList.Add($"{reward.awardName} [USED]");
                }
                else
                {
                    tempRewardList.Add($"{reward.awardName}");
                }
            }

            rewardsListView.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem2, tempRewardList);
            rewardsListView.ItemClick += RewardsListView_ItemClick;
        }

        private void RewardsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
        }
    }
}