using Xamarin.Forms;


namespace WhichTurtleAreYou
{
    
    public partial class MainPage : ContentPage
    {
        public int index = -1;

        public MainPage()
        {
            InitializeComponent();
            NextQuestion();
        }

        public void NextQuestion()
        {
            index++;
            if (index < QuizQuestion.All.Count)
            {
                // Still questions left. Keep going
                Question.Text = QuizQuestion.All[index].Question;
            }
            else
            {
                // No more questions left. Score the quiz.
                Yes_Button.IsVisible = false;
                No_Button.IsVisible = false;
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
                string Image_Name = Result_Turtle.ToLower() + ".png";
                Banner.Source = Image_Name;
                Banner.IsVisible = true;
                Question.Text = "You're "+Result_Turtle+"!";
            }
        }

        

        void OnNoButtonClicked(System.Object sender, System.EventArgs e)
        {
            Turtles.All[QuizQuestion.All[index].NoPoints].Points++;
            NextQuestion();
        }

        void OnYesButtonClicked(System.Object sender, System.EventArgs e)
        {
            Turtles.All[QuizQuestion.All[index].YesPoints].Points++;
            NextQuestion();
        }
    }
}
