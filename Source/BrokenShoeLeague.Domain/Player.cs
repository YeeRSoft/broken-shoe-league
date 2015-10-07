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
                return PlayerRecords.Count(pRecord => pRecord.Performance == pRecord.MatchDay.TopPerformance);
            }
        }
        public double Performance
        {
            get { return Utils.CalculatePerformance(this); }
        }
        public int MVPs
        {
            get
            {
                return PlayerRecords.Count(x => Math.Abs(x.Performance - x.MatchDay.PlayerStats.Max(ps => ps.Performance)) < 0.0001);
            }
        }
        public double AveragePerformance
        {
            get { return PlayerRecords.Any() ? PlayerRecords.Average(x => x.Performance) : 0; }
        }
    }
}
