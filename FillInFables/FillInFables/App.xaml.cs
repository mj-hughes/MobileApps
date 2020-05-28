using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FillInFables
{
    public partial class App : Application
    {
        static PlayerDatabase database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new MainPage());
        }

        public static PlayerDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PlayerDatabase();
                }
                return database;
            }
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
