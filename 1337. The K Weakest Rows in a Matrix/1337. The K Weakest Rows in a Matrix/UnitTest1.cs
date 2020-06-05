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
            //[[1,1,0,0,0],
            //    [1,1,1,1,0],
            //    [1,0,0,0,0],
            //    [1,1,0,0,0],
            //    [1,1,1,1,1]], 
            //
            //Output: [2,0,3]
            var mat = new int[][]
            {
                new[] {1, 1, 0, 0, 0},
                new[] {1, 1, 1, 1, 0},
                new[] {1, 0, 0, 0, 0},
                new[] {1, 1, 0, 0, 0},
                new[] {1, 1, 1, 1, 1},
            };
            var k = 3;

            var actual = KWeakestRows(mat, k);

            var expected = new int[] {2, 0, 3};
            CollectionAssert.AreEqual(expected, actual);
        }

        public int[] KWeakestRows(int[][] mat, int k)
        {
            var dic = new Dictionary<int, int>();

            for (int i = 0; i < mat.Length; i++)
            {
                var sum = mat[i].Sum();
                dic.Add(i, sum);
            }

            return dic.OrderBy(_ => _.Value).Select(_ => _.Key).Take(k).ToArray();
        }
    }
}