using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var rating = new int[] {2, 5, 3, 4, 1};
            var actual = NumTeams(rating);
            var expected = 3;

            Assert.AreEqual(expected, actual);
        } 

        [Test]
        public void Test2()
        {
            var rating = new int[] { 2, 1, 3 };
            var actual = NumTeams(rating);
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var rating = new int[] { 1, 2, 3, 4 };
            var actual = NumTeams(rating);
            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        public int NumTeams(int[] rating)
        {

            if (rating.Length < 3) return 0;
            var res = 0;
            for (int i = 0; i < rating.Length - 2; i++)
            {
                for (int j = i + 1; j < rating.Length - 1; j++)
                {
                    for (int k = j + 1; k < rating.Length ; k++)
                    {
                        if ((rating[i] < rating[j] && rating[j] < rating[k]) || (rating[i] > rating[j] && rating[j] > rating[k])) res++;
                    }
                }
            }

            return res;
        }
    }
}