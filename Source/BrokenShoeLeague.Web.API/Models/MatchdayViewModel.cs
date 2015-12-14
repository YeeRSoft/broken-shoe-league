using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrokenShoeLeague.Domain;

namespace BrokenShoeLeague.Web.API.Models
{
    public class MatchdayViewModel
    {
        public MatchdayViewModel(Matchday matchday)
        {
            Date =matchday.Date;
            Number = matchday.Number;
            PlayerStats = matchday.PlayerStats.Select(x => new PlayerRankingStatsViewModel(x));
        }

        public IEnumerable<PlayerRankingStatsViewModel> PlayerStats { get; set; }

        public DateTime Date { get; set; }
        public int Number { get; set; }
    }
}