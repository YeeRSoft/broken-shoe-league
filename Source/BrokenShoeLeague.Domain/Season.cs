using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrokenShoeLeague.Domain
{
    public class Season
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Matchday> Matchdays { get; set; }

        public void Update(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
