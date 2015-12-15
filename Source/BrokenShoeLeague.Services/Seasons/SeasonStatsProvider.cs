using System.Linq;
using BrokenShoeLeague.Services.Seasons.Models;

namespace BrokenShoeLeague.Services.Seasons
{
    public class SeasonStatsProvider : ISeasonStatsProvider
    {
        public IQueryable<PlayerStats> GetSeasonRanking(int seasonId)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<PlayerStats> GetSeasonTopScorers(int seasonId)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<PlayerStats> GetSeasonTopAssists(int seasonId)
        {
            throw new System.NotImplementedException();
        }
    }
}
