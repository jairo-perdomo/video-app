using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PhotoApp.Views;
using PhotoApp.Controllers;
using System.IO;

namespace PhotoApp
{
    public partial class App : Application
    {
        static Database database;
        public static Database BaseDatos
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM02VideoApp.db3"));
                }

                return database;
            }


        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
