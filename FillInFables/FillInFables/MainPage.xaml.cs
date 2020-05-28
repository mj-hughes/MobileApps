using System;
using FillInFables.Models;
using Xamarin.Forms;

namespace FillInFables
{
    
    public partial class MainPage : ContentPage
    {
        public static Player player;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            player = await App.Database.GetPlayerAsync();
            if (player == null)
            {
                player = new Player();
            }
            playerName.BindingContext = player;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {

            ((ListView)sender).SelectedItem = null;
            if (args.SelectedItem != null)
            {
                PageDataViewModel pageData = (PageDataViewModel)args.SelectedItem;
                Page page = (Page)Activator.CreateInstance(pageData.Type);
                await Navigation.PushAsync(page);
            }
        }
    }
}
