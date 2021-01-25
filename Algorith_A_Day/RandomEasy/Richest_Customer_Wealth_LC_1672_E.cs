using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Richest_Customer_Wealth_LC_1672_E
    {
        public int MaximumWealth(int[][] accounts)
        {
            if (accounts == null || accounts.Length == 0) return 0;

            int maxWealth = 0;

            for (int i = 0; i < accounts.GetLength(0); i++)
            {
                int currentSum = 0;
                for (int j = 0; j < accounts[i].Length; j++)
                {
                    currentSum += accounts[i][j];
                }
                maxWealth = Math.Max(maxWealth, currentSum);
            }
            return maxWealth;
        }
        public int MaximumWealth2(int[][] accounts) => accounts.Select(row => row.Sum()).Max();

    }
}

    //    var maximumWealth = function(accounts) {
    //    if(accounts == null || accounts.length == 0) return 0;

    //        maxWealth = 0;

    //        for(i = 0; i<accounts.length; i++)
    //        {
    //            currentSum = 0;
    //            for(j = 0; j<accounts[i].length; j++)
    //            {
    //                currentSum += accounts[i][j];
    //            }
    //            maxWealth = Math.max(maxWealth, currentSum);
    //        }  
    //        return maxWealth;
    //     };

    //    var maximumWealth = function(accounts) {
          //return in reduce returns to accumulation variable
    //    return accounts.reduce((acc, val) => {
    //        const result = val.reduce((acc, val) => acc + val, 0);
    //        return Math.max(result, acc);
    //    }, 0)
    //};
    //let maximumWealth = A => Math.max(...A.map(row => _.sum(row)));
    //const sum = (array) => array.reduce((a, b) => a + b, 0);

    //const maximumWealth = (accounts) => accounts
    //  .reduce((max, account) => Math.max(max, sum(account)), -Infinity);

