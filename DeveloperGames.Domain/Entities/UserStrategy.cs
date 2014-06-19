using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperGames.Domain.Entities
{
    public class UserStrategy
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
        [StringLength(8000)] 
        public String UserCode { get; set; }

    }
}
