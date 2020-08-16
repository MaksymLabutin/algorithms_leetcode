using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var num = 2736;
            var actual = MaximumSwap(num);
            var expected = 7236;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var num = 9973;
            var actual = MaximumSwap(num);
            var expected = 9973;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var num = 998828;
            var actual = MaximumSwap(num);
            var expected = 998882;

            Assert.AreEqual(expected, actual);
        }

        public int MaximumSwap(int num)
        {
            var s = new StringBuilder();
            s.Append(num);

            var dictionary = new Dictionary<int, List<int>>();

            for(var i = 0; i < s.Length; i++)
            {
                var currNum = int.Parse(s[i].ToString());
                if (dictionary.ContainsKey(currNum)) dictionary[currNum].Add(i);
                else dictionary.Add(currNum, new List<int>(){ i });
            }

            var pointer = -1;
            var hasSwaped = false;

            while (!hasSwaped)
            {
                pointer++;
                if(pointer >= s.Length)break;
                var val = int.Parse(s[pointer].ToString());

                if (val == 9) continue;

                var maxVal = 9;
                while (maxVal != val && !hasSwaped)
                { 
                    if (dictionary.ContainsKey(maxVal) && dictionary[maxVal].Any(index => index > pointer))
                    {
                        s[pointer] = s[dictionary[maxVal].Last()];
                        s[dictionary[maxVal].Last()] = val.ToString()[0];
                        hasSwaped = true;
                    }
                    else
                    {
                        maxVal--;
                    }
                }  
            }
          
            return int.Parse(s.ToString());
        }
    }
}