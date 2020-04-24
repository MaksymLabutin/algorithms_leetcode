using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var arr = new int[] {4, 2, 3, 0, 3, 1, 2};
            var start = 5;

            var actual = CanReach(arr, start);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test2()
        {
            var arr = new int[] { 4, 2, 3, 0, 3, 1, 2 };
            var start = 0;

            var actual = CanReach(arr, start);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test3()
        {
            var arr = new int[] { 3, 0, 2, 1, 2 };
            var start = 2;

            var actual = CanReach(arr, start);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Test4()
        {
            var arr = new int[] { 0, 1 };
            var start = 1;

            var actual = CanReach(arr, start);

            Assert.IsTrue(actual);
        }

        public bool CanReach(int[] arr, int start)
        {
            var indexes = new Queue<int>();
            indexes.Enqueue(start);
            var visited = new HashSet<int>();

            while (indexes.Count > 0)
            { 
                var size = indexes.Count;

                for (var i = 0; i < size; i++)
                {
                    var index = indexes.Dequeue();

                    if (visited.Contains(index)) continue;
                    
                    if (arr[index] == 0) return true;

                    visited.Add(index);

                    if (arr[index] + index < arr.Length) indexes.Enqueue(arr[index] + index);
                    if(index - arr[index] >= 0) indexes.Enqueue(index - arr[index]);
                }
            }

            return false;
        }
    }
}