using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BrokenShoeLeague.Services.Achievement.Models;

namespace BrokenShoeLeague.Services.Achievement
{
    public class AchivementProviderService : IAchivementProviderService
    {
        public IEnumerable<AchievementWrapper> GetAchievements()
        {
            var result = new List<AchievementWrapper>();

            var achievementsAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes()).Where(t => t.BaseType == typeof(Domain.DefaultAchievements.BaseAchievement)).ToList();

            foreach (var achievementsAssembly in achievementsAssemblies)
            {
                var instance = (Domain.DefaultAchievements.BaseAchievement)Activator.CreateInstance(achievementsAssembly);
                result.Add(new AchievementWrapper(instance.Name, instance.IconName));
            }
            return result;
        }
    }
}
