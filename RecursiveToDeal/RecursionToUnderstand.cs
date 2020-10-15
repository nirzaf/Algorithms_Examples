using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BST.Recursion
{
    class RecursionToUnderstand
    {
        //We create recursion base case in helper methods(here calculate) thus create int s as argument for method
        //then first loop starts with index of s (from argument) and inner loop starts with the same index + 1(next one)
        //then we compare element from arr on index start with next one (+1) if first is smaller than next 
        //method is called recursively

        public int MaxProfit(int[] prices)
        {
            return Calculate(prices, 0);
        }
        //[7,1,5,3,6,4] 7
        public int Calculate(int[] prices, int s)
        {
            if (s >= prices.Length)
                return 0;
            int max = 0;
            for (int start = s; start < prices.Length; start++)
            {
                int maxprofit = 0;
                for (int i = start + 1; i < prices.Length; i++)
                {
                    if (prices[start] < prices[i])
                    {
                        int profit = Calculate(prices, i + 1) + prices[i] - prices[start];
                        if (profit > maxprofit)
                            maxprofit = profit;
                    }
                }
                if (maxprofit > max)
                    max = maxprofit;
            }
            return max;
        }
        //inner loop comes back with i = 4 + 1 so next one afeter calling
        //so profit = 3 so 3 > 0 maxprofit = 3
        //C(prices, 5) returns 0;
        //outer loop doesnt triggers with start = 6 becouse it equals to len
        //maxp = 0, max = 0;
        //C(prices, 5) i = 6 so second loop is not working here
        //profit = C(prices, 5) + 6 -3 
        //3(start = 3) < 6(i = 4) 
        //C(prices, 3) we start first loop with index 3 so with the next one after it was smaller than next XDDD
        //profit = C(prices, 3) + 5 -1 
        //1(start = 1) < 5(i = 2) 
        //all elements are smaller than 7 so now start is at index 1(value 1)
        //C(prices, 0)max = 0 , mp = 0; second loop is for compering all elements to first element then all to second and so on
    }
}
