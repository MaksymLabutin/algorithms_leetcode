using System.Diagnostics;
using System.Text;
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
            var res = LongestCommonPrefix(new []{ "flower", "flow", "flight" });
   
            Assert.AreEqual(res, "fl");
        }
        [Test]
        public void Test2()
        { 
            var res = LongestCommonPrefix(new []{""});
   
            Assert.AreEqual(res, "");
        }

        [Test]
        public void Test3()
        { 
            var res = LongestCommonPrefix(new []{"", ""});
   
            Assert.AreEqual(res, "");
        }

        [Test]
        public void Test4()
        { 
            var res = LongestCommonPrefix(new []{"1 1", "1 11"});
   
            Assert.AreEqual(res, "1 1");
        }

        public string LongestCommonPrefix(string[] strs)
        { 
            if (strs.Length == 0 || (strs.Length == 1 && strs[0] == "")) return "";

            if (strs.Length == 1) return strs[0];
             
            var index = 0;

            var str = strs[0];

            while (true)
            {
                var currentChar = '\0';

                foreach (var el in strs)
                {
                    if (el.Length <= index) return str.Substring(0, index);

                    if (currentChar == '\0' && el[index] != '\0') currentChar = el[index];

                    if (el[index] != currentChar) return str.Substring(0, index);
                }

                index++; 
            } 
        }
    }
}