using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperGames.Domain.Entities
{
   public class Game
   {
       public int Id { get; set; }
       public String Name { get; set; }
       public bool Active { get; set; }
   }
}
