namespace WpfApp1.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public int GenreID { get; set; }
        public float Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Platform { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
