using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_A_Day.Patterns.K_way_Merge
{
    /// <summary>
    /// //TODO: More work is need with this one
    /// We need to keep track of the heads of all lists at all times and be able to do the following operations efficiently:
    ///1- Get/Remove Min
    ///2- Add(once you remove the head of one list, you need to add the next from that list)

    ///A min heap(or a priority queue) is obviously the data structure we need here, where the key of the dictionary is the value of the ListNode, and the value of the dictionary is a queue of ListNodes having that value. (we need to queue the ones with the same value since Dictionary cannot have dupes)
    ///I implemented mine using a SortedDictionary of queues.
    ///SortedDictionary is internally implemented using a binary tree, and provides O(logn) for Add() and O(1) for PopMin(), so it's as efficient as it gets.
    /// </summary>
    public class Merge_k_Sorted_Lists
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            MinHeap heap = new MinHeap();
            foreach (var node in lists)
            {
                if (node == null)
                    continue;

                heap.Add(node.val, node);
            }
            ListNode curr = null, newHead = null;
            while (heap.map.Count > 0)
            {
                ListNode node = heap.PopMin();

                if (node.next != null)
                {
                    heap.Add(node.next.val, node.next);
                }

                if (curr == null)
                {
                    curr = node;
                    newHead = curr;
                }
                else
                {
                    curr.next = node;
                    curr = curr.next;
                }
            }
            return newHead;
        }
    }
    public class MinHeap
    {
        public SortedDictionary<int, Queue<ListNode>> map =
            new SortedDictionary<int, Queue<ListNode>>();

        public void Add(int val, ListNode node)
        {
            if (!map.ContainsKey(val))
            {
                map.Add(val, new Queue<ListNode>());
            }

            map[val].Enqueue(node);
        }

        public ListNode PopMin()
        {
            int minKey = map.First().Key;
            ListNode node = map[minKey].Dequeue();

            if (map[minKey].Count == 0)
                map.Remove(minKey);

            return node;
        }
    }
    //TODO: Merge sort solution

}
