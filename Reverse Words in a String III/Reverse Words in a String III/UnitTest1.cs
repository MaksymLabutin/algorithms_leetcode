using System.Text;
using System.Threading;
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
            var res = ReverseWords("Let's take LeetCode contest");

            Assert.AreEqual(res, "s'teL ekat edoCteeL tsetnoc");
        }

        [Test]
        public void Test2()
        {
            var res = ReverseWords(" ");

            Assert.AreEqual(res, string.Empty);
        }
        [Test]
        public void Test3()
        {
            var res = ReverseWords("test ");

            Assert.AreEqual(res, "tset");
        }
  [Test]
        public void Test4()
        {
            var res = ReverseWords("I love u");

            Assert.AreEqual(res, "I evol u");
        }

        public string ReverseWords(string s)
        {
            var str = new StringBuilder();

            int pointer = 0, startWord = 0;

            while (pointer < s.Length - 1)
            {
                pointer++; 
                if (!char.IsWhiteSpace(s[pointer])) continue;

                var currentPosition = pointer;
                pointer--;
                while (pointer >= startWord)
                {
                    if (pointer == currentPosition - 1) str.Append(' ');
                    str.Append(s[pointer--]);
                }

                pointer = currentPosition + 1;
                startWord = pointer; 
            }

            if (str.Length == s.Length) return str.ToString().Trim();

            while (pointer >= startWord)
            {
                if (pointer == s.Length - 1) str.Append(' ');
                str.Append(s[pointer--]);
            }
             
            return str.ToString().Trim();
        } 

    }
}