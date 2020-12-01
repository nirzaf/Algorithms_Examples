using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.Patterns.MergeIntervals
{
    public class Insert_Interval_LC_57_M
    {
        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0 && newInterval.Length != 0)
            {
                return new int[][] { newInterval };
            }
            var result = new List<int[]>();
            result.Add(intervals[0]);


            for (int i = 1; i < intervals.Length; i++)
            {
                var current = intervals[i];
                var last = result.Last();

                if (current[1] < newInterval[0] || last[1] < newInterval[0])
                {
                    result.Add(current);
                    // countinue 
                }
                else if(current[1] >= newInterval[0]);
                {
                    var first = current[0]; //first element of new merged array
                    var secondElement = newInterval[1];
                    //check second element of newInterval 
                    while (secondElement > intervals[i][1])
                    {
                        i++;
                    }
                    // bigger element
                    var x = intervals[i];
                    if (x[0] > secondElement)
                    {
                        result.Add(new int[] { first, secondElement });
                        result.Add(intervals[i]);
                    }
                    else
                    {
                        result.Add(new int[] { first, x[1] });
                    }
                }
            }


            //4,8
            // 6,8         8,10    

            return result.ToArray();
        }
    }
}
