using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var str = "()";

            var res = IsValid(str);

            Assert.IsTrue(res);
        }

        [Test]
        public void Test2()
        {
            var str = "()[]{}";

            var res = IsValid(str);

            Assert.IsTrue(res);
        }
            
        [Test]
        public void Test3()
        {
            var str = "(]";

            var res = IsValid(str);

            Assert.IsFalse(res);
        }

        [Test]
        public void Test4()
        {
            var str = "([)]";

            var res = IsValid(str);

            Assert.IsFalse(res);
        }

        [Test]
        public void Test5()
        {
            var str = "{[]}";

            var res = IsValid(str);

            Assert.IsTrue(res);
        }

        public bool IsValid(string s)
        {
            var s1 = new Stack<char>();

            for (var i = 0; i < s.Length; i++)
            {
                if (s1.Count > 0 &&( s1.Peek() + 1 == s[i] || s1.Peek() + 2 == s[i])) s1.Pop();
                else s1.Push(s[i]);
            }

            return s1.Count == 0;
        }
    }
}