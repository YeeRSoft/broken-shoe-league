using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrokenShoeLeague.Domain;

namespace BrokenShoeLeague.Web.API.Models
{
    public class SeasonViewModel
    {
        public SeasonViewModel(Season season)
        {
            Name = season.Name;
            Matchdays = season.Matchdays.Select(x => new MatchdayViewModel(x));
        }

        public IEnumerable<MatchdayViewModel> Matchdays { get; set; }

        public string Name { get; set; }
    }
}