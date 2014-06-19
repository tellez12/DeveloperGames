using DeveloperGames.Games.RockPaperScissors;


   public class Test:IStrat
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

   public class Test2 : IStrat
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
               case Move.Scissors:
                   return Move.Rock;
               default:
                   return Move.Scissors;
           }
       }
   }