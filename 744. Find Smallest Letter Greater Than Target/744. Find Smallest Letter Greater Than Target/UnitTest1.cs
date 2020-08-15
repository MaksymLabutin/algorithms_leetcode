using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {  
        [Test]
        public void Test1()
        {
            var letters = new Char[] { 'c', 'f', 'j' };
            var target = 'a';

            var actual = NextGreatestLetter(letters, target);

            var extected = 'c';

            Assert.AreEqual(extected, actual);
        }
        [Test]
        public void Test2()
        {
            var letters = new Char[] { 'c', 'f', 'j' };
            var target = 'c';

            var actual = NextGreatestLetter(letters, target);

            var extected = 'f';

            Assert.AreEqual(extected, actual);
        }

        [Test]
        public void Test3()
        {
            var letters = new Char[] { 'c', 'f', 'j' };
            var target = 'd';

            var actual = NextGreatestLetter(letters, target);

            var extected = 'f';

            Assert.AreEqual(extected, actual);
        }

        [Test]
        public void Test4()
        {
            var letters = new Char[] { 'c', 'f', 'j' };
            var target = 'g';

            var actual = NextGreatestLetter(letters, target);

            var extected = 'j';

            Assert.AreEqual(extected, actual);
        }

        [Test]
        public void Test5()
        {
            var letters = new Char[] { 'c', 'f', 'j' };
            var target = 'j';

            var actual = NextGreatestLetter(letters, target);

            var extected = 'c';

            Assert.AreEqual(extected, actual);
        }

        [Test]
        public void Test6()
        {
            var letters = new Char[] { 'c', 'f', 'j' };
            var target = 'k';

            var actual = NextGreatestLetter(letters, target);

            var extected = 'c';

            Assert.AreEqual(extected, actual);
        }

        public char NextGreatestLetter(char[] letters, char target)
        { 
            for (var i = 0; i < letters.Length; i++)
            {
                if (letters[i] > target) return letters[i];
            }

            return letters[0];
        }
    }
}