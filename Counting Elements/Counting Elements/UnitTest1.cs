using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var arr = new int[] {1, 2, 3};

            var actual = CountElements(arr);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var arr = new int[] { 1, 1, 3, 3, 5, 5, 7, 7 };

            var actual = CountElements(arr);

            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var arr = new int[] { 1, 3, 2, 3, 5, 0 };

            var actual = CountElements(arr);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            var arr = new int[] { 1, 1, 2, 2 };

            var actual = CountElements(arr);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        public int CountElements(int[] arr)
        {
            var set = new HashSet<int>();

            foreach (var el in arr)
            {
                if (!set.Contains(el))
                { 
                    set.Add(el);
                }
            }

            var count = 0;

            foreach (var el in arr)
            {
                count = set.Contains(el + 1) ? 1 + count : count;
            }

            return count;
        }
    }
}