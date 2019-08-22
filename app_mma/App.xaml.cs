using System;
using app_mma.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_mma
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new InicioPageView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
