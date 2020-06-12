using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var arr = new int[] { 1, 0, 2, 3, 0, 4, 5, 0 };

            DuplicateZeros(arr);

            var expected = new int[] { 1, 0, 0, 2, 3, 0, 0, 4 };

            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void Test2()
        {
            var arr = new int[] {0, 0, 0, 0, 0, 0, 0 };

            DuplicateZeros(arr);

            var expected = new int[] { 0, 0, 0, 0, 0, 0, 0 };

            CollectionAssert.AreEqual(expected, arr);
        }

        public void DuplicateZeros(int[] arr)
        { 
            var q = new Queue<int>();
            for (var i = 0; i < arr.Length; i++)
            {
                if (q.Count > 0)
                {
                    q.Enqueue(arr[i]);
                    arr[i] = q.Dequeue();

                }
                if (arr[i] != 0) continue;

                if(i + 1 >= arr.Length) return;
                
                q.Enqueue(arr[i + 1]);
                arr[i + 1] = 0;
                i++;
            }
        }
    }
}