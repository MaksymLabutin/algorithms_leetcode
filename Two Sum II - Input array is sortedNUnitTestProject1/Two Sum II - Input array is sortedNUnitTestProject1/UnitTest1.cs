using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var res = TwoSum(new int[] { 2, 7, 11, 15 }, 9);

            CollectionAssert.AreEqual(res, new int[] { 1, 2 });
        }

        [Test]
        public void Test2()
        {
            var res = TwoSum(new int[] { 2, 7, 11, 15 }, 17);

            CollectionAssert.AreEqual(res, new int[] { 1, 4 });
        }

        [Test]
        public void Test3()
        {
            var res = TwoSum(new int[] { 1, 2, 2, 4, 7, 11, 15 }, 17);

            CollectionAssert.AreEqual(res, new int[] { 2, 7 });
        }
        [Test]
        public void Test4()
        {
            var res = TwoSum(new int[] {0, 0, 3, 4}, 0);

            CollectionAssert.AreEqual(res, new int[] { 1, 2});
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            for (var i = 0; i < numbers.Length; i++)
            {  
                for (var j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < target - numbers[i]) continue;

                    if (numbers[j] == target - numbers[i])
                    {
                        return new int[] { i + 1, j + 1 };
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return new int[] { };
        }
    }
}