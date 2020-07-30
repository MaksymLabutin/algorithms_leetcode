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
            int[][] matrix = new int[][]
            {
                new int[]{0},
                new int[]{1},
                new int[]{1},
                new int[]{1},
            };

            var actual = UpdateMatrix(matrix);

            var expected = new int[][]
            {
                new int[]{0},
                new int[]{1},
                new int[]{2},
                new int[]{3},
            };

            CollectionAssert.AreEqual(expected, actual);
        }


        [Test]
        public void Test2()
        {
            int[][] matrix = new int[][]
            {
                new int[]{0,0,0},
                new int[]{0,1,0},
                new int[]{1,1,1},
            };

            var actual = UpdateMatrix(matrix);

            var expected = new int[][]
            {
                new int[]{0,0,0},
                new int[]{0,1,0},
                new int[]{1,2,1},
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            int[][] matrix = new int[][]
            {
                new int[]{0,0,0},
                new int[]{0,1,0},
                new int[]{1,1,1},
                new int[]{1,1,1},
            };

            var actual = UpdateMatrix(matrix);

            var expected = new int[][]
            {
                new int[]{0,0,0},
                new int[]{0,1,0},
                new int[]{1,2,1},
                new int[]{2,3,2},
            };

            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void Test4()
        {
            int[][] matrix = new int[][]
            {
                new int[]{1,0,1,1,0,0,1,0,0,1},
                new int[]{0,1,1,0,1,0,1,0,1,1},
                new int[]{0,0,1,0,1,0,0,1,0,0},
                new int[]{1,0,1,0,1,1,1,1,1,1},
                new int[]{0,1,0,1,1,0,0,0,0,1},
                new int[]{0,0,1,0,1,1,1,0,1,0},
                new int[]{0,1,0,1,0,1,0,0,1,1},
                new int[]{1,0,0,0,1,1,1,1,0,1},
                new int[]{1,1,1,1,1,1,1,0,1,0},
                new int[]{1,1,1,1,0,1,0,0,1,1},
            };

            var actual = UpdateMatrix(matrix);

            var expected = new int[][]
            {
                new int[]{1,0,1,1,0,0,1,0,0,1},
                new int[]
                    {0,1,1,0,1,0,1,0,1,1},
                new int[]
                    { 0,0,1,0,1,0,0,1,0,0},

                new int[]
                { 1,0,1,0,1,1,1,1,1,1},
                new int[]
                { 0,1,0,1,1,0,0,0,0,1},
                new int[]
                { 0,0,1,0,1,1,1,0,1,0},
                new int[]
                { 0,1,0,1,0,1,0,0,1,1},
                new int[]
                { 1,0,0,0,1,2,1,1,0,1},
                new int[]
                { 2,1,1,1,1,2,1,0,1,0},
                new int[]                { 3,2,2,1,0,1,0,0,1,1}
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        private Dictionary<(int, int), int> _memo;
        public int[][] UpdateMatrix(int[][] matrix)
        {
            var res = new int[matrix.Length][];
            _memo = new Dictionary<(int, int), int>();
            for (var row = 0; row < matrix.Length; row++)
            {
                res[row] = new int[matrix[row].Length];
                for (var col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 0) continue;
                    res[row][col] = Dfs(matrix, row, col, 0);
                }
            }

            return res;
        }

        private int Dfs(int[][] matrix, int row, int col, int distance)
        {
            if (row >= matrix.Length || row < 0 || col < 0 || matrix[row].Length <= col || matrix[row][col] == -1)
            {
                return int.MaxValue;
            };

            if (matrix[row][col] == 0) return distance;

            if (distance > 2 && _memo.ContainsKey((row, col))) return _memo[(row, col)] + distance;

            var tmp = matrix[row][col];
            matrix[row][col] = -1; 

            var down = Dfs(matrix, row + 1, col, distance + 1);
            var up = Dfs(matrix, row - 1, col, distance + 1);
            var left = Dfs(matrix, row, col - 1, distance + 1);
            var right = Dfs(matrix, row, col + 1, distance + 1);

            var minDistance = Math.Min(Math.Min(down, up), Math.Min(right, left));

            if (minDistance != int.MaxValue)
            {
                if (_memo.ContainsKey((row, col)))
                    _memo[(row, col)] = Math.Min(_memo[(row, col)], minDistance - distance);
                else _memo.Add((row, col), minDistance - distance);
            }

            matrix[row][col] = tmp;

            return minDistance == int.MaxValue ? int.MaxValue : minDistance;
        }
    }
}