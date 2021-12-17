using Lect10.Services;
using Lect10.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lect10
{
    public partial class App : Application
    {
        private static ItemDatabase _database;
        /// <summary>
        /// singleton
        /// </summary>
        public static ItemDatabase Database
        {
            get
            {
                if( _database == null )
                    _database = new ItemDatabase();
                return _database;
            }
        }
        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new ItemHomePage());
            MainPage = new NotificationDemoPage();
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
