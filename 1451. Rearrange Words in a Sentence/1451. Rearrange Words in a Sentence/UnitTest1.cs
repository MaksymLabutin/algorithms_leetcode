using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        

        [Test]
        public void Test1()
        {
            var text = "Leetcode is cool";

            var actual = ArrangeWords(text); 

            var expected = "Is cool leetcode";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var text = "Keep calm and code on";

            var actual = ArrangeWords(text); 

            var expected = "On and keep calm code";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var text = "To be or not to be";

            var actual = ArrangeWords(text); 

            var expected = "To be or to be not";

            Assert.AreEqual(expected, actual);
        }

        public string ArrangeWords(string text)
        {
            if (text.Length == 1) return text;

            var words = text.Split(' ').OrderBy(_ => _.Length).ToList();

            var res = new StringBuilder();

            foreach (var word in words)
            { 
                if (res.Length == 0)
                {
                    res.Append(word[0].ToString().ToUpper());
                    if (word.Length > 1) res.Append(word.Substring(1, word.Length - 1));
                }
                else
                {
                    res.Append(word.ToLower());
                }

                res.Append(' ');
            }

            return res.Remove(res.Length - 1, 1).ToString();
        }
    }
}