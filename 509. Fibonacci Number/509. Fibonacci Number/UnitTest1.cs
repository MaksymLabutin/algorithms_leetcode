using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var N = 30;

            var actual = Fib(N);

            var expected = 832040;
            Assert.AreEqual(expected, actual);
        }


        private readonly Dictionary<int, int> _cache = new Dictionary<int, int>();
         
        public int Fib(int N)
        {
            if (N < 2) return N;

            var l = 0;

            if (_cache.ContainsKey(N - 1))
            {
                l = _cache[N - 1];
            }
            else
            {
                l = Fib(N - 1);
                _cache.Add(N - 1, l);
            }

            var r = 0;

            if (_cache.ContainsKey(N - 2))
            {
                r = _cache[N - 2];
            }
            else
            {
                r = Fib(N - 2);
                _cache.Add(N - 2, r);
            }
            return l + r;
        }
    }
}