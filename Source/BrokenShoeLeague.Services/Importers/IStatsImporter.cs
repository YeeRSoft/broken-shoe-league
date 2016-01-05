using BrokenShoeLeague.Services.Seasons.Models;

namespace BrokenShoeLeague.Services.Importers
{
    public interface IStatsImporter
    {
        PlayerStats[] GetStats(string path);
    }
}
