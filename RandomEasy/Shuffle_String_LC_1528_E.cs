using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Shuffle_String_LC_1528_E
    {
        public string RestoreString(string s, int[] indices)
        {
            if (s == null || s.Length == 0) return string.Empty;
            if (indices == null || indices.Length == 0) return s;
            if (s.Length != indices.Length) return "";

            char[] result = new char[indices.Length];

            for (int i = 0; i < indices.Length; i++)
            {
                result[indices[i]] = s[i];
            }

            //return new string(result);
            return string.Join("", result);
        }

        //LINQ
        public string RestoreString2(string s, int[] indices)
        {
            return String.Join("", s.ToArray().Select((x, idx) => new { Value = x, Index = idx }).OrderBy(x => indices[x.Index]).Select(x => x.Value).ToArray());
        }

        public string RestoreString3(string s, int[] indices)
        {
            //SortesDictionary<int,char>();
            //dict.Add(indices[i],s[i]);.
            //Take a sorted dictionary.
            //return new string(dict.Values.ToArray());
            SortedDictionary<int, char> dict = new SortedDictionary<int, char>();
            for (int i = 0; i < indices.Length; i++)
            {
                dict.Add(indices[i], s[i]);
            }
            return new string(dict.Values.ToArray());
        }

        //JS
        //var restoreString = function(s, indices) {
        //if (s == null || s.length == 0) return "";
        //if (indices == null || indices.length == 0) return s;
        //if(s.length != indices.length) return "";

        //result = [];

        //for(let i = 0; i<indices.length; i++)
        //{
        //    result[indices[i]] = s[i];
        //}

        //return result.join("");
        //};
    //    var restoreString = function(s, indices) {
    //        return [...s].map((a, i)=>{
    //        return { a, i: indices[i]};
    //    }).sort((a, b)=>a.i-b.i).map(({ a})=>a).join('');
    //};

    //const restoreString = (s, indices) => s.split('').map((c, i) => [c, indices[i]]).sort((a, b) => a[1] - b[1]).map(x => x[0]).join('');
}
}
