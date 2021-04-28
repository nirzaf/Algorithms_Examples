using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Merge_Alternately_LC_1768_E
    {
        public string MergeAlternately(string word1, string word2)
        {
            if (word1 == null || word2 == null) return "";
            if (word1.Length == 0) return word2;
            if (word2.Length == 0) return word1;

            string result = "";
            int wl1 = word1.Length;
            int wl2 = word2.Length;

            for (int i = 0; i < wl1; i++)
            {
                result += (word1[i].ToString() + word2[i].ToString());
                if (wl1 != wl2)
                {
                    if (i + 1 == wl1)
                    {
                        result += (word2.Substring(i + 1).ToString());
                        break;
                    }
                    else if (i + 1 == wl2)
                    {
                        result += (word1.Substring(i + 1).ToString());
                        break;
                    }
                }

            }

            return result;
        }

        /*
         public string MergeAlternately(string word1, string word2) {
        string final = "";
        int w1 = word1.Length;
        int w2 = word2.Length;
        for(int i = 0; i< w1 ; i++){
            final = final + word1[i];
            if(w2>i) final = final + word2[i];
        }
            if(w2>w1) final = final + word2.Substring(w1);
            return final;
        }
         JS

        var mergeAlternately = function(word1, word2) {
            let result = '';
            let minSize = Math.min(word1.length, word2.length);
    
            for(let i=0; i<minSize; i++) {
                result += word1[i];
                result += word2[i];
            }
    
            if(word1.length > word2.length)
                    result += word1.substr(word2.length);
            if(word1.length < word2.length)
                result += word2.substr(word1.length);
    
            return result;
        };
         
         var mergeAlternately = function(word1, word2) {

                return (word1.length===0)? word2: word1[0]+ mergeAlternately(word2,word1.slice(1))

        var mergeAlternately = function(word1, word2) {
        let stringArray=[];
        let longLength= word1.length>word2.length?word1.length:word2.length;
        for(let index=0;index<longLength;index++){
        stringArray.push(word1[index]);
        stringArray.push(word2[index]);
        }
        return stringArray.join('');

        };
        }; 
         */
    }
}
