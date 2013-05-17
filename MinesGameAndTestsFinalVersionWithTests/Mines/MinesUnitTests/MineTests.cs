using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleField;

namespace Mines.Test
{
    [TestClass]
    public class TestMine
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateMineWithIHigherType()
        {
            Mine mine = new Mine(6);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateMineWithILowerType()
        {
            Mine mine = new Mine(0);
        }


        [TestMethod]
        public void TestCreateMineWithBorderCase()
        {
            Mine mine = new Mine(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateMineWithNegative()
        {
            Mine mine = new Mine(-1);
        }

        [TestMethod]
        public void TestCreateMineWithICorrectType()
        {
            Mine mine = new Mine(4);
            Assert.AreEqual(4, mine.Type);
        }

        [TestMethod]
        public void TestMethodExplodeTypeWithInvalidData()
        {
            Mine mine = new Mine(4);
            int[,] expected = {{0,1,1,1,0},
                            {0,1,1,1,1},
                            {1,1,1,1,1},
                            {1,1,1,1,1},
                            {0,1,1,1,0}};
            int[,] actual = mine.ExplodeType();
            CollectionAssert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodExplodeTypeWithCorrectDataTypeOne()
        {
            Mine mine = new Mine(1);
            int[,] expected = {{0,0,0,0,0},
                            {0,1,0,1,0},
                            {0,0,1,0,0},
                            {0,1,0,1,0},
                            {0,0,0,0,0}};
            int[,] actual = mine.ExplodeType();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodExplodeTypeWithCorrectDataTypeTow()
        {
            Mine mine = new Mine(2);
            int[,] expected = {{0,0,0,0,0},
                            {0,1,1,1,0},
                            {0,1,1,1,0},
                            {0,1,1,1,0},
                            {0,0,0,0,0}};
            int[,] actual = mine.ExplodeType();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodExplodeTypeWithCorrectDataTypeThree()
        {
            Mine mine = new Mine(3);
            int[,] expected = {{0,0,1,0,0},
                            {0,1,1,1,0},
                            {1,1,1,1,1},
                            {0,1,1,1,0},
                            {0,0,1,0,0}};
            int[,] actual = mine.ExplodeType();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodExplodeTypeWithCorrectDataTypeFive()
        {
            Mine mine = new Mine(5);
            int[,] expected = {{1,1,1,1,1},
                            {1,1,1,1,1},
                            {1,1,1,1,1},
                            {1,1,1,1,1},
                            {1,1,1,1,1}};
            int[,] actual = mine.ExplodeType();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodExplodeTypeWithCorrectDataTypeFour()
        {
            Mine mine = new Mine(4);
            int[,] expected = {{0,1,1,1,0},
                            {1,1,1,1,1},
                            {1,1,1,1,1},
                            {1,1,1,1,1},
                            {0,1,1,1,0}};
            int[,] actual = mine.ExplodeType();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}