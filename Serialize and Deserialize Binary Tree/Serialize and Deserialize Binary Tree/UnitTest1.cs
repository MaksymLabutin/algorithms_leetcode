using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        Codec codec = new Codec();
        private TreeNode _root;

        [SetUp]
        public void SetUp()
        {
            _root = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                }
            };
        }


        [Test]
        public void SerializeTest()
        {

            var serializedNodes = codec.serialize(_root);

            var res = "1,2,3,null,null,4,5";

            Assert.AreEqual(serializedNodes, res);
        }

          

        [Test]
        public void DeserializeTest()
        {

            var serializedNodes = codec.serialize(_root);

            var des = codec.deserialize(serializedNodes);

            var res = codec.serialize(des);

            Assert.AreEqual(serializedNodes, res);
        }

        [Test]
        public void DeserializeTest2()
        {

            var serializedNodes = "1,2,3,null,null,4,5,null,6,7,8,9";

            var des = codec.deserialize(serializedNodes);

            var res = codec.serialize(des);

            Assert.AreEqual(serializedNodes, res);
        }


        public class Codec
        {

            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                if (root == null) return "";

                var q = new Queue<TreeNode>();

                q.Enqueue(root);

                var str = new StringBuilder();
                var tmp = new StringBuilder();

                while (q.Count > 0)
                {
                    var treeNode = q.Dequeue();

                    if (treeNode == null)
                    {
                        tmp.Append("null,");
                        continue;
                    }

                    str.Append(tmp);
                    str.Append(treeNode.val + ",");

                    tmp = new StringBuilder();

                    q.Enqueue(treeNode.left);
                    q.Enqueue(treeNode.right);
                }

                str.Length -= 1;

                return str.ToString();
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                if (data.Length == 0) return null;

                var arr = data.Split(',');

                var queue = new Queue<TreeNode>(); 

                var root = new TreeNode(int.Parse(arr[0]));

                queue.Enqueue(root);

                for (var i = 0; i < arr.Length; i += 2)
                {
                    var el = queue.Dequeue();

                    if (i + 1 < arr.Length)
                    {
                        if (int.TryParse(arr[i + 1], out int res))
                        {
                            el.left = new TreeNode(res);
                            queue.Enqueue(el.left);
                        }
                   
                    }

                    if (i + 2 < arr.Length)
                    {
                        if (int.TryParse(arr[i + 2], out int res))
                        {
                            el.right = new TreeNode(res);
                            queue.Enqueue(el.right);
                        }
            
                    }
                }

                return root;
            }
        }


        // codec.deserialize(codec.serialize(root));
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}