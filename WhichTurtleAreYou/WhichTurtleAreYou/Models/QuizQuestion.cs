using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace WhichTurtleAreYou
{
    public class QuizQuestion : INotifyPropertyChanged
    {
        public string Question { get; set; }
        public int QuestionNum { get; set; }
        string response { get; set; }
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

        public event PropertyChangedEventHandler PropertyChanged;

        private QuizQuestion()
        {
        }

        public QuizQuestion(string q, string response, int qNum)
        {
            this.Question = q;
            this.Response = response;
            this.QuestionNum = qNum;
        }

        public void UpdateResponse(string resp)
        {
            Response = resp;
        }
    }
}
