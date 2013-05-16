using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            Console.Write("Welcome to \"Battle Field\" game.\nEnter battle type size: n = ");
            int.TryParse(Console.ReadLine(), out n);
            while (n < 1 || n > 10)
            {
                Console.Write("n is between 1 and 10! Please enter new n = ");
                int.TryParse(Console.ReadLine(), out n);
            }
            GameEngine gamePlay = new GameEngine(n);
            gamePlay.MakeATurn();
        }
    }
}
