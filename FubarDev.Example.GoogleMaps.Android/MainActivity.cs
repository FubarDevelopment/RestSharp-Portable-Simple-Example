using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FubarDev.Example.GoogleMaps.Android
{
    [Activity(Label = "FubarDev.Example.GoogleMaps.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.buttonSearch);
            button.Click += button_Click;
        }

        async void button_Click(object sender, EventArgs e)
        {

            var Origin = FindViewById<EditText>(Resource.Id.editOrigin);
            var Destination = FindViewById<EditText>(Resource.Id.editDestination);
            var OutputText = FindViewById<EditText>(Resource.Id.editOutput);
            try
            {
                var client = new GoogleMapsClient();
                var result = await client.GetDirections(Origin.Text, Destination.Text);
                OutputText.Text = result.ToString();
            }
            catch (Exception ex)
            {
                new AlertDialog.Builder(this)
                    .SetMessage(ex.ToString())
                    .SetTitle("Error")
                    .Show();
            }
        }
    }
}

