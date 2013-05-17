using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    public class GameEngine
    {
        private Field field;

        public Field Field
        {
            get { return this.field; }
            private set { this.field = value; }
        }

        private int ExplodeMine(int[,] field)
        {
            int row = 0, col = 0;
            SetNextMinePosition(field, out row, out col);

            Mine mine = new Mine(field[row, col]);
            int[,] explodeType = mine.ExplodeType();

            int explodeMinesCount = 0;
            for (int i = -2; i < 3; i++)
            {
                for (int j = -2; j < 3; j++)
                {
                    if (row + i >= 0 && row + i < field.GetLength(0) && col + j >= 0 &&
                        col + j < field.GetLength(1))
                    {
                        if (explodeType[i + 2, j + 2] == 1)
                        {
                            if (field[row + i, col + j] > 0)
                            {
                                explodeMinesCount++;
                            }
                            field[row + i, col + j] = -1;
                        }
                    }
                }
            }

            return explodeMinesCount;
        }

        private void SetNextMinePosition(int [,] field, out int row, out int col)
        {
            row = 0;
            col = 0;
            bool isInvalid = true;
            while (isInvalid)
            {
                Console.Write("Please enter coordinates: ");
                string minePosition = Console.ReadLine();
                string[] coordinates = minePosition.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (coordinates.Length == 2)
                {
                    row = int.Parse(coordinates[0]);
                    col = int.Parse(coordinates[1]);
                    if (row < 0 || row >= field.GetLength(0) || col < 0 || col >= field.GetLength(1))
                    {
                        Console.WriteLine("Invalid move!");
                    }
                    else
                    {
                        isInvalid = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move!");
                }
                if (!isInvalid)
                {
                    if (field[row, col] <= 0)
                    {
                        isInvalid = true;
                        Console.WriteLine("Invalid move!");
                    }
                }
            }
        }

        private int GenerateNumberOfMines(int sizeOfField)
        {
            Random randomGen = new Random();
            int minPercentOfMines = 15 * sizeOfField * sizeOfField / 100;
            int maxPercentOfMines = 30 * sizeOfField * sizeOfField / 100;

            int numberOfMines = randomGen.Next(minPercentOfMines, maxPercentOfMines + 1);
            return numberOfMines;
        }


        private void CreateGameField(int size)
        {
            int minesNumber = GenerateNumberOfMines(size);
            Field field = new Field(size, minesNumber);

            field.FillTheField();
            field.PrintField();

            this.Field = field;
        }

        private void Play()
        {
            int minesNumber = this.Field.NumberOfMines;

            int turns = 0;
            while (minesNumber > 0)
            {
                int explodedMines = ExplodeMine(this.Field.MatrixForField);
                minesNumber -= explodedMines;

                this.Field.PrintField();

                turns++;
            }
            Console.WriteLine("Game over -> detonated mines: {0}", turns);
        }

        private int GetInitialSize()
        {
            int size;
            Console.Write("Welcome to \"Mines\" game.\nEnter battle type size between 1 and 10: n = ");
            int.TryParse(Console.ReadLine(), out size);

            while (size < 1 || size > 10)
            {
                Console.Write("n is between 1 and 10! Please enter new n = ");
                int.TryParse(Console.ReadLine(), out size);
            }

            return size;
        }

        public void InitiateGame()
        {
            int size = GetInitialSize();

            CreateGameField(size);

            Play();
        }
    }
}
