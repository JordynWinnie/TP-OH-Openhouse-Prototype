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
    [Activity(Label = "AwardDetailedActivity")]
    public class AwardDetailedActivity : Activity
    {
        private TextView awardInformationHeader;
        private EditText awardMainInformationEditText;
        private Button redeemAwardButton;
        private int awardId;
        private TextView awardNameTextView;
        private TextView awardMetadataTextview;
        private UserModel userInfo;
        private AwardListModel award;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.generic_detailed_view_layout);
            InitView();
        }

        private async void InitView()
        {
            awardNameTextView = FindViewById<TextView>(Resource.Id.eventNameTextViewDetailed);
            awardMetadataTextview = FindViewById<TextView>(Resource.Id.offeredByTextViewDetailed);
            awardInformationHeader = FindViewById<TextView>(Resource.Id.eventInformationHeaderTextView);
            awardMainInformationEditText = FindViewById<EditText>(Resource.Id.eventInformationEditTextDetailed);
            redeemAwardButton = FindViewById<Button>(Resource.Id.joinEventButtonDetailed);

            awardId = Intent.GetIntExtra("awardId", -1);
            var awardRequest = await WebRequest.HttpClient.GetAsync($"http://10.0.2.2:54888/AwardsTables/GetAward?awardID={awardId}");

            var userRequest = await WebRequest.HttpClient.GetAsync($"http://10.0.2.2:54888/Users/GetUserInfo?userid={MainMenuActivity.UserId}");
            userInfo = JsonConvert.DeserializeObject<UserModel>(await userRequest.Content.ReadAsStringAsync());
            award = JsonConvert.DeserializeObject<AwardListModel>(await awardRequest.Content.ReadAsStringAsync());

            awardNameTextView.Text = award.awardName;
            awardMetadataTextview.Text = $"Credits Required: {award.creditsRequired} | Amount Left: {award.Limit}";
            awardInformationHeader.Text = "Reward Description:";
            awardMainInformationEditText.Text = award.awardDescription;

            if (userInfo.credits >= award.creditsRequired)
            {
                redeemAwardButton.Text = $"Redeem Reward for {award.creditsRequired} credits!";
            }
            else
            {
                redeemAwardButton.Text = "You do not have enough credits to redeem this";
                redeemAwardButton.Enabled = false;
            }

            if (award.Limit <= 0)
            {
                redeemAwardButton.Text = "Fully Redeemed :(";
                redeemAwardButton.Enabled = false;
            }

            redeemAwardButton.Click += RedeemAwardButton_Click;
        }

        private async void RedeemAwardButton_Click(object sender, EventArgs e)
        {
            var attemptAwardRedeem = await WebRequest.HttpClient.GetAsync($"http://10.0.2.2:54888/AwardsTables/RedeemAward?awardID={awardId}&userID={MainMenuActivity.UserId}");

            switch (attemptAwardRedeem.StatusCode)
            {
                case System.Net.HttpStatusCode.Unauthorized:
                    redeemAwardButton.Text = "Fully Redeemed :(";
                    redeemAwardButton.Enabled = false;
                    break;

                case System.Net.HttpStatusCode.Forbidden:
                    redeemAwardButton.Text = "Sorry, you have already redeemed this reward";
                    redeemAwardButton.Enabled = false;
                    break;

                case System.Net.HttpStatusCode.NotAcceptable:
                    redeemAwardButton.Text = "You do not have enough credits to redeem this";
                    redeemAwardButton.Enabled = false;
                    break;

                case System.Net.HttpStatusCode.InternalServerError:
                    redeemAwardButton.Text = "An error occurred, try again?";
                    redeemAwardButton.Enabled = true;
                    break;

                default:
                    redeemAwardButton.Text = "Reward claimed!";
                    redeemAwardButton.Enabled = false;
                    break;
            }
        }
    }
}