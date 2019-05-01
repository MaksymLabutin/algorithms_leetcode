using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Spiral_Matrix
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {


            var inpArr = new int[][]
            {
                new []{1,2,3, 1},
                new []{4,5,6, 1},
                new []{7,8,9, 1}
            };

            var res = SpiralOrder(inpArr);

            var inpArr2 = new int[][]
            {
                new []{1,2},
                new []{4,5}
            };

            var res2 = SpiralOrder(inpArr2);

            var inpArr3 = new int[][]
            {
                new []{1,2,3}
            };

            var res3 = SpiralOrder(inpArr3);


            var inpArr4 = new int[][]
            {
                new []{1,2,3,4},
                new []{5,6,7,8},
                new []{9,10,11,12},
                new []{13,14,15,16},
            };

            var res4 = SpiralOrder(inpArr4);

            var inpArr5 = new int[][]
            {
                new []{1,2,3,4,5,6,7,8,9,10},
                new []{ 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }
            };

            var res5 = SpiralOrder(inpArr5);

            //[[1,11],[2,12],[3,13],[4,14],[5,15],[6,16],[7,17],[8,18],[9,19],[10,20]]
            var inpArr6 = new int[][]
             {
                new []{1,11},
                new []{2,12},
                new []{3,13},
                new []{4,14},
                new []{5,15},
                new []{6,16},
                new []{7,17},
                new []{8,18},
                new []{9,19},
                new []{10,20}
            };

            var res6 = SpiralOrder(inpArr6);
            var inpArr7 = new int[][]
            {
                new []{1},
                new []{2},
                new []{3},
                new []{4},
                new []{5},
                new []{6},
                new []{7},
                new []{8},
                new []{9},
                new []{10}
            };

            var res7 = SpiralOrder(inpArr7);

        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix.Length == 0) return new int[] { };

            var maxTopLine = 0;
            var maxBottomLine = matrix.Length == 1 ? matrix.Length : matrix.Length - 1;
            var maxLeftCol = 0;
            var maxRightCol = matrix[0].Length - 1;

            var countElements = matrix.Length * matrix[0].Length;

            var res = new List<int>();

            int line = 0, col = 0;

            for (var index = 0; index < countElements; index++)
            {
                res.Add(matrix[line][col]);

                if (maxBottomLine == line && col > maxLeftCol)
                {
                    col--;
                    if (col == maxLeftCol)
                    {
                        maxBottomLine--;
                    }


                }
                else if (col == maxLeftCol && line > maxTopLine && matrix[0].Length != 1)
                {
                    line--;
                    if (line == maxTopLine)
                    {
                        maxLeftCol++;
                    }

                   
                }
                else if (line == maxTopLine && col < maxRightCol)
                {
                    col++;

                    if (col == maxRightCol)
                    {
                        maxTopLine++;
                    }
                }
                else
                {
                    line++;
                    if (line == maxBottomLine)
                    {
                        maxRightCol--;
                    }
                }

            }

            return res;
        }
    }
}
