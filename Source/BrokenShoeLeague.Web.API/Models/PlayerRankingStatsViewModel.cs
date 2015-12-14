using BrokenShoeLeague.Domain;

namespace BrokenShoeLeague.Web.API.Models
{
    public class PlayerRankingStatsViewModel
    {
        public PlayerRankingStatsViewModel()
        {
            
        }

        public PlayerRankingStatsViewModel(PlayerRecord playerRecord)
        {
            PlayerName = playerRecord.Player.Name;
            ImageUrl = playerRecord.Player.ImageProfileUrl;
            Performance = playerRecord.Performance;
            Won = playerRecord.Won;
            Lost = playerRecord.Lost;
            Tied = playerRecord.Tied;
            Goals = playerRecord.Goals;
            Assists = playerRecord.Assists;
        }

        public string PlayerName { get; set; }
        public string ImageUrl { get; set; }
        public double Performance { get; set; }
        public int Won { get; set; }
        public int Lost { get; set; }
        public int Tied { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
    }
}