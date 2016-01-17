using System.Collections.Generic;
using BrokenShoeLeague.Domain.Enums;

namespace BrokenShoeLeague.Domain.DefaultAchievements
{
    public abstract class BaseAchievement
    {
        public abstract string Name { get; }

        public abstract string IconName { get; }

        public abstract string Description { get; }

        public abstract string Text(string username);

        public abstract bool MatchCondition(IEnumerable<PlayerRecord> stats);

        public abstract AchievementType Type { get; }
    }
}