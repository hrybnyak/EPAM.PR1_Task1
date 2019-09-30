using NUnit.Framework;
using System.Collections.Generic;
using Matrix;
using Matrix.MatrixOperators;

namespace Matrix.UnitTests
{
    [TestFixture]
    public class MatrixTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MatrixCreationTest()
        {
            var list = new List<List<double>>();
            int expectedNumberOfRows = 3;
            int expectedNumberOfCollums = 2;
            for (int i = 0; i<expectedNumberOfRows; i++)
            {
                var row = new List<double>();
                for(int j = 0; j<expectedNumberOfCollums; j++)
                {
                    row.Add(i + j);
                }
                list.Add(row);
            }
            Matrix matrix = new Matrix(list);
            Assert.IsTrue(matrix.NumberOfRows == expectedNumberOfRows && matrix.NumberOfCollums == expectedNumberOfCollums);
            Assert.IsNotNull(matrix);
            for (int i = 0; i < expectedNumberOfRows; i++)
            {
                
                for (int j = 0; j < expectedNumberOfCollums; j++)
                {
                    Assert.IsTrue(list[i][j] == matrix[i, j]);
                }  
            }
            Assert.AreNotSame(list, matrix.MatrixBody);
        }
        [Test]
        public void MatrixCloneTest()
        {
            var list = new List<List<double>>();
            int expectedNumberOfRows = 3;
            int expectedNumberOfCollums = 2;
            for (int i = 0; i < expectedNumberOfRows; i++)
            {
                var row = new List<double>();
                for (int j = 0; j < expectedNumberOfCollums; j++)
                {
                    row.Add(i + j);
                }
                list.Add(row);
            }
            Matrix matrix = new Matrix(list);
            Matrix matrix1 = (Matrix)matrix.Clone();
            Assert.AreNotSame(matrix, matrix1);
        }
        [Test]
        public void MatrixEqualsTest()
        {
            var list = new List<List<double>>();
            int expectedNumberOfRows = 3;
            int expectedNumberOfCollums = 2;
            for (int i = 0; i < expectedNumberOfRows; i++)
            {
                var row = new List<double>();
                for (int j = 0; j < expectedNumberOfCollums; j++)
                {
                    row.Add(i + j);
                }
                list.Add(row);
            }
            Matrix matrix = new Matrix(list);
            Matrix matrix1 = new Matrix(list);
            Assert.IsTrue(matrix.Equals(matrix1));
        }
        [Test]
        public void MatrixDeterminantTest()
        {
            var list = new List<List<double>>();
            int expectedNumberOfRows = 2;
            int expectedNumberOfCollums = 2;
            int expectedDeterminant = -1;
            for (int i = 0; i < expectedNumberOfRows; i++)
            {
                var row = new List<double>();
                for (int j = 0; j < expectedNumberOfCollums; j++)
                {
                    row.Add(i + j + 1);
                }
                list.Add(row);
            }
            Matrix matrix = new Matrix(list);
            Assert.AreEqual(matrix.Determinant(), expectedDeterminant);
        }
        [Test]
        public void MatrixMinorTest()
        {
            var list = new List<List<double>>();
            var minorList = new List<List<double>>();
            int excludedRow = 0;
            int excludedCollumn = 2;
            int expectedNumberOfRows = 3;
            int expectedNumberOfCollums = 3;
            for (int i = 0; i < expectedNumberOfRows; i++)
            {
                var row = new List<double>();
                for (int j = 0; j < expectedNumberOfCollums; j++)
                {
                    row.Add(i + j + 1);
                }
                list.Add(row);
            }
            for (int i = 0; i < expectedNumberOfRows; i++)
            {
                if (i == excludedRow) continue;
                var row = new List<double>();
                for (int j = 0; j < expectedNumberOfCollums; j++)
                {
                    if (j == excludedCollumn) continue;
                    row.Add(i + j + 1);
                }
                minorList.Add(row);
            }
            Matrix matrix = new Matrix(list);
            Matrix expectedMatrix = new Matrix(minorList);
            Matrix minor = matrix.Minor(excludedRow, excludedCollumn);
            Assert.IsTrue(expectedMatrix.Equals(minor));
            Assert.IsTrue(minor.NumberOfCollums == matrix.NumberOfCollums - 1 && minor.NumberOfRows == matrix.NumberOfRows - 1);
        }
        [Test]
        public void MatrixAddingTest()
        {
            var list = new List<List<double>>();
            //1 2
            //2 3
            var list1 = new List<List<double>>();
            //0 1
            //2 3
            var expected = new List<List<double>>();
            //1 3
            //4 6
            int expectedNumberOfRows = 2;
            int expectedNumberOfCollums = 2;
            for (int i = 0; i < expectedNumberOfRows; i++)
            {
                var row = new List<double>();
                var row1 = new List<double>();
                var expectedRow = new List<double>();
                for (int j = 0; j < expectedNumberOfCollums; j++)
                {
                    row.Add(i + j + 1);
                    row1.Add(i * 2 + j);
                    expectedRow.Add(3*i+j*2+1);
                }
                list.Add(row);
                list1.Add(row1);
                expected.Add(expectedRow);
            }
            Matrix matrix = new Matrix(list);
            Matrix matrix1 = new Matrix(list1);
            Matrix expectedResult = new Matrix(expected);
            Matrix result = matrix + matrix1;
            Matrix anotherResult = matrix1 + matrix;
            Assert.IsTrue(result.Equals(expectedResult));
            Assert.IsTrue(anotherResult.Equals(expectedResult));
            Assert.IsNotNull(result);
            Assert.IsNotNull(anotherResult);
        }
        [Test]
        public void MatrixSubtractionTest()
        {
            var list = new List<List<double>>();
            //1 2
            //2 3
            var list1 = new List<List<double>>();
            //0 1
            //2 3
            var expected = new List<List<double>>();
            //1 1
            //0 0
            int expectedNumberOfRows = 2;
            int expectedNumberOfCollums = 2;
            for (int i = 0; i < expectedNumberOfRows; i++)
            {
                var row = new List<double>();
                var row1 = new List<double>();
                var expectedRow = new List<double>();
                for (int j = 0; j < expectedNumberOfCollums; j++)
                {
                    row.Add(i + j + 1);
                    row1.Add(i * 2 + j);
                    expectedRow.Add( -i + 1);
                }
                list.Add(row);
                list1.Add(row1);
                expected.Add(expectedRow);
            }
            Matrix matrix = new Matrix(list);
            Matrix matrix1 = new Matrix(list1);
            Matrix expectedResult = new Matrix(expected);
            Matrix result = matrix - matrix1;
            Assert.IsTrue(result.Equals(expectedResult));
            Assert.IsNotNull(result);
        }
        [Test]
        public void MatrixMultiplyingTest()
        {
            var list = new List<List<double>>();
            //1 2
            //2 3
            var list1 = new List<List<double>>();
            //0 1
            //2 3
            var expected = new List<List<double>>();
            //4 7
            //6 11
            int expectedNumberOfRows = 2;
            int expectedNumberOfCollums = 2;
            for (int i = 0; i < expectedNumberOfRows; i++)
            {
                var row = new List<double>();
                var row1 = new List<double>();
                var expectedRow = new List<double>();
                for (int j = 0; j < expectedNumberOfCollums; j++)
                {
                    row.Add(i + j + 1);
                    row1.Add(i * 2 + j);
                    expectedRow.Add(0.0);
                }
                list.Add(row);
                list1.Add(row1);
                expected.Add(expectedRow);
            }
            expected[0][0] = 4;
            expected[0][1] = 7;
            expected[1][0] = 6;
            expected[1][1] = 11;
            Matrix matrix = new Matrix(list);
            Matrix matrix1 = new Matrix(list1);
            Matrix expectedResult = new Matrix(expected);
            Matrix result = matrix * matrix1;
            Assert.IsTrue(result.Equals(expectedResult));
            Assert.IsNotNull(result);
        }
        [Test]
        public void MultiplyingByNumber()
        {
            var list = new List<List<double>>();
            //1 2
            //2 3
            int number = 3;
            var expected = new List<List<double>>();
            //3 6
            //6 9
            int expectedNumberOfRows = 2;
            int expectedNumberOfCollums = 2;
            for (int i = 0; i < expectedNumberOfRows; i++)
            {
                var row = new List<double>();
                var expectedRow = new List<double>();
                for (int j = 0; j < expectedNumberOfCollums; j++)
                {
                    row.Add(i + j + 1);
                    expectedRow.Add(number*(i+j+1));
                }
                list.Add(row);
                expected.Add(expectedRow);
            }
            Matrix matrix = new Matrix(list);
            Matrix expectedResult = new Matrix(expected);
            Matrix result = matrix * number;
            Matrix anotherResult = number * matrix;
            Assert.IsTrue(result.Equals(expectedResult));
            Assert.IsTrue(anotherResult.Equals(expectedResult));
            Assert.IsNotNull(result);
            Assert.IsNotNull(anotherResult);
        }
    }
}