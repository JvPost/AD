using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MijnDatastructuren.Interfaces;

namespace MijnDatastructuren.Implementations
{
	public class BinaryTree<T> : Interfaces.BinaryTree<T>
	{
		public BinaryNode<T> Root { get; private set; }

		public BinaryTree()
		{
			Root = null;
		}

		public BinaryTree(T rootItem)
		{
			Root = new BinaryNode<T>(rootItem, null, null);
		}

		public BinaryTree(BinaryNode<T> rootNode)
		{
			Root = rootNode;
		}

		public BinaryNode<T> GetRoot()
		{
			return Root;
		}

		public int Size()
		{
			return Root.Size();
		}

		public int Heigh()
		{
			return Root.Height();
		}

		public bool IsEmpty()
		{
			return Root == null;
		}

		public void MakeEmpty()
		{
			Root = null;
		}

		/// <summary>
		/// Merge routine for Binary Tree class.
		/// Forms a new tree from rootItem, t1 and t2
		/// Does not allow t1 and t2 to be the same
		/// correctly handles other aliasing conditions.
		/// </summary>
		/// <param name="rootItem"> Element in new root node. </param>
		/// <param name="t1">tree 1</param>
		/// <param name="t2">tree 2</param>
		public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
		{

			if (t1.Root == t2.Root && t1.Root != null)
				throw new ArgumentException();

			Root = new BinaryNode<T>(rootItem, t1.Root, t2.Root);

			if (this != t1)
				t1.Root = null;
			if (this != t2)
				t1.Root = null;
		}

		public void PrintInOrder()
		{
			Root.PrintInOrder();
		}

		public void PrintPostOrder()
		{
			Root.PrintPostOrder();
		}

		public void PrintPreOrder()
		{
			Root.PrintPreOrder();
		}

		public override string ToString()
		{
			InOrder<T> inOrderIt = new InOrder<T>(this);
			return inOrderIt.InOrderString();
		}
	}
}
