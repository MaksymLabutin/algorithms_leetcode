using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var nodes = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                        }
                    }
                }
            };

            var res = MiddleNode(nodes);

            var expectedRes = 3;

            Assert.AreEqual(expectedRes, res.val);
        }

        [Test]
        public void Test2()
        {
            var nodes = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                            {
                                next = new ListNode(6)
                            }
                        }
                    }
                }
            };

            var res = MiddleNode(nodes);

            var expectedRes = 4;

            Assert.AreEqual(expectedRes, res.val);
        }



        public ListNode MiddleNode(ListNode head)
        {

            var arr = new List<ListNode>();

            while (head != null)
            {
                arr.Add(head);
                head = head.next;
            }

            return arr[arr.Count / 2];
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}