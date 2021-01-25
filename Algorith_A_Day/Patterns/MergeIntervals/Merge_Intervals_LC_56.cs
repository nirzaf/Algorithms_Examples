using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.Patterns.MergeIntervals
{
    public class Merge_Intervals_LC_56
    {
        // it shows mutability of list in c#

        public static int[][] Merge(int[][] intervals)
        {
            //for 0 or 1 elements (intervals)
            if (intervals.Length <= 0) return intervals;
            // it just put input with smaller first value first
            Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));
            //int[][] temp = intervals.OrderBy(a => a[0]).ToArray();
            var tempList = new List<int[]>();

            int[] currentIterval = intervals[0];
            tempList.Add(currentIterval);

            for (int i = 1; i < intervals.Length; i++)
            {           
                var next = intervals[i];
                var lastFromResult = tempList.Last();
                if(next[0] <= lastFromResult[1])
                {
                    //So he's able to do that because ArrayList is mutable in Java.(same C# as it seems)
                    //Whatever modification he performs on the current interval within the for loop
                    //is also reflected inside the interval found in output_arr.
                    //If he were to update the interval under a new variable assignment,
                    //then the interval update wouldn't roll over to the interval found in output_arr.
                    //This same reasoning is also applicable to Python.
                    //more: https://www.youtube.com/watch?v=qKczfGUrFY4
                    lastFromResult[1] = Math.Max(lastFromResult[1], next[1]);
                }
                else
                {
                    tempList.Add(next);
                }

            }
            return tempList.ToArray();
        }
    }
}
