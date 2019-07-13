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
            var res = RemoveDuplicates(new int[] { 1, 1, 2 });

            Assert.AreEqual(2, res);
        }

        [Test]
        public void Test2()
        {
            var res = RemoveDuplicates(new int[] { 1, 1 });

            Assert.AreEqual(1, res);
        }

        [Test]
        public void Test3()
        {
            var res = RemoveDuplicates(new int[] { 1, 2, 3, 4, 5 });

            Assert.AreEqual(5, res);
        }

        [Test]
        public void Test4()
        {
            var res = RemoveDuplicates(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            Assert.AreEqual(1, res);
        } 

        [Test]
        public void Test6()
        {
            var res = RemoveDuplicates(new int[] { 1, 1, 1, 1, 1, 2 });

            Assert.AreEqual(2, res);
        }

        [Test]
        public void Test7()
        {
            var res = RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 });

            Assert.AreEqual(5, res);
        }

        [Test]
        public void Test8()
        {
            var res = RemoveDuplicates(new int[] { -1, 0, 0, 0, 0, 3, 3 });

            Assert.AreEqual(3, res);
        } 

        [Test]
        public void Test9()
        {
            var res = RemoveDuplicates(new int[] { -3, -1, -1 });

            Assert.AreEqual(2, res);
        }

        // better one
        public int RemoveDuplicates(int[] nums)
        {
            int dupCount = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] == nums[i])
                {
                    dupCount++;
                }
                nums[i - dupCount] = nums[i];
            }
            return nums.Length - dupCount;
        }


        //my solution
        //public int RemoveDuplicates(int[] nums)
        //{
        //    if (nums.Length < 2) return nums.Length;
        //    int pointerStart = 0, pointerEnd = 1;

        //    var stub = nums[0] - 1;
             
        //    while (pointerEnd != nums.Length)
        //    {
        //        if (nums[pointerEnd] == nums[pointerStart])
        //        {
        //            nums[pointerEnd] = stub;
        //        }
        //        else
        //        {
        //            pointerStart = pointerEnd;
        //        }
        //        pointerEnd++;
        //    }

        //    pointerStart = 0;
        //    pointerEnd = 0;
        //    while (pointerEnd != nums.Length)
        //    {
        //        if (nums[pointerEnd] == stub)
        //        {
        //            if (pointerEnd == 0 || nums[pointerEnd - 1] < stub)
        //            { 
        //                pointerEnd++;
        //                continue;
        //            }
        //            pointerStart = pointerStart == 0 ? pointerEnd : pointerStart;
        //        }
        //        else if (pointerStart > 0)
        //        {
        //            var tmp = nums[pointerEnd];
        //            nums[pointerEnd] = nums[pointerStart];
        //            nums[pointerStart] = tmp;

        //            pointerStart++;
        //        }

        //        pointerEnd++;
        //    }

        //    return pointerStart == 0 ? pointerEnd : pointerEnd == pointerStart ? 0 : pointerStart;
        //}


    }
}