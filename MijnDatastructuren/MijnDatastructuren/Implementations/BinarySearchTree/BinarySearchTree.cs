using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Implementations.BinarySearchTree
{
	public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
	{
		protected BinaryNode<T> Root { get; private set; }

		public BinarySearchTree(BinaryNode<T> root)
		{
			Root = root;
		}

		public void Insert(T x)
		{
			Root = Insert(x, Root);
		}

		public void Remove(T x)
		{
			Root = Remove(x, Root);
		}
		
		public void RemoveMin()
		{
			Root = RemoveMin(Root);
		}
		
		public T FindMin() => ElementAt(FindMin(Root));
		public T FindMax() => ElementAt(FindMax(Root));
		public T Find(T x) => ElementAt(Find(x, Root));

		private T ElementAt(BinaryNode<T> n) => n == null ? default(T) : n.Element;

		protected BinaryNode<T> Find(T x, BinaryNode<T> n)
		{
			while (n != null)
				if (x.CompareTo(n.Element) < 0)
					n = n.Left;
				else if (x.CompareTo(n.Element) > 0)
					n = n.Right;
				else
					return n;
			return null;
		}
		protected BinaryNode<T> FindMin(BinaryNode<T> n)
		{
			if (n != null)
				while (n.Left != null)
					n = n.Left;
			return n;
		}

		protected BinaryNode<T> FindMax(BinaryNode<T> n)
		{
			if (n != null)
				while (n.Right != null)
					n = n.Right;
			return n;
		}

		protected BinaryNode<T> Insert(T x, BinaryNode<T> n)
		{
			if (n == null)
				n = new BinaryNode<T>(x);
			else if (x.CompareTo(n.Element) < 0)
				n.Left = Insert(x, n.Left);
			else if (x.CompareTo(n.Element) > 0)
				n.Right = Insert(x, n.Right);
			else
				throw new Exception();
			return n;
		}

		protected BinaryNode<T> RemoveMin(BinaryNode<T> n)
		{
			if (n == null)
				throw new KeyNotFoundException();
			else if (n.Left != null)
			{
				n.Left = RemoveMin(n.Left);
				return n;
			}
			else
				return n.Right;
		}

		protected BinaryNode<T> Remove(T x, BinaryNode<T> n)
		{
			if (n == null)
				throw new KeyNotFoundException();
			if (x.CompareTo(n.Element) < 0)
				n.Left = Remove(x, n.Left);
			else if (x.CompareTo(n.Element) > 0)
				n.Right = Remove(x, n.Right);
			else if (n.Left != null && n.Right != null) // 2 children
			{
				n.Element = FindMin(n.Right).Element;
				n.Right = RemoveMin(n.Right);
			}
			else n = (n.Left != null) ? n.Left : n.Right;
			return n;
		}
		
		public void MakeEmpty()
		{
			Root = null;
		}

		public bool IsEmpty() => Root == null;

		public override string ToString()
		{
			return base.ToString();
		}

		public string InOrder()
		{
			string str = " ";
			return str += $" {InOrder(ref str, Root).Element.ToString()}";
		}

		private BinaryNode<T> InOrder(ref string str,  BinaryNode<T> Root)
		{
			if (Root.Left != null)
				str += $" {InOrder(ref str, Root.Left).Element.ToString()}";
			str += Root.Element.ToString();
			if (Root.Right != null)
				str += $" {InOrder(ref str, Root.Right).Element.ToString()}";

			return Root;
		}
	}
}
