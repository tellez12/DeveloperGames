using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperGames.Domain.Entities
{
    public class Leaderboard
    {
        public int Id { get; set; }
        public string Name { get;  set; }
        public string Code { get; set; }

        public bool IsPrivate { get; set; }
        public DateTime CreatedDate { get; set; }
     
    }
}
