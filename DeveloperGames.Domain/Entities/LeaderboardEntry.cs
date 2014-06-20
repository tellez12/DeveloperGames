using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperGames.Domain.Entities
{
    public class LeaderboardEntry
    {
        public int Id { get; set; }
        public string LeaderboardId { get; set; }

        [ForeignKey("LeaderboardId")]
        public Leaderboard Leaderboard { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }

        public int Wins { get; set; }

        public int Ties { get; set; }

        public int Losses { get; set; }

        [NotMapped]
        public int Points
        {
            get { return Wins*3 + Ties; }
           
        }
    }
}
