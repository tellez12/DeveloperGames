using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperGames.Domain.Entities
{
    public class MatchResult
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public string User1Id { get; set; }

        [ForeignKey("User1Id")]
        public ApplicationUser User1 { get; set; }
        public int User1Score { get; set; }
        public string User2Id { get; set; }

        [ForeignKey("User2Id")]
        public ApplicationUser User2 { get; set; }
        public int User2Score { get; set; }
    }
}
