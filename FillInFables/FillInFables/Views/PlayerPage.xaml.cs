using FillInFables.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Collections.Generic;

namespace FillInFables.Views
{
    public partial class PlayerPage : ContentPage
    {
        public Player player;

        public PlayerPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            player = await App.Database.GetPlayerAsync();
            if (player==null)
            {
                player = new Player();
            }
            playerInfo.BindingContext = player;
            var locales = await TextToSpeech.GetLocalesAsync();
            List<string> localesList = new List<string>();
            foreach (Locale l in locales)
            {
                localesList.Add(l.Language.ToString());
            }
            picker.ItemsSource = localesList;
        }

        async void OnSaveClicked(System.Object sender, System.EventArgs e)
        {
            if (picker.SelectedItem != null)
            {
                player.Language = picker.SelectedItem.ToString();
            }
            await App.Database.SaveItemAsync(player);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
