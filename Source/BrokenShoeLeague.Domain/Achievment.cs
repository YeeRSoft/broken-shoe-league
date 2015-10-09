using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokenShoeLeague.Domain
{
    public class Achievment
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string IconName { get; set; }
    }
}
