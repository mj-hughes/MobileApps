using System.Collections.Generic;
using Xamarin.Forms;


namespace WhichTurtleAreYou
{
    
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {

            InitializeComponent();

            listView.BindingContext = QuizQuestion.All;
        }

        public void ScoreQuiz()
        {
            // No more questions left. Score the quiz.
            int Result_Turtle_Points = 0;
            string Result_Turtle = "";
            foreach (Turtles turtle in Turtles.All)
            {
                if (turtle.Points>Result_Turtle_Points)
                {
                    Result_Turtle = turtle.Name;
                    Result_Turtle_Points = turtle.Points;
                }
            }
            Turtles.ResetPoints();
            QuizQuestion.ResetQuestions();
            string Image_Name = Result_Turtle.ToLower() + ".png";
            Banner.Source = Image_Name;
            Banner.IsVisible = true;
            TurtleName.Text = "You're "+Result_Turtle+"!";
        }  

        void OnNoButtonClicked(int index)
        {
            var NoPointsTo = QuizQuestion.All[index].NoPoints;
            //await DisplayAlert("No turtle: " + NoPointsTo, "No points to " + Turtles.All[NoPointsTo].Name, "OK");
            Turtles.All[QuizQuestion.All[index].NoPoints].Points++;
            QuizQuestion.SetResponse(index, "N");
        }

        void OnYesButtonClicked(int index)
        {
            var YesPointsTo = QuizQuestion.All[index].YesPoints;
            //await DisplayAlert("Yes turtle: "+YesPointsTo, "Yes points to "+Turtles.All[YesPointsTo].Name, "OK");
            Turtles.All[QuizQuestion.All[index].YesPoints].Points++;
            QuizQuestion.SetResponse(index, "Y");
        }

        void OnItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null) return;
            //await DisplayAlert("tapped", e.Item + " row was tapped", "OK");
            ((ListView)sender).SelectedItem = null;
        }

        void OnCellClicked(System.Object sender, System.EventArgs e)
        {
            var b = (Button)sender;
            var t = b.CommandParameter;
            //var n = b.FindByName("qNum");
            var q = (QuizQuestion)t;
            /*
            await ((ContentPage)((StackLayout)((ListView)((ViewCell)((StackLayout)
                b.Parent).Parent).Parent).Parent).Parent).DisplayAlert(
                "Clicked", b.Text + " button was clicked "+t+ " and "+
                q.QuestionNum.ToString(), "OK");
                */
            if (b.Text=="Yes")
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
