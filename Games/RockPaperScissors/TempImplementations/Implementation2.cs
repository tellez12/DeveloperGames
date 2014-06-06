using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperGames.Games.RockPaperScissors.TempImplementations
{
    public class Implementation2 : IStrat
    {
        public Random MyRandom { get; set; }
        public Implementation2()
        {
            MyRandom = new Random();
        }
        //Random All moves
        public Move GetMove(Player player1, Player player2)
        {
            Array values = Enum.GetValues(typeof(Move));
            Random random = new Random();
            Move randomBar = (Move)values.GetValue(random.Next(values.Length));
            return randomBar;

            
        }
    }
}
