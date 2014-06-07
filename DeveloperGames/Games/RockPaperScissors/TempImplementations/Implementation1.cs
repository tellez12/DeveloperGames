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
           switch (me.LastMove)
           {
               case Move.Rock:
                   return Move.Paper;
               case Move.Paper:
                   return Move.Scissors;
               default:
                   return Move.Rock;
           }
       }
    }
}
