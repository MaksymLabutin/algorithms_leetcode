using System.Collections.Generic;
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
            var res = Intersection(new int[] {1, 2, 2, 1}, new int[] {2, 2});
            CollectionAssert.AreEqual(res, new int[]{2});
        }


        [Test]
        public void Test2()
        {
            var res = Intersection(new int[] {1, 1}, new int[] {2, 2});
            CollectionAssert.AreEqual(res, new int[]{});
        }

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var dicNum = new Dictionary<int, int>(); 
            var dic2Num = new Dictionary<int, int>(); 

            foreach (var t in nums1)
            {
                if(dicNum.ContainsKey(t)) continue;
                dicNum.Add(t, 0);
            }

            var res = new List<int>();

            foreach (var t in nums2)
            {
                if(!dicNum.ContainsKey(t) || dicNum.ContainsKey(t) && dic2Num.ContainsKey(t)) continue;
                dic2Num.Add(t, 0);
                res.Add(t);
            } 
             
            return res.ToArray();

        }

    }
}