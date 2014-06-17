using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperGames.Domain.Entities
{
    public class MatchResult
    {
        public ApplicationUser Winner { get; set; }
        public ApplicationUser Loser { get; set; }

        public int WinnerScore { get; set; }
    }
}
