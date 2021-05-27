using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Keyboard_Row_LC_500_E
    {
        public static string[] FindWords(string[] words)
        {
            if (words == null || words.Length <= 0) return new string[] { };

            List<string> result = new List<string>();

            string row1 = "qwertyuiop";
            string row2 = "asdfghjkl";
            string row3 = "zxcvbnm";


            foreach (string word in words)
            {
                bool r1 = true;
                bool r2 = true;
                bool r3 = true;

                

                for (int i = 0; i < word.Length; i++)
                {
                    if (!(row1.Contains(word[i].ToString().ToLower())))
                    {
                        r1 = false;
                        break;
                    }
                }

                for (int i = 0; i < word.Length; i++)
                {
                    if (!(row2.Contains(word[i].ToString().ToLower())))
                    {
                        r2 = false;
                        break;
                    }
                }

                for (int i = 0; i < word.Length; i++)
                {
                    if (!(row3.Contains(word[i].ToString().ToLower())))
                    {
                        r3 = false;
                        break;
                    }
                }

                if (r1 == true || r2 == true || r3 == true) result.Add(word);
            }

            return result.ToArray();

        }
    }
}
