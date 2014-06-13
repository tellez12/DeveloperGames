using DeveloperGames.Games;
using DeveloperGames.Games.RockPaperScissors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSimulateClick(object sender, EventArgs e)
        {
            string code = TxtCodeSource.Text;

            var users = new List<User>
                           {
                               new User {Id = 1, NickName = "Progression"},
                               new User {Id = 3, NickName = "TestRandom", StratCode = code}
                           };
            {
                IEngine engine = new Engine();
                var result = engine.StartGame(users[0], users[1]);
                User winner;
                int winnerScore;
                User loser;
                int loserScore;

                if (result.Player1Score > result.Player2Score)
                {
                    winner = users[0];
                    winnerScore = result.Player1Score;
                    loser = users[1];
                    loserScore = result.Player2Score;
                }
                else//else if(result.Player1Score < result.Player2Score)
                {
                    winner = users[1];
                    winnerScore = result.Player2Score;
                    loser = users[0];
                    loserScore = result.Player1Score;
                }
                TxtResults.Text = String.Format("The winner of the match was {0} with {1} points over {2} scored by {3}", winner.NickName, winnerScore, loser.NickName, loserScore);
            }


        }
    }
}
