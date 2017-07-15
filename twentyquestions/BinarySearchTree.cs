using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twentyquestions
{
    class BinarySearchTree<T> where T : IComparable
    {
        public BSTNode<T> Root;
        public bool IsEmpty => Root == null;

        public BSTNode<T> Add(T value)
        {
            //if there is no head, insert the BSTNode as the root
            if (Root == null)
            {
                Root = new BSTNode<T>(value);
                return Root;
            }

            //if there is a root

            BSTNode<T> current = Root;


            while (current != null)
            {

                //if the new bstNodes value is less than the root's value-> the new bstnode would be on left of root  
                if (current.Value.CompareTo(value) > 0)
                {
                    if (current.leftChild == null)
                    {
                        current.leftChild = new BSTNode<T>(value);
                        current.leftChild.parent = current;
                        return current.leftChild;
                    }

                    current = current.leftChild;

                }
                //if the new bstNodes value is greater than that of the root-> the new bstnode would be on the right of root
                else if (current.Value.CompareTo(value) <= 0)
                {
                    if (current.rightChild == null)
                    {
                        current.rightChild = new BSTNode<T>(value);
                        current.rightChild.parent = current;
                        return current.rightChild;
                    }

                    current = current.rightChild;
                }
            }

            return current;

        }

        public bool Remove(T value)
        {
            if (Root == null)
            {
                return false;
            }

            else if (Root != null)
            {
                BSTNode<T> current = Root;
                BSTNode<T> nodeToRemove = null;

                while (current != null)
                {
                    //if the new bstNodes value is less than the root's value-> the new bstnode would be on left of root  
                    if (current.Value.CompareTo(value) > 0)
                    {
                        if (current.Value.CompareTo(value) == 0)
                        {
                            nodeToRemove = current;
                        }

                        current = current.leftChild;
                    }

                    //if the new bstNodes value is greater than that of the root-> the new bstnode would be on the right of root
                    else if (current.Value.CompareTo(value) <= 0)
                    {
                        if (current.Value.CompareTo(value) == 0)
                        {
                            nodeToRemove = current;
                        }

                        current = current.rightChild;
                    }
                }

                if (nodeToRemove != null)
                {
                    if (nodeToRemove.leftChild == null && nodeToRemove.rightChild == null)
                    {
                        //if the nodeToRemove is a left child then delete the parents connection to the left child
                        if (nodeToRemove.parent.leftChild == nodeToRemove)
                        {
                            nodeToRemove.parent.leftChild = null;
                        }

                        //if the nodeToRemove is a right child then delete the parents connection to the right child 
                        else if (nodeToRemove.parent.rightChild == nodeToRemove)
                        {
                            nodeToRemove.parent.rightChild = null;
                        }

                        nodeToRemove.parent = null;
                    }

                    //if the nodeToRemove only has a rightchild
                    else if (nodeToRemove.leftChild == null)
                    {
                        nodeToRemove.rightChild.parent = nodeToRemove.parent;
                        nodeToRemove.parent.leftChild = nodeToRemove.rightChild;

                    }

                    //if the nodeToRemove only has a leftchild
                    else if (nodeToRemove.rightChild == null)
                    {
                        nodeToRemove.leftChild.parent = nodeToRemove.parent;
                        nodeToRemove.parent.rightChild = nodeToRemove.leftChild;
                    }

                    //if the nodeToRemove has both a leftchild and a rightchild
                    else
                    {
                        bool movedRight = false;

                        current = nodeToRemove.leftChild;

                        while (current.rightChild != null)
                        {
                            current = current.rightChild;
                            movedRight = true;
                        }

                        if (movedRight == true)
                        {
                            current.leftChild = nodeToRemove.leftChild;
                            current.leftChild.parent = current;
                        }

                        //if the node is as leftchild
                        if (nodeToRemove.parent.leftChild == nodeToRemove)
                        {
                            current.parent = nodeToRemove.parent;
                            nodeToRemove.parent.leftChild = current;
                        }

                        //if the node is a rightchild
                        else if (nodeToRemove.parent.rightChild == nodeToRemove)
                        {
                            current.parent = nodeToRemove.parent;
                            nodeToRemove.parent.rightChild = current;
                        }

                        current.rightChild = nodeToRemove.rightChild;
                        current.rightChild.parent = current;



                    }

                    return true;
                }

            }

            return false;
        }

        public BSTNode<T> Search(T value)
        {
            BSTNode<T> current = Root;

            while (current != null)
            {
                //if the new bstNodes value is less than the root's value-> the new bstnode would be on left of root  
                if (current.Value.CompareTo(value) > 0)
                {
                    if (current.Value.CompareTo(value) == 0)
                    {
                        //Console.WriteLine(current.Value);
                        return current;
                    }

                    current = current.leftChild;
                }

                //if the new bstNodes value is greater than that of the root-> the new bstnode would be on the right of root
                else if (current.Value.CompareTo(value) <= 0)
                {
                    if (current.Value.CompareTo(value) == 0)
                    {
                        //Console.WriteLine(current.Value);
                        return current;
                    }

                    current = current.rightChild;
                }
            }

            return null;
        }

        public BSTNode<T> Minimum()
        {
            BSTNode<T> current = Root;

            while (current != null)
            {
                if (current.leftChild == null)
                {
                    Console.WriteLine(current.Value);
                    return current;
                }

                current = current.leftChild;
            }

            return null;
        }

        public BSTNode<T> Maximum()
        {
            BSTNode<T> current = Root;

            while (current != null)
            {
                if (current.rightChild == null)
                {
                    Console.WriteLine(current.Value);
                    return current;
                }

                current = current.rightChild;
            }

            return null;
        }

        public void TraverseInOrder(BSTNode<T> node)
        {
            if (node.leftChild != null)
            {
                TraverseInOrder(node.leftChild);
            }

            Console.WriteLine(node.Value);

            if (node.rightChild != null)
            {
                TraverseInOrder(node.rightChild);
            }

        }

        public void TraversePreOrder(BSTNode<T> node)
        {
            Console.WriteLine(node.Value);

            if (node.leftChild != null)
            {
                TraversePreOrder(node.leftChild);
            }

            if (node.rightChild != null)
            {
                TraversePreOrder(node.rightChild);
            }

        }

        public void TraversePostOrder(BSTNode<T> node)
        {
            if (node.leftChild != null)
            {
                TraversePreOrder(node.leftChild);
            }

            if (node.rightChild != null)
            {
                TraversePreOrder(node.rightChild);
            }

            Console.WriteLine(node.Value);
        }

    }

}
