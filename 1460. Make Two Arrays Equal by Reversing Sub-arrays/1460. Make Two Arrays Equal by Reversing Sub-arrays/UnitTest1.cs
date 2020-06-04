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
            //[1,2,3,4]
            //    [2,4,1,3]

            var target = new int[] { 1, 2, 3, 4 };
            var arr = new int[] { 2, 4, 1, 3 };

            var actual = CanBeEqual(target, arr);

            Assert.True(actual);
        }

        public bool CanBeEqual(int[] target, int[] arr)
        {
            var sort = Sort(arr.ToList());
            var ints = Sort(target.ToList());
            return sort.SequenceEqual(ints);
        }

        private List<int> Sort(List<int> arr)
        {
            if (arr.Count < 2) return arr;

            var mid = arr.Count / 2;

            var l = Sort(arr.Take(mid).ToList());
            var r = Sort(arr.TakeLast(arr.Count - mid).ToList());

            return Merge(l, r);
        }

        private List<int> Merge(List<int> l, List<int> r)
        {
            var capacity = l.Count + r.Count;
            var res = new List<int>(capacity);

            var lPointer = 0;
            var rPointer = 0;

            for (var i = 0; i < capacity; i++)
            {
                if (rPointer >= r.Count || lPointer < l.Count && l[lPointer] < r[rPointer])
                {
                    res.Add(l[lPointer++]);
                }
                else
                {
                    res.Add(r[rPointer++]);
                }
            }

            return res;
        }
    }
}