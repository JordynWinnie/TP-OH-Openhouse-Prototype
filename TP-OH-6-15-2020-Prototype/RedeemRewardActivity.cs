using Android.App;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Widget;
using Java.IO;
using System;
using ZXing.Common;
using ZXing.Mobile;
using ZXing.QrCode;

namespace TP_OH_6_15_2020_Prototype
{
    [Activity(Label = "RedeemRewardActivity")]
    public class RedeemRewardActivity : Activity
    {
        private ImageView qrCodeImage;
        private TextView codeTextView;
        private ProgressBar progressBar;
        private TextView progressTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.redemption_detailed_layout);

            qrCodeImage = FindViewById<ImageView>(Resource.Id.qrCodeImage);
            codeTextView = FindViewById<TextView>(Resource.Id.codeTextView);
            progressBar = FindViewById<ProgressBar>(Resource.Id.loadingBar);
            progressTextView = FindViewById<TextView>(Resource.Id.progressTextView);
            GenerateQRCode();

            var timer = new System.Threading.Timer((e) =>
            {
                CheckForValidation();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        private async void CheckForValidation()
        {
            var uuid = Intent.GetStringExtra("uuid");
            var validationCheck = await WebRequest.HttpClient.GetAsync($"http://10.0.2.2:54888/AwardRedemptions/ConfirmRewardRedemption?guid={uuid}");

            if (validationCheck.IsSuccessStatusCode)
            {
                CloseUpActivity();
            }
        }

        private void CloseUpActivity()
        {
            progressBar.Visibility = Android.Views.ViewStates.Gone;
            progressTextView.Text = "Success!";

            var timer = new System.Threading.Timer((e) =>
            {
                Finish();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
        }

        private void GenerateQRCode()
        {
            var uuid = Intent.GetStringExtra("uuid");
            codeTextView.Text = uuid;
            QRCodeWriter writer = new QRCodeWriter();
            BitMatrix bm = writer.encode(uuid, ZXing.BarcodeFormat.QR_CODE, 600, 600);
            BitmapRenderer bit = new BitmapRenderer();
            Bitmap image = bit.Render(bm, ZXing.BarcodeFormat.QR_CODE, uuid);
            qrCodeImage.SetImageBitmap(image);
        }
    }
}