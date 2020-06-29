using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {  
        [Test]
        public void Test1()
        {
            var days = new int[] {1, 4, 6, 7, 8, 20};
            var costs = new int[] {2, 7, 15};

            var actual = MincostTickets(days, costs);

            var expected = 11;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var days = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 30, 31 };
            var costs = new int[] { 2, 7, 15 };

            var actual = MincostTickets(days, costs);

            var expected = 17;
            Assert.AreEqual(expected, actual);
        }



        private Dictionary<string, int> _memo;
        private int[] _days;
        private int[] _costs;

        public int MincostTickets(int[] days, int[] costs)
        {
            _memo = new Dictionary<string, int>();
            _days = days;
            _costs = costs;
            return MincostTickets(0, 0);
        }

        public int MincostTickets(int dayIndex, int skipDays)
        {
            if (dayIndex >= _days.Length) return 0;

            for (var i = 0; i < _costs.Length; i++)
            {
                var key = _days[dayIndex] + "-" + _costs[i];
                if (_memo.ContainsKey(key)) continue;
                var sum = MincostTickets(GetNextIndex(i, dayIndex), i) + _costs[i];
                _memo.Add(key, sum);
            }
            var partKey = _days[dayIndex] + "-";
            return Math.Min(_memo[partKey + _costs[0]], Math.Min(_memo[partKey + _costs[1]], _memo[partKey + _costs[2]]));
        }

        private int GetNextIndex(int passDaysIndex, int dayIndex)
        {
            if (passDaysIndex == 0) dayIndex++;
            else
            {
                var maxDay = (passDaysIndex == 1 ? 7 : 30) + _days[dayIndex] - 1;
                while (maxDay >= _days[dayIndex])
                {
                    dayIndex++;
                    if (dayIndex >= _days.Length) return dayIndex + 1;
                }
            }

            return dayIndex;
        }
    }
}