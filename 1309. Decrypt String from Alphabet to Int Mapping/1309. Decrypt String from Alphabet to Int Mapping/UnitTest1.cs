using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var s = "10#11#12";
            var actual = FreqAlphabets(s);
            var expected = "jkab";
            Assert.AreEqual(expected,actual);
        }

        public string FreqAlphabets(string s)
        {
            var alphabet = new Dictionary<string, char>();
            int i = 1;
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                alphabet.Add(i <= 9 ? i.ToString() : $"{i}#", letter);
                i++;
            }

            var str = new StringBuilder();
            i = s.Length - 1;
            while (i >= 0)
            {
                if (s[i] == '#')
                {
                    var val = $"{s[i - 2]}{s[i - 1]}#";
                    str.Insert(0, alphabet[val]);
                    i -= 3;
                }
                else
                {
                    str.Insert(0, alphabet[s[i].ToString()]);
                    i--;
                }
            }
            return str.ToString();
        }
    }
}