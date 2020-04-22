using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            var s = "3[a]2[bc]";

            var acutal = DecodeString(s);

            var expected = "aaabcbc";
             
            Assert.AreEqual(expected, acutal);
        }

        [Test]
        public void Test2()
        {
            var s = "3[a2[c]]";

            var acutal = DecodeString(s);

            var expected = "accaccacc";
             
            Assert.AreEqual(expected, acutal);
        }

        [Test]
        public void Test3()
        {
            var s = "2[abc]3[cd]ef";

            var acutal = DecodeString(s);

            var expected = "abcabccdcdcdef";
             
            Assert.AreEqual(expected, acutal);
        }

        [Test]
        public void Test4()
        {
            var s = "[a]11[b]";

            var acutal = DecodeString(s);

            var expected = "abbbbbbbbbbb";
             
            Assert.AreEqual(expected, acutal);
        }

        public string DecodeString(string s)
        {
            var _k = new Stack<int?>();
            var strings = new Stack<string>();

            var str = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
            {
                int? k;
                switch (s[i])
                {
                    case '[':
                        k = GetK(s, i);
                        if(k != null) str.Remove(str.Length - k.ToString().Length, k.ToString().Length);
                        strings.Push(str.ToString());
                        str.Clear();
                        _k.Push(k);
                        break;
                    case ']':
                        k = _k.Pop();
                        var res = "";
                        if (k != null)
                        {
                            res = MultipleStr(str, (int)k);
                        }
                        else
                        {
                            res = str.ToString();
                        } 
                            str.Clear();

                        if (strings.Count > 0) str.Append(strings.Pop());
                        str.Append(res);
                         
                        break;
                    default:
                        str.Append(s[i]);
                        break;
                        
                }
            }
             
            return str.ToString();
        }

        private string MultipleStr(StringBuilder str, int k)
        {
            var res = new StringBuilder();
            for (int i = 0; i < k; i++)
            {
                res.Append(str);
            }

            return res.ToString();
        }

        private int? GetK(string s, int pointer)
        {
            pointer--;
            if (pointer < 0) return null;

            int? k = null; 
            var numberStr = "";
            while (pointer >= 0)
            {
                numberStr = s[pointer] + numberStr;
                if(!int.TryParse(numberStr, out int _k))
                {
                    return k;
                }

                k = _k;

                pointer--;
            }

            return k;
        }
    }
}