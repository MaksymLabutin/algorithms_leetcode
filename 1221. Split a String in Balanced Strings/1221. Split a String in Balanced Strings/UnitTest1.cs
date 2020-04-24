using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var s = "RLRRLLRLRL";

            var actual = BalancedStringSplit(s);

            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var s = "RLLLLRRRLR";

            var actual = BalancedStringSplit(s);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var s = "LLLLRRRR";

            var actual = BalancedStringSplit(s);

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            var s = "RLRRRLLRLL";

            var actual = BalancedStringSplit(s);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        public int BalancedStringSplit(string s)
        {
            var num = 0;

            var tmp = 0;

            for (int i = 0; i < s.Length; i++)
            {
                tmp += s[i] == 'R' ? 1 : -1;
                if (tmp == 0) num++;
            } 

            return num; 
        }
    }
}