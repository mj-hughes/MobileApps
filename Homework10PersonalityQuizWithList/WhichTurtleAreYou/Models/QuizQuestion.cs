using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace WhichTurtleAreYou
{
    public class QuizQuestion : INotifyPropertyChanged
    {
        public string Question { get; private set; }
        public int QuestionNum { get; private set; }
        //  public string Response { get; private set; }
        string response;
        public int YesPoints { get; private set; }
        public int NoPoints { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Response
        {
            private set
            {
                if (response != value)
                {
                    response = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Response"));
                }
            }
            get
            {
                return response;
            }
        }

        public static IList<QuizQuestion> All { get; set; }

        private QuizQuestion()
        {
        }

        public QuizQuestion(string question, int questionNum, string response, int yesPoints, int noPoints)
        {
            Question = question;
            QuestionNum = questionNum;
            Response = response;
            YesPoints = yesPoints;
            NoPoints = noPoints;
        }

        // Runs once at the beginning of the program
        static QuizQuestion ()
        {
            List<QuizQuestion> all = new List<QuizQuestion>
            {
                new QuizQuestion("You like cool intellectual colors, like blue and purple.", 0, null, 1, 2),
                new QuizQuestion("You like warm emotional colors, like red and orange.", 1, null, 2, 0),
                new QuizQuestion("You like sharp, pointy weapons.", 2, null, 3, 1),
                new QuizQuestion("You like impact weapons. Ooh. That's going to leave a mark.", 3, null, 1, 3),
                new QuizQuestion("You're going to have to get--sarcastic.", 4, null, 3, 0),
                new QuizQuestion("You're a natural leader.", 5, null, 0, 2)

            };

            All = all;
        }

        public static Boolean AllQuestionsAnswered()
        {
            Boolean done = true;
            foreach (var q in QuizQuestion.All)
            {
                if (q.Response == null)
                    done=false;
            }

            return done;
        } 

        public static void SetResponse(int index, string response)
        {
            QuizQuestion.All[index].Response = response;
        }

        public static void ResetQuestions()
        {
            foreach (QuizQuestion q in QuizQuestion.All)
            {
                q.Response = null;
            }
        }

    }
}
