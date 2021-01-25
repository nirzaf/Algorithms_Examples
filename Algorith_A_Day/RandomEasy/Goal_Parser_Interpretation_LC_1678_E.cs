using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.RandomEasy
{
    public class Goal_Parser_Interpretation_LC_1678_E
    {
        public string Interpret(string command)
        {
            if (command == null || command.Length == 0) return "";

            string result = "";
            int current = 0;
            while (current <= command.Length - 1)
            {
                if (command.Substring(current, 1) == "G")
                {
                    result += "G";
                    current += 1;
                }
                else if (command.Substring(current, 2) == "()")
                {
                    result += "o";
                    current += 2;
                }
                else
                {
                    result += "al";
                    current += 4;
                }
            }

            return result;
        }

        // linq 
        public string Interpret2(string command) => command.Replace("(al)", "al").Replace("()", "o");

        // just nice 
        public string Interpret3(string command)
        {
            string result = String.Empty;
            string currentString = String.Empty;
            foreach (char c in command)
            {
                currentString = currentString + c.ToString();
                if (IsG(currentString))
                {
                    result = result + currentString;
                    currentString = String.Empty;
                }
                else if (IsO(currentString))
                {
                    result = result + "o";
                    currentString = String.Empty;
                }
                else if (IsAL(currentString))
                {
                    result = result + "al";
                    currentString = String.Empty;
                }
            }
            return result;
        }
        private bool IsG(string value)
        {
            return (value == "G");
        }

        private bool IsO(string value)
        {
            return (value == "()");
        }

        private bool IsAL(string value)
        {
            return (value == "(al)");
        }
    }
}
