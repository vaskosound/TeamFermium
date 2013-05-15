using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    public class Field
    {
        private int size;
        private int[,] matrixForField;

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value <= 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("dimension", "The dimension of the matrix should be between 1 and 10");
                }
                else
                {
                    this.size = value;
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

        public Field(int size)
        {
            this.Size = size;
            this.MatrixForField = new int[size, size];
        }

        public void FillTheField()
        {
            Random random = new Random(); //vhoid i inicializaciq na n i matricata;

            int size = this.Size;
            int[,] arr = this.MatrixForField;
            int minPercentOfMines = 15 * size * size / 100;
            int maxPercentOfMines = 30 * size * size / 100;

            int numberOfMines = random.Next(minPercentOfMines, maxPercentOfMines + 1); 

            for (int i = 0; i < numberOfMines; i++)
            {
                int row = random.Next(0, size);
                int col = random.Next(0, size);

                while (arr[row, col] != 0)
                {
                    row = random.Next(0, size);
                    col = random.Next(0, size);
                }

                arr[row, col] = random.Next(1, 6);
            }
        }

        public void Print()
        {
            int size = this.Size;
            int[,] arr = this.MatrixForField;

            Console.Write(" ");
            for (int i = 0; i < size; i++)
            {
                Console.Write(" {0}", i);
            }

            Console.WriteLine();

            Console.Write("  ");
            for (int i = 0; i < size * 2; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (int i = 0; i < size; i++)
            {
                Console.Write("{0}|", i);
                for (int j = 0; j < size; j++)
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