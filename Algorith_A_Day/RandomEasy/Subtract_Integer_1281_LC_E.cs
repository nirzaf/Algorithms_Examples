using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Subtract_Integer_1281_LC_E
    {
        public int SubtractProductAndSum(int n)
        {
            if (n <= 0) return - 1;

            int multi = 1;
            int addi = 0;

            foreach (char c in n.ToString())
            {
                multi *= int.Parse(c.ToString());
                addi += int.Parse(c.ToString());
            }

            return multi - addi;
        }


        //suprisngly fast but SC not too good
        /*
        var subtractProductAndSum = function(n) {
            m = n.toString().split('');

            addi = m.reduce((total, cur) => total + parseInt(cur), 0);
            multi = m.reduce((total, cur) => total * parseInt(cur), 1);
    
            return multi - addi;
        };


        var subtractProductAndSum = function(n) {
            return [...String(n)].reduce((a,c) => a * Number(c)) - [...String(n)].reduce((a,c) => a + Number(c), 0)
        };????

        var subtractProductAndSum = function(n) {
    let product = 1, sum = 0;
    while (n > 0) {
        let lastDigit = n % 10;
        product *= lastDigit;
        sum += lastDigit;
        n = Math.floor(n / 10);
    }
    return product - sum;
};
         */
    }
}
