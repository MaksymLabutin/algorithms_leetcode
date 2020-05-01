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
            //Input: 1->1->2
            //Output: 1->2

            var head = new ListNode(1)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(2)
                }
            };

            var actual = DeleteDuplicates(head);

            Assert.AreEqual(1, actual.val);
            Assert.AreEqual(2, actual.next.val);
            Assert.Null(actual.next.next);
        }

        [Test]
        public void Test2()
        {
            //Input: 1->1->2->3->3
            //Output: 1->2->3

            var head = new ListNode(1)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(3)
                        {
                            next = new ListNode(3)
                        }
                    }
                }
            };

            var actual = DeleteDuplicates(head);

            Assert.AreEqual(1, actual.val);
            Assert.AreEqual(2, actual.next.val);
            Assert.AreEqual(3, actual.next.next.val);
            Assert.Null(actual.next.next.next);
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return head;

            var prev = head;
            var current = head.next;

            while (current != null) 
            {
                if (current.val == prev.val)
                {
                    prev.next = current.next;
                }
                else
                {
                    prev = current; 
                }

                current = current.next;
            }

            return head;

        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}