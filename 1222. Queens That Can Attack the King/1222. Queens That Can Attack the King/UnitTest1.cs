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
            //[0, 1],[1, 0],[4, 0],[0, 4],[3, 3],[2, 4]
            var queens = new int[][] { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 4, 0 }, new[] { 0, 4 }, new[] { 3, 3 }, new[] { 2, 4 } };

            var king = new int[] { 0, 0 };

            var actual = QueensAttacktheKing(queens, king);

            var expected = new List<List<int>>()
                {new List<int>() {1, 0}, new List<int>() {0, 1}, new List<int>() {3, 3}};
            CollectionAssert.AreEqual(expected, actual);
        }


        [Test]
        public void Test2()
        {
            //[0, 1],[1, 0],[4, 0],[0, 4],[3, 3],[2, 4]
            var queens = new int[][] { new[] { 0, 0 }, new[] { 1, 1 }, new[] { 2, 2 }, new[] { 3, 4 }, new[] { 3, 5 }, new[] { 4, 4 }, new []{ 4, 5 } };

            var king = new int[] { 3, 3 };

            var actual = QueensAttacktheKing(queens, king);

            var expected = new List<List<int>>()
                {new List<int>() {3, 4}, new List<int>() {2, 2}, new List<int>() {4, 4}};
            CollectionAssert.AreEqual(expected, actual);
        }

        private HashSet<(int, int)> _queens;
        public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
        {
            var res = new List<IList<int>>();
            _queens = new HashSet<(int, int)>();

            foreach (var queen in queens)
            {
                _queens.Add((queen[0], queen[1]));
            }

            //top
            res.Add(FindQueenInDirection(king, -1, 0));
            //down
            res.Add(FindQueenInDirection(king, 1, 0));
            //left  
            res.Add(FindQueenInDirection(king, 0, -1));
            //right  
            res.Add(FindQueenInDirection(king, 0, +1));

            //top-left
            res.Add(FindQueenInDirection(king, -1, -1));
            //top-right
            res.Add(FindQueenInDirection(king, -1, 1));
            //down-left
            res.Add(FindQueenInDirection(king, 1, -1));
            //down-right 
            res.Add(FindQueenInDirection(king, 1, 1));

            return res.Where(_ => _.Count > 0).ToList();
        }

        private IList<int> FindQueenInDirection(int[] king, int verticalStep, int horizontalStep)
        {
            var res = new List<int>();

            var currVerticalPosition = king[0] + verticalStep;
            var currHorizontalPosition = king[1] + horizontalStep;

            while (currVerticalPosition >= 0 && currHorizontalPosition >= 0 && currVerticalPosition <= 8 && currHorizontalPosition <= 8)
            {
                if (_queens.Contains((currVerticalPosition, currHorizontalPosition)))
                {
                    res.Add(currVerticalPosition);
                    res.Add(currHorizontalPosition);
                    return res;
                }

                currVerticalPosition += verticalStep;
                currHorizontalPosition += horizontalStep;
            }

            return res;
        }

    }
}