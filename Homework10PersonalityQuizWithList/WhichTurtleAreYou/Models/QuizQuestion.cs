using System;
using System.Collections.Generic;

namespace WhichTurtleAreYou
{
    public class QuizQuestion
    {
        public string Question { get; private set; }
        public int Response { get; private set; }
        public int YesPoints { get; private set; }
        public int NoPoints { get; private set; }

        public static IList<QuizQuestion> All { get; set; }

        private QuizQuestion()
        {
        }

        public QuizQuestion(string question, int response, int yesPoints, int noPoints)
        {
            Question = question;
            Response = response;
            YesPoints = yesPoints;
            NoPoints = noPoints;
        }

        // Runs once at the beginning of the program
        static QuizQuestion ()
        {
            List<QuizQuestion> all = new List<QuizQuestion>
            {
                new QuizQuestion("You like cool intellectual colors, like blue and purple.", 0, 1, 3),
                new QuizQuestion("You like warm emotional colors, like red and orange.", 0, 4, 2),
                new QuizQuestion("You like sharp, pointy weapons.", 0, 1, 3),
                new QuizQuestion("You like impact weapons. Ooh. That's going to leave a mark.", 0, 2, 3),
                new QuizQuestion("You're going to have to get--sarcastic.", 0, 4, 1)

            };

            All = all;
        }

    }
}
