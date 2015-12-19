using System;
namespace BrokenShoeLeague.Services.Seasons.Models
{
    public class PlayerStats
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int PlayedGames { get; set; }
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

        //Calculates the performance
        public void CalculatePerformance()
        {
            const double wGoals = 0.5;
            const double wAssists = 0.25;
            const double wWin = 0.2;
            const double wDraw = 1 / 15.0;
            const double wLost = 0.1;
            Performance = Math.Round((wWin * Wins + wDraw * Draws - wLost * Losts + wGoals * Goals + wAssists * Assists) / PlayedGames, 3);
        }
    }
}
