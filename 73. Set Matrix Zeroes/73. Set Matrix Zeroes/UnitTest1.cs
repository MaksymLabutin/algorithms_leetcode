using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var matrix = new int[][]
            {
                new []{ 0, 1, 2, 0 },
                new []{ 3,4,5,2 },
                new []{ 1,3,1,5 },
            };

            SetZeroes(matrix);

            var expected = new int[][]
            {
                new []{ 0, 0, 0, 0 },
                new []{ 0,4,5,0 },
                new []{ 0,3,1,0 },
            };

            CollectionAssert.AreEqual(expected, matrix);
        }

        [Test]
        public void Test2()
        {
            var matrix = new int[][]
            {
                new []{ 1,1,1 },
                new []{ 0,1,2 },
            };

            SetZeroes(matrix);

            var expected = new int[][]
            {
                new []{ 0,1,1 },
                new []{ 0,0,0 },
            };

            CollectionAssert.AreEqual(expected, matrix);
        }
        [Test]
        public void Test3()
        {
            var matrix = new int[][]
            {
                new []{ 0,1,1 },
                new []{ 0,1,2 },
            };

            SetZeroes(matrix);

            var expected = new int[][]
            {
                new []{ 0,0,0 },
                new []{ 0,0,0 },
            };

            CollectionAssert.AreEqual(expected, matrix);
        }

        public void SetZeroes(int[][] matrix)
        {
            var flag = int.MaxValue / 6;
            for (var row = 1; row < matrix.GetLength(0); row++)
            {
                for (var col = 1; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] != 0) continue;

                    matrix[0][col] = -flag;
                    matrix[row][0] = flag;

                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                if(matrix[])
            }

        }

        private void SetZeroCol(int[][] matrix, int currCol)
        {
            for (var row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                matrix[row][currCol] = 0;
            }
        }

        private void SetZeroRow(int[][] matrix, int currRow)
        {
            for (var row = currRow; row >= currRow; row--)
            {
                for (var col = 0; col < matrix[currRow].Length; col++)
                {
                    matrix[currRow][col] = 0;
                }
            }
        }
    }
}