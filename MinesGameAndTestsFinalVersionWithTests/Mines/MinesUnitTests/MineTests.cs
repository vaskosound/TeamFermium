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
        public void TestMethodExplodeTypeWithCorrectData()
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
