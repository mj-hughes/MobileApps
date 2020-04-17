using System.Collections.Generic;

namespace WhichTurtleAreYou
{
    public class Turtles
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public static IList<Turtles> All { get; set; }

        public Turtles()
        {

        }

        public Turtles(string name, int points)
        {
            Name = name;
            Points = points;
        }

        static Turtles()
        {
            List<Turtles> all = new List<Turtles>
            {
                new Turtles("Leonardo", 0),
                new Turtles("Donatello", 0),
                new Turtles("Michelangelo", 0),
                new Turtles("Raphael", 0)
            };

            All = all;
        }

        public static void ResetPoints()
        {
            foreach (Turtles t in Turtles.All)
            {
                t.Points = 0;
            }
        }
    }
}
