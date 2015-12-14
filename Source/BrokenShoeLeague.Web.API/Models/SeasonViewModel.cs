using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BrokenShoeLeague.Domain;

namespace BrokenShoeLeague.Web.API.Models
{
    public class SeasonViewModel
    {
        public SeasonViewModel()
        {
            
        }

        public SeasonViewModel(Season season)
        {
            Name = season.Name;
            StartDate = season.StartDate;
            EndDate = season.EndDate;
            Matchdays = season.Matchdays.Select(x => new MatchdayViewModel(x));
        }

        public DateTime EndDate { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        public IEnumerable<MatchdayViewModel> Matchdays { get; set; }
        [Required]
        public string Name { get; set; }
    }
}