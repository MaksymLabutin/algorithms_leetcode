using System;
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
            var s = "leetcode";
            var wordDict = new List<string>() { "leet", "code" };

            var actual = WordBreak(s, wordDict);

            Assert.IsTrue(actual);
        }


        [Test]
        public void Test2()
        {
            var s = "catsanddog";
            var wordDict = new List<string>() { "cat", "cats", "and", "dog" };

            var actual = WordBreak(s, wordDict);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test3()
        {
            var s = "catsandog";
            var wordDict = new List<string>() { "cats", "dog", "sand", "and", "cat" };

            var actual = WordBreak(s, wordDict);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Test4()
        {
            var s = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab";
            var wordDict = new List<string>() { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" };

            var actual = WordBreak(s, wordDict);

            Assert.IsFalse(actual);
        }

        private HashSet<string> _wordDic;
        public bool WordBreak(string s, IList<string> wordDict)
        {
            _wordDic = new HashSet<string>(wordDict);
            return Dfs(s, new Dictionary<string, bool>());
        }

        private bool Dfs(string s, Dictionary<string, bool> memo)
        {
            var sb = "";

            if (memo.ContainsKey(s)) return memo[s];

            foreach (var symbol in s)
            {
                sb += symbol;

                if (!_wordDic.Contains(sb) || memo.ContainsKey(sb)) continue;
                var isExist = Dfs(s.Substring(sb.Length, s.Length - sb.Length), memo);

                if(!memo.ContainsKey(sb)) memo.Add(sb, isExist);

                if (isExist) return true;
            }

            return _wordDic.Contains(sb);
        }


    }
}