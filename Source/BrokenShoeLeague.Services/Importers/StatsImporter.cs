using System;
using System.Collections.Generic;
using System.IO;
using BrokenShoeLeague.Domain;
using BrokenShoeLeague.Services.Helpers;
using BrokenShoeLeague.Services.Seasons.Models;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace BrokenShoeLeague.Services.Importers
{
    public class StatsImporter : IStatsImporter
    {
        public PlayerStats[] GetStats(string path)
        {
            var stats = new List<PlayerStats> { };

            foreach (var line in Common.ParseCsv(path))
            {
                if (line[1] == "" || line[1] == "0")
                    continue;

                var stat = new PlayerStats
                {
                    Wins = int.Parse(line[2]),
                    Draws = int.Parse(line[3]),
                    Losts = int.Parse(line[4]),
                    Goals = int.Parse(line[5]),
                    Assists = int.Parse(line[6]),
                };
                if (stat.IsValid())
                    stats.Add(stat);
                else
                    throw new Exception(string.Format("The stats of {0} are invalid: {1}!={2}+{3}+{4}", stat.PlayerName, stat.PlayedGames, stat.Wins, stat.Draws, stat.Losts));
            }

            return stats.ToArray();
        }
    }
}
