using System;
namespace BrokenShoeLeague.Services.Seasons.Models
{
    public class PlayerStats
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        public int PlayedGames
        {
            get { return Wins + Draws + Losts; }
        }

        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losts { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int AllowedGoals { get; set; }
        public double Performance { get; set; }

        //It checks the performance of a player in a MatchDay is valid
        public bool IsValid()
        {
            if (PlayedGames != Wins + Draws + Losts)
                return false;
            if (2 * PlayedGames < Goals)
                return false;
            return true;
        }
    }
}
