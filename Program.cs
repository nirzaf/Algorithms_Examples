using Algorithm_A_Day.BinarySearch;
using System;

namespace Algorith_A_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            var testArr = new int[] { 10,9,8,2,5,6 };
            var sortedArr = new int[] { 1, 2, 3, 4, 5, 6 };
            var mixedArr = new int[] { 1, 4, 6, 8, 9 };


            Console.WriteLine(FindPeakElement.FindPeakRecur(testArr, 0, testArr.Length -1));
        }
    }
}
