using System;
using System.Collections.Generic;
using FillInFables.Views;

namespace FillInFables
{
    public class PageDataViewModel
    {
        public Type Type { private set; get; }
        public string Title { private set; get; }
        public string Description { private set; get; }

        public static IList<PageDataViewModel> All { private set; get; }


        public PageDataViewModel(Type type, string title, string description)
        {
            Type = type;
            Title = title;
            Description = description;
        }

        static PageDataViewModel()
        {
            All = new List<PageDataViewModel>
            {
                new PageDataViewModel(typeof(PlayerPage), "Edit Player", "Create and edit a player"),
                new PageDataViewModel(typeof(GamePage), "Play Game", "Fill in these words to create a fun story")
            };
        }

    }

}
