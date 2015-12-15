using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokenShoeLeague.Domain;
using BrokenShoeLeague.Services.Seasons.Models;

namespace BrokenShoeLeague.Services.Seasons
{
    public interface ISeasonStatsProvider
    {
        IQueryable<PlayerStats> GetSeasonRanking(int seasonId);
        IQueryable<PlayerStats> GetSeasonTopScorers(int seasonId);
        IQueryable<PlayerStats> GetSeasonTopAssists(int seasonId);
    }
}
