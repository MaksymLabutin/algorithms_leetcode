using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SingleNumber
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {

            var arr = new[] { 4, 1, 2, 1, 2 };

            var res = SingleNumber(arr);

            var expectedRes = 4;

            Assert.AreEqual(expectedRes, res);
        }


        [Test]
        public void Test2()
        {

            var arr = new[] { 2, 2, 1 };

            var res = SingleNumber(arr);

            var expectedRes = 1;

            Assert.AreEqual(expectedRes, res);
        }


        public int SingleNumber(int[] nums)
        {
            var hs = new HashSet<int>();

            foreach (var num in nums)
            {
                if(hs.Contains(num)) hs.Remove(num);
                else
                {
                    hs.Add(num);
                }
            }

            return hs.First();
        }
    }
}