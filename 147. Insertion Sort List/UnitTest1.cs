using NUnit.Framework;

namespace Tests
{
    public class Tests
    {   

        [Test]
        public void Test1()
        {
            //4->2->1->3
            var head = new ListNode(4){ next = new ListNode(2){next = new ListNode(1){next = new ListNode(3)}}};

            var actual = InsertionSortList(head);

            Assert.AreEqual(1, actual.val);
            Assert.AreEqual(2, actual.next.val);
            Assert.AreEqual(3, actual.next.next.val);
            Assert.AreEqual(4, actual.next.next.next.val);
        }

        public ListNode InsertionSortList(ListNode head)
        {
            if (head == null) return null;

            var copiedHead = head;
            var prevNode = head;
            var currNode = head;

            while (currNode != null)
            {
                if (currNode.val >= prevNode.val)
                {
                    prevNode = currNode;
                    currNode = currNode.next;
                    continue;
                }

                prevNode.next = currNode.next;

                var copiedH = copiedHead;
                var tmpPrevNode = copiedHead;
                while (copiedHead.val < currNode.val)
                {
                    tmpPrevNode = copiedHead;
                    copiedHead = copiedHead.next;
                }

                if (tmpPrevNode == copiedHead) copiedHead = new ListNode(currNode.val){ next = tmpPrevNode };
                else
                {
                    var nextPrevTmp = tmpPrevNode.next;
                    tmpPrevNode.next = currNode;
                    currNode.next = nextPrevTmp;
                    copiedHead = copiedH;
                }; 
                currNode = prevNode.next;
            }

            return copiedHead;
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