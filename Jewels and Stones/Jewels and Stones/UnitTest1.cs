using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var res = NumJewelsInStones("aA", "aAAbbbb");

            Assert.AreEqual(res, 3);
        }

        [Test]
        public void Test2()
        {
            var res = NumJewelsInStones("z", "ZZ");

            Assert.AreEqual(res, 0);
        }

        public int NumJewelsInStones(string J, string S)
        {
            var map = new HashSet<char>(J);
             
            var res = 0;
            foreach (var t in S)
            {
                if (map.Contains(t)) res++;
            }

            return res;
        }
    }
}