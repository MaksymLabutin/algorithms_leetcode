using System;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var actual = AddStrings("99", "9");
            Assert.AreEqual("108", actual);
        }


        public string AddStrings(string num1, string num2)
        {
            if (string.IsNullOrEmpty(num1) || string.IsNullOrEmpty(num2)) return num1 ?? num2;

            var lP = num1.Length - 1;
            var rP = num2.Length - 1;
         
            var tmp = 0;

            var str = new StringBuilder();
            while (lP >= 0 || rP >= 0)
            {
                var lVal = lP >= 0 ?  num1[lP] - '0' : 0;
                var rVal = rP >= 0 ?  num2[rP] - '0' : 0;
                var val = tmp + lVal + rVal;
                tmp = val > 9 ? 1 : 0;
                val = val > 9 ? val - 10 : val;

                str.Insert(0, val);
                lP--;
                rP--;
            }

            if (tmp == 1) str.Insert(0, 1);

            return str.ToString();

        }
    }   
}