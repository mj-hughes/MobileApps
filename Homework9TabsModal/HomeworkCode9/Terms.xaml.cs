using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HomeworkCode9
{
    public partial class Terms : ContentPage
    {
        public Terms()
        {
            InitializeComponent();
        }

        async void OnDismissButtonClicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
