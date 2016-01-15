using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokenShoeLeague.Domain.Enums;

namespace BrokenShoeLeague.Domain.Interfaces.Common
{
    public interface IAchievement
    {
        string GetName();
        string GetIconName();
        string Text(string username);
        bool MatchCondition(IEnumerable<PlayerRecord> stats);
    }
}