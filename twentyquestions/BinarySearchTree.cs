using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twentyquestions
{
    class BinarySearchTree<T> where T : IComparable<T>
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
                else
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

        public List<T> ToList()
        {
            List<T> list = new List<T>();
            ToListHelper(list, Root);
            return list;
        }

        public void ToListHelper(List<T> list, BSTNode<T> node)
        {
            if (node.leftChild != null)
            {
                ToListHelper(list, node.leftChild);
            }
            list.Add(node.Value);

            if (node.rightChild != null)
            {
                ToListHelper(list, node.rightChild);
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

        public List<T> ToListPreO()
        {
            List<T> list = new List<T>();
            ToListPreOrder(list, Root);
            return list;
        }
        public void ToListPreOrder(List<T> list, BSTNode<T> node)
        {
            list.Add(node.Value);

            if (node.leftChild != null)
            {
                ToListPreOrder(list, node.leftChild);
            }

            if (node.rightChild != null)
            {
                ToListPreOrder(list, node.rightChild);
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
