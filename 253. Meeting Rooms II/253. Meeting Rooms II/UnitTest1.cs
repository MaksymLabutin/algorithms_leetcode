using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace _253._Meeting_Rooms_II
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //[[0, 30],[5, 10],[15, 20]]
            var intervals = new int[][]
            {
                new int[] {0, 30},
                new int[] {5, 10},
                new int[] {15, 20},
            };

            var actual = MinMeetingRooms(intervals);

            var expected = 2;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test2()
        {
            //[[0, 30],[5, 10],[15, 20]]
            var intervals = new int[][]
            {
                new int[] {7,10},
                new int[] {2,4}
            };

            var actual = MinMeetingRooms(intervals);

            var expected = 1;

            Assert.Equal(expected, actual);
        }


        public int MinMeetingRooms(int[][] intervals)
        {
            if (intervals.Length == 0) return 0;

            var sorted = intervals.OrderBy(_ => _[0]).ToList();

            var maxRooms = 0;
            var meetingRoomsOccupied = new SortedList<int, int>(new Sorter());

            foreach (var interval in sorted)
            {
                ReleaseMeetingRoom(meetingRoomsOccupied, interval[0]); 
                meetingRoomsOccupied.Add(interval[1], interval[1]);
                maxRooms = Math.Max(maxRooms, meetingRoomsOccupied.Count);
            }

            return maxRooms;
        }

        private void ReleaseMeetingRoom(SortedList<int, int> rooms, int time)
        {
            while (rooms.Count > 0)
            { 
                if(rooms.ElementAt(0).Key > time) break;
                rooms.RemoveAt(0);
            } 
        }
    }

    public class Sorter : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x > y ? 1 : -1;
        }
    }
}
