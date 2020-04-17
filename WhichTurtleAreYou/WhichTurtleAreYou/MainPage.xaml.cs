using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace WhichTurtleAreYou
{

    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            listView.BindingContext = QuizDataViewModel.All;
        }

        void OnCellClicked(System.Object sender, System.EventArgs e)
        {
            var b = (ImageButton)sender;
            var q = (QuizQuestion)b.CommandParameter;

            if (b.Source.ToString().Contains("yesturtle"))
            {
                QuizDataViewModel.SetResponse(q.QuestionNum, "Y");
            }
            else
            {
                QuizDataViewModel.SetResponse(q.QuestionNum, "N");
            }
        }


        async void OnScoreQuizClicked(System.Object sender, System.EventArgs e)
        {
            string turtle= QuizDataViewModel.getWinner();
            string msg = "Please answer all questions before scoring quiz.";
            string title = "Missing questions";
            if (turtle!="")
            {
                title = turtle;
                msg = "You're " + turtle + "!";
                TurtleImage.Source = turtle.ToString().ToLower() + ".png";
                TurtleName.Text = turtle;
            }

            await DisplayAlert(title, msg, "OK");
        }
    }
}
