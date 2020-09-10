using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var n = 2;
            var actual = GenerateParenthesis(n);

            var expected = new List<string>(){ "(())", "()()" };

            CollectionAssert.AreEqual(expected, actual); 
        }

        private List<string> _res;

        public IList<string> GenerateParenthesis(int n)
        {
            _res = new List<string>();
            if (n < 1) return _res;
            GenerateParenthesis(1, 0, n, "(");

            return _res;
        }

        public void GenerateParenthesis(int open, int close, int n, string s)
        { 
            if(close > open || n < open || n < close) return;
            
            if (open == n && close == n)
            {
                _res.Add(s);
                return;
            }

            GenerateParenthesis(open + 1, close, n, s + '(');
            GenerateParenthesis(open, close + 1, n, s + ')'); 
        }

    }
}