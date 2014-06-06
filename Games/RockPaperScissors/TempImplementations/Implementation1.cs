using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperGames.Games.RockPaperScissors.TempImplementations
{
   public class Implementation1:IStrat
    {
       //Progression
       public Move GetMove(Player me, Player opponent)
       {
           if (me.LastMove == Move.Rock)
               return Move.Paper;
           else if (me.LastMove == Move.Paper)
               return Move.Scissors;
           else
               return Move.Rock;

           
       }
    }
}
