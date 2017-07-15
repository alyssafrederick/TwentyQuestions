using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twentyquestions
{
    class BSTNode<T> where T : IComparable
    {
        public T Value;
        public BSTNode<T> parent;
        public BSTNode<T> leftChild;
        public BSTNode<T> rightChild;

        public BSTNode(T value)
        {
            Value = value;
        }
    }
}
