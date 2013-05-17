using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    public class Field
    {
        private const int MIN_FIELD_SIZE = 1;
        private const int MAX_FIELD_SIZE = 10;

        private int size;
        private int numberOfMines;
        private int[,] matrixForField;
        private Random randomGen = new Random();

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value < MIN_FIELD_SIZE || value > MAX_FIELD_SIZE)
                {
                    throw new ArgumentOutOfRangeException("dimension", "The dimension of the matrix should be between 1 and 10");
                }
                else
                {
                    this.size = value;
                }
            }
        }

        public int NumberOfMines
        {
            get
            {
                return this.numberOfMines;
            }
            set
            {
                this.numberOfMines = value;
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
                else if (value.GetLength(0) > MAX_FIELD_SIZE || value.GetLength(0) < MIN_FIELD_SIZE)
                {
                    throw new ArgumentException("Matrix size shoud be between 1 and 10 including", "matrixForField");
                }
                else
                {
                    this.matrixForField = value;
                }
            }
        }

        public Field(int size, int numberOfMines)
        {
            this.Size = size;
            this.NumberOfMines = numberOfMines;
            this.MatrixForField = new int[size, size];
        }

        public void FillTheField()
        {
            int size = this.Size;
            int[,] matrix = this.MatrixForField;
            int numberOfMines = this.NumberOfMines;

            for (int i = 0; i < numberOfMines; i++)
            {
                int row = this.randomGen.Next(0, size);
                int col = this.randomGen.Next(0, size);

                while (matrix[row, col] != 0)
                {
                    row = this.randomGen.Next(0, size);
                    col = this.randomGen.Next(0, size);
                }

                matrix[row, col] = this.randomGen.Next(1, 6);
            }
        }

        public string PrintField()
        {
            int size = this.Size;
            int[,] matrix = this.MatrixForField;

            StringBuilder result = new StringBuilder();

            //Print the numeration of cols
            result.Append(" ");
            for (int col = 0; col < size; col++)
            {
                result.Append(String.Format(" {0}", col));
            }

            result.AppendLine();

            result.Append("  ");
            for (int col = 1; col < size * 2; col++)
            {
                result.Append("-");
            }

            result.AppendLine();

            for (int row = 0; row < size; row++)
            {
                result.Append(String.Format("{0}|", row));
                for (int col = 0; col < size; col++)
                {
                    char cellValue;
                    switch (matrix[row, col])
                    {
                        case 0: cellValue = '-'; break;
                        //when it is already exploded
                        case -1: cellValue = 'X'; break;
                        default: cellValue = (char)('0' + matrix[row, col]); break;
                    }
                    result.Append(String.Format("{0} ", cellValue));
                }
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}