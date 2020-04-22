using System;
using Xamarin.Forms;

namespace Code11JokesDatabase
{
    public partial class JokeListPage : ContentPage
    {
        public JokeListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetJokesAsync();
        }

    

        async void OnItemAdded(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new JokePage
            {
                BindingContext = new Joke()
            });
        }

        async void OnListItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem !=null)
            {
                await Navigation.PushAsync(new JokePage
                {
                    BindingContext = e.SelectedItem as Joke
                });
            }
        }
    }
}
