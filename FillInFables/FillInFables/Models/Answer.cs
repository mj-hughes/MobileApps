using System;
namespace FillInFables.Models
{
    public class Answer
    {
        public string[] answers { get; set; }

        public Answer(int i)
        {
            answers = new string[i];
        }
    }
}
