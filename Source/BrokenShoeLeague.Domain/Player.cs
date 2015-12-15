using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BrokenShoeLeague.Domain
{
    public class Player
    {
        public Player()
        {
            PlayerRecords = new List<PlayerRecord>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string  ImageProfileUrl { get; set; }
        public virtual IList<PlayerRecord> PlayerRecords { get; set; }
        public bool Enabled { get; set; }
        public int TopPlayer
        {
            get
            {
                return PlayerRecords.Count(pRecord => pRecord.Performance == pRecord.Matchday.TopPerformance);
            }
        }
        public double CalculatePerformance(int seasonId = 0)
        {
            return Utils.CalculatePerformance(seasonId <= 0 ? PlayerRecords : PlayerRecords.Where(x => x.Matchday.Season.Id == seasonId));
        }

        public int MVPs
        {
            get
            {
                return PlayerRecords.Count(x => Math.Abs(x.Performance - x.Matchday.PlayerStats.Max(ps => ps.Performance)) < 0.0001);
            }
        }
        public double AveragePerformance
        {
            get { return PlayerRecords.Any() ? PlayerRecords.Average(x => x.Performance) : 0; }
        }

        public void Update(string name, string imageProfileUrl, bool enabled)
        {
            Name = name;
            ImageProfileUrl = imageProfileUrl;
            Enabled = enabled;
        }
    }
}
