using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Logger logger = new Logger();

            // logging string "foo" at timestamp 1
            var t1 = logger.ShouldPrintMessage(1, "foo"); //returns true;

            // logging string "bar" at timestamp 2
            var t2 = logger.ShouldPrintMessage(2, "bar"); //returns true;

            // logging string "foo" at timestamp 3
            var t3 = logger.ShouldPrintMessage(3, "foo"); //returns false;

            // logging string "bar" at timestamp 8
            var t4 = logger.ShouldPrintMessage(8, "bar"); //returns false;

            // logging string "foo" at timestamp 10
            var t5 = logger.ShouldPrintMessage(10, "foo"); //returns false;

            // logging string "foo" at timestamp 11
            var t6 = logger.ShouldPrintMessage(11, "foo"); //returns true;

            Assert.Pass();
        }
    }

    public class Logger
    {
        private readonly Dictionary<string, int> _dic;

        /** Initialize your data structure here. */
        public Logger()
        {
            _dic = new Dictionary<string, int>();
        }

        /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
            If this method returns false, the message will not be printed.
            The timestamp is in seconds granularity. */
        public bool ShouldPrintMessage(int timestamp, string message)
        {
            var response = false;
            if (_dic.ContainsKey(message))
            {
                if (_dic[message] <= timestamp)
                {
                    _dic[message] = timestamp + 10;
                    response = true;
                }
            }
            else
            {
                _dic.Add(message, timestamp + 10);
                response = true;
            }

            return response;
        }
    }
}