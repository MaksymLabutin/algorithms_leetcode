using System;
using System.Text;
using NUnit.Framework;

namespace ToLowerCase
{
    public class ToLowerCaseTests
    { 

        [Test]
        public void Should_return_hello()
        {
            var str = "Hello";

            var res = ToLowerCase(str);

            var expectedRes = "hello";

            Assert.AreEqual(res, expectedRes);
        }


        [Test]
        public void Should_return_lovely()
        {
            var str = "LOVELY";

            var res = ToLowerCase(str);

            var expectedRes = "lovely";

            Assert.AreEqual(res, expectedRes);
        }

         
        [Test]
        public void Should_return_hello_world()
        {
            var str = "HeLlO-WoRlD";

            var res = ToLowerCase(str);

            var expectedRes = "hello-world";

            Assert.AreEqual(res, expectedRes);
        }


        public string ToLowerCase(string str)
        {
            var alphabet = new char[]{'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

            var res = new StringBuilder();

            foreach (var symbol in str)
            {
                if (symbol >= 65 && symbol <= 91)
                {
                    res.Append(alphabet[symbol - 65]);
                }
                else
                {
                    res.Append(symbol);
                }
            }

            return res.ToString();

        }
    }
}