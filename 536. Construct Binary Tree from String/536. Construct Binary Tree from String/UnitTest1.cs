using System.Collections.Generic;
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
            var s = "-41(2(3)(1))(6(5))";

            var actual = Str2tree(s);

            Assert.AreEqual(-41, actual.val);
            Assert.AreEqual(2, actual.left.val);
            Assert.AreEqual(6, actual.right.val);
        }

        public TreeNode Str2tree(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;

            var stack = new Stack<TreeNode>();

            var valueTuple = GetInt(s, 0);
            var root = new TreeNode(valueTuple.val);
            TreeNode node = root;

            for (int i = valueTuple.index; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '(':
                        stack.Push(node);
                        break;

                    case ')':
                        node = stack.Pop();
                        break;

                    default:
                        var tuple = GetInt(s, i);
                        var newNode = new TreeNode(tuple.val);
                        i = tuple.index - 1;
                        if (node.left == null) node.left = newNode;
                        else node.right = newNode;
                        node = newNode;
                        break;

                }
            }

            return root;
        }

        private (int val, int index) GetInt(string s, int position)
        {
            var str = "";
            while (s.Length > position)
            {
                if(s[position] == '(' || s[position] == ')') break;
                str += s[position];
                position++;
            }

            return (int.Parse(str), position);
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}