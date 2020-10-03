using System;
using NodeExtensionsNextAssessment;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var root = new Node(
                1,
                new Node(
                    2,
                    new Node(3),
                    new Node(4)),
                new Node(
                    5,
                    new Node(6),
                    new Node(7)));
            var n = root;
            while (n != null)
            {
                Console.WriteLine(n.Data);
                n = n.Next();
            }

            n = root;
            Assert.AreEqual(1, n.Data);
            n = n.Next();
            Assert.AreEqual(2, n.Data);
            n = n.Next();
            Assert.AreEqual(3, n.Data);
            n = n.Next();
            Assert.AreEqual(4, n.Data);
            n = n.Next();
            Assert.AreEqual(5, n.Data);
            n = n.Next();
            Assert.AreEqual(6, n.Data);
            n = n.Next();
            Assert.AreEqual(7, n.Data);
            n = n.Next();
            Assert.IsNull(n);
        }

        [Test]
        public void Next_should_be_null_When_root_is_null()
        {
            Node root = null;

            var n = root;
            n = n.Next();
            Assert.IsNull(n);
        }

        [Test]
        public void Should_find_all_nexts_When_node_values_the_same()
        {
            var root = new Node(
                1,
                new Node(
                    1,
                    new Node(1),
                    new Node(1)),
                new Node(
                    1,
                    new Node(1),
                    new Node(1),
                    new Node(1)));

            var n = root;
            Assert.AreEqual(1, n.Data);
            n = n.Next();
            Assert.AreEqual(1, n.Data);
            n = n.Next();
            Assert.AreEqual(1, n.Data);
            n = n.Next();
            Assert.AreEqual(1, n.Data);
            n = n.Next();
            Assert.AreEqual(1, n.Data);
            n = n.Next();
            Assert.AreEqual(1, n.Data);
            n = n.Next();
            Assert.AreEqual(1, n.Data);
            n = n.Next();
            Assert.IsNull(n);
        }

    }
}