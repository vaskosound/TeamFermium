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
            get
            {
                return this.matrixForField;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("matrixForField", "Matrix for field is missing.");
                }
                else if (value.GetLength(0) != value.GetLength(1))
                {
                    throw new ArgumentException("Matrix should be square.", "matrixForField");
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
            Random randomGen = new Random();

            int size = this.Size;
            int[,] arr = this.MatrixForField;

            int numberOfMines = GenerateNumberOfMines();

            for (int i = 0; i < numberOfMines; i++)
            {
                int row = randomGen.Next(0, size);
                int col = randomGen.Next(0, size);

                while (arr[row, col] != 0)
                {
                    row = randomGen.Next(0, size);
                    col = randomGen.Next(0, size);
                }

                arr[row, col] = randomGen.Next(1, 6);
            }
        }

        public int GenerateNumberOfMines() 
        {
            Random randomGen = new Random();
            int minPercentOfMines = 15 * this.Size * this.Size / 100;
            int maxPercentOfMines = 30 * this.Size * this.Size / 100;

            int numberOfMines = randomGen.Next(minPercentOfMines, maxPercentOfMines + 1);
            return numberOfMines;
        }

        public void PrintField()
        {
            int size = this.Size;
            int[,] arr = this.MatrixForField;

            //Print the numeration of cols
            Console.Write(" ");
            for (int col = 0; col < size; col++)
            {
                Console.Write(" {0}", col);
            }

            Console.WriteLine();

            Console.Write("  ");
            for (int col = 1; col < size * 2; col++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (int row = 0; row < size; row++)
            {
                Console.Write("{0}|", row);
                for (int col = 0; col < size; col++)
                {
                    char cellValue;
                    switch (arr[row, col])
                    {
                        case 0: cellValue = '-'; break;
                        //when it is already exploded
                        case -1: cellValue = 'X'; break;
                        default: cellValue = (char)('0' + arr[row, col]); break;
                    }
                    Console.Write("{0} ", cellValue);
                }
                Console.WriteLine();
            }
        }
    }
}