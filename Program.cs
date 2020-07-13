using Algorithm_A_Day.BinarySearch;
using System;

namespace Algorith_A_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            var testArr = new int[] { 10, 2, 5, 6, 8, 9 };

            NumberOfRoatations numberOfRoatations = new NumberOfRoatations();
            Console.WriteLine(numberOfRoatations.NumberOfRotation(testArr));
        }
    }
}
