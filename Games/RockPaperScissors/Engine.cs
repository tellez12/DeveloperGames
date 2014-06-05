using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperGames.Games.RockPaperScissors.TempImplementations;

namespace DeveloperGames.Games.RockPaperScissors
{
   public class Engine:IEngine
    {
       public GameResult StartGame(User u1, User u2)
       {
           IStrat u1Strat = LoadPlayerStrat(u1);
           IStrat u2Strat = LoadPlayerStrat(u2);
           Player player1 = new Player(u1);
           Player player2 = new Player(u2);
           var result = new GameResult();
          
           for (int round = 0; round < Constants.Rounds; round++)
           {
               Move m1 = u1Strat.GetMove(player1, player2);
               Move m2 = u1Strat.GetMove(player2, player1);
               RoundResult roundResult = Compare(m1, m2);
               

               player1.LastMove = m1;
               player2.LastMove = m2;
              
           }
           

           return result;
       }

       private RoundResult Compare(Move m1, Move m2)
       {
           throw new NotImplementedException();
       }

       private IStrat LoadPlayerStrat(User user)
       {
           if (user.Id == 1)
           {
               return new Implementation1();
           }
           else
           {
               return new Implementation2();
           }
       }
    }

    public class GameResult
    {
        
    }

    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
    }

    public class Player :User
    {
        public Player(User user)
        {
            Id = user.Id;
            NickName = user.NickName;
        }
        public Move? LastMove { get; set; }
        public int RoundsWon { get; set; }
        public int RoundsTied { get; set; }
        public int RoundsLost { get; set; }

    }

    public enum RoundResult
    {

    }

}
