using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var S = "())";

            var actual = MinAddToMakeValid(S);

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var S = "(((";

            var actual = MinAddToMakeValid(S);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var S = "()";

            var actual = MinAddToMakeValid(S);

            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            var S = "()))((";

            var actual = MinAddToMakeValid(S);

            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        public int MinAddToMakeValid(string S)
        {
            if (string.IsNullOrEmpty(S)) return 0;

            var answer = 0;
            var openBreacks = 0;

            foreach (var symbol in S)
            {
                if (symbol == '(') openBreacks++;
                else
                {
                    if (openBreacks == 0) answer++;
                    else openBreacks--;
                }
            }

            return answer + openBreacks;
        }
    }
}