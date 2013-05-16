using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    public class GameEngine
    {
        private int gameField;

        public int GameField
        {
            get
            {
                return this.gameField;
            }
            set
            {
                if (value <= 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("dimension",
                        "The dimension of the matrix should be between 1 and 10");
                }
                else
                {
                    this.gameField = value;
                }
            }
        }

        public GameEngine(int gameField)
        {
            this.GameField = gameField;
        }

        public int ExplodeMine(int[,] field, int x, int y)
        {
            Mine mine = new Mine(field[x, y]);
            int[,] explodeType = mine.ExplodeType();
            int explodeMinesCount = 0;
            for (int i = -2; i < 3; i++)
            {
                for (int j = -2; j < 3; j++)
                {
                    if (x + i >= 0 && x + i < this.GameField && y + j >= 0 &&
                        y + j < this.GameField)
                    {
                        if (explodeType[i + 2, j + 2] == 1)
                        {
                            if (field[x + i, y + j] > 0)
                            {
                                explodeMinesCount++;
                            }
                            field[x + i, y + j] = -1;
                        }
                    }
                }
            }
            return explodeMinesCount;
        }

        public int SetNextMinePosition(int[,] field)
        {
            int row = 0, col = 0;
            bool isInvalid = true;
            while (isInvalid) //check input
            {
                Console.Write("Please enter coordinates: ");
                string minePosition = Console.ReadLine();
                string[] coordinates = minePosition.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                if (coordinates.Length == 2)
                {
                    row = int.Parse(coordinates[0]);
                    col = int.Parse(coordinates[1]);
                    if (row < 0 || row >= this.GameField || col < 0 || col >= this.GameField)
                        Console.WriteLine("Invalid move!");
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

            return ExplodeMine(field, row, col);

        }

        public void MakeATurn()
        {
            int minesNumber = GenerateNumberOfMines();
            Field field = new Field(this.GameField, minesNumber);

            field.FillTheField();
            field.PrintField();            
            int turns = 0;
            while (minesNumber > 0)
            {
                int explodedMines = SetNextMinePosition(field.MatrixForField);
                minesNumber -= explodedMines;
                field.PrintField();
                //Console.WriteLine("Mines Blowed this round: {0}",explodedMines);
                turns++;
            }
            Console.WriteLine("Game over -> detonated mines: {0}", turns);
        }

        private int GenerateNumberOfMines()
        {
            Random randomGen = new Random();
            int minPercentOfMines = 15 * this.GameField * this.GameField / 100;
            int maxPercentOfMines = 30 * this.GameField * this.GameField / 100;

            int numberOfMines = randomGen.Next(minPercentOfMines, maxPercentOfMines + 1);
            return numberOfMines;
        }

    }
}
