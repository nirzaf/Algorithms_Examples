using System;
using System.Collections.Generic;

namespace Algorithm_A_Day.Patterns.K_thLargestElement
{
    public class K_Closest_Points_to_Origin_LC_973
    {

        /// <summary>
        /// Euclidean distance for points (x1, y1) and (x2, y2) is
        /// pow(x2 - x1, 2) + pow(y2 - y1, 2)
        /// here it is just (pow(x,2) + pow(y,2) becasue origin point is always (0,0)
        /// </summary>
        public static int[][] KClosest(int[][] points, int K)
        {
            List<int[]> result = new List<int[]>();
            if (points.Length == 0 || points == null) return result.ToArray();

            var distances = new SortedDictionary<double, int>();
            var index = 0;
            List<int> indexOfDoubleValue = new List<int>();

            foreach (int[] point in points)
            {
                var distance = GetDistance(point);

                if (!distances.ContainsKey(distance))
                {
                    distances.Add(distance, index);
                    index++;
                }
                else if(distances.ContainsKey(distance) && distances[distance] != index)
                {
                    indexOfDoubleValue.Add(index);
                }
            }

            foreach (KeyValuePair<double, int> item in distances)
            {
                result.Add(points[item.Value]);
                //if (indexOfDoubleValue.Contains(item.Value))
                //{
                //    result.Add(points[i]);
                //}
                K--;
                if(K <= 0)
                {
                    break;
                }
            }

              
            return result.ToArray();

        }

        public static int[][] KClosest2(int[][] points, int K)
        {
            SortedDictionary<double, List<int[]>> Sd = new SortedDictionary<double, List<int[]>>();
            foreach (int[] curr in points)
            {
                double dist = GetDistance(curr);
                if (!Sd.ContainsKey(dist))
                    Sd[dist] = new List<int[]>();
                Sd[dist].Add(curr);
            }
            int[][] res = new int[K][];
            int k = 0;
            foreach (double key in Sd.Keys)
            {
                foreach (int[] p in Sd[key])
                {
                    if (k == K) break;
                    res[k++] = p;

                }
            }
            return res;
        }

        private static double GetDistance(int[] point)
        {
            return Math.Sqrt((point[0] * point[0]) + (point[1] * point[1]));
        }
    }
}
