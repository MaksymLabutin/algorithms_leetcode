using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        //todo
        public int NumEquivDominoPairs(int[][] dominoes)
        {
            var hs = new HashSet<(int, int)>();
            var res = 0;
            foreach (var domino in dominoes)
            {
                if (domino[0] > domino[1])
                {
                    if(hs.Contains((domino[1], domino[0]))) res++;
                    else hs.Add((domino[1], domino[0]));
                }
                else
                {
                    if (hs.Contains((domino[0], domino[1]))) res++;
                    else hs.Add((domino[0], domino[1]));
                }
            }

            return res;
        }
    }
}