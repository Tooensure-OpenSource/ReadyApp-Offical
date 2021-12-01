using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Auth0.OidcClient;

namespace ReadyApp.UI.Mobile.Droid
{
    [Activity(Label = "ReadyApp.UI.Mobile", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //private Auth0Client _auth0Client;
        //private Action<string> writeLine;
        //private Action clearText;
        //private string accessToken;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            //_auth0Client = new Auth0Client(new Auth0ClientOptions
            //{
            //    Domain = "tooensure-dev.us.auth0.com",
            //    ClientId = "NijRLEMh33No4Z49LjNLmaYvJNiPWNsT",
            //    Scope = "openid profile email"

            //}, this);
            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.au);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        //private async void LoginButtonOnClick(object sender, EventArgs eventArgs)
        //{


            //var loginResult = await _auth0Client.LoginAsync();

            //if (loginResult.IsError)
            //{
            //    writeLine($"An error occurred during login: {loginResult.Error}");
            //    return;
            //}

            //accessToken = loginResult.AccessToken;

            //foreach (var claim in loginResult.User.Claims)
            //{
            //    writeLine($"{claim.Type} = {claim.Value}");
            //}
        //}
    }
}