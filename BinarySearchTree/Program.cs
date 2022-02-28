using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        class Node
        {
            public Node leftNode { get; set; }
            public Node rightNode { get; set; }
            public int Data { get; set; }   

        }

        class BinaryTree
        {
            public Node? root { get; set; }
            
            public void Add(int value)
            {
                Node? before = null, after = this.root;

                while(after != null)
                {

                }
            }
            
        }

    }
}
