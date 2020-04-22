using System;
using Xamarin.Forms;

namespace Code11JokesDatabase
{
    public partial class JokePage : ContentPage
    {
        public JokePage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(System.Object sender, System.EventArgs e)
        {
            var joke = (Joke)BindingContext;
            await App.Database.SaveItemAsync(joke);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
