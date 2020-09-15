using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.NodesModels
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x = 0, ListNode next = null)
        {
            val = x;
            next = null;
        }
    }
}
