using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using Xamarin.Forms;

namespace PersonalityQuizWithAPI
{
   
    [DesignTimeVisible(false)]

    public partial class MainPage : ContentPage
    {
        public static HeroesManager HeroesManager { get; private set; }

        public MainPage()
        {

            InitializeComponent();

            listView.BindingContext = QuizQuestion.All;
        }

        public void ScoreQuiz()
        {
            // No more questions left. Score the quiz.
            int Result_Hero_Points = 0;
            string Result_Hero = "";
            string Result_Hero_Id = "";
            foreach (Heroes Hero in Heroes.All)
            {
                if (Hero.Points > Result_Hero_Points)
                {
                    Result_Hero = Hero.Name;
                    Result_Hero_Points = Hero.Points;
                    Result_Hero_Id = Hero.ApiId;
                }
            }
            Heroes.ResetPoints();
            QuizQuestion.ResetQuestions();
            GetHeroInfo(Result_Hero_Id);
            HeroName.Text = "You're " + Result_Hero + "!";
        }

        async void GetHeroInfo(string heroId)
        {

            HeroesManager = new HeroesManager(new RestService(heroId));
            HeroAPI hero = await HeroesManager.GetTasksAsync();

            // Apparently the iOS system will automatically push the url
            // to https, which will result in no image found. Taking the
            // image source from stream works around that.
            string Image_Name = hero.data.results[0].thumbnail.path + "/standard_fantastic." +
                hero.data.results[0].thumbnail.extension;
            Banner.Source = ImageSource.FromStream(()=>new MemoryStream(new WebClient().DownloadData(Image_Name)));
            
            Banner.IsVisible = true;
            Description.Text = hero.data.results[0].description;

        }

        void OnNoButtonClicked(int index)
        {
            var NoPointsTo = QuizQuestion.All[index].NoPoints;
            Heroes.All[QuizQuestion.All[index].NoPoints].Points++;
            QuizQuestion.SetResponse(index, "N");
        }

        void OnYesButtonClicked(int index)
        {
            var YesPointsTo = QuizQuestion.All[index].YesPoints;
            Heroes.All[QuizQuestion.All[index].YesPoints].Points++;
            QuizQuestion.SetResponse(index, "Y");
        }

        void OnItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null) return;
            ((ListView)sender).SelectedItem = null;
        }

        void OnCellClicked(System.Object sender, System.EventArgs e)
        {
            var b = (Button)sender;
            var t = b.CommandParameter;
            //var n = b.FindByName("qNum");
            var q = (QuizQuestion)t;
            if (b.Text == "Yes")
            {
                OnYesButtonClicked(q.QuestionNum);
            }
            else
            {
                OnNoButtonClicked(q.QuestionNum);
            }

        }

        async void OnScoreQuizClicked(System.Object sender, System.EventArgs e)
        {
            // Check that all questions have been answered
            if (QuizQuestion.AllQuestionsAnswered())
            {
                // Score quiz
                ScoreQuiz();
            }
            else
            {
                await DisplayAlert("Questions Missing", "Please answer all questions before scoring.", "OK");
            }
        }
    }
}
