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
            var S = "cba";
            var T = "abcd";

            var actual = CustomSortString(S, T);
            var expected = "cbad";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {   
            var S = "cba";
            var T = "abcdqsalasdfoiuasdfoiujkljdasdfasdf";

            var actual = CustomSortString(S, T);
            var expected = "dqslsdfoiusdfoiujkljdsdfsdfcbaaaaaa";
            Assert.AreEqual(expected, actual);
        }

        private Dictionary<char, int> _s;

        public string CustomSortString(string S, string T)
        {
            if (string.IsNullOrEmpty(S) || string.IsNullOrEmpty(T) || S.Length == 1) return T;

            _s = new Dictionary<char, int>();
            var i = 0;
            foreach (var s in S)
            {
                _s.Add(s, i++);
            }

            var splitedStr = Split(T);

            return splitedStr.notInS + Sort(splitedStr.inS);
        }

        private (string notInS, string inS) Split(string T)
        {
            var notInS = new StringBuilder();
            var inS = new StringBuilder();

            foreach (var t in T)
            {
                if (_s.ContainsKey(t)) inS.Append(t);
                else notInS.Append(t);
            }

            return (notInS.ToString(), inS.ToString());
        }

        private string Sort(string str)
        {
            if (str.Length < 2) return str;

            var mid = str.Length / 2;
            var l = Sort(str.Substring(0, mid));
            var r = Sort(str.Substring(mid, str.Length - mid));

            return Marge(l, r);
        }

        private string Marge(string l, string r)
        {
            var str = new StringBuilder();

            var lPointer = 0;
            var rPointer = 0;

            while (lPointer < l.Length || rPointer < r.Length)
            {

                if (lPointer >= l.Length || rPointer < r.Length && _s[r[rPointer]] < _s[l[lPointer]])
                    str.Append(r[rPointer++]);
                else str.Append(l[lPointer++]);
            }

            return str.ToString();

        }

    }
}