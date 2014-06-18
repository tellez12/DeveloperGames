using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperGames.Domain.Entities
{
    public class MatchResult
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public ApplicationUser User1 { get; set; }
        public int User1Score { get; set; }
        public ApplicationUser User2 { get; set; }
        public int User2Score { get; set; }
    }
}
