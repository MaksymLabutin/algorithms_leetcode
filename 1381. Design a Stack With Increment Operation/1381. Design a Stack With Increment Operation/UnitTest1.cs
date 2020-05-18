using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
       

        [Test]
        public void Test1()
        {
            //["CustomStack","push","push","pop","push","push","push","increment","increment","pop","pop","pop","pop"]
            //    [[3],[1],[2],[],[2],[3],[4],[5,100],[2,100],[],[],[],[]]


            //[null,null,null,2,null,null,null,null,null,103,202,201,-1]
        var stack = new CustomStack(3);
            stack.Push(1);
            stack.Push(2);

            var p_2 = stack.Pop();
            Assert.AreEqual(2, p_2);

            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            stack.Increment(5,100);
            stack.Increment(2,100);

            var p_103 = stack.Pop();
            Assert.AreEqual(103, p_103);
            var p_202 = stack.Pop();
            Assert.AreEqual(202, p_202);
            var p_201 = stack.Pop();
            Assert.AreEqual(201, p_201);
            var p_minus_1 = stack.Pop();
            Assert.AreEqual(-1, p_minus_1);
        }


        public class CustomStack
        {
            private int pointer;
            private int[] stack;
            public CustomStack(int maxSize)
            {
                pointer = 0;
                stack = new int[maxSize];
            }

            public void Push(int x)
            {
                if(stack.Length - 1 < pointer) return;
                if (pointer < 0) pointer = 0;
                stack[pointer] = x;
                ++pointer;
            }

            public int Pop()
            {
                if (pointer <= 0) return -1;
                return stack[--pointer];
            }

            public void Increment(int k, int val)
            {
                if(val == 0) return;

                k = k > pointer ? pointer : k;

                for (var i = 0; i < k; i++)
                {
                    stack[i] += val;
                }
            }
        }

    }
}