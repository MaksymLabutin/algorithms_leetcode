using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var arr = new int[][]
            {
                new[] {1, 1, 0},
                new[] {1, 0, 1},
                new[] {0, 0, 0}
            };

            var res = FlipAndInvertImage(arr);

            var expectedRes = new int[][]
            {
                new[] {1,0,0},
                new[] {0, 1, 0},
                new[] {1,1,1}
            };
            CollectionAssert.AreEqual(expectedRes, res);
        }

        [Test]
        public void Test2()
        {
            var arr = new int[][]
            {
                new[] {1,1,0,0},
                new[] {1,0,0,1},
                new[] { 0, 1, 1, 1 },
                new[] { 1, 0, 1, 0 }
            };

            var res = FlipAndInvertImage(arr);

            var expectedRes = new int[][]
            {
                new[] {1,1,0,0},
                new[] {0,1,1,0},
                new[] { 0, 0, 0, 1 },
                new[] { 1, 0, 1, 0 }
            };
            CollectionAssert.AreEqual(expectedRes, res);
        }

        public int[][] FlipAndInvertImage(int[][] A)
        {
            foreach (var element in A)
            {
                var st = new Stack<int>();
                foreach (var t in element)
                {
                    st.Push(t);
                }
                for (var j = 0; j < element.Length; j++)
                {
                    var val = st.Pop();

                    element[j] = val == 1 ? 0 : 1;

                }
            }

            return A;
        }
    }
}