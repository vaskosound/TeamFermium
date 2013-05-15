using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    public class Field
    {
        private int dimension;
        private int[,] matrixForField;

        public int Dimension
        {
            get
            {
                return this.dimension;
            }
            set
            {
                //Do we need a check?
                this.dimension = value;
            }
        }

        public int[,] MatrixForField
        {
            get { return this.matrixForField; }
            set { this.matrixForField = value; }
        }

        public Field(int dimension)
        {
            this.Dimension = dimension;
        }

        public void FillTheField()
        {
            Random random = new Random(); //vhoid i inicializaciq na n i matricata;

            int dimension = this.Dimension;
            int[,] arr = this.MatrixForField;
            int minPercentOfMines = 15 * dimension * dimension / 100;
            int maxPercentOfMines = 30 * dimension * dimension / 100;

            int mineNumber = random.Next(minPercentOfMines, maxPercentOfMines + 1); 

            for (int i = 0; i < mineNumber; i++)
            {
                int row = random.Next(0, dimension);
                int col = random.Next(0, dimension);

                while (arr[row, col] != 0)
                {
                    row = random.Next(0, dimension);
                    col = random.Next(0, dimension);
                }

                arr[row, col] = random.Next(1, 6);
            }
        }

        public void Print()
        {
            throw new System.NotImplementedException();
        }
    }
}