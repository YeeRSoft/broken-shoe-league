using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokenShoeLeague.Services.Achievement.Models;

namespace BrokenShoeLeague.Services.Achievement
{
    public class AchivementProviderService : IAchivementProviderService
    {
        public IEnumerable<AchievementWrapper> GetAchievements()
        {
            return Enumerable.Empty<AchievementWrapper>();
        }
    }
}
