using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Unique_Morse_Code_Words_LC_804_E
    {
        public int UniqueMorseRepresentations(string[] words)
        {
            if (words == null || words.Length == 0) return 0;

            string[] morse = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

            HashSet<string> transformations = new HashSet<string>();

            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            foreach (string w in words)
            {
                string temp = "";

                foreach (char c in w)
                {
                    int tempIndex = alphabet.IndexOf(c);
                    temp += morse[tempIndex];
                }
                transformations.Add(temp);

            }

            return transformations.Count();

        }

        //nice LINQ
        public int UniqueMorseRepresentations2(string[] words)
        {
            var morse = new[]
            {
        ".-", "-...", "-.-.", "-..", ".", "..-.",
        "--.", "....", "..", ".---", "-.-", ".-..",
        "--", "-.", "---", ".--.", "--.-", ".-.",
        "...", "-", "..-", "...-", ".--", "-..-",
        "-.--", "--.."
            };
            var alphabet = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i).ToArray();
            var dictionary = alphabet.ToDictionary(c => c, c => morse[c - 'a']);
            var result = words
                .Select(x => x.ToCharArray().Select(y => dictionary[y]).Aggregate("", (a, b) => a + b))
                .Distinct();

            return result.Count();
        }

        //LOL
        public int UniqueMorseRepresentations3(string[] words)
        {
            Dictionary<char, string> map = new Dictionary<char, string>();
            HashSet<string> result = new HashSet<string>();
            map.Add('a', ".-");
            map.Add('b', "-...");
            map.Add('c', "-.-.");
            map.Add('d', "-..");
            map.Add('e', ".");
            map.Add('f', "..-.");
            map.Add('g', "--.");
            map.Add('h', "....");
            map.Add('i', "..");
            map.Add('j', ".---");
            map.Add('k', "-.-");
            map.Add('l', ".-..");
            map.Add('m', "--");
            map.Add('n', "-.");
            map.Add('o', "---");
            map.Add('p', ".--.");
            map.Add('q', "--.-");
            map.Add('r', ".-.");
            map.Add('s', "...");
            map.Add('t', "-");
            map.Add('u', "..-");
            map.Add('v', "...-");
            map.Add('w', ".--");
            map.Add('x', "-..-");
            map.Add('y', "-.--");
            map.Add('z', "--..");

            for (int i = 0; i < words.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                string word = words[i];
                for (int j = 0; j < word.Length; j++)
                {
                    sb.Append(map[word[j]]);
                }
                result.Add(sb.ToString());
            }

            return result.Count;
        }


        //JS

        /*
         var uniqueMorseRepresentations = function(words) {
            let dir = [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."];
            let m = new Map();
            for(let i = 0 ; i < 26 ; i++){
                m.set( String.fromCharCode(97+i), dir[i])
            }
            return new Array(...new Set(words.map( word => word.split('').map(s => m.get(s)).join('')))).length
        };
         
         
         
         
         
         
         
         */

    }
}
