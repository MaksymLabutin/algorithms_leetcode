using System.Collections.Generic;
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
                next = cycledNode
            };

            head.next.next = new ListNode(0)
            {
                next = new ListNode(4)
                {
                    next = cycledNode
                }
            };

            var actual = DetectCycle(head);

            Assert.AreEqual(actual, cycledNode);
        }

        public ListNode DetectCycle(ListNode head)
        {
            var visited = new Dictionary<ListNode, bool>();

            while (head != null)
            {
                if (visited.ContainsKey(head)) return head;

                visited.Add(head, true);
                head = head.next;
            }

            return null;
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