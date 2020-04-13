using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HomeworkCode9
{
    public partial class Credits : ContentPage
    {
        public Credits()
        {
            InitializeComponent();
        }

        async void SeeTerms(System.Object sender, System.EventArgs e)
        {
            var terms = new Terms();
            await Navigation.PushModalAsync(terms);
        }
    }
}
