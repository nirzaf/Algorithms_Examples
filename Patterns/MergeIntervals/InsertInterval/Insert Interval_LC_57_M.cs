using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.Patterns.MergeIntervals.InsertInterval
{
    public class Insert_Interval_LC_57_M
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {

            // return list of list with newInterval
            if (intervals.Length == 0) return new int[][] { newInterval };

            // insert new interval in correct location
            var output = new List<int[]>();
            bool pushed = false;

            foreach (var i in intervals) {
                // check only first numbers as we gonna mergr them anyway
                if (!pushed && newInterval[0] < i[0])
                {
                    output.Add(newInterval);
                    pushed = true;
                }
                output.Add(i);
            }

            //for input [[1,5]] , [2,7] expected is [1,7] so we need to:
            // if new interval is not pushed we need to push it here:
            if (!pushed) output.Add(newInterval);


            // merge intervals along with push newInterval
            // this is the same as mergeintervals 56
            return MergeIntervals(output.ToArray());
        }

        private int[][] MergeIntervals(int[][] intervals)
        {
            //normallly it shoul be sorted but it is sorted in that case
            var output = new List<int[]>();

            var candidateInterval = intervals[0];


            for (int i = 1; i < intervals.Length; i++)
            {
                var currentInterval = intervals[i];

                if (currentInterval[0] <= candidateInterval[1])
                {
                    candidateInterval[1] = Math.Max(candidateInterval[1], currentInterval[1]);
                }
                else
                {
                    output.Add(candidateInterval);
                    candidateInterval = currentInterval;
                }
            }


            output.Add(candidateInterval);


            return output.ToArray();
        }

        public int[][] Insert2(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0 && newInterval.Length != 0)
            {
                return new int[][] { newInterval };
            }
            var result = new List<int[]>
            {
                intervals[0]
            };

            for (int i = 1; i < intervals.Length; i++)
            {
                var current = intervals[i];
                var last = result.Last();

                if (current[1] < newInterval[0] || last[1] < newInterval[0])
                {
                    result.Add(current);
                    // countinue 
                }
                else if (current[1] >= newInterval[0])
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
            return result.ToArray();
        }
    }
}



