using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.BitManipulation
{

    // todo: bit manipulation to understand, looks quite easy
    public class Binary_Watch_401
    {
        public IList<string> ReadBinaryWatch(int num)
        {
            List<string> result = new List<string>();

            for (int hour = 0; hour < 12; hour++)
            {
                for (int minute = 0; minute < 60; minute++)
                {
                    if (countBits(hour) + countBits(minute) == num)
                    {
                        result.Add($"{hour}:{minute:D2}");
                    }
                }
            }

            return result;
        }


        private int countBits(int num)
        {
            int count = 0;
            for (int i = 0; i < 32; i++)
            {
                if ((num & (1 << i)) != 0)
                {
                    count++;
                }
            }

            return count;
        }

        // todo: backtracking solution
         public IList<string> ReadBinaryWatch2(int num) {
        List<string> Result = new List<string> ();
        if (num == 0) {
            Result.Add ("0:00");
            return Result;
        }
        HashSet<string> BinaryNumbers = new HashSet<string> (new string[] { "01", "02", "04", "08", "16", "32", "1", "2", "4", "8" });
        HashSet<string> Chosen = new HashSet<string> ();
        ReadBinaryWatchHelper (BinaryNumbers, Chosen, Result, num);
        return Result;

    }

    private void ReadBinaryWatchHelper (HashSet<string> RemainingNumbers, HashSet<string> Chosen, List<string> Result, int num) {

        if (Chosen.Count == num) {
            string time = GetFormattedTime (Chosen);
            AddToResult (ref Result, time);
        } else if (RemainingNumbers.Count == 0) {
            return;
        } else {
            HashSet<string> nextChosen1 = new HashSet<string> (Chosen);
            HashSet<string> nextChosen2 = new HashSet<string> (Chosen);
            HashSet<string> nextRemaining = new HashSet<string> (RemainingNumbers);
            string candidate = RemainingNumbers.First ();
            // remove candidate from given binary numbers so that each recursive call makes progress towards solution
            nextRemaining.Remove (candidate);
            // add candidate to chosen list & recurse
            nextChosen1.Add (candidate);
            ReadBinaryWatchHelper (nextRemaining, nextChosen1, Result, num);
            // don't add candidate to chosen list & recurse
            ReadBinaryWatchHelper (nextRemaining, nextChosen2, Result, num);
        }

    }
    private void AddToResult (ref List<string> result, string t) {
        if (!string.IsNullOrEmpty (t)) {
            result.Add (t);
        }
    }
    private string GetFormattedTime (HashSet<string> chosen) {
        int min = 0;
        int hours = 0;
        foreach (string s in chosen) {
            if (s.StartsWith ("0") || s == "16" || s == "32") {
                min = min + int.Parse (s);
            } else {
                hours = hours + int.Parse (s);
            }
            if (min > 59 || hours > 11) {
                return string.Empty;
            }
        }
        return $"{hours}:{min.ToString().PadLeft(2,'0')}";
    }
    }
}
