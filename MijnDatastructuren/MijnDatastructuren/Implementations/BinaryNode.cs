using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MijnDatastructuren.Interfaces;

namespace MijnDatastructuren.Implementations
{
	public class BinaryNode<T> : TreeNode<T>
	{
		public T Element { get; set; }
		public BinaryNode<T> Left { get; set; }
		public BinaryNode<T> Right { get; set; }

		public BinaryNode()
		{

		}

		public BinaryNode(T element, BinaryNode<T> lt, BinaryNode<T> rt)
		{
			Element = element;
			Left = lt;
			Left = rt;
		}
		
		public int Size()
		{
			return Size(this);
		}

		public static int Size(BinaryNode<T> t)
		{
			if (t == null)
				return 0;
			else
				return 1 + Size(t.Left) + Size(t.Right);
		}
		
		public int Height()
		{
			return Height(this);
		}

		public static int Height(BinaryNode<T> t)
		{
			if (t == null)
				return -1;
			else
				return 1+Math.Max(t.Left.Height(), t.Right.Height());
		}

		/// <summary>
		/// REturns a refernece to a node that is the root of a
		/// duplicate of the binay tree rooted at the current node.
		/// </summary>
		/// <returns></returns>
		public TreeNode<T> Duplicate()
		{
			BinaryNode<T> root = new BinaryNode<T>(Element, null, null);

			if (Left != null)
				root.Left = (BinaryNode<T>)Left.Duplicate();
			if (Right != null)
				root.Right = (BinaryNode<T>)Right.Duplicate();
			return root;
		}

		public override string ToString()
		{
			return Element.ToString();
		}

		public void PrintPreOrder()
		{
			Console.WriteLine(Element);
			if (Left != null)
				Left.PrintInOrder();
			if (Right != null)
				Right.PrintInOrder();
		}

		public void PrintPostOrder()
		{
			if (Left != null)
				Left.PrintPostOrder();
			if (Right != null)
				Right.PrintPostOrder();
			Console.WriteLine(Element);
		}

		public void PrintInOrder()
		{
			if (Left != null)
				Left.PrintInOrder();
			Console.WriteLine(Element);
			if (Right != null)
				Right.PrintInOrder();
		}
	}
}
