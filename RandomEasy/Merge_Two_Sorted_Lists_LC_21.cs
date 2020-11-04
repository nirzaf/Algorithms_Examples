using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.RandomEasy
{
    public class Merge_Two_Sorted_Lists_LC_21
    {

        /// <summary>
        /// linked-list
        /// current.next = l1/l2  changes the result but current = current.l1/l2 doesn't
        /// reference more todo 
        /// </summary>

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l2 == null && l1 == null) return null;

            ListNode result = new ListNode(0);
            ListNode current = result;

            while (l1 != null && l2 != null)
            {
                
                if (l1.val < l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }

                current = current.next;
            }

            // l1 is lognger than l2 
            if(l1 != null)
            {
                current.next = l1;
                l1 = l1.next;
            }

            // l2 is lognger than l1 
            if (l2 != null)
            {
                current.next = l2;
                l2 = l2.next;
            }

            return result.next;
        }
    }
}
