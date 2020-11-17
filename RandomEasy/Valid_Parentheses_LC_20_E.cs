using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.RandomEasy
{
    public class Valid_Parentheses_LC_20_E
    {
        /// <summary>
        /// iterate over the string
        /// we either push each the opening paren. into stack
        /// or check if it closing one and the one of top of the stack is opposite 
        /// if it is continue 
        /// otherwise return false
        /// </summary>

        public static bool IsValid(string s)
        {

            if (s.Length % 2 != 0) return false;
            var stack = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '{' || c == '(' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ']' && stack.Count > 0 && stack.Peek() == '[')
                {
                    stack.Pop();
                }
                else if (c == '}' && stack.Count > 0 && stack.Peek() == '{')
                {
                    stack.Pop();
                }
                else if (c == ')' && stack.Count > 0 && stack.Peek() == '(')
                {
                    stack.Pop();
                }
                else // "( [ } } ])" first closing is not on the top of the stack
                {
                    return false;
                }
            }

            return !(stack.Count > 0);
        }

        // stack with dictionary
        public bool IsValid2(string s)
        {
            if (s == null || s == string.Empty)
                return true;

            Dictionary<char, char> dict = new Dictionary<char, char>();
            Stack<char> stack = new Stack<char>();

            dict.Add(')', '(');
            dict.Add('}', '{');
            dict.Add(']', '[');

            foreach (var c in s)
                if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count > 0 && stack.Peek() == dict[c])
                        stack.Pop();
                    else
                        return false;
                }
                else
                    stack.Push(c);

            return stack.Count == 0;
        }
    }
}
