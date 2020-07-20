using Algorithm_A_Day.BinarySearch;
using System;

namespace Algorith_A_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            var testArr = new int[] { 10, 2,2,2,2,2, 5, 6,8, 8, 9 };
            var sortedArr = new int[] { 0, 1, 2, 6, 9, 11, 15 };


            SmallestMissingElement smallest = new SmallestMissingElement();

            smallest.SmallestMissingEL(sortedArr, 0, sortedArr.Length - 1);
        }
    }
}
