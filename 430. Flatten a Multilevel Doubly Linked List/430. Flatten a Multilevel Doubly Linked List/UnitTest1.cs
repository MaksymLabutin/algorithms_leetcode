using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //Input: head = [1, 2, 3, 4, 5, 6, null, null, null, 7, 8, 9, 10, null, null, 11, 12]
            //Output: [1, 2, 3, 7, 8, 11, 12, 9, 10, 4, 5, 6]
             

            var nodeL3 = new Node() { val = 11, next = new Node() { val = 12 } };
            var nodeL2 = new Node() { val = 7, next = new Node() { val = 8, child = nodeL3, next = new Node() { val = 9, next = new Node() { val = 10 } } } };
            var nodeL1 = new Node() { val = 1, next = new Node() { val = 2, next = new Node() { val = 3, child = nodeL2, next = new Node() { val = 4, next = new Node() { val = 5, next = new Node() { val = 6 } } } } } };

            var acutal = Flatten(nodeL1);


            Assert.AreEqual(1, acutal.val);
            Assert.AreEqual(2, acutal.next.val);
            Assert.AreEqual(3, acutal.next.next.val);
            Assert.AreEqual(7, acutal.next.next.next.val);
            Assert.AreEqual(8, acutal.next.next.next.next.val);
            Assert.AreEqual(11, acutal.next.next.next.next.next.val);
            Assert.AreEqual(12, acutal.next.next.next.next.next.next.val);
            Assert.AreEqual(9, acutal.next.next.next.next.next.next.next.val);
            Assert.AreEqual(10, acutal.next.next.next.next.next.next.next.next.val);
            Assert.AreEqual(4, acutal.next.next.next.next.next.next.next.next.next.val);
            Assert.AreEqual(5, acutal.next.next.next.next.next.next.next.next.next.next.val);
            Assert.AreEqual(6, acutal.next.next.next.next.next.next.next.next.next.next.next.val);
            Assert.Null(acutal.next.next.next.next.next.next.next.next.next.next.next.next);
        }


        [Test]
        public void Test2()
        {
            var head = new Node(){val = 1, child = new Node(){val = 2, child = new Node(){val = 3, child = new Node(){val = 4}}}}; 

            var acutal = Flatten(head);
             
            Assert.AreEqual(1, acutal.val);
            Assert.AreEqual(2, acutal.next.val);
            Assert.AreEqual(3, acutal.next.next.val);
            Assert.AreEqual(4, acutal.next.next.next.val); 
            Assert.Null(acutal.next.next.next.next);
        }



        public Node Flatten(Node head)
        {
            if (head == null) return null;

            var tmp = new Node() { val = 0, next = head };

            var tmpCopy = tmp;

            while (tmp != null)
            {
                if (tmp.child != null)
                {
                    var prevNext = tmp.next;

                    var currNext = Flatten(tmp.child);

                    tmp.child = null;
                    if (currNext == null) continue;

                    currNext.prev = tmp;
                    tmp.next = currNext;

                    while (tmp.next != null)
                    {
                        tmp = tmp.next;
                    }

                    if (prevNext != null)
                    {
                        tmp.next = prevNext;
                        prevNext.prev = tmp; 
                    } 
                }

                tmp = tmp.next;
            }


            return tmpCopy.next;
        }
         

        public class Node
        {
            public int val;
            public Node prev;
            public Node next;
            public Node child;
        }
    }
}