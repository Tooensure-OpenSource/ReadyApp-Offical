using ReadyApp.UI.Mobile.sandbox;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReadyApp.UI.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RegisterUserPage();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
