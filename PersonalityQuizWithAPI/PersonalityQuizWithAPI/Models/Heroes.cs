using System.Collections.Generic;

namespace PersonalityQuizWithAPI
{
    public class Heroes
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public string ApiId { get; set; }

        public static IList<Heroes> All { get; set; }

        public Heroes()
        {

        }

        public Heroes(string name, int points, string apiId)
        {
            Name = name;
            Points = points;
            ApiId = apiId;
        }

        static Heroes()
        {
            List<Heroes> all = new List<Heroes>
            {
                new Heroes("Captain America", 0, "1009220"), // or 1017327
                new Heroes("Iron Man", 0, "1009368"),
                new Heroes("Squirrel Girl", 0, "1010860"),
                new Heroes("Star-Lord", 0, "1010733")  
            };

            All = all;
        }

        public static void ResetPoints()
        {
            foreach (Heroes h in Heroes.All)
            {
                h.Points = 0;
            }
        }

    }
}
