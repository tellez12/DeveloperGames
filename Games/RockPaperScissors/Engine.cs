using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperGames.Games.RockPaperScissors.TempImplementations;

namespace DeveloperGames.Games.RockPaperScissors
{
   public class Engine
    {
       GameResult StartGame(Player p1, Player p2)
       {
           IStrat p1Strat = LoadPlayerStrat(p1);
           IStrat p2Strat = LoadPlayerStrat(p1);
           var result = Simulate(p1Strat,p2Strat);
           return result;
       }

       private GameResult Simulate(IStrat p1Strat, IStrat p2Strat)
       {
           for (int round = 0; round < Constants.Rounds; round++)
           {
               
           }
           return new  GameResult();
       }

       private IStrat LoadPlayerStrat(Player player)
       {
           if (player.Id == 1)
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

    public class Player
    {
        public int Id { get; set; }
        public string NickName { get; set; }
    }
}
