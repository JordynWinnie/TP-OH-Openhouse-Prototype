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

namespace TP_OH_6_15_2020_Prototype
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        private EditText nameEditText;
        private EditText emailEditText;
        private EditText passwordEditText;
        private EditText rePasswordEditText;
        private Button registerButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.register_layout);
            InitViews();
        }

        private void InitViews()
        {
            nameEditText = FindViewById<EditText>(Resource.Id.nameEditTextRegister);
            emailEditText = FindViewById<EditText>(Resource.Id.emailEditTextRegister);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditTextRegister);
            rePasswordEditText = FindViewById<EditText>(Resource.Id.rePasswordEditTextRegister);
            registerButton = FindViewById<Button>(Resource.Id.registerBtnRegister);

            registerButton.Click += RegisterButton_Click;
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                var request = await WebRequest.HttpClient.GetAsync($"http://10.0.2.2:54888/Users/RegisterNewUser?email={emailEditText.Text}&password={passwordEditText.Text}&name={nameEditText.Text}");

                var response = await request.Content.ReadAsStringAsync();

                if (request.IsSuccessStatusCode)
                {
                    if (response.Contains("Already Registered"))
                    {
                        Toast.MakeText(this, "The email is tied to another acccount :(", ToastLength.Short).Show();
                        return;
                    }
                    Toast.MakeText(this, "Registered :D", ToastLength.Short).Show();
                    Finish();
                    return;
                }
                Toast.MakeText(this, "Registration unsuccessful", ToastLength.Short).Show();
            }
        }

        private bool Validation()
        {
            if (nameEditText.Text.Equals(string.Empty) || emailEditText.Text.Equals(string.Empty) ||
                passwordEditText.Text.Equals(string.Empty) || rePasswordEditText.Text.Equals(string.Empty))
            {
                Toast.MakeText(this, "Please fill up all the fields", ToastLength.Short).Show();
                return false;
            }

            if (passwordEditText.Text.Length < 8)
            {
                Toast.MakeText(this, "Password must have 8 or more characters", ToastLength.Short).Show();
                return false;
            }

            if (!passwordEditText.Text.Equals(rePasswordEditText.Text))
            {
                Toast.MakeText(this, "Passwords do not match", ToastLength.Short).Show();
                return false;
            }
            return true;
        }
    }
}