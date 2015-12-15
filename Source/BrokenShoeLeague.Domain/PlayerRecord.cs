
namespace BrokenShoeLeague.Domain
{
    public class PlayerRecord
    {
        public int Id { get; set; }
        public int PlayedGames { get; set; }
        public int Won { get; set; }
        public int Tied { get; set; }
        public int Lost { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public virtual Player Player { get; set; }
        public int PlayerId { get; set; }
        public int AllowedGoals { get; set; }
        public virtual Matchday Matchday { get; set; }
        public int MatchdayId { get; set; }
        public double Performance
        {
            get { return Utils.CalculatePerformance(this); }
        }
    }
}
