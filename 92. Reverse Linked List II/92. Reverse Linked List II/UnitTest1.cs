using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        //Task
        //Reverse a linked list from position m to n. Do it in one-pass.

        [Test]
        public void Test1()
        {
            var head = new ListNode(1)
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

            var m = 2;
            var n = 4;

            var actual = ReverseBetween(head, m, n);

            Assert.AreEqual(1, actual.val);
            Assert.AreEqual(4, actual.next.val);
            Assert.AreEqual(3, actual.next.next.val);
            Assert.AreEqual(2, actual.next.next.next.val);
            Assert.AreEqual(5, actual.next.next.next.next.val);
            Assert.Null(actual.next.next.next.next.next);
        }

        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head == null) return null;

            var copiedHead = head;
            var headToInser = head;

            for (var i = 1; i <= n; i++)
            {
                if (copiedHead == null) return head;
                if (i < m)
                {
                    headToInser = headToInser.next;
                    continue;
                }

                var node = copiedHead.next;



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