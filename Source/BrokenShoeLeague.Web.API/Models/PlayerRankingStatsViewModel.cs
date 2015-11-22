namespace BrokenShoeLeague.Web.API.Models
{
    public class PlayerRankingStatsViewModel
    {
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