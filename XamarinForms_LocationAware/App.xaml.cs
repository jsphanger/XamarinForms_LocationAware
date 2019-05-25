using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms_LocationAware.Data;

namespace XamarinForms_LocationAware
{
    public partial class App : Application
    {
        static LocationDatabase _database;
        public static LocationDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new LocationDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                    "LocationDatabase.db3"));
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
