using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class NumJewelsInStonesTests
    {
        [Test]
        public void Should_return_3_Whene_in_stones_3_stones_type()
        {
            var J = "aA";
            var S = "aAAbbbb";

            var res = NumJewelsInStones(J, S);

            Assert.AreEqual(3, res);
        }


        [Test]
        public void Should_return_0_Whene_no_stones_type()
        {
            var J = "z";
            var S = "ZZ";

            var res = NumJewelsInStones(J, S);

            Assert.AreEqual(0, res);
        }


        public int NumJewelsInStones(string J, string S)
        {
            if (string.IsNullOrEmpty(J) || string.IsNullOrEmpty(S)) return 0;

            var set = new HashSet<char>();
            foreach (var el in J)
            {
                set.Add(el);
            }

            var res = 0;

            foreach (var el in S)
            {
                if (set.Contains(el)) res++;
            }

            return res;
        }
    }
}