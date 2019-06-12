using NUnit.Framework;
using NUnit.Framework.Internal;

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
            var res = StrStr("hello", "ll");
            
            Assert.IsTrue(res == 2);
        }

        [Test]
        public void Test2()
        {
            var res = StrStr("aaaaa", "bba");
            
            Assert.IsTrue(res == -1);
        }


        [Test]
        public void Test3()
        {
            var res = StrStr("aaaaall", "ll");
            
            Assert.IsTrue(res == 5);
        }

        [Test]
        public void Test4()
        {
            var res = StrStr("aaaaall", "");
            
            Assert.IsTrue(res == 0);
        }

        public int StrStr(string haystack, string needle)
        {

            if (needle.Length == 0) return 0;
            if (needle.Length > haystack.Length) return -1;

            for (var index = 0; index < haystack.Length + 1 - needle.Length; index++)
            {
                var subStr = haystack.Substring(index, needle.Length);

                if (subStr == needle) return index;
            }

            return -1;
        }
    }
}