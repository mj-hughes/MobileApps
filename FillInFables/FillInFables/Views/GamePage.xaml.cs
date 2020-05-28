using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using FillInFables.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FillInFables.Views
{
    
    public partial class GamePage : ContentPage
    {
        public static MadLibzManager MadLibzManager { get; private set; }
        public static MadLibz madLibz { get; private set; }
        public static GameViewModel gameViewModel { get; set; }
        public static IList<GameViewModel> All { get; private set; }
        //        public ObservableCollection<string> Items { get; set; }

        public GamePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MadLibzManager = new MadLibzManager(new RestService());
            madLibz = await MadLibzManager.GetTasksAsync();

            gameViewModel = new GameViewModel();
            All = gameViewModel.AddMadLibz(madLibz);

            listView.ItemsSource = All;

        }


        async void OnDoneClicked(System.Object sender, System.EventArgs e)
        {
            string story="";

            // Create story
            foreach (GameViewModel gameViewModel in All)
            {
                story += gameViewModel.Value + gameViewModel.Answer;
            }
    
            await Navigation.PushAsync(new StoryPage(All[0].Title, story));
        }
    }
}
