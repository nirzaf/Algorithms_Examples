using Algorithm_A_Day.BinarySearch;
using System;

namespace Algorith_A_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            var testArr = new int[] {8,9,10,2,5,6,7 };
            var sortedArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 15, 21, 50, 200, 400 };
            var mixedArr = new int[] { 1, 4, 6, 8, 9 };

            Console.WriteLine(ExponentialSearch.ESearch(sortedArr, 21));
        }
    }
}
