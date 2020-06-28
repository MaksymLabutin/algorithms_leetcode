using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var people = new int[] {3, 2, 2, 1};
            var limit = 3;

            var actual = NumRescueBoats(people, limit);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test2()
        {
            var people = new int[] { 3, 5, 3, 4 };
            var limit = 5;

            var actual = NumRescueBoats(people, limit);

            var expected = 4;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test3()
        {
            
            var people = new int[] { 21, 40, 16, 24, 30 };
            var limit = 50;

            var actual = NumRescueBoats(people, limit);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        public int NumRescueBoats(int[] people, int limit)
        {
            Sort(people, 0, people.Length - 1);

            var lPointer = 0;
            var rPointer = people.Length - 1;

            var boats = 0;
            while (rPointer >= lPointer)
            {
                if (people[lPointer] + people[rPointer] <= limit) lPointer++;
                boats++;
                rPointer--;
            }

            return boats;
        }

        private void Sort(int[] arr, int l, int r)
        {
            if(l > r) return; 
            var index = Partition(arr, l, r);

            Sort(arr, l, index - 1);
            Sort(arr, index + 1, r);
        }

        private int Partition(int[] arr, int l, int r)
        {
            int pivot = arr[r];
            var low = l - 1;
            var tmp = 0;
            for (var i = l; i < r; i++)
            {
                if (arr[i] < pivot)
                {
                    low++;
                    tmp = arr[low];
                    arr[low] = arr[i];
                    arr[i] = tmp;
                }
            }

            low++;
            tmp = arr[low];
            arr[low] = arr[r];
            arr[r] = tmp;

            return low;
        }
    }
}