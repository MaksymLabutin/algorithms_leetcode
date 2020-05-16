using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //[[3,7,8],[9,11,13],[15,16,17]]
            var matrix = new int[][]
            {
                new[] {3, 7, 8},
                new[] {9, 11, 13},
                new[] {15, 16, 17}
            };

            var actual = LuckyNumbers(matrix);

            var expected = new List<int> {15};
            Assert.AreEqual(expected, actual);
        }

        public IList<int> LuckyNumbers(int[][] matrix)
        { 
            var minRow = new List<int>();
            var maxCol = new List<int>(); 

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    if (minRow.Count <= i) minRow.Add(matrix[i][j]);
                    else minRow[i] = Math.Min(minRow[i], matrix[i][j]);

                    if (maxCol.Count <= j) maxCol.Add(matrix[i][j]);
                    else maxCol[j] = Math.Max(maxCol[j], matrix[i][j]);
                }
            }
            

            return minRow.Where(_ => maxCol.Contains(_)).ToList();
        }
    }
}