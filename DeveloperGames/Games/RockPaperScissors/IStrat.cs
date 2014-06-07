using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperGames.Games.RockPaperScissors
{
    public interface IStrat
    {

        Move GetMove(Player player1, Player player2);
    }
}
