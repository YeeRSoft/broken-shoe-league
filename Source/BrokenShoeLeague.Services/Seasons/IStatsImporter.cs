using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokenShoeLeague.Services.Seasons.Models;

namespace BrokenShoeLeague.Services.Seasons
{
    public interface IStatsImporter
    {
        PlayerStats[] GetStats(string path);
    }
}
