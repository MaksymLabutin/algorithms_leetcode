using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        

        [Test]
        public void Test1()
        {
            //1->2->3->4->5

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

            var actual = OddEvenList(head);

            //1->3->5->2->4
            Assert.AreEqual(1, actual.val);
            Assert.AreEqual(3, actual.next.val);
            Assert.AreEqual(5, actual.next.next.val);
            Assert.AreEqual(2, actual.next.next.next.val);
            Assert.AreEqual(4, actual.next.next.next.next.val);
        }

        public ListNode OddEvenList(ListNode head)
        {
            if (head == null) return head;
            var odd = head;
            var even  = head.next;

            if (even == null)
            {
                return head;
            }

            var evenHead  = head.next;

            var currNode = head.next?.next;

            var i = 1;

            while (currNode != null)
            {

                if (i % 2 == 0)
                {
                    even.next = currNode;
                    even = even.next;
                }
                else
                {
                    odd.next = currNode;
                    odd = odd.next;
                }

                i++;
                currNode = currNode.next;
            }

            even.next = null;


            odd.next = evenHead;

            return head;
        }

    


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}