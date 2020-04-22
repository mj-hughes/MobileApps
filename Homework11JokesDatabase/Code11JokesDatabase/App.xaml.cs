using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Code11JokesDatabase
{
    public partial class App : Application
    {
        static JokeDatabase database;

        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new JokeListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryDarkGreen"];
            nav.BarTextColor = Color.Ivory;

            MainPage = nav;
        }

        public static JokeDatabase Database
        {
            get
            {
                if (database == null )
                {
                    database = new JokeDatabase();
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
