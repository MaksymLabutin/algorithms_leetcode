using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var word = "USA";
            var actual = DetectCapitalUse(word);
            Assert.IsTrue(actual);
        }

        public bool DetectCapitalUse(string word)
        {
            if (string.IsNullOrEmpty(word)) return true;

            if (word == word.ToLower()) return true;
            if (word == word.ToUpper()) return true;
            if (word[0].ToString() != word[0].ToString().ToUpper()) return false;

            for (int i = 1; i < word.Length; i++)
            {
                if (word[i].ToString() != word[i].ToString().ToLower()) return false;
            }
            return true;
        }
    }
}