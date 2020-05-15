using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var n = 3;
            GenerateMatrix(n);
            Assert.Pass();
        }


        private int _colPointer;
        private int _rowPointer;
        private Direction _direction;
        private int[][] _arr;
        public int[][] GenerateMatrix(int n)
        { 
            _arr = new int[n][];
            for (int i = 0; i < n; i++)
            {
                _arr[i] = new int[n];
            }

            var currVal = 1;
            var pow = Math.Pow(n, 2);

            _direction = Direction.Right;
            _colPointer = 0;
            _rowPointer = 0;

            while (currVal <= pow)
            {
                _arr[_rowPointer][_colPointer] = currVal;
                GetNextCell(n);
                currVal++;
            }

            return _arr;
        }

        private void GetNextCell(int n)
        {
            switch (_direction)
            {
                case Direction.Right:
                    if (_colPointer + 1 >= n || _arr[_rowPointer][_colPointer + 1] > 0)
                    {
                        _direction = Direction.Down;
                        _rowPointer++;
                    }
                    else
                    {
                        _colPointer++;
                    }
                    break;

                case Direction.Down:
                    if (_rowPointer + 1 >= n || _arr[_rowPointer + 1][_colPointer] > 0)
                    {
                        _direction = Direction.Left;
                        _colPointer--;
                    }
                    else
                    {
                        _rowPointer++;
                    }
                    break;

                case Direction.Left:
                    if (_colPointer - 1 < 0 || _arr[_rowPointer][_colPointer - 1] > 0)
                    {
                        _direction = Direction.Top;
                        _rowPointer--;
                    }
                    else
                    {
                        _colPointer--;
                    }
                    break;

                case Direction.Top:
                    if (_rowPointer - 1 < 0 || _arr[_rowPointer - 1][_colPointer] > 0)
                    {
                        _direction = Direction.Right;
                        _colPointer++;
                    }
                    else
                    {
                        _rowPointer--;
                    }
                    break;

            }
        }

        public enum Direction
        {
            Left,
            Right,
            Top,
            Down
        }
    }
}