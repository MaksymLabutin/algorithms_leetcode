using System.Collections.Generic;
using System.Net.NetworkInformation;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var third = new Node(3);

            var second = new Node(2)
            {
                next = third
            };

            var first = new Node(1)
            {
                next = second
            };

            second.random = first;

            var actual = CopyRandomList(first);

            Assert.AreNotEqual(first, actual);
            Assert.AreEqual(first.val, actual.val);
            Assert.AreNotEqual(second, actual.next);
            Assert.AreEqual(second.val, actual.next.val);
            Assert.AreNotEqual(second.random, actual.next.random);
            Assert.AreEqual(second.random.val, actual.next.random.val);
            Assert.AreNotEqual(third, actual.next.next);
            Assert.AreEqual(third.val, actual.next.next.val);
        }

        public Node CopyRandomList(Node head)
        {
            if (head == null) return head;
            var visited = new Dictionary<Node, Node>();

            var node = head;

            while (node != null)
            {
                visited.Add(node, new Node(node.val));
                node = node.next;
            }

            while (node != null)
            {
                if (node.next != null) visited[node].next = visited[node.next];
                if (node.random != null) visited[node].random = visited[node.random];

                node = node.next;
            }

            return visited[head];
        }

        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }
    }
}