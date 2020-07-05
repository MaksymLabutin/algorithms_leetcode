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
            var people = new int[][]
            {
                new[] {7, 1},
                new[] {7, 0},
                new[] {4, 4},
                new[] {5, 0},
                new[] {6, 1},
                new[] {5, 2}

            };

            var actual = ReconstructQueue(people);

            var expected = new int[][]
            {
                new[] {5, 0},
                new[] {7, 0},
                new[] {5, 2},
                new[] {6, 1},
                new[] {4, 4},
                new[] {7, 1}
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        public int[][] ReconstructQueue(int[][] people)
        {
            int n = people.Length;

            var sortedArray = people.OrderByDescending(x => x[0]).ThenBy(x => x[1]).ToList();
            var result = new List<int[]>(n);

            foreach (int[] arr in sortedArray)
            {
                result.Insert(arr[1], arr);
            }

            return result.ToArray();
        }
        
    }
}