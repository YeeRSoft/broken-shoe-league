using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokenShoeLeague.Services.Achievement.Models
{
    public class AchievementWrapper
    {
        public AchievementWrapper()
        {
            
        }

        public AchievementWrapper(string name, string imageUrl)
        {
            Name = name;
            ImageUrl = imageUrl;
        }

        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
