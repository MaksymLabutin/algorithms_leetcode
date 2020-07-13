using System;
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
                new[] {1, 3, 5, 7},
                new[] {10, 11, 16, 20},
                new[] {23, 30, 34, 50},
            };

            var target = 3;

            var actual = SearchMatrix(matrix, target);
            
            Assert.IsTrue(actual);
        }

        [Test]
        public void Test2()
        {
            var matrix = new int[][]
            {
                new[] {1, 3, 5, 7},
                new[] {10, 11, 16, 20},
                new[] {23, 30, 34, 50},
            };

            var target = 13;

            var actual = SearchMatrix(matrix, target);
            
            Assert.IsFalse(actual);
        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix.Length == 0) return false;

            var row = matrix.Length - 1;
            var col = 0; 

            while (row >= 0 && col < matrix[0].Length)
            {
                if (matrix[row][col] >= target)
                {
                    if (matrix[row][col] == target) return true; 
                    row--; 
                }
                else
                {
                    col++; 
                }
            }

            return false;
        }
    }
}