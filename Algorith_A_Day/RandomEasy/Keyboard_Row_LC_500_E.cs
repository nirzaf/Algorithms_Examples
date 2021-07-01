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

        public string[] FindWords2(string[] words)
        {
            var result = new List<string>();

            if (words.Length == 0) return result.ToArray();

            var keyboard = new HashSet<char>[3];
            keyboard[0] = new HashSet<char>() { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
            keyboard[1] = new HashSet<char>() { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
            keyboard[2] = new HashSet<char>() { 'z', 'x', 'c', 'v', 'b', 'n', 'm' };



            foreach (var word in words)
            {
                if (word == "") continue;
                var curRow = -1;

                foreach (var c in word)
                {
                    if (curRow == -1)
                    {
                        for (int i = 0; i < keyboard.Length; i++)
                        {
                            if (keyboard[i].Contains(char.ToLower(c)))
                            {
                                if (curRow == -1) curRow = i;
                            }
                        }
                    }
                    else
                    {
                        if (!keyboard[curRow].Contains(char.ToLower(c)))
                        {
                            curRow = -1;
                            break;
                        }
                    }
                }

                if (curRow != -1)
                {
                    result.Add(word);
                }
            }

            return result.ToArray();
        }


        /*
         
         var findWords = function(words) {
            return words.filter(word =>{
            let presentInTopRow = word.split('').every(c=>"qwertyuiop".indexOf(c.toLowerCase())>-1);
            let presentInTMidRow = word.split('').every(c=>"asdfghjkl".indexOf(c.toLowerCase())>-1);
            let presentInTBottomRow = word.split('').every(c=>"zxcvbnm".indexOf(c.toLowerCase())>-1);
        return presentInTopRow||presentInTMidRow||presentInTBottomRow;
    });
};
         
         var findWords2 = function(words) {
    var keyMap = [
        {
            q: 'q', w: 'w', e: 'e', r: 'r', t: 't', y: 'y',
            u: 'u', i: 'i', o: 'o', p: 'p'
        
        },
        {
            a: 'a', s: 's', d: 'd', f: 'f', g: 'g', h: 'h',
            j: 'j', k: 'k', l:'l'
        },
        {
            z: 'z', x: 'x', c: 'c', v: 'v', b: 'b', n: 'n', m: 'm'
        }
    ];
    
    var row = '';
    var output = [];
    
    for (var i = 0; i < words.length; i++) {
        for (var j = 0; j < words[i].length; j++) {
            var char = words[i][j].toLowerCase();
            
            if (keyMap[0][char]) {
                row += '0';
            }
            if (keyMap[1][char]) {
                row += '1';
            }
                
            if (keyMap[2][char]) {
                row += '2';
            }
        }
        
        if (checkRow(row.split(''))) {
            output.push(words[i]);
        }
        row = '';
    }
    
    return output;
};

const checkRow = arr => arr.every( v => v === arr[0] );
         
         
         */
    }
}
