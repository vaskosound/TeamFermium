using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    public class Mine
    {
        private int type;

        public int Type
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private int[,] GetExplodeType(int[,] field, int x, int y)
        {
            int[,] explodeType = new int[5, 5];
            switch (field[x, y])
            {
                case 1: explodeType = MineType.minePowerOne;
                    break;
                case 2: explodeType = MineType.minePowerTwo;
                    break;
                case 3: explodeType = MineType.minePowerThree;
                    break;
                case 4: explodeType = MineType.minePowerFour;
                    break;
                case 5: explodeType = MineType.minePowerFive;
                    break;
                default:
                    throw new ArgumentException("Invalid mine type!");
            }

            return explodeType;
        }

        public int Explode()
        {
            throw new System.NotImplementedException();
        }
    }
}