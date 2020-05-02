using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

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

            var k = 2;
            var actual = RotateRight(head, k);

            //4->5->1->2->3->NULL
            Assert.AreEqual(4, actual.val);
            Assert.AreEqual(5, actual.next.val);
            Assert.AreEqual(1, actual.next.next.val);
            Assert.AreEqual(2, actual.next.next.next.val);
            Assert.AreEqual(3, actual.next.next.next.next.val);
            Assert.Null(actual.next.next.next.next.next);
        }

        [Test]
        public void Test2()
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

            var k = 12;
            var actual = RotateRight(head, k);

            //4->5->1->2->3->NULL
            Assert.AreEqual(4, actual.val);
            Assert.AreEqual(5, actual.next.val);
            Assert.AreEqual(1, actual.next.next.val);
            Assert.AreEqual(2, actual.next.next.next.val);
            Assert.AreEqual(3, actual.next.next.next.next.val);
            Assert.Null(actual.next.next.next.next.next);
        }

        [Test]
        public void Test3()
        {

            var head = new ListNode(1)
            {
                next = new ListNode(2) 
            };

            var k = 2;
            var actual = RotateRight(head, k);
             
            Assert.AreEqual(1, actual.val);
            Assert.AreEqual(2, actual.next.val); 
            Assert.Null(actual.next.next);
        }

        [Test]
        public void Test4()
        {

            var head = new ListNode(1) ;

            var k = 2;
            var actual = RotateRight(head, k);
             
            Assert.AreEqual(1, actual.val); 
            Assert.Null(actual.next);
        }

        [Test]
        public void Test5()
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

            var k = 10;
            var actual = RotateRight(head, k);

            //4->5->1->2->3->NULL
            Assert.AreEqual(1, actual.val);
            Assert.AreEqual(2, actual.next.val);
            Assert.AreEqual(3, actual.next.next.val);
            Assert.AreEqual(4, actual.next.next.next.val);
            Assert.AreEqual(5, actual.next.next.next.next.val);
            Assert.Null(actual.next.next.next.next.next);
        }

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head?.next == null) return head;
            if (k <= 0) return head; 

            var l = GetLenght(head);

            k = k % l;
            if (k == l || k == 0) return head;

            var headCopy = head;

            var prev = head;
            while (l > 0)
            {
                if (k == l)
                {
                    prev.next = null;
                    break;
                }

                prev = head;
                head = head.next;
                l--;
            }

            var newHead = head;

            while (head.next != null)
            {
                head = head.next;
            }

            head.next = headCopy;

            return newHead;
        }

        private int GetLenght(ListNode node)
        {
            var l = 0;
            while (node != null)
            {
                l++;
                node = node.next;
            }

            return l;
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