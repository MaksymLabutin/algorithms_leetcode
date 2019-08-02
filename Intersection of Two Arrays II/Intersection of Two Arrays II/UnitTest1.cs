using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var res = Intersection(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 });
            CollectionAssert.AreEqual(res, new int[] { 2, 2 });
        }

        [Test]
        public void Test2()
        {
            var res = Intersection(new int[] { 1, 1 }, new int[] { 2, 2 });
            CollectionAssert.AreEqual(res, new int[] { });
        }

        [Test]
        public void Test3()
        {
            var res = Intersection(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 });
            CollectionAssert.AreEqual(res, new int[] { 9, 4 });
        }

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var dicNum = new Dictionary<int, int>();

            foreach (var t in nums1)
            {
                if (dicNum.ContainsKey(t))
                {
                    dicNum[t] += 1;
                }
                else
                {
                    dicNum.Add(t, 1);
                }
            }

            var res = new List<int>();

            foreach (var t in nums2)
            {
                if (!dicNum.ContainsKey(t)) continue;
                if (dicNum[t] == 0) continue;

                dicNum[t] -= 1;
                res.Add(t);
            }

            return res.ToArray();

        }
    }
}