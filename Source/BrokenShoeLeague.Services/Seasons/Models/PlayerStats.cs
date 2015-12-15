namespace BrokenShoeLeague.Services.Seasons.Models
{
    public class PlayerStats
    {
        public int PlayerId { get; set; }
        public int PlayerName { get; set; }
        public int PlayedGames { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losts { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int AllowedGoals { get; set; }
        public double Performance { get; set; }
    }
}
