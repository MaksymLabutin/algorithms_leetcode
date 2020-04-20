using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var seats = new int[] { 1, 0, 0, 0, 1, 0, 1 };

            var actual = MaxDistToClosest(seats);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var seats = new int[] { 1, 0, 0, 0 };

            var actual = MaxDistToClosest(seats);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var seats = new int[] { 0, 0, 1, 0 };

            var actual = MaxDistToClosest(seats);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            var seats = new int[] { 0, 1 };

            var actual = MaxDistToClosest(seats);

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test5()
        {
            var seats = new int[] { 1, 0, 1 };

            var actual = MaxDistToClosest(seats);

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test6()
        {
            var seats = new int[] { 1, 0, 0, 1 };

            var actual = MaxDistToClosest(seats);

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        public int MaxDistToClosest(int[] seats)
        {
            var max = 0;

            for (var i = 0; i < seats.Length; i++)
            {
                if (seats[i] == 1) continue;

                var rPointer = i + 1;
                while (rPointer < seats.Length)
                {
                    if (seats[rPointer] == 1) break;
                    rPointer++;
                }

                if (i == 0)
                {
                    max = rPointer;
                }
                else if (rPointer + 1 >= seats.Length && seats[seats.Length - 1] == 0)
                {
                    max = max > rPointer - i ? max : rPointer - i;
                }
                else
                {
                    var val = (rPointer - i)%2 == 0  ? (rPointer - i) / 2 : (rPointer - i) / 2 + 1;
                    max = max > val ? max : val;
                }

                i = rPointer;
            }

            return max;
        }
    }
}