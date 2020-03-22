using System.Text;
using NUnit.Framework;

namespace DefangingIPAddress
{
    public class DefangIPaddrTests
    {

        [Test]
        public void Test1()
        {
            var address = "1.1.1.1";

            var res = DefangIPaddr(address);

            var expectedRes = "1[.]1[.]1[.]1";

            Assert.AreEqual(res, expectedRes);
        }


        [Test]
        public void Test2()
        {
            var address = "255.100.50.0";

            var res = DefangIPaddr(address);

            var expectedRes = "255[.]100[.]50[.]0";

            Assert.AreEqual(res, expectedRes);
        }

        public string DefangIPaddr(string address)
        {
            var str = new StringBuilder();

            foreach (var symbol in address)
            {
                if (symbol != '.')
                {
                    str.Append(symbol);
                }
                else
                {  
                    str.Append($"[{symbol}]"); 
                }
            }

            return str.ToString();
        }
    }
}