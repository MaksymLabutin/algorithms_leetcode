
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        //canConstruct("a", "b") -> false
        //canConstruct("aa", "ab") -> false
        //canConstruct("aa", "aab") -> true

        [Test]
        public void Test1()
        {
            var ransomNote = "a";
            var magazine = "b";

            var actual = CanConstruct(ransomNote, magazine);

            Assert.False(actual);
        }

        [Test]
        public void Test2()
        {
            var ransomNote = "aa";
            var magazine = "ab";

            var actual = CanConstruct(ransomNote, magazine);

            Assert.False(actual);
        }

        [Test]
        public void Test3()
        {
            var ransomNote = "aa";
            var magazine = "aab";

            var actual = CanConstruct(ransomNote, magazine);

            Assert.True(actual);
        }

        [Test]
        public void Test4()
        {
            var ransomNote = "";
            var magazine = "aab";

            var actual = CanConstruct(ransomNote, magazine);

            Assert.True(actual);
        }


        [Test]
        public void Test5()
        {
            var ransomNote = "";
            var magazine = "";

            var actual = CanConstruct(ransomNote, magazine);

            Assert.True(actual);
        }

        [Test]
        public void Test6()
        {
            var ransomNote = "a";
            var magazine = "";

            var actual = CanConstruct(ransomNote, magazine);

            Assert.False(actual);
        }

        public bool CanConstruct(string ransomNote, string magazine)
        {
            if (string.IsNullOrEmpty(magazine) || string.IsNullOrEmpty(ransomNote)) return string.IsNullOrEmpty(ransomNote);

            var symbols = new Dictionary<int, int>();

            foreach (var symbol in magazine)
            {
                if (symbols.ContainsKey(symbol))
                {
                    symbols[symbol] += 1;
                }
                else
                {
                    symbols.Add(symbol, 1);
                }
            }

            foreach (var sybmol in ransomNote)
            {
                if (!symbols.ContainsKey(sybmol) || symbols[sybmol] == 0) return false;
                symbols[sybmol] -= 1;
            }
            
            return true;
        }
    }
}