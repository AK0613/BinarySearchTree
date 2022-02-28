using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree? bt = new();
            int x;

            //Driver code: Create tree
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

            //Do stuff to the tree and print it
            bt.PrintInOrder(bt.root);
            Console.WriteLine();
            bt.PreOrder(bt.root);
            Console.WriteLine();
            bt.PostOrder(bt.root);
            Console.WriteLine();
            bt.FindMax(bt.root);
            bt.FindMin(bt.root);
            Console.WriteLine("The height of the tree is: " + bt.GetHeight(bt.root));
            x = 57;
            Console.WriteLine("Deleting node: " + x);
            bt.DeleteNode(bt.root, x);
            bt.PrintInOrder(bt.root);
            Console.WriteLine("The height of the tree is: " + bt.GetHeight(bt.root));

        }

        class Node
        {
            public Node? Left { get; set; }
            public Node? Right { get; set; }
            public int Data { get; set; } 

            public void PrintNode() => Console.Write(Data + " ");

        }

        class BinaryTree
        {
            public Node? root;

            public BinaryTree()
            {
                root = null;
            }
            
            public void Add(int value)
            {
                //Current will be the iterator that starts at the root
                Node? current = root;
                //newNode is the node to be inserted once its place has been found
                Node? newNode = new();
                newNode.Data = value;
                
                //if tree is empty
                if(root == null)
                {
                    root = newNode;
                    return true;
                }

                else
                {
                    Node? parent;

                    while(true)
                    {
                        parent = current;
                        //If the data in the current node is greater than the value provided, add the value provided to the left child node
                        if(current.Data > value)
                        {
                            //Move one node to the left to check it again
                            current = current.Left;
                            //If that node is empty
                            if(current == null)
                            {
                                //Add a value to it. Using parent variable since current moved one node to the left
                                parent.Left = newNode;
                                return true;
                            }
                        }

                        //If the value is bigger than the current node. Move to the right until it's empty 
                        else if (current.Data < value)
                        {
                            current = current.Right;

                            if(current == null)
                            {
                                parent.Right = newNode;
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
            public void PrintInOrder(Node root)
            {
                if(root != null)
                {
                    PrintInOrder(root.Left);
                    Console.Write(root.Data + " ");
                    PrintInOrder(root.Right);
                }
            }

            public void PostOrder(Node root)
            {
                if(root!=null)
                {
                    PostOrder(root.Left);
                    PostOrder(root.Right);
                    Console.Write(root.Data + " ");
                }
            }

            public void PreOrder(Node root)
            {
                if (root != null)
                {
                    Console.Write(root.Data + " ");
                    PreOrder(root.Left);
                    PreOrder(root.Right);
                }
            }

            public int FindMin (Node root)
            {
                Node current = root;

                while (root != null)
                {
                    current = root;
                    root = root.Left;
                }
                Console.WriteLine("The minumum value is: " + current.Data);
                return current.Data;
            }

            public int FindMax(Node root)
            {
                Node current = root;

                while(root != null)
                {
                    current = root;
                    root = root.Right;
                }
                Console.WriteLine("The maximum value is: " + current.Data);
                return current.Data;
            }

            public Node DeleteNode(Node? root, int key)
            {
                //If the given node is null return
                if (root == null)
                {
                    Console.WriteLine("The tree is empty.");
                    return root;
                }
                if (root.Data > key)
                {
                    root.Left = DeleteNode(root.Left, key);
                    return root;
                }
                else if (root.Data < key)
                {
                    root.Right = DeleteNode(root.Right, key);
                    return root;
                }

                //Reach here when the root is the node to be deleted
                //If one of the children are empty
                if(root.Left == null)
                {
                    Node? temp = root.Right;
                    return temp;
                }

                else if (root.Right == null)
                {
                    Node? temp = root.Left;
                    return temp;
                }

                //Else if both children exist
                else
                {
                    Node? succParent = root;

                    //Find successor
                    Node? succ = root.Right;

                    while (succ.Left != null)
                    {
                        succParent = succ;
                        succ = succ.Left;
                    }

                    // Delete successor. Since successor
                    // is always left child of its parent
                    // we can safely make successor's right
                    // right child as left of its parent.
                    // If there is no succ, then assign
                    // succ->right to succParent->right

                    if (succParent != root)
                        succParent.Left = succ.Right;
                    else
                        succParent.Right = succ.Right;

                    //Copy successor Data to root
                    root.Data = succ.Data;

                    return root;
                }
            }
            public int GetHeight(Node root)
            {
                if (root == null)
                    return -1;
                else
                    return 1 + Math.Max(GetHeight(root.Left), GetHeight(root.Right));
            }
        }
    }
}
