using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokenShoeLeague.Domain.Enums;

namespace BrokenShoeLeague.Domain.DefaultAchievements
{
    public class MatchdayLeader : BaseAchievement
    {
        public override string Name
        {
            get { return "Matchday Leader"; }
        }

        public override string Description
        {
            get
            {
                return "Earn this achievement being the best player on a single matchday this in the current season";
            }
        }

        public override string IconName
        {
            get
            {
                return "sportive54.svg";
            }
        }

        public override bool MatchCondition(IEnumerable<PlayerRecord> stats)
        {
            throw new NotImplementedException();
        }

        public override string Text(string username)
        {
            return string.Format("{0} earn the achivement: 'Matchday Leader'");
        }

        public override AchievementType Type
        {
            get { return AchievementType.SingleSeason; }
        }
    }
}
