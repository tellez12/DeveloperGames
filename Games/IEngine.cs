using DeveloperGames.Games.RockPaperScissors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperGames.Games
{
    public interface IEngine
    {
        GameResult StartGame(User p1, User p2);
    }
}
