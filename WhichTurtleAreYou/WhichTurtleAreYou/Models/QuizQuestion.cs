using System;
namespace WhichTurtleAreYou
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public int Response { get; set; }

        public QuizQuestion()
        {
        }

        public QuizQuestion(string q)
        {
            this.Question = q;
            this.Response = -1;
        }
    }
}
