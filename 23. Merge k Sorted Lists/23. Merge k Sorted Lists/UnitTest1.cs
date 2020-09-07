using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            // [[1,4,5],[1,3,4],[2,6]]
            var first = new ListNode(1) {next = new ListNode(4) {next = new ListNode(5)}};
            var second = new ListNode(1) {next = new ListNode(3) {next = new ListNode(4)}};
            var third = new ListNode(2) {next = new ListNode(6)};
            var lists = new ListNode[]
            {
                first,
                second,
                third
            };

            var actual = MergeKLists(lists);
            //1,1,2,3,4,4,5,6
            Assert.AreEqual(1, actual.val);
            Assert.AreEqual(1, actual.next.val);
            Assert.AreEqual(2, actual.next.next.val);
            Assert.AreEqual(3, actual.next.next.next.val);
            Assert.AreEqual(4, actual.next.next.next.next.val);
            Assert.AreEqual(4, actual.next.next.next.next.next.val);
            Assert.AreEqual(5, actual.next.next.next.next.next.next.val);
            Assert.AreEqual(6, actual.next.next.next.next.next.next.next.val);
        }


        [Test]
        public void Test2()
        {
            var actual = MergeKLists(new ListNode[0]);
            Assert.IsNull(actual);
        }

        [Test]
        public void Test3()
        {
            var actual = MergeKLists(new ListNode[]{null});
            Assert.IsNull(actual);
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0) return null;

            var heap = new SortedList<int, int>();

            foreach (var listNode in lists)
            {
                var node = listNode;
                while (node != null)
                {
                    if (heap.ContainsKey(node.val))
                    {
                        heap[node.val] += 1;
                    }
                    else
                    {
                        heap.Add(node.val, 1);
                    }

                    node = node.next;
                }
            }

            ListNode head = null;
            ListNode headNode = null;

            foreach (var i in heap)
            {
                var node = new ListNode(i.Key);
                if (head == null)
                {
                    head = node;
                    headNode = head;
                }
                else
                {
                    head.next = node;
                    head = head.next;
                }

                for (int j = 1; j < i.Value; j++)
                {
                    head.next = new ListNode(i.Key);
                    head = head.next;
                }
            }

            return headNode;
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