using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperGames.Games.RockPaperScissors.TempImplementations;

namespace DeveloperGames.Games.RockPaperScissors
{
    public class Engine : IEngine
    {
        public GameResult StartGame(User u1, User u2)
        {
            var u1Strat = StratManager.LoadPlayerStrat(u1);
            var u2Strat = StratManager.LoadPlayerStrat(u2);
            var player1 = new Player(u1);
            var player2 = new Player(u2);
            var result = new GameResult();
            var tieBonus = 0;

            for (var round = 0; round < Constants.Rounds; round++)
            {
                var m1 = u1Strat.GetMove(player1, player2);
                var m2 = u2Strat.GetMove(player2, player1);
                m1 = ValidateMove(ref player1, m1);
                m2 = ValidateMove(ref player2, m2);
                
                var roundResult = Compare(m1, m2);
                switch (roundResult)
                {
                    case RoundResult.Tie:
                        player1.RoundsTied++;
                        player1.RoundsTied++;
                        tieBonus++;
                        break;
                    case RoundResult.Win:
                        player1.RoundsWon= player1.RoundsWon + 1 + tieBonus;
                        player2.RoundsLost++;
                        tieBonus = 0;
                        break;
                    default:
                        player1.RoundsLost++;
                        player2.RoundsWon = player2.RoundsWon + 1 + tieBonus;
                        tieBonus = 0;
                        break;
                }
                player1.LastMove = m1;
                player2.LastMove = m2;

            }
            result.Player1Score = player1.RoundsWon;
            result.Player2Score = player2.RoundsWon;

            return result;
        }

        private Move ValidateMove(ref Player player, Move m1)
        {
            if (m1 != Move.Dynamite)
                return m1;

            if (player.DynamiteLeft == 0)
                return Move.Invalid;

            player.DynamiteLeft--;
            return m1;
        }
        //Return the Round result for the first player. 
        private RoundResult Compare(Move m1, Move m2)
        {
            if (m1 == m2)
                return RoundResult.Tie;

            if (m1 == Move.Invalid)
                return RoundResult.Loss;
            if (m2 == Move.Invalid)
                return RoundResult.Win;
            //Dynamite win against anything but WaterBallon
            if (m1 == Move.Dynamite)
                return m2 != Move.WaterBalloon ? RoundResult.Win : RoundResult.Loss;

            //Water Ballon only win against Dynamite
            if (m1 == Move.WaterBalloon)
                return m2 != Move.Dynamite ? RoundResult.Loss : RoundResult.Win;
            if (m1 == Move.Rock)
                return m2 == Move.Scissors ? RoundResult.Win : RoundResult.Loss;
            if (m1 == Move.Paper)
                return m2 == Move.Rock ? RoundResult.Win : RoundResult.Loss;
            if (m1 == Move.Scissors)
                return m2 == Move.Paper ? RoundResult.Win : RoundResult.Loss;

            return RoundResult.Tie;
        }

    }

    public class GameResult
    {
        public int Player1Score { get; set; }
        public String Player1Log { get; set; }
        public int Player2Score { get; set; }
        public String Player2Log { get; set; }

    }

    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public StringBuilder GameLog { get; set; }

        public string StratCode { get; set; }
    }

    public class Player : User
    {
        public Player(User user)
        {
            Id = user.Id;
            NickName = user.NickName;
            DynamiteLeft = Constants.NDynamite;
            GameLog= new StringBuilder();
        }
        public Move? LastMove { get; set; }
        public int RoundsWon { get; set; }
        public int RoundsTied { get; set; }
        public int RoundsLost { get; set; }


        public int DynamiteLeft { get; set; }
    }

    public enum RoundResult
    {
        Tie,
        Win,
        Loss
    }

}
