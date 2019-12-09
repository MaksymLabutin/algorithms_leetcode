using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        private TreeNode _root;

        [SetUp]
        public void SetUp()
        {
            _root = new TreeNode(7)
            {
                left = new TreeNode(3),
                right = new TreeNode(15)
                {
                    left = new TreeNode(9),
                    right = new TreeNode(20)
                }
            };
        }

        [Test]
        public void Test1()
        {

            BSTIterator iterator = new BSTIterator(_root);
            var n1 = iterator.Next();    // return 3
            var n2 = iterator.Next();    // return 7
            var hasNext1 = iterator.HasNext(); // return true
            var n3 = iterator.Next();    // return 9
            var hasNext2 = iterator.HasNext(); // return true
            var n4 = iterator.Next();    // return 15
            var hasNext3 = iterator.HasNext(); // return true
            var n5 = iterator.Next();    // return 20
            var hasNext4 = iterator.HasNext(); // return false
            Assert.Pass();
        }


        public class BSTIterator
        {

            private Queue<int> queue;

            public BSTIterator(TreeNode root)
            {
                queue =  new Queue<int>();
                SetNoded(root);
            }

            private void SetNoded(TreeNode node)
            {
                if(node == null) return;

                SetNoded(node.left);

                queue.Enqueue(node.val);

                SetNoded(node.right); 
            }


            /** @return the next smallest number */
            public int Next()
            {
                return queue.Dequeue();
            }

            /** @return whether we have a next smallest number */
            public bool HasNext()
            {
                return queue.Count > 0;
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }


}