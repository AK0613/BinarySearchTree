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
            public Node LeftNode { get; set; }
            public Node RightNode { get; set; }
            public int Data { get; set; } 

        }

        class BinaryTree
        {
            public Node Root { get; set; }
            
            public bool Add(int value)
            {
                Node before = null, after = this.Root;
                while(after != null)
                {
                    before = after;

                    if (value < after.Data)
                        after = after.LeftNode;
                    else if (value > after.Data)
                        after = after.RightNode;
                    else
                        return false;

                    Node newNode = new Node(); 
                    newNode.Data = value; 
                    if(this.Root = null)
                        this.Root = newNode;

                }
            }
        }

    }
}
