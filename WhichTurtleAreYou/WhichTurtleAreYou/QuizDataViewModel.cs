using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace WhichTurtleAreYou
{
    class QuizDataViewModel : INotifyPropertyChanged
    {

        public static IList<QuizQuestion> All { private set; get; }
        int index=0;
        int[] turtles = new int[4];
        private string newQuestion;
        private string turtleImage;

        // The property changed event handler is for both question changes and command changes
        public event PropertyChangedEventHandler PropertyChanged;
        // The Command property is only for the commands (True/False)
        public ICommand TFResponse { protected set; get; }

        // Constructor
        public QuizDataViewModel()
        {
            // Create the list of questions
            All = new List<QuizQuestion>
            {
                new QuizQuestion("You like cool intellectual colors, like blue and purple."),
                new QuizQuestion("You like warm emotional colors, like red and orange."),
                new QuizQuestion("You like sharp, pointy weapons."),
                new QuizQuestion("You like impact weapons. Ooh. That's going to leave a mark."),
                new QuizQuestion("You're going to have to get--sarcastic.")
            };
            // Set the initial question and image
            newQuestion = All[index].Question;
            turtleImage ="tmnt.png";

            // Instantiate the True/False command. Set to invalid if no more questions.
            TFResponse = new Command<string>((key) =>
            {
                int resp;
                if (key=="True")
                {
                    resp = 1;
                    yes();
                }
                else
                {
                    resp = 0;
                    no();
                }
                if (index < All.Count)
                {
                    All[index].Response = resp;

                }
                nextQuestion();
            },
            (key)=>
                {
                    return index > All.Count-1 ? false : true;
                });
        }

        private void yes()
        {
            // Changing TurtleImage and not turtleImage because changing via code.
            // Otherwise the user would change it and the turtleImage would be the code behind
            TurtleImage = "yesturtle.png";
        }

        private void no()
        {
            TurtleImage = "noturtle.png";
        }

        public string TurtleImage
        {
            protected set
            {
                if (turtleImage != value)
                {
                    turtleImage = value;
                    OnPropertyChanged("TurtleImage");
                }
            }
            get { return turtleImage;  }
        }

        public string NewQuestion
        {
            protected set
            {
                if (newQuestion != value)
                {
                    newQuestion = value;
                    OnPropertyChanged("NewQuestion");
                }
            }
            get { return newQuestion; }
        }


        // Advance to the next question. If out of questions, determine personality.
        public void nextQuestion()
        {
            if (index<All.Count-1)
            {
                // This changes the value of NewQuestion but not NewQuestion, which changes in the setter, triggering the PropertyChanged.
                NewQuestion = All[++index].Question;

            }
            else
            {
                index++;
                NewQuestion = "You're " + nameResult().ToString() + "!";
                ((Command)TFResponse).ChangeCanExecute();

            }
        }

        public Turtles nameResult()
        {

           for (int i = 0; i < All.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        // Question 1
                        if (All[i].Response == 1)
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
                        if (All[i].Response == 1)
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
                        if (All[i].Response == 1)
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
                        if (All[i].Response == 1)
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
                        if (All[i].Response == 1)
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
            
            for (int i = 1; i < turtles.Length; i++)
            {
                if (turtles[i] > turtleScore)
                {
                    turtleScore = turtles[i];
                    turtle = i;
                }
            }

            return(Turtles)turtle;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
