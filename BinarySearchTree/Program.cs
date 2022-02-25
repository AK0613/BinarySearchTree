using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree? bt = new();

            bt.Add(30);
            bt.Add(35);
            bt.Add(57);
            bt.Add(15);
            bt.Add(63);
            bt.Add(49);
            bt.Add(89);
            bt.Add(77);
            bt.Add(67);
            bt.Add(98);
            bt.Add(91);

            bt.PrintInOrder(bt.Root);
            Console.WriteLine();
            bt.PreOrder(bt.Root);
            Console.WriteLine();
            bt.PostOrder(bt.Root);
            Console.WriteLine();


        }

        class Node
        {
            public Node? LeftNode { get; set; }
            public Node? RightNode { get; set; }
            public int Data { get; set; } 

            public void PrintNode() => Console.Write(Data + " ");

        }

        class BinaryTree
        {
            public Node? Root;

            public BinaryTree()
            {
                Root = null;
            }
            
            public bool Add(int value)
            {
                //Current will be the iterator that starts at the root
                Node current = Root;
                //newNode is the node to be inserted once its place has been found
                Node newNode = new();
                newNode.Data = value;
                
                //if tree is empty
                if(Root == null)
                {
                    Root = newNode;
                    return true;
                }

                else
                {
                    Node parent;

                    while(true)
                    {
                        parent = current;
                        //If the data in the current node is greater than the value provided, add the value provided to the left child node
                        if(current.Data > value)
                        {
                            //Move one node to the left to check it again
                            current = current.LeftNode;
                            //If that node is empty
                            if(current == null)
                            {
                                //Add a value to it. Using parent variable since current moved one node to the left
                                parent.LeftNode = newNode;
                                return true;
                            }
                        }

                        //If the value is bigger than the current node. Move to the right until it's empty 
                        else if (current.Data < value)
                        {
                            current = current.RightNode;

                            if(current == null)
                            {
                                parent.RightNode = newNode;
                                return true;
                            }
                        }

                        //Else no repeated values
                        else
                            return false;

                    }
                }
            }

            //Print in order
            public void PrintInOrder(Node Root)
            {
                if(Root != null)
                {
                    PrintInOrder(Root.LeftNode);
                    Console.Write(Root.Data + " ");
                    PrintInOrder(Root.RightNode);
                }
            }

            public void PostOrder(Node Root)
            {
                if(Root!=null)
                {
                    PostOrder(Root.LeftNode);
                    PostOrder(Root.RightNode);
                    Console.Write(Root.Data + " ");
                }
            }

            public void PreOrder(Node Root)
            {
                if (Root != null)
                {
                    Console.Write(Root.Data + " ");
                    PreOrder(Root.LeftNode);
                    PreOrder(Root.RightNode);
                }
            }

        }

    }
}
