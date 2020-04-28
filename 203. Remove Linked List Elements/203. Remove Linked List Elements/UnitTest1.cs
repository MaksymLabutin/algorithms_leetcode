using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //1->2->6->3->4->5->6, val = 6
            var head = new ListNode(6)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(6)
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
                    }
                }
            };

            var val = 6;

            var actual = RemoveElements(head, val);


            Assert.AreEqual(actual.val, 1);
            Assert.AreEqual(actual.next.val, 2);
            Assert.AreEqual(actual.next.next.val, 3);
            Assert.AreEqual(actual.next.next.next.val, 4);
            Assert.AreEqual(actual.next.next.next.next.val, 5);
            Assert.IsNull(actual.next.next.next.next.next);
        }

        [Test]
        public void Test2()
        {
            var head = new ListNode(6);
            var val = 6;

            var actual = RemoveElements(head, val);

            Assert.IsNull(actual);
        }

        [Test]
        public void Test3()
        {
            var head = new ListNode(6)
            {
                next = new ListNode(6)
            };
            var val = 6;

            var actual = RemoveElements(head, val);

            Assert.IsNull(actual);
        }

        [Test]
        public void Test5()
        {
            var head = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(1)
                    }
                }
            };
            var val = 1;

            var actual = RemoveElements(head, val);

            Assert.AreEqual(actual.val, 2);
            Assert.AreEqual(actual.next.val, 2);
            Assert.IsNull(actual.next.next);
        }

        [Test]
        public void Test6()
        {
            var head = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(1)
                        {
                            next = new ListNode(2)
                            {
                                next = new ListNode(1)
                            }
                        }
                    }
                }
            };
            var val = 1;

            var actual = RemoveElements(head, val);

            Assert.AreEqual(actual.val, 2);
            Assert.AreEqual(actual.next.val, 2);
            Assert.AreEqual(actual.next.next.val, 2);
            Assert.IsNull(actual.next.next.next);
        }

        [Test]
        public void Test7()
        {
            var head = new ListNode(1)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(2)
                        {
                            next = new ListNode(2)
                            {
                                next = new ListNode(2)
                            }
                        }
                    }
                }
            };
            var val = 1;

            var actual = RemoveElements(head, val);

            Assert.AreEqual(actual.val, 2);
            Assert.AreEqual(actual.next.val, 2);
            Assert.AreEqual(actual.next.next.val, 2);
            Assert.AreEqual(actual.next.next.next.val, 2);
            Assert.IsNull(actual.next.next.next.next);
        }


        [Test]
        public void Test4()
        {
            var head = new ListNode(1)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(2)
                        {
                            next = new ListNode(2)
                        }
                    }
                }
            };
            var val = 2;

            var actual = RemoveElements(head, val);

            Assert.AreEqual(actual.val, 1);
            Assert.AreEqual(actual.next.val, 1);
            Assert.IsNull(actual.next.next);
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null) return null;
            if (head.val == val)
            {
                head = head.next;
                if (head == null) return null;
            }

            var prev = head;
            var node = head.next;

            while (node != null)
            {
                if (node.val == val)
                {
                    prev.next = node.next;
                }
                else
                {
                    prev = node;
                }

                node = node.next;
            }

            return head.val == val ? head.next : head;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}