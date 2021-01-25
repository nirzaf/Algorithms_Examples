using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST.FromCompanies
{
    class Codility
    {
        public static int Frogs(int[] blocks)
        {
            int numbersOfBlock = blocks.Length;
            if (numbersOfBlock <= 0) return 0;

            int initialBlockIndex = 0;
            int frog1Index;
            int frog2Index;
            int maxDistance = 0;

            while (initialBlockIndex < numbersOfBlock)
            {
                frog1Index = initialBlockIndex;
                frog2Index = initialBlockIndex;
                //frogs sit on any of middle blocks
                if (initialBlockIndex != 0 && initialBlockIndex != numbersOfBlock - 1)
                {
                    //frog2 goes left if possible
                    for (int i = frog2Index; i > 0; i--)
                    {
                        if (blocks[i] <= blocks[i - 1])
                        {
                            frog2Index = i - 1;
                        }
                        else break;
                    }

                    //frog1 goes right if possible
                    for (int i = frog1Index; i < blocks.Length - 1; i++)
                    {
                        if (blocks[i] <= blocks[i + 1])
                        {
                            frog1Index = i + 1;
                        }
                        else break;
                    }

                }//frogs sit at the last block
                else if (initialBlockIndex == numbersOfBlock - 1)
                {
                    frog1Index = numbersOfBlock - 1;
                    for (int i = frog1Index; i > 0; i--)
                    {
                        if (blocks[i] <= blocks[i - 1])
                        {
                            frog2Index = i - 1;
                        }
                        else break;
                    }
                }//sit on first block
                else
                {
                    frog2Index = 0;
                    for (int i = 1; i < blocks.Length; i++)
                    {
                        if (blocks[i] >= blocks[i - 1])
                        {
                            frog1Index = i;
                        }
                        else break;
                    }
                }

                //always move frog1 right if possible so f1-f2
                int difference = frog1Index - frog2Index;
                maxDistance = Math.Max(difference, maxDistance);
                initialBlockIndex++;
            }

            return maxDistance + 1;
        }

        public static int FindRome(int[] roads1, int[] roads2)
        {
            var connections = new Dictionary<int, List<int>>();
            if (roads1.Length != roads2.Length) return -1;
            else
            {//create dict with values from r2 as a keys and roads1 values as a dict values no duplicates
                for (int i = 0; i < roads1.Length; i++)
                {
                    if (!connections.ContainsKey(roads2[i]))
                    {
                        connections.Add(roads2[i], new List<int>());
                        connections[roads2[i]].Add(roads1[i]);
                    }
                    else
                    {
                        connections[roads2[i]].Add(roads1[i]);
                    }
                }
            }

            var rome = -1;

            if (connections.Count == 1) return connections.ElementAt(0).Key;
            int counter = connections.Count;
            int maxNumbersOfRoads = connections.First().Value.Count;

            while (counter > 0)
            {
                var listOfRoads = connections.ElementAt(counter - 1).Value;
                foreach (var item in connections)
                {
                    if (listOfRoads.Contains(item.Key) &&
                        item.Value.Count >= maxNumbersOfRoads)
                    {
                        rome = connections.ElementAt(counter - 1).Key;
                        maxNumbersOfRoads = listOfRoads.Count;
                    }
                }
                counter--;
            }

            return rome;
        }

        public static string CreateCustomPalindrome(int len, int numberOfLetters)
        {
            if (numberOfLetters >= len && len > 2 ||
                len - numberOfLetters == 1 && len > 3 ||
                len - numberOfLetters == 2 && len > 5
                ) return string.Empty;
            string alphabet = string.Empty;
            for (char i = 'a'; i <= 'z'; i++)
            {
                alphabet += i;
            }

            string firstHalf = string.Empty;
            var halfLen = len / 2;
            var distnict = numberOfLetters;
            //==========create half of the palindorme
            //distinct letters
            while (distnict > 0)
            {
                firstHalf += alphabet.Substring(0, 1);
                alphabet = alphabet.Substring(1);
                distnict--;
            }
            //concat more of the last to the half of len
            while (firstHalf.Length < halfLen)
            {

                firstHalf += firstHalf[firstHalf.Length - 1];

            }
            //len 3 is special case
            if (len == 3 && numberOfLetters == 2) return firstHalf += firstHalf[0];
            //len is odd
            if (len % 2 != 0)
            {
                firstHalf += firstHalf[firstHalf.Length - 1];
            }
            //=====end of create



            //concat second half if len 
            if (firstHalf.Length % 2 != 0 && len > 3)
            {
                for (int i = firstHalf.Length - 2; i >= 0; i--)
                {
                    firstHalf += firstHalf[i];
                }
            }
            else
            //concat second half if len is even
            {
                for (int i = firstHalf.Length - 1; i >= 0; i--)
                {
                    firstHalf += firstHalf[i];
                }
            }


            return firstHalf;
        }

    }
}
