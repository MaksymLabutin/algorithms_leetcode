using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var grid = new char[][]
            {
                new char[] {'1', '1', '1', '1', '0'},
                new char[] {'1', '1', '0', '1', '0'},
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'0', '0', '0', '0', '0'}
            };

            var actual = NumIslands(grid);

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var grid = new char[][]
            {
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'0', '0', '1', '0', '0'},
                new char[] {'0', '0', '0', '1', '1'}
            };

            var actual = NumIslands(grid);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var grid = new char[][]
            {
                new char[] {'1', '1', '0', '0', '1'}
            };

            var actual = NumIslands(grid);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            var grid = new char[][]
            {
            };

            var actual = NumIslands(grid);

            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        private char[][] _grid;
        private HashSet<(int, int)> _visited;

        public int NumIslands(char[][] grid)
        {
            _grid = grid;
            _visited = new HashSet<(int, int)>();

            var islands = 0;
            for (var i = 0; i < _grid.GetLength(0); i++)
            {
                for (var j = 0; j < _grid[i].Length; j++)
                {
                    if(_visited.Contains((i, j))) continue;
                    
                    DFS(i, j);
                    
                    if (_grid[i][j] == '1') islands++;
                }
            }

            return islands;
        }

        private void DFS(int i, int j)
        {
            _visited.Add((i, j));
            if (_grid[i][j] == '0') return;

            GoUp(i,j);
            GoLeft(i,j);
            GoRight(i,j);
            GoBottom(i,j);
        }

        private void GoBottom(int i, int j)
        {
            var bottom = i + 1; 
            if(_visited.Contains((bottom, j)) || bottom >= _grid.GetLength(0)) return;
            DFS(bottom, j);
        }

        private void GoUp(int i, int j)
        {
            var top = i - 1;
            if (_visited.Contains((top, j)) || top < 0) return;
            DFS(top, j);
        }

        private void GoLeft(int i, int j)
        {
            var left = j - 1;
            if (_visited.Contains((i, left)) || left < 0) return;
            DFS(i, left);
        }

        private void GoRight(int i, int j)
        {
            var right = j + 1;
            if (_visited.Contains((i, right)) || right >= _grid[i].Length) return;
            DFS(i, right);
        }
    }
}