using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private NumMatrix _numMatrix;
        [SetUp]
        public void SetUp()
        {
            var matrix = new int[][]
            {
                new[] {3, 0, 1, 4, 2},
                new[] {5, 6, 3, 2, 1},
                new[] {1, 2, 0, 1, 5},
                new[] {4, 1, 0, 1, 7},
                new[] {1, 0, 3, 0, 5},
                new[] {2, 1, 4, 3},
                new[] {1, 1, 2, 2},
                new[] {1, 2, 2, 4}
            };

            _numMatrix = new NumMatrix(matrix);
        }

        [Test]
        public void Test1()
        { 
            var actual = _numMatrix.SumRegion(1, 1, 1, 1);
            var expected = 6;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        { 
            var actual = _numMatrix.SumRegion(0, 0, 4, 4);
            var expected = 58;
            Assert.AreEqual(expected, actual);
        }

        public class NumMatrix
        { 
            private readonly int[][] _matrix;
            private readonly Dictionary<(int, int, int, int), int> _visited;

            public NumMatrix(int[][] matrix)
            {
                _matrix = matrix;
                _visited = new Dictionary<(int, int, int, int), int>();
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            { 
                if (_visited.ContainsKey((row1, col1, row2, col2))) return _visited[(row1, col1, row2, col2)];

                var sum = 0; 

                for (int i = row1; i <= row2; i++)
                {
                    for (int j = col1; j <= col2; j++)
                    {
                        sum += _matrix[i][j];
                    }
                }

                _visited.Add((row1, col1, row2, col2), sum);

                return sum;
            }
        }
       
    }
}