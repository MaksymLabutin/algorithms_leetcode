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

        [Test]
        public void Test4()
        {
            //[[-4,-2147483648,6,-7,0],[-8,6,-8,-6,0],[2147483647,2,-9,-6,-10]]
            var matrix = new int[][]
            {
                new []{ -4,-2147483648,6,-7,0 },
                new []{-8,6,-8,-6,0},
                new []{2147483647,2,-9,-6,-10}
            };

            SetZeroes(matrix);
                //[[0,0,0,0,0],[0,0,0,0,0],[2147483647,2,-9,-6,0]]
            var expected = new int[][]
            {
                new []{ 0,0,0,0,0 },
                new []{0,0,0,0,0},
                new []{ 2147483647, 2, -9, -6, 0 }
            };

            CollectionAssert.AreEqual(expected, matrix);
        }
        //todo
        [Test]
        public void Test5()
        {
            //[[8,3,6,9,7,8,0,6],[0,3,7,0,0,4,3,8],[5,3,6,7,1,6,2,6],[8,7,2,5,0,6,4,0],[0,2,9,9,3,9,7,3]]
            var matrix = new int[][]
            {
                new []{ 8,3,6,9,7,8,0,6 },
                new []{ 0,3,7,0,0,4,3,8},
                new []{ 5,3,6,7,1,6,2,6 },
                new []{ 8,7,2,5,0,6,4,0},
                new []{ 0,2,9,9,3,9,7,3}
            };

            SetZeroes(matrix);
            //[[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,3,6,0,0,6,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0]]
            var expected = new int[][]
            {
                new []{ 0,0,0,0,0,0,0,0 },
                new []{ 0,0,0,0,0,0,0,0},
                new []{ 0,3,6,0,0,6,0,0 },
                new []{ 0,0,0,0,0,0,0,0 },
                new []{ 0,0,0,0,0,0,0,0 }
            };

            CollectionAssert.AreEqual(expected, matrix);
        }

        public void SetZeroes(int[][] matrix)
        {
            var flag = false;
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row][0] == 0) flag = true;

                for (var col = 1; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] != 0) continue;

                    matrix[row][0] = 0;
                    matrix[0][col] = 0;

                }
            }

            for (var row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (var col = matrix[row].Length - 1; col >= 1; col--)
                {
                    if (matrix[row][0] == 0 || matrix[0][col] == 0) matrix[row][col] = 0;
                }

                if (flag) matrix[row][0] = 0;
            }
        }

        //public void SetZeroes(int[][] matrix)
        //{
        //    var flag = int.MaxValue / 6;
        //    for (var row = 0; row < matrix.GetLength(0); row++)
        //    {
        //        for (var col = 0; col < matrix[row].Length; col++)
        //        {
        //            if (matrix[row][col] != 0) continue;

        //            if (row == 0)
        //            {
        //                matrix[0][col] = -flag;
        //                matrix[row][0] = col == 0 || matrix[row][0] == 0 ? 0 : flag;
        //                continue;
        //            }

        //            matrix[row][0] = flag;
        //            if (matrix[0][col] != 0)
        //            {
        //                matrix[0][col] = matrix[0][col] == flag ? 0 :  - flag;
        //            }

        //        }
        //    }

        //    for (var row = matrix.GetLength(0) - 1; row >= 0; row--)
        //    {
        //        for (var col = matrix[row].Length - 1; col >= 0; col--)
        //        {
        //            if (matrix[row][0] == 0 || matrix[row][0] == flag || matrix[0][col] == -flag || matrix[0][col] == 0) matrix[row][col] = 0;
        //        }
        //    }
        //}


    }
}