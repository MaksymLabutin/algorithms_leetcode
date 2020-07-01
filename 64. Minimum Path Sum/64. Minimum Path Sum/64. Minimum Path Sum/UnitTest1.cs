using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var grid = new int[][]
            {
                new[] {1, 3, 1},
                new[] {1, 5, 1},
                new[] {4, 2, 1},
            };

            var actual = MinPathSum(grid);

            var expected = 7;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test2()
        {
            var grid = new int[][]
            {
                new[] {1, 2, 3},
                new[] {4, 5, 6}
            };

            var actual = MinPathSum(grid);

            var expected = 12;

            Assert.AreEqual(expected, actual);
        }

        private Dictionary<(int, int), int> _memo;
        public int MinPathSum(int[][] grid)
        {
            if (grid.Length == 0) return 0;
            _memo = new Dictionary<(int, int), int>();

            return MinPathSum(grid, 0, 0);
        }

        private int MinPathSum(int[][] grid, int row, int col)
        {
            if (_memo.ContainsKey((row, col))) return _memo[(row, col)];

            if (row >= grid.Length || col >= grid[row].Length) return row + 1 == grid.Length && col + 1 == grid[row].Length ? 0 : -1;

            var down = MinPathSum(grid, row + 1, col);
            var right = MinPathSum(grid, row, col + 1);
            var sum = 0;
            if (down >= 0 && right >= 0)
            {
                sum =  Math.Min(down,right);
            } 
            else if (down >= 0) sum = down;
            else if (right >= 0) sum = right;

            sum += grid[row][col];
            _memo.Add((row, col), sum);

            return _memo[(row, col)];
        }
    }
}