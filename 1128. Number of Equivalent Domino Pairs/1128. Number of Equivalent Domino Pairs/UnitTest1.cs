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
            var hs = new Dictionary<(int, int), int>();
            var res = 0;
            foreach (var domino in dominoes)
            {
                if (domino[0] > domino[1])
                {
                    if (hs.ContainsKey((domino[1], domino[0])))
                    {
                        res += hs[(domino[1], domino[0])];
                        hs[(domino[1], domino[0])] += 1;
                    }
                    else hs.Add((domino[1], domino[0]), 1);
                }
                else
                {
                    if (hs.ContainsKey((domino[0], domino[1])))
                    {
                        res += hs[(domino[0], domino[1])];
                        hs[(domino[0], domino[1])] += 1;
                    }
                    else hs.Add((domino[0], domino[1]), 1);
                }
            }

            return res;
        }
    }
}