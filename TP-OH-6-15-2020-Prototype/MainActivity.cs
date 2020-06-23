using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using TP_OH_6_15_2020_Prototype.Models;
using Android.Content;
using ZXing.Mobile;

namespace TP_OH_6_15_2020_Prototype
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText emailEditText;
        private EditText passwordEditText;
        private Button loginBtn;
        private Button registerBtn;
        private Button shortCutButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitViews();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void InitViews()
        {
            //Initialises all the views:
            emailEditText = FindViewById<EditText>(Resource.Id.usernameEditTextLogin);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditTextLogin);
            loginBtn = FindViewById<Button>(Resource.Id.loginBtnLogin);
            registerBtn = FindViewById<Button>(Resource.Id.registerBtnLogin);
            shortCutButton = FindViewById<Button>(Resource.Id.testingButton);

            loginBtn.Click += LoginBtn_Click;
            registerBtn.Click += RegisterBtn_Click;
            shortCutButton.Click += ShortCutButton_Click;
        }

        private async void ShortCutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RedeemRewardActivity));
            StartActivity(intent);
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisterActivity));
            StartActivity(intent);
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            //Access the HttpClient Singleton process to login GET:
            var response = await
                WebRequest.HttpClient.GetAsync($"http://10.0.2.2:54888/Users/Login?email={emailEditText.Text}&password={passwordEditText.Text}");

            //Only allow login when success:
            if (response.IsSuccessStatusCode)
            {
                var user = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());
                Toast.MakeText(this, "Welcome back, " + user.username + "!", ToastLength.Short).Show();
                var intent = new Intent(this, typeof(MainMenuActivity));
                intent.PutExtra("userid", user.userid);
                StartActivity(intent);

                return;
            }
            Toast.MakeText(this, "Wrong username or password", ToastLength.Short).Show();
        }
    }
}