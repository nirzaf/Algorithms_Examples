using System;
using System.Collections.Generic;
using System.Text;

namespace BST.Traversals
{
    class BinarySearchTree
    {

    }
    public class Bnode
    {
        public int label;

        public Bnode left;
        public Bnode right;

        public Bnode(int data)
        {
            this.label = data;
            left = null;
            right = null;
        }

        public void AddNode(Bnode root)
        {
            if(root == null)
            {
                Console.WriteLine("Can't add null to the tree");
            }
            else if(root.label == label)
            {
                Console.WriteLine("No duplicates!");
            }
            else if (label < root.label)
            {
                //left
                if(root.left != null)
                {
                    AddNode(root.left);
                }
                else
                {
                    Console.WriteLine("Added" + label + "to the left of" + root.label);
                    root.left = this;
                }
            }
            else if (label > root.label)
            {
                //right
                if(root.right != null)
                {
                    AddNode(root.right);
                }
                else
                {
                    Console.WriteLine("Added" + label + "to the right of" + root.label);
                    root.right = this;
                }
            }
        }
    }
}
