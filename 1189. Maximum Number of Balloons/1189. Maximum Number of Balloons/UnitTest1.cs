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
            var text = "nlaebolko";

            var actual = MaxNumberOfBalloons(text);
            
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        public int MaxNumberOfBalloons(string text)
        {
            if (text.Length < 5) return 0;

            var dic = new Dictionary<char, int>()
            {
                {'b', 0 },
                {'a', 0 },
                {'l', 0 },
                {'o', 0 },
                {'n', 0 }
            };

            foreach (var symbol in text)
            {
                if (dic.ContainsKey(symbol)) dic[symbol] += 1;
            }

            if (dic['l'] == 0 || dic['o'] == 0) return 0;

            dic['l'] = dic['l'] / 2;
            dic['o'] = dic['o'] / 2;

            return dic.Values.Min();
        }
    }
}