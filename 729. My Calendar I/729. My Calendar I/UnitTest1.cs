using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var calendar = new MyCalendar();
            Assert.IsTrue(calendar.Book(10, 20));
            Assert.IsFalse(calendar.Book(15, 25));
            Assert.IsTrue(calendar.Book(20, 30));
        }


        [Test]
        public void Test2()
        {
            var calendar = new MyCalendar();
            Assert.IsTrue(calendar.Book(47, 50));
            Assert.IsTrue(calendar.Book(33, 41));
            Assert.IsFalse(calendar.Book(39, 45));
            Assert.IsFalse(calendar.Book(33, 42));
            Assert.IsTrue(calendar.Book(25, 32));
            Assert.IsFalse(calendar.Book(26, 35));
            Assert.IsTrue(calendar.Book(19, 25));
            Assert.IsTrue(calendar.Book(3, 8));
            Assert.IsTrue(calendar.Book(8, 13));
            Assert.IsFalse(calendar.Book(18, 27));
        }

        [Test]
        public void Test3()
        {
            var calendar = new MyCalendar();
            Assert.IsTrue(calendar.Book(37, 50));
            Assert.IsFalse(calendar.Book(33, 50));
            Assert.IsTrue(calendar.Book(4, 17));
            Assert.IsFalse(calendar.Book(35, 48));
            Assert.IsFalse(calendar.Book(8, 25));
        }

        [Test]
        public void Test4()
        {
            var calendar = new MyCalendar();
            Assert.IsTrue(calendar.Book(69, 70));
            Assert.IsTrue(calendar.Book(3, 4));
            Assert.IsTrue(calendar.Book(39, 40));
            Assert.IsTrue(calendar.Book(35, 36));
            Assert.IsFalse(calendar.Book(3, 4));
            Assert.IsTrue(calendar.Book(55, 56));
            Assert.IsTrue(calendar.Book(61, 62));
            Assert.IsTrue(calendar.Book(97, 98));
            Assert.IsTrue(calendar.Book(79, 80));
            Assert.IsTrue(calendar.Book(76, 77));
            Assert.IsTrue(calendar.Book(46, 47));
            Assert.IsTrue(calendar.Book(78, 79));
        }

        [Test]
        public void Test5()
        {


            //[[0,6],[27,36],[6,11],[20,25],[32,37],[14,20],[7,16],[13,22],[39,47],[37,46],[42,50],[9,17],[49,50],[31,37],[43,49],[2,10],[3,12],[8,14],[14,21],[42,47],[43,49],[36,43]]
            //[true,false,false,false,true,true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]
            var calendar = new MyCalendar();
            Assert.IsTrue(calendar.Book(23, 32));
            Assert.IsTrue(calendar.Book(42, 50));
            Assert.IsTrue(calendar.Book(6, 14));
            Assert.IsFalse(calendar.Book(0, 7));
            Assert.IsFalse(calendar.Book(21, 30));
            Assert.IsFalse(calendar.Book(26, 31));
            Assert.IsFalse(calendar.Book(46, 50));
            Assert.IsFalse(calendar.Book(46, 50));
            Assert.IsFalse(calendar.Book(28, 36));
            Assert.IsTrue(calendar.Book(0, 6));
        }

        public class MyCalendar
        {
            private List<int[]> _events;

            public MyCalendar()
            {
                _events = new List<int[]>();
            }

            public bool Book(int start, int end)
            {
                foreach (var ev in _events)
                {
                    if (end > ev[0] && start < ev[1])
                    {
                        return false;
                    }
                }

                _events.Add(new int[] { start, end });

                return true;
            }
        }

    }
}