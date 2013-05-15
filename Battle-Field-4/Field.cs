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
                if (value <= 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("dimension", "The dimension of the matrix should be between 1 and 10");
                }
                else
                {
                    this.dimension = value;
                }
            }
        }

        public int[,] MatrixForField
        {
            get { return this.matrixForField; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("matrixForField", "Matrix for field is missing.");
                }
                else if(value.GetLength(0)!=value.GetLength(1))
                {
                    throw new ArgumentException("Matrix should be square.","matrixForField");
                }
                else if (value.GetLength(0) > 10 || value.GetLength(0) < 0)
                {
                    throw new ArgumentException("Matrix size shoud be between 1 and 10 including", "matrixForField");
                }
                else
                {
                    this.matrixForField = value;
                }
            }
        }

        public Field(int dimension)
        {
            this.Dimension = dimension;
            this.MatrixForField = new int[dimension, dimension];
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
            int dimension = this.Dimension;
            int[,] arr = this.MatrixForField;

            Console.Write(" ");
            for (int i = 0; i < dimension; i++)
            {
                Console.Write(" {0}", i);
            }

            Console.WriteLine();

            Console.Write("  ");
            for (int i = 0; i < dimension * 2; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (int i = 0; i < dimension; i++)
            {
                Console.Write("{0}|", i);
                for (int j = 0; j < dimension; j++)
                {
                    char cellValue;
                    switch (arr[i, j])
                    {
                        case 0: cellValue = '-'; break;
                        case -1: cellValue = 'X'; break;
                        default: cellValue = (char)('0' + arr[i, j]); break;
                    }
                    Console.Write("{0} ", cellValue);
                }
                Console.WriteLine();
            }
        }
    }
}