using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Buddy_Strings
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var A = "ab";
            var B = "ba";

            var actual = BuddyStrings(A, B);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test2()
        {
            var A = "ab";
            var B = "ab";

            var actual = BuddyStrings(A, B);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Test3()
        {
            var A = "aa";
            var B = "aa";

            var actual = BuddyStrings(A, B);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test4()
        {
            var A = "aaaaaaabc";
            var B = "aaaaaaacb";

            var actual = BuddyStrings(A, B);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test5()
        {
            var A = "";
            var B = "aa";

            var actual = BuddyStrings(A, B);

            Assert.IsFalse(actual);
        }


        [Test]
        public void Test6()
        {
            var A = "abab";
            var B = "abab";

            var actual = BuddyStrings(A, B);

            Assert.IsTrue(actual);
        }


        [Test]
        public void Test7()
        { 
            var A = "abab";
            var B = "abad";

            var actual = BuddyStrings(A, B);

            Assert.IsFalse(actual);
        }

        public bool BuddyStrings(string A, string B)
        {
            if (A.Length < 2 || B.Length < 2 || A.Length != B.Length) return false;

            if (A == B)
            {
                var hs = new HashSet<char>();

                foreach (var s in A)
                {
                    if (hs.Contains(s)) return true;
                    hs.Add(s);
                }

                return false;
            }
            else
            {
                var aPointer = 0;

                while (A[aPointer] == B[aPointer]) aPointer++;
                var bPointer = aPointer + 1; 
                while (bPointer < B.Length && A[bPointer] == B[bPointer]) bPointer++;

                bPointer = bPointer >= B.Length ? bPointer - 1 : bPointer;

                aPointer = aPointer >= A.Length ? aPointer - 1 : aPointer;

                var str = new StringBuilder();
                
                for (var i = 0; i < A.Length; i++)
                {
                    if (i == aPointer || i == bPointer)
                    {
                        str.Append(i == aPointer ? A[bPointer] : A[aPointer]);
                    }
                    else
                    {
                        str.Append(A[i]);
                    }
                }

                return str.ToString() == B;
            } 
        }
    }
}