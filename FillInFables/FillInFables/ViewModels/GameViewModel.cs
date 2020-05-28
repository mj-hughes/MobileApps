using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FillInFables.Models;

namespace FillInFables
{
    public class GameViewModel
    {
        public string Title { get; set; }
        public string Blank { get; set; }
        public string Answer { get; set; }
        public string Value { get; set; }

        public ObservableCollection<GameViewModel> gameViewModel { get; set; }
        public static IList<GameViewModel> All { get; private set; }

        public GameViewModel() { }
        public GameViewModel(string title, string blank, string answer, string value)
        {
            Title = title;
            Blank = blank;
            Answer = answer;
            Value = value;
        }
        public List<GameViewModel> AddMadLibz(MadLibz madLibz)
        {
            List<GameViewModel> all = new List<GameViewModel>();

            // create arrays
            for (int i = 0; i < madLibz.blanks.Length; i++)
            {
                GameViewModel gvm = new GameViewModel(madLibz.title,
                    madLibz.blanks[i],
                    "",
                    madLibz.value[i].ToString());
                all.Add(gvm);

            }

            return all;

        }

        static GameViewModel()
        {
            List<GameViewModel> All = new List<GameViewModel>();
        }
    }
}
