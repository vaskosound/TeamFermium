using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    class MinesDemonstration
    {
        static void Main(string[] args)
        {
            GameEngine gamePlay = new GameEngine();
            gamePlay.initiateGame();
        }
    }
}
