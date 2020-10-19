using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace _187._Repeated_DNA_Sequences
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT";
            
            var actual = FindRepeatedDnaSequences(s);

            var expected = new List<string>() {"AAAAACCCCC", "CCCCCAAAAA"};

            Assert.Equal(expected, actual);
        }

        public IList<string> FindRepeatedDnaSequences(string s)
        {
            if(string.IsNullOrEmpty(s) || s.Length < 11) return new List<string>();

            var hs = new HashSet<string>();
            var l = 0;

            var res = new HashSet<string>();

            while (l + 9 < s.Length)
            {
                var substring = s.Substring(l, 10);
                if (hs.Contains(substring)) res.Add(substring);
                else hs.Add(substring);
                l++;
            }

            return res.ToList();
        }
    }
}
