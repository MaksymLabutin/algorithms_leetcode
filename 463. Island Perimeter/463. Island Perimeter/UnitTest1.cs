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
                new[] {0, 1, 0, 0},
                new[] {1, 1, 1, 0},
                new[] {0, 1, 0, 0},
                new[] {1, 1, 0, 0},
            };

            var actual = IslandPerimeter(grid);

            var expected = 16; 

            Assert.AreEqual(expected, actual);
        }
         
        [Test]
        public void Test2()
        {
            var grid = new int[][]
            {
                new[] {0, 1}, 
            };

            var actual = IslandPerimeter(grid);

            var expected = 4; 

            Assert.AreEqual(expected, actual);
        }


         
        [Test]
        public void Test3()
        {
            var grid = new int[][]
            {
                new[] {1, 1}, 
            };

            var actual = IslandPerimeter(grid);

            var expected = 6; 

            Assert.AreEqual(expected, actual);
        }

         
        public int IslandPerimeter(int[][] grid)
        {
            var hs = new HashSet<(int, int)>();
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[0].Length; col++)
                {
                    if(grid[row][col] == 0) continue;
                    hs.Add((row, col));   
                }
            }
            var p = 0;

            foreach (var val in hs)
            {
                if (!hs.Contains((val.Item1 - 1, val.Item2))) p++;
                if (!hs.Contains((val.Item1 + 1, val.Item2))) p++;
                if (!hs.Contains((val.Item1, val.Item2 - 1))) p++;
                if (!hs.Contains((val.Item1, val.Item2 + 1))) p++;
            }

            return p;
        }
    }
}