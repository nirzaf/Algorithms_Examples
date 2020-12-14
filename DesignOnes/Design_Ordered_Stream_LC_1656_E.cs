using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.DesignOnes
{
    public class Design_Ordered_Stream_LC_1656_E
    {
        private string[] result;
        private int index = 1;

        public Design_Ordered_Stream_LC_1656_E(int n)
        {
            result = new string[n + 1];
            index = 1;
        }

        public IList<string> Insert(int id, string value)
        {
            var res = new List<string>();
            var current = id;
            result[current] = value;

            if (index == id)
            {
                for (; current < result.Length; current++)
                {
                    if (result[current] != null)
                    {
                        res.Add(result[current]);
                    }
                    else break;
                }
                index = current;
            }
            return res;
        }
    }
}
