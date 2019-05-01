using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiagonalTraverse
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = new int[][]
                {
                    new [] {1, 2, 3},
                    new [] {4, 5, 6},
                    new [] {7, 8, 9}
                 };

             var res = FindDiagonalOrder(input);
        }

        public int[] FindDiagonalOrder(int[][] matrix)
        {

            if (matrix.Length == 0) return new int[]{};

            var matrixLenght = matrix.Length * matrix[0].Length;
            var res = new List<int>(){matrix[0][0]};
            var vectorToUp = true;

            int col = 0, line = 0;

            while (matrixLenght != res.Count)
            {
                try
                {
                    var currCol = col;
                    var currLine = line;

                    if (vectorToUp)
                    {
                        res.Add(matrix[--currLine][++currCol]);
                    }
                    else
                    {
                        res.Add(matrix[++currLine][--currCol]); 
                    }

                    col = currCol;
                    line = currLine;
                }
                catch (Exception ex)
                {
                    vectorToUp = !vectorToUp;

                    var currCol = col;
                    var currLine = line;

                    if (vectorToUp)
                    {
                        try
                        {
                            res.Add(matrix[++currLine][currCol]); 
                        }
                        catch (Exception e)
                        {
                            res.Add(matrix[--currLine][++currCol]);
                        }

                    }
                    else
                    {
                        try
                        {
                            res.Add(matrix[currLine][++currCol]); 
                        }
                        catch (Exception e)
                        {
                            res.Add(matrix[++currLine][--currCol]); 
                        }
                    }

                    col = currCol;
                    line = currLine;
                }
 
            }

            return res.ToArray();
        }
    }
}
