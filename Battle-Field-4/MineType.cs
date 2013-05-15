using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    public static class MineType
    {
        public static readonly int[,] minePowerOne = {{0,0,0,0,0},
                                                    {0,1,0,1,0},
                                                    {0,0,1,0,0},
                                                    {0,1,0,1,0},
                                                    {0,0,0,0,0}};
        public static readonly int[,] minePowerTwo = {{0,0,0,0,0},
                                                    {0,1,1,1,0},
                                                    {0,1,1,1,0},
                                                    {0,1,1,1,0},
                                                    {0,0,0,0,0}};
        public static readonly int[,] minePowerThree = {{0,0,1,0,0},
                                                    {0,1,1,1,0},
                                                    {1,1,1,1,1},
                                                    {0,1,1,1,0},
                                                    {0,0,1,0,0}};
        public static readonly int[,] minePowerFour = {{0,1,1,1,0},
                                                    {1,1,1,1,1},
                                                    {1,1,1,1,1},
                                                    {1,1,1,1,1},
                                                    {0,1,1,1,0}};
        public static readonly int[,] minePowerFive = {{1,1,1,1,1},
                                                    {1,1,1,1,1},
                                                    {1,1,1,1,1},
                                                    {1,1,1,1,1},
                                                    {1,1,1,1,1}};
        }
}

