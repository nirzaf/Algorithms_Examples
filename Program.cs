using Algorithm_A_Day.BinarySearch;
using System;

namespace Algorith_A_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            var testArr = new int[] { 10, 2,2,2,2,2, 5, 6,8, 8, 9 };
            var sortedArr = new int[] { 1, 2, 3, 4, 5, 6 };
            var mixedArr = new int[] { 1, 4, 6, 8, 9 };


            FindFloorOrCeil floorOrCeil = new FindFloorOrCeil();
            floorOrCeil.GetFloor(mixedArr, 2);
        }
    }
}
