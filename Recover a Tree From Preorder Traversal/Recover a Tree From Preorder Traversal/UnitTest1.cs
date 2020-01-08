using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [SetUp]
        public void Init()
        {
            _str = "";
            _strPointer = 0;
        }

        [Test]
        public void Test1()
        {
            var res = RecoverFromPreorder("1-2--3--4-5--6--7");

            Assert.AreEqual(res.val, 1);

            //left side of the tree
            Assert.AreEqual(res.left.val, 2);

            Assert.AreEqual(res.left.left.val, 3);
            Assert.AreEqual(res.left.right.val, 4);

            //right side of the tree
            Assert.AreEqual(res.right.val, 5);

            Assert.AreEqual(res.right.left.val, 6);
            Assert.AreEqual(res.right.right.val, 7);

        }
        [Test]
        public void Test2()
        {
            var res = RecoverFromPreorder("1-2--3---4-5--6---7");

            Assert.AreEqual(res.val, 1);

            Assert.AreEqual(res.left.val, 2);
            Assert.AreEqual(res.left.left.val, 3);
            Assert.AreEqual(res.left.left.left.val, 4);


            Assert.AreEqual(res.right.val, 5);
            Assert.AreEqual(res.right.left.val, 6);
            Assert.AreEqual(res.right.left.left.val, 7);
        }

        [Test]
        public void Test3()
        {
            var res = RecoverFromPreorder("1-401--349---90--88");

            Assert.AreEqual(res.val, 1);

            Assert.AreEqual(res.left.val, 401);
            Assert.AreEqual(res.left.left.val, 349);
            Assert.AreEqual(res.left.left.left.val, 90);


            Assert.AreEqual(res.left.right.val, 88);
        }

        [Test]
        public void Test4()
        {
            var res = RecoverFromPreorder("");
             
            Assert.IsNull(res);
        }

        [Test]
        public void Test5()
        {
            var res = RecoverFromPreorder("1-");
             
            Assert.IsNull(res);
        }

        [Test]
        public void Test6()
        {
            var res = RecoverFromPreorder("-1");
             
            Assert.AreEqual(res.val, 1);
        }

        private string _str;
        private int _strPointer = 0;

        public TreeNode RecoverFromPreorder(string S)
        {
            if (string.IsNullOrEmpty(S) || S[S.Length - 1] == '-') return null;

            _str = S.TrimStart('-'); 

            return Visit(0);
        }

        private TreeNode Visit(int level)
        {
            if (CountSlashes(_strPointer) != level) return null;

            _strPointer += level;

            var valRes = int.TryParse(ReadLine(_strPointer), out int val);
            if (!valRes) return null;

            _strPointer += val.ToString().Length;

            var node = new TreeNode(val)
            {
                left = Visit(level + 1),
                right = Visit(level + 1)
            };

            return node;
        }

        private int CountSlashes(int pointer)
        {
            var res = 0;

            while (_str.Length > pointer)
            {
                if (_str[pointer++] != '-') return res;

                res++;
            }

            return res;
        }

        private string ReadLine(int pointer)
        {
            var res = "";

            while (_str.Length > pointer)
            {
                if (_str[pointer] == '-') return res;

                res += _str[pointer++];
            }

            return res;
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