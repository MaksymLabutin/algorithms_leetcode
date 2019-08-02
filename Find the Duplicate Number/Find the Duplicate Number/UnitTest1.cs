using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var res = FindDuplicate(new[] {1, 3, 4, 2, 2});

            Assert.AreEqual(res, 2);
        }


        public int FindDuplicate(int[] nums)
        {
            var dic = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (dic.ContainsKey(num)) return num;
                dic.Add(num, num);
            } 
            return 0;
        }
    }
}