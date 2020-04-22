using SQLite;

namespace Code11JokesDatabase
{
    public class Joke
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string JokeSetup { get; set; }
        public string Punchline { get; set; }

    }
}
