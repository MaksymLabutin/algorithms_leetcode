using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var emails = new string[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" };

            var actual = NumUniqueEmails(emails);

            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        public int NumUniqueEmails(string[] emails)
        {
            var uniqe = new HashSet<string>();

            foreach (var email in emails)
            {
                var str = new StringBuilder();
                var isSkiping = false;
                var isAt = false;
                foreach (var symbol in email)
                {
                    switch (symbol)
                    {
                        case '+':
                            isSkiping = true;
                            break;
                        case '.':
                            if (isAt) str.Append(symbol);
                            break;
                        case '@':
                            str.Append(symbol);
                            isSkiping = false;
                            isAt = true;
                            break;
                        default:
                            if (!isSkiping) str.Append(symbol);
                            break;
                    }
                }

                uniqe.Add(str.ToString());
                str.Clear();
            }

            return uniqe.Count;
        }
    }
}