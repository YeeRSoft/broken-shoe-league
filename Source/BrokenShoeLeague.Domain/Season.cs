using System.Collections.Generic;

namespace BrokenShoeLeague.Domain
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Matchday> MatchDays { get; set; }
    }
}
