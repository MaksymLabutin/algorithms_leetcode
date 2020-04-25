using NUnit.Framework;

namespace Tests
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            //3,2,0,-4
            var cycledNode = new ListNode(2);
            var head = new ListNode(3)
            {
                next = cycledNode.next = new ListNode(0)
                {
                    next = new ListNode(-4)
                    {
                        next = cycledNode
                    }
                }
            };

            var actual = HasCycle(head);

            Assert.IsTrue(actual);
        }

        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;
            var fast = head.next;
            var slow = head;

            while (slow != null && fast?.next != null)
            {
                if (fast == slow) return true;
                fast = fast.next.next;
                slow = slow.next;
            }

            return false;
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }
    }
}