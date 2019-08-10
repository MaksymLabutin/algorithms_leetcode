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
            var res = IsHappy(19);

            Assert.IsTrue(res);
        }

        [Test]
        public void Test2()
        {
            var res = IsHappy(21);

            Assert.IsFalse(res);
        }

        public bool IsHappy(int n)
        {
            var set = new HashSet<int>(){n}; 

            while (true)
            {
                var str = set.Last().ToString();

                var res = 0;
                for (var index = 0; index < str.Length; index++)
                {
                    var t = int.Parse(str[index].ToString());
                    res +=  t * t;
                }

                if (res == 1) return true;
                if () return false;
                set.Add(res);
            }
             
        }
    }
}