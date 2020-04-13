using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Code6
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnClickedColorBox(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ColorBox());
        }
        async void OnClickedStaticResources(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new StaticResources());
        }
        async void OnClickedScrollView(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ScrollView());
        }
    }
}
