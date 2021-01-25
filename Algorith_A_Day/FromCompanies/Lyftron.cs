using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.FromCompanies
{
    public class Lyftron
    {
        
        /// <summary>
        /// Napisz funkcję zwracającą trzeci najmniejszy element tablicy.
        /// Przykłady wywołania:
        /// Najwiekszy(int[] { 3, 2, 1, 5, 6, 7 })   -> zwraca 3
        /// Najwiekszy(int[] { 1,6, 1, 5, 4, 9 })   -> zwraca 4
        /// </summary>
        public int Najwiekszy(int[] tablica)
        {
            if (tablica.Length == 0 || tablica == null) return 0;
            if (tablica.Length < 3) return -1; // or return tablica[tablica.Length - 1] - not specified

            Array.Sort(tablica);
            
            return tablica[2];

            // time complexity : O(n log n), if tablica.Lenght < 16 Insertion sort otherwise QuickSort(or Heapsort)
            // space complexity : O(1)
        }


        //heap is needed here not dictionary
        //public int Najwiekszy2(int[] tablica)
        //{
        //    if (tablica.Length == 0 || tablica == null) return 0;
        //    if (tablica.Length < 3) return -1;

        //    int limit = 3; // from description
        //    int arr_len = tablica.Length;
        //    var sorted_list = new SortedList<int, int>();
        //    sorted_list.Add(tablica[0], 0);

        //    for (int i = 1; i < arr_len; i++)
        //    {
        //        // in case of duplicates
        //        if (sorted_list.Last().Key != tablica[i])
        //        {
        //            sorted_list.Add(tablica[i], i);
        //        }

        //        //remove anything bigger than first 3 smallest
        //        if(sorted_list.Count > limit)
        //        {
        //            sorted_list.RemoveAt(limit);
        //        }
        //    }

        //    return sorted_list.Last().Key;
        //    // time complexity : O(n)
        //    // space complexity : O(1), fixed size = 3 -4
        //}

        /// <summary>
        /// Znajdź wartość, która występuje największą liczbę razy w kolekcji:
        /// Najczestrza(int[] { 1, 2, 3, 4, 5 })      -> zwraca 1, bo wszystkie liczby występują tyle samo razy
        /// Najczestrza(int[] { 3, 6, 3, 5, 4, 9 })   -> zwraca 3, bo jako jedyna liczba występuje dwukrotnie
        /// Najczestrza(int[] { 3, 6, 3, 6, 6, 9 })   -> zwraca 6, bo jako jedyna liczba występuje trzykrotnie
        /// </summary>

        public int Najczestrza(IEnumerable<int> liczby)
        {
            if (liczby.ToArray().Length == 0 || liczby == null) return 0;

            var dict = new Dictionary<int, int>();

            foreach(int number in liczby)
            {
                if (!dict.ContainsKey(number))
                {
                    dict.Add(number, 1);
                }
                else
                {
                    dict[number]++;
                }
            }

            int frequency = 1;
            var result = 1; 
            // get key of most frequent element
            foreach (KeyValuePair<int, int> kv in dict)
            {
                if(frequency < kv.Value)
                {
                    frequency = kv.Value;
                    result = kv.Key;
                }
            }
            return frequency == 1 ? frequency : result;

            // time complexity : O(n)
            // space complexity : O(n)

        }

        /// <summary>
        /// Napisz funkcję, która policzy ile elementów tablicy tab1 znajduje się w tablicy tab2:
        /// IleJestWDrugiejTablicy(string[] { "abc", "def", "ghi"}, string[] { "aaaa", "def", "ddd"})   -> zwraca 1, bo tylko "def" występuje
        /// IleJestWDrugiejTablicy(string[] { "abc", "def", "def"}, string[] { "aaaa", "def", "ddd"})   -> zwraca 2, bo tylko "def" występuje,
        /// ale "def" było dwa razy w tablicy pierwszej
        /// IleJestWDrugiejTablicy(string[] { "abc", "def", "ghi"}, string[]
        /// { "abc", "abc", "def", "def", "ghi"})   -> zwraca 2, bo bo znaleziono "def" i "ghi", co z "abc" w tym przykladzie ?
        /// </summary>
        public int IleJestWDrugiejTablicy(string[] tab1, string[] tab2)
        {
            if (tab1 == null || tab1.Length == 0 || tab2 == null || tab2.Length == 0) return 0;

            int result = 0;

            // remove duplicate from tab2, as only tab1 duplicates count double
            var set2 = new HashSet<string>(tab2);

            foreach (string item in tab1)
            {
                foreach (string item2 in set2)
                {
                    if (item == item2) result++;
                }
            }

            return result;

            // time complexity : O(n^2)
            // space complexity : O(n)
        }  
    }

    /// <summary>
    /// Napisz funkcję GetHashCode w klasie Punkt:
    /// </summary>
    public class Punkt
    {
        private int? _x;
        private int? _y;

    public override bool Equals(Object obj)
    {
        if(obj is Punkt)
        {
            Punkt p = (Punkt)obj;
            return _x == p._x && _y == p._y;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return Hash.Base
        .HashObject(_x)
        .HashObject(_y);
    }
    }
    public static class Hash
    {
        public const int Base = 17;

        public static int HashObject(this int hash, object obj)
        {
            unchecked { return hash * 23 + (obj == null ? 0 : obj.GetHashCode()); }
        }

        public static int HashValue<T>(this int hash, T value)
            where T : struct
        {
            unchecked { return hash * 23 + value.GetHashCode(); }
        }
    }
}
