using Xamarin.Forms;
using Xamarin.Essentials;
using System.Linq;

namespace FillInFables
{
    public partial class StoryPage : ContentPage
    {
        public string Story;

        public StoryPage(string title, string story)
        {
            InitializeComponent();
  
            PageName.Text = title;
            PageStory.Text = story;

            Story = story;

            BindingContext = MainPage.player;
        }

        async void OnHearItClicked(System.Object sender, System.EventArgs e)
        {
            var locales = await TextToSpeech.GetLocalesAsync();

            var locale = locales.FirstOrDefault(l=>l.Language == MainPage.player.Language);
            var settings = new SpeechOptions()
            {
                Volume = 1.0f,
                Pitch = 1.0f,
                Locale = locale
            }; 
            await TextToSpeech.SpeakAsync(Story, settings);
        }
    }
}
