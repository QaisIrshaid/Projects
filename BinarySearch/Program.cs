using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp5
{
    class program
    {
        

        public static int Sum(int start, int end)
        {
            if (start == end)
                return start;
            else
            {
                int rec = Sum(start, end - 1);
                int result = rec + end;
                return result;
            }

        }


        class node
        {
            public node left { get; set; }
            public node right { get; set; }
            public int value { get; set; }
        }

        class binaryTree
        {

            public node root { get; set; }

            public bool add(int value)
            {
                node before = null, after = this.root;


                while (after != null)
                {
                    before = after;
                    if (value < after.value)
                        after = after.left;
                    else if (value > after.value)
                        after = after.right;
                    else
                        return false;

                }

                node newNode = new node();
                newNode.value = value;
                if (root == null)
                    root = newNode;
                else
                {
                    if (newNode.value < before.value)
                        before.left = newNode;
                    else
                        before.right = newNode;
                }

                return true;

            }

           

            public bool find(int value)
            {
                if (this.root == null)
                    return false;
                else
                {
                    node search = this.root;
                    while (search != null)
                    {
                        if (value > search.value)
                        { search = search.right; }
                        else if (value < search.value)
                        { search = search.left; }
                        else
                            return true;

                    }
                    return false;


                }

            }

            public void PreOrder(node parent)
            {
                if (parent != null)
                {
                    Console.Write(parent.value + " ");
                    PreOrder(parent.left);
                    PreOrder(parent.right);
                }
            }
        }
    }
}

    
    

    






                


    

