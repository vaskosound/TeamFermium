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
                return this.type;
            }
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Mine type should be between 1 and 5");
                }
                else
                {
                    this.type = value;
                }
            }
        }

        public Mine(int mineType)
        {
            this.Type = mineType;
        }

        public int[,] ExplodeType()
        {
            int[,] explodeType = new int[5, 5];
            switch (this.Type)
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
    }
}