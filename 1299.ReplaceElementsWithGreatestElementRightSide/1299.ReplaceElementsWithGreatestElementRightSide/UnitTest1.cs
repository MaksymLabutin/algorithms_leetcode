using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var arr = new[] {17, 18, 5, 4, 6, 1};

            var res = ReplaceElements(arr);

            var expectedRes = new[] {18, 6, 6, 6, 1, -1};

            CollectionAssert.AreEqual(expectedRes, res);
        }

        public int[] ReplaceElements(int[] arr)
        {
            var selectedVal = arr[arr.Length - 1]; 

            for (var i = arr.Length - 1; i > 0; i--)
            {
                var tmp = selectedVal;
                if (selectedVal < arr[i]) selectedVal = arr[i];
                arr[i] = tmp; 
            }

            arr[0] = selectedVal;
            arr[arr.Length - 1] = -1;

            return arr;
        }
    }
}