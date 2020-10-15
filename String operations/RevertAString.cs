using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.String_operations
{
    class RevertAString
    {
        public static string RevertString(string input)
        {
            string result = String.Empty;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                result += input[i];
            }
            string reverseValue = new string(input.Reverse().ToArray());
            var result2 = input.Aggregate("", (acc, c) => c + acc);
            //"",("",d) => d+""
            //   (d,u) => u + d
            //   (ud,p) => p + ud
            //   (pud,a) => a + pud = apud XDDD
            var result3 = input.Aggregate(new StringBuilder(), (x, y) => x.Insert(0, y)).ToString();
            //public string Insert(int startIndex, string value);
            //"",("",d) => sb.Insert(0,d)
            //   (d,u) => d.Insert(0,u) = ud(inserting u at index 0 + the rest ("d")
            //   (ud, p) => ud.Insert(0,p) = pud(inserting p at index 0 + the rest ("ud"))
            //   (pud,a) => pud.Insert(0,a) = apud(inserting a at index 0 + the rest ("pud")

            var result4 = input.ToCharArray()//it is not necessary here
                         .Select(ch => ch.ToString())
                         .Aggregate<string>((xs, x) => x + xs);
            Func<String, String> f = null; f = s => s.Length == 1 ? s : f(s.Substring(1)) + s[0];
            //f(dupa) = f(upa) + d
            //f(upa) = f(pa) + u
            //f(pa) = f(a) + p
            //f(a) = a, here "s.Length == 1 ? s"  is a BASE CASE
            var result5 = f(input);

            //todo
            var result6 = new string(Enumerable.Range(1, input.Length).Select(i => input[input.Length - i]).ToArray());

            var result7 = new string(input.Select((c, index) => new { c, index })
                                         .OrderByDescending(x => x.index)
                                         .Select(x => x.c)
                                         .ToArray());
            return result3;
        }
    }
}
