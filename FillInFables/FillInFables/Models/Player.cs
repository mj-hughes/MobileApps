using SQLite;
namespace FillInFables.Models
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }

    }
}
