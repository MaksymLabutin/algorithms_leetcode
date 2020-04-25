using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {

            //["MyLinkedList","addAtHead","addAtTail","addAtIndex","get","deleteAtIndex","get"]
            //    [[],[1],[3],[1,2],[1],[1],[1]]
            var ll = new MyLinkedList();

            ll.AddAtHead(1);
            ll.AddAtTail(3);
            ll.AddAtIndex(1,2);
            var val_2 = ll.Get(1);
            Assert.AreEqual(2, val_2);
            ll.DeleteAtIndex(1);
            var val_3 = ll.Get(1);
            Assert.AreEqual(3, val_3); 
            ll.DeleteAtIndex(0);
            ll.DeleteAtIndex(0);
             
        }

        [Test]
        public void Test2()
        {

            //["MyLinkedList","addAtHead","addAtHead","addAtHead","addAtIndex","deleteAtIndex",  "addAtHead","addAtTail","get","addAtHead","addAtIndex","addAtHead"]
            //    [[],[7],[2],[1],[3,0],[2]  ,[6],[4], [4],[4],[5,0],[6]]
            var ll = new MyLinkedList();

            ll.AddAtHead(7);
            ll.AddAtHead(2);
            ll.AddAtHead(1);
            ll.AddAtIndex(3,0);
            ll.DeleteAtIndex(2);
            ll.AddAtHead(6);
            ll.AddAtTail(4);

            var val_4 = ll.Get(4);

            Assert.AreEqual(4, val_4);
            ll.AddAtHead(4);

            ll.AddAtIndex(5, 0);
            ll.AddAtHead(6);
             
        }
        [Test]
        public void Test3()
        {
            //["MyLinkedList","addAtHead","deleteAtIndex","addAtHead","addAtHead","addAtHead","addAtHead","addAtHead","addAtTail","get","deleteAtIndex","deleteAtIndex"]
            //    [[],[2],[1],[2],[7],[3],[2],[5],[5],[5],[6],[4]]
            var ll = new MyLinkedList();

            ll.AddAtHead(2);
            ll.DeleteAtIndex(1);
            ll.AddAtHead(2);
            ll.AddAtHead(7);
            ll.AddAtHead(3);
            ll.AddAtHead(2);
            ll.AddAtHead(5);
            ll.AddAtTail(5);
            var val_2 = ll.Get(5);

            Assert.AreEqual(2, val_2);
            ll.DeleteAtIndex(6);
            ll.DeleteAtIndex(4); 
        }

        public class MyLinkedList
        {
            private LinkedList _head;
            private int _lenght;

            /** Initialize your data structure here. */
            public MyLinkedList()
            {
                _head = null;
                _lenght = 0;
            }

            /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
            public int Get(int index)
            {
                if (index >= _lenght) return -1;

                var node = _head;
                for (var i = 0; i < index; i++)
                {
                    node = node.Next;
                }

                return node.Val;
            }

            /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
            public void AddAtHead(int val)
            {
                var newHead = new LinkedList(val) {Next = _head};
                _head = newHead;
                _lenght++;
            }

            /** Append a node of value val to the last element of the linked list. */
            public void AddAtTail(int val)
            {
                if (_head == null)
                {
                    _head = new LinkedList(val);
                    _lenght++;
                    return;
                }

                var node = _head;

                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = new LinkedList(val);
                _lenght++;
            }

            /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
            public void AddAtIndex(int index, int val)
            {
                if(index > _lenght)return;

                if (_head == null)
                {
                    _head = new LinkedList(val);
                    _lenght++;
                    return;
                }

                if (index == _lenght)
                {
                    AddAtTail(val);
                    return;
                }

                if (index == 0)
                {
                    AddAtHead(val);
                    return;
                }

                LinkedList prev = null;
                LinkedList curr = _head;

                for (var i = 0; i < index; i++)
                {
                    prev = curr;
                    curr = curr.Next;
                }

                var node = new LinkedList(val) {Next = curr};
                prev.Next = node;

                _lenght++;
            }

            /** Delete the index-th node in the linked list, if the index is valid. */
            public void DeleteAtIndex(int index)
            {
                if(index >= _lenght || _lenght == 0)return;

                _lenght--;

                if (_lenght == 0)
                {
                    _head = null;
                    return;
                }

                if (index == 0)
                {
                    _head = _head.Next;
                    return;
                }

                LinkedList prev = null;
                LinkedList curr = _head;

                for (var i = 0; i < index; i++)
                {
                    prev = curr;
                    curr = curr.Next;
                }

                prev.Next = curr?.Next ;

            }
        }

        public class LinkedList
        {
            public LinkedList(int val)
            {
                Val = val;
            }

            public int Val { get; set; }
            public LinkedList Next { get; set; }
        }
    }
}