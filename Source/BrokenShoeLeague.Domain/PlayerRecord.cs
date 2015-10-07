
namespace BrokenShoeLeague.Domain
{
    public class PlayerRecord
    {
        //public int JJP { get; set; } //TODO: what this fields is for?
        public int Id { get; set; }
        public int PlayedGames { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losts { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public virtual Player Player { get; set; }
        public int PlayerId { get; set; }
        public int AllowedGoals { get; set; }
        public virtual MatchDay MatchDay { get; set; }
        public int MatchDayId { get; set; }
        public double Performance
        {
            get { return Utils.CalculatePerformance(this); }
        }
    }
}
