using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var res = ContainsDuplicate(new int[] {1, 2, 3, 1});

            Assert.IsTrue(res);
        }

        [Test]
        public void Test2()
        {
            var res = ContainsDuplicate(new int[] {1, 2, 3, 4});

            Assert.IsFalse(res);
        }


        public bool ContainsDuplicate(int[] nums)
        {
            var hashSet = new HashSet<int>();

            foreach (var num in nums)
            {
                if (hashSet.Contains(num)) return true;
                hashSet.Add(num);
            }

            return false;
        }
    }
}