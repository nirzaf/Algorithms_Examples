using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Number_of_Segments_in_a_String_LC_434_E
    {
        public static int CountSegments(string s)
        {
            if (s == null || s.Length == 0) return 0;

            int result = 0;
            bool hasCharacter = false;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i].ToString() != " ") hasCharacter = true;
                if (s[i].ToString() == " " && s[i - 1].ToString() != " ") result++;
            }

            if (result == 0 && hasCharacter || (s.Length == 1 && s[0].ToString() != " ")) return 1;
            if (result > 0 && hasCharacter && s[s.Length - 1].ToString() != " ") return result + 1;

            int x = (int)'a';
            var x1 = (int)'b';


            return result;

        }

        //var x2 = (int)' ' === 32
        public static int CountSegments2(string s)
        {
            if (s == null || s == string.Empty)
                return 0;

            int count = 0;
            string trimmedString = s.Trim();

            if (trimmedString == string.Empty)
                return 0;

            for (int index = 1; index <= trimmedString.Length - 1; index++)
                if ((int)trimmedString[index] == 32 && (int)trimmedString[index - 1] != 32)
                    count++;

            return ++count;

        }

        //LINQ
        public static int CountSegments3(string s)
        {
            var word = s.Split(' ').ToList();
            var removeSpace = word.RemoveAll(x => x == "");

            return word.Count;
        }

        /*
         var countSegments = function (s) {
            let a = s.split(" ");
            let b = [];

            for (i = 0; i < a.length; i++) {
                if (a[i] !== "") { b.push(a[i]); }
            }

            return b.length;
         };


        var countSegments = function(s) {
            if(!s) return 0;
            return s.split(' ').filter(val => {return val !== ''}).length;
        };
         */
    }
}
