using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Number__Square_1725_LC_E
    {
        public static int CountGoodRectangles(int[][] rectangles)
        {
            if (rectangles == null || rectangles.Length == 0) return 0;

            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < rectangles.Length; i++)
            {
                if (rectangles[i][0] < rectangles[i][1])
                {
                    if (dict.ContainsKey(rectangles[i][0]))
                    {
                        dict[rectangles[i][0]]++;
                    }
                    else
                    {
                        dict[rectangles[i][0]] = 1;
                    }
                }
                else
                {
                    if (dict.ContainsKey(rectangles[i][1]))
                    {
                        dict[rectangles[i][1]]++;
                    }
                    else
                    {
                        dict[rectangles[i][1]] = 1;
                    }
                }

            }

            int result = 0;

            foreach (KeyValuePair<int, int> entry in dict)
            {
                if (entry.Value > result)
                {
                    result = entry.Value;
                }
            }

            return result;
        }

        public int CountGoodRectangles2(int[][] rectangles)
        {
            int[] squares = new int[rectangles.Length];
            int max = int.MinValue;

            for (int i = 0; i < rectangles.Length; i++)
            {
                squares[i] = Math.Min(rectangles[i][0], rectangles[i][1]);
                max = Math.Max(max, squares[i]);
            }

            int count = 0;
            foreach (var s in squares)
            {
                if (s == max)
                {
                    count++;
                }
            }

            return count;
        }

        /*
         var countGoodRectangles = function(rectangles) {
            if(rectangles.length == 0) return 0;
    
            let largest = [];
            let max = 0;
    
            for(let i = 0; i < rectangles.length; i++){
                largest[i] = Math.min(rectangles[i][0], rectangles[i][1]);
                console.log(rectangles[i][0]);
                max = Math.max(max, largest[i]);
            }
    
            let result = 0;
    
            largest.forEach(x => {
                if(x == max) result++;
            });
    
            return result;
         }
         */



    }
}
