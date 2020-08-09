using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //"[1,2,3,null,null,4,5]"

            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    right = new TreeNode(11)
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(4)
                }
            };

            var actual = new Codec().serialize(root);

            var expected = "1,2,3,-,11,4,-";

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test2()
        {
            var data = "1,2,3,-,11,4,-";

            var actual = new Codec().deserialize(data);

            var expected = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    right = new TreeNode(11)
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(4)
                }
            };

            Assert.AreEqual(expected.val, actual.val);
        }



        [Test]
        public void Test3()
        {
            var data = "";

            var actual = new Codec().deserialize(data);

            Assert.IsNull(actual);
        }


        [Test]
        public void Test4()
        {
            var data = "1,2,3,-,-,4,5,2,3,-,-,4,5,2,3,-,-,4,5,2,3,-,-,4,5,-,-,-,-,-";

            var actual = new Codec().deserialize(data);

            Assert.IsNotNull(actual);
        }
         

        [Test]
        public void Test5()
        { 
            //[1,2,3,null,null,4,5,2,3] 

            var root = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
                {
                    left = new TreeNode(4)
                    {
                        left = new TreeNode(2),
                        right = new TreeNode(3)
                    },
                    right = new TreeNode(5)
                }
            };

            var serialize = new Codec().serialize(root);
            var actual = new Codec().deserialize(serialize);

            Assert.AreEqual(root.val, actual.val);
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

                while (q.Count > 0)
                {
                    var size = q.Count;

                    var hasNotNull = false;

                    var tmpStr = new StringBuilder();

                    while (size > 0)
                    {
                        var node = q.Dequeue();

                        if (node == null)
                        {
                            tmpStr.Append("-,");
                            size--;
                            continue;
                            
                        }
                        else
                        {
                            tmpStr.Append($"{node.val},");
                            hasNotNull = true;
                        }

                        q.Enqueue(node?.left);
                        q.Enqueue(node?.right);
                        size--;
                    }

                    if (!hasNotNull) break;
                    str.Append(tmpStr);
                }

                return str.Remove(str.Length - 1, 1).ToString();
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                if (string.IsNullOrEmpty(data)) return null;

                var nodes = data.Split(',').ToList();

                var q = new Queue<TreeNode>();
                var root = new TreeNode(int.Parse(nodes.First()));
                q.Enqueue(root);
                var i = 1;
                while (q.Count > 0)
                {
                    var size = q.Count;
                    while (size > 0)
                    {
                        var node = q.Dequeue();

                        if (i >= nodes.Count) break;

                        if (nodes[i] != "-")
                        {
                            node.left = new TreeNode(int.Parse(nodes[i]));
                            q.Enqueue(node.left);
                        }

                        if (i + 1 < nodes.Count && nodes[i + 1] != "-")
                        {
                            node.right = new TreeNode(int.Parse(nodes[i + 1]));
                            q.Enqueue(node.right);
                        }

                        i += 2;

                        size--;
                    }

                    if (i >= nodes.Count) break;
                }


                return root;
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