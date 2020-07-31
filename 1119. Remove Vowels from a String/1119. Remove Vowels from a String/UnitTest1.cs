using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        

        [Test]
        public void Test1()
        {
            var S = "leetcodeisacommunityforcoders";
            var actual = RemoveVowels(S);
            var expected = "ltcdscmmntyfrcdrs";
            Assert.AreEqual(expected, actual);
        }

        

        [Test]
        public void Test2()
        {
            var S = "aeiou";
            var actual = RemoveVowels(S);
            var expected = "";
            Assert.AreEqual(expected, actual);
        }

        public string RemoveVowels(string S)
        { 
            var answer = new StringBuilder();

            var vowels = new HashSet<char>() {'a', 'e', 'i', 'o', 'u'};

            foreach (var symbol in S)
            {
                if(vowels.Contains(symbol)) continue;

                answer.Append(symbol);
            }

            return answer.ToString();
        }
    }
}