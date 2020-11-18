using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.RandomEasy
{
    class Defanging_an_IP_Address_1108_E
    {
        // extra space
        public string DefangIPaddr(string address)
        {
            string result = "";
            if (address.Length == 0 || address == null) return result;

            for (int i = 0; i < address.Length; i++)
            {
                if (address[i] == '.')
                {
                    result += "[.]";
                }
                else
                {
                    result += address[i];
                }
            }

            return result;
        }

        public static string DefangIPaddr2(string address)
        {
            if (address.Length == 0 || address == null) return "";

            for (int i = 0; i < address.Length; i++)
            {
                if (i -1 >= 0 && address[i] == '.')
                {
                    address = address.Substring(0, i) + "[.]" + address.Substring(i + 1);
                    i += 2;
                }
               
            }

            return address;
        }

        public string DefangIPaddr3(string address)
        {
            //O(n) 
            return address.Replace(".", @"[.]");

        }

        /// <summary>
        /// return new array of numbers separated by . 
        /// join with new sign
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string DefangIPaddr4(string address)
        {
            var x = address.Split(".");
            return string.Join("[.]", x);
        }


    }
}
