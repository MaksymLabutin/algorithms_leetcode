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
            //1->2->3->4
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

            var actual = SwapPairs(head);

            //2->1->4->3.
            Assert.AreEqual(2, actual.val);
            Assert.AreEqual(1, actual.next.val);
            Assert.AreEqual(4, actual.next.next.val);
            Assert.AreEqual(3, actual.next.next.next.val);
            Assert.AreEqual(5, actual.next.next.next.next.val);
            Assert.Null(actual.next.next.next.next.next);
        }

        public ListNode SwapPairs(ListNode head)
        {
            if (head?.next == null) return head;

            var tmp = head.next;
            var headTmp = head;

            var nextNextTmp = SwapPairs(head.next.next);
            
            head = tmp;
            head.next = headTmp;
            head.next.next = nextNextTmp;

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