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
            var left = 1;
            var right = 22;

            var actual = SelfDividingNumbers(left, right);

            var expected = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22 };
            CollectionAssert.AreEqual(expected, actual); 
        }


        public IList<int> SelfDividingNumbers(int left, int right)
        {
            var res = new List<int>();

            while (left <= right)
            {
                var str = left.ToString();
                var isValid = true;
                foreach (var symbol in str)
                {
                    var number = int.Parse(symbol.ToString());
                    if (number == 0 || left % number != 0)
                    {
                        isValid = false;
                        break;
                    } 
                }

                if (isValid) res.Add(left);
                left++;
            }

            return res;
        }
    }
}