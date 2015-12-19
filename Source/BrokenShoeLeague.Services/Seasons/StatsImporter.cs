using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using BrokenShoeLeague.Services.Seasons.Models;

namespace BrokenShoeLeague.Services.Seasons
{
    public class StatsImporter : IStatsImporter
    {
        public PlayerStats[] GetStats(string path)
        {
            List<PlayerStats> stats = new List<PlayerStats> { };

            using (var parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                bool hasHeader = true;
                if (hasHeader)
                    parser.ReadLine();
                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();
                    if (fields != null)
                    {
                        if (fields[1] != "" && fields[1] != "0")
                        {
                            var toAdd = GetStatsLine(fields);
                            if (toAdd.IsValid())
                                stats.Add(toAdd);
                            else
                            {
                                Console.WriteLine("Invalid stats");
                                throw new Exception(String.Format("The stats of {0} are invalid: {1}!={2}+{3}+{4}", toAdd.PlayerName, toAdd.PlayedGames, toAdd.Wins, toAdd.Draws, toAdd.Losts));
                            }
                        }
                    }
                }
            }

            return stats.ToArray();
        }

        static PlayerStats GetStatsLine(string[] line)
        {
            PlayerStats p1 = new PlayerStats()
            {
                PlayerName = line[0],
                PlayedGames = int.Parse(line[1])
            };

            int temp = 0;

            if (int.TryParse(line[2], out temp))
                p1.Wins = temp;
            else
                p1.Wins = 0;

            if (int.TryParse(line[3], out temp))
                p1.Draws = temp;
            else
                p1.Draws = 0;

            if (int.TryParse(line[4], out temp))
                p1.Losts = temp;
            else
                p1.Losts = 0;

            if (int.TryParse(line[5], out temp))
                p1.Goals = temp;
            else
                p1.Goals = 0;

            if (int.TryParse(line[6], out temp))
                p1.Assists = temp;
            else
                p1.Assists = 0;

            p1.CalculatePerformance();

            return p1;
        }
    }
}
