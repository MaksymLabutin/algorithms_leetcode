using System.Collections;
using System.Collections.Generic;
using System.Xml;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var str = "((**";

            var res = CheckValidString(str);

            Assert.IsTrue(res);
        }


        [Test]
        public void Test2()
        {
            var str = "(( **";

            var res = CheckValidString(str);

            Assert.IsFalse(res);
        }


        [Test]
        public void Test3()
        {
            var str = "()";

            var res = CheckValidString(str);

            Assert.IsTrue(res);
        }

        [Test]
        public void Test4()
        {
            var str = "(*)";

            var res = CheckValidString(str);

            Assert.IsTrue(res);
        }

        [Test]
        public void Test5()
        {
            var str = "(*))";

            var res = CheckValidString(str);

            Assert.IsTrue(res);
        }

        [Test]
        public void Test6()
        {
            var str = "(())((())()()(*)(*()(())())())()()((()())((()))(*";

            var res = CheckValidString(str);

            Assert.IsFalse(res);
        }
 
        [Test]
        public void Test7()
        {
            var str = "(((******))";

            var res = CheckValidString(str);

            Assert.IsTrue(res);
        }
 
        [Test]
        public void Test8()
        {
            var str = ")";

            var res = CheckValidString(str);

            Assert.IsFalse(res);
        }
 
        public bool CheckValidString(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;

            var left = new Stack<int>();
            var undef = new Stack<int>();

            for (var i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case ')':
                        if (left.Count == 0 && undef.Count > 0) undef.Pop();
                        else if (left.Count == 0 && undef.Count == 0) return false;
                        else left.Pop();
                        break; 
                    case '*':
                        undef.Push(i);
                        break; 
                    default:
                        left.Push(i);
                        break;
                }
            }

            while (left.Count > 0)
            {
                var el = left.Pop();
                if (undef.Count == 0 || undef.Pop() < el) return false;
            }

            return true;
        }
    }
}