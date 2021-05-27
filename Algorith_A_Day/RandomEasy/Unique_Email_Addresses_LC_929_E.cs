using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Unique_Email_Addresses_LC_929_E
    {
        public static int NumUniqueEmails(string[] emails)
        {
            if (emails == null || emails.Length == 0) return 0;

            HashSet<string> result = new HashSet<string>();


            foreach (string e in emails)
            {
                string temp = String.Empty;
                for (int i = 0; i < e.Length; i++)
                {
                    char current = e[i];
                    if (current == '.') continue;
                    else if (current == '@')
                    {
                        temp += e.Substring(e.IndexOf('@'));
                        break;
                    }
                    else if (current == '+')
                    {
                        temp += e.Substring(e.IndexOf('@'));
                        break;
                    }
                    else temp += current.ToString();

                }
                result.Add(temp);
            }

            return result.Count;
        }

        //public int NumUniqueEmails2(string[] emails)
        //{

        //    HashSet<string> set = new HashSet<string>();
        //    foreach (string item in emails)
        //    {
        //        string domain = item.Substring(item.IndexOf('@'));
        //        string val = rep(item.Substring(0, item.IndexOf("@")));
        //        if (!set.Contains(val + domain))
        //            set.Add(val + domain);
        //    }
        //    return set.Count();
        //}
        //public static string rep(string s)
        //{
        //    if (s.Contains("."))
        //    {
        //        s = s.Replace(".", "");
        //    }

        //    if (s.Contains("+"))
        //    {
        //        s = s.Substring(0, s.IndexOf('+'));
        //    }
        //    return s;
        //}

        /*
         var numUniqueEmails = function(emails) {
            let resEmails = emails.map((item) => {
            let res = item.split('@')
            let temp1 = res[0].replace(/\./g,'')
            temp1 = temp1.split('+')[0]
            let temp2 = res[1]
            return temp1 +'@'+temp2
        })
            let res = new Set(resEmails)
            return res.size
        };      
         */
    }
}
