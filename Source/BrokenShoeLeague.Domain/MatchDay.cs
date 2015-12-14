using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BrokenShoeLeague.Domain
{
    public class Matchday
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        public virtual IList<PlayerRecord> PlayerStats { get; set; }
        public virtual IList<ImageCarousel> MatchdayImages { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Season Season{ get; set; }

        /// <summary>
        /// retrieve the player with the higher performance on this matchday
        /// </summary>
        public double TopPerformance
        {
            get { return PlayerStats.Max(x => x.Performance); }
        }
    }
}
