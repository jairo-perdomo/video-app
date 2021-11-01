using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PhotoApp.Views;
namespace PhotoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PhotosView();
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
