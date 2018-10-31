using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Implementations.BinarySearchTree
{
	class RankedBinarySearchTree<T> : BinarySearchTree<T> where T : IComparable 
	{
		private class SizedBinaryNode : BinaryNode<T>
		{
			public int Size;

			public SizedBinaryNode(T element) : base(element)
			{
				Size = 0;
			}
		}

		public RankedBinarySearchTree(BinaryNode<T> root) : base(root)
		{
		}

		public T FindKth(int k) => FindKth(k, Root).Element;

		protected BinaryNode<T> FindKth(int k, BinaryNode<T> root)
		{
			if (root == null)
				throw new KeyNotFoundException();
			int leftSize = (root.Left != null) ? ((SizedBinaryNode)root.Left).Size : 0;

			if (k <= leftSize)
				return FindKth(k, root.Left);
			if (k == leftSize + 1)
				return root;
			else
				return FindKth(k - leftSize - 1, root.Right);
		}

		protected new BinaryNode<T> Insert(T x, BinaryNode<T> root)
		{
			SizedBinaryNode newRoot = (SizedBinaryNode)root;
			if (newRoot == null)
				newRoot = new SizedBinaryNode(x);
			else if (x.CompareTo(newRoot.Element) < 0)
				return Insert(x, newRoot.Left);
			else if (x.CompareTo(newRoot.Element) > 0)
				return Insert(x, newRoot.Right);
			else
				throw new DuplicateWaitObjectException($"While inserting {root.ToString()}");
			newRoot.Size++;
			return newRoot;
		}

		protected new BinaryNode<T> RemoveMin(BinaryNode<T> root)
		{
			SizedBinaryNode newRoot = (SizedBinaryNode)root;

			if (newRoot == null)
			{
				throw new ArgumentNullException();
			}
			if (newRoot.Left == null)
				return newRoot.Right;

			newRoot.Left = RemoveMin(newRoot);
			newRoot.Size--;
			return newRoot;
		}

		protected new BinaryNode<T> Remove(T x, BinaryNode<T> root)
		{
			SizedBinaryNode newRoot = (SizedBinaryNode)root;
			if (newRoot == null)
				throw new ArgumentNullException();
			if (x.CompareTo(newRoot.Element) < 0)
				newRoot.Left = Remove(x, newRoot.Left);
			else if (x.CompareTo(newRoot.Element) > 0)
				newRoot.Right = Remove(x, newRoot.Right);
			else if (newRoot.Left != null && newRoot.Right != null)
			{
				newRoot.Element = FindMin(newRoot.Right).Element;
				newRoot.Right = RemoveMin(newRoot.Right);
			}
			else
				return (newRoot != null) ? newRoot.Left : newRoot.Right;

			newRoot.Size--;
			return newRoot;
		}
	}
}
