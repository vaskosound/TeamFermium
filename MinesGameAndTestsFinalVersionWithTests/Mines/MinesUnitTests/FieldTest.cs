using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleField;
using System.Reflection;

namespace MinesUnitTests
{
    [TestClass]
    public class FieldTest
    {
        [TestMethod]
        public void ConstructorRegularTest()
        {
            Field field = new Field(4, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        //It is the sam with smaller size than allowed
        public void ConstructorTestWithBiggerSizeThanTheMaxAllowed()
        {
            Field field = new Field(11, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void MatrixPropertyNullTest()
        {
            Field field = new Field(4, 4);
            field.MatrixForField = null;
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void MatrixPropertyNotSquareMatrixTest()
        {
            Field field = new Field(4, 4);
            field.MatrixForField = new int [3,4];
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void MatrixPropertyPutMatrixWithBiggerDimensionsTest()
        {
            Field field = new Field(4, 4);
            field.MatrixForField = new int[12, 12];
        }

        [TestMethod]
        public void FillTheFieldTest()
        {
            Field field = new Field(5, 8);

            Random fixedRandomGen = new Random(8);

            Type type = typeof(Field);
            var fieldValue = type.GetField("randomGen", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(field, fixedRandomGen);

            field.FillTheField();

            int[,] expected = new int [,]{
                                            {0,5,0,3,0},
                                            {4,0,0,0,3},
                                            {0,0,5,0,0},
                                            {0,0,0,0,0},
                                            {2,5,5,0,0}
            };

            CollectionAssert.AreEqual(expected, field.MatrixForField);
        }
    }
}
