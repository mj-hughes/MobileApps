using System.ComponentModel;
using System.Collections.Generic;

namespace WhichTurtleAreYou
{
    class QuizDataViewModel : INotifyPropertyChanged
    {

        public static IList<QuizQuestion> All { private set; get; }
        int index=0;
        static int[] turtles = new int[4];

        // The property changed event handler is for both question changes and command changes
        public event PropertyChangedEventHandler PropertyChanged;

        public List<QuizQuestion> all
        {
            private set
            {
                if (all != value)
                {
                    all = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("All"));
                }
            }
            get
            {
                return all;
            }
        }


        // Constructor
        public QuizDataViewModel() { }

        static QuizDataViewModel()
        {
            // Create the list of questions
            List<QuizQuestion> all = new List<QuizQuestion>
            {
                new QuizQuestion("You like cool intellectual colors, like blue and purple.", "",0),
                new QuizQuestion("You like warm emotional colors, like red and orange.", "", 1),
                new QuizQuestion("You like sharp, pointy weapons.", "", 2),
                new QuizQuestion("You like impact weapons. Ooh. That's going to leave a mark.", "", 3),
                new QuizQuestion("You're going to have to get--sarcastic.", "", 4)
            };
            All = all;

        }

        public static void SetResponse(int qNum, string resp)
        {

            All[qNum].UpdateResponse(resp);
        }

        public static string getWinner()
        {
            // Check that all the questions have been answered
            if (AllQuestionsAnswered())
            {
                Turtles turtle = nameResult();
                ClearResponses();

                return turtle.ToString();
            }
            else
            {
                return "";
            }
        }

        private static bool AllQuestionsAnswered()
        {
            bool done = true;
            foreach (var q in All)
            {
                if (q.Response == "")
                    done = false;
            }
            return done;
        }

        private static void ClearResponses()
        {
            foreach (var q in All)
            {
                q.UpdateResponse("");
            }
        }

        private static Turtles nameResult()
        {

           for (int i = 0; i < All.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        // Question 1
                        if (All[i].Response == "Y")
                        {
                            turtles[(int)Turtles.Leonardo] += 2;
                            turtles[(int)Turtles.Donatello] += 2;
                        }
                        else
                        {
                            turtles[(int)Turtles.Michelangelo]++;
                            turtles[(int)Turtles.Raphael]++;
                        }
                        break;
                    case 1:
                        // Question 2
                        if (All[i].Response == "Y")
                        {
                            turtles[(int)Turtles.Michelangelo] += 2;
                            turtles[(int)Turtles.Raphael] += 2;
                        }
                        else
                        {
                            turtles[(int)Turtles.Leonardo]++;
                            turtles[(int)Turtles.Donatello]++;
                        }
                        break;
                    case 2:
                        // Question 3
                        if (All[i].Response == "Y")
                        {
                            turtles[(int)Turtles.Leonardo] += 2;
                            turtles[(int)Turtles.Raphael] += 2;
                        }
                        else
                        {
                            turtles[(int)Turtles.Donatello]++;
                            turtles[(int)Turtles.Michelangelo]++;
                        }
                        break;
                    case 3:
                        // Question 4
                        if (All[i].Response == "Y")
                        {
                            turtles[(int)Turtles.Donatello] += 2;
                            turtles[(int)Turtles.Michelangelo] += 2;
                        }
                        else
                        {
                            turtles[(int)Turtles.Leonardo]++;
                            turtles[(int)Turtles.Raphael]++;
                        }
                        break;
                    case 4:
                        // Question 5
                        if (All[i].Response == "Y")
                        {
                            turtles[(int)Turtles.Raphael] += 4;
                        }
                        else
                        {
                            turtles[(int)Turtles.Leonardo]++;
                        }
                        break;

                }

            }

            // Find out which turtle has the highest score
            int turtleScore = turtles[0];
            int turtle = 0;
            turtles[0] = 0;
            for (int i = 1; i < turtles.Length; i++)
            {
                if (turtles[i] > turtleScore)
                {
                    turtleScore = turtles[i];
                    turtle = i;
                }
                // Reinitialize for another run
                turtles[i] = 0;
            }

            return(Turtles)turtle;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
