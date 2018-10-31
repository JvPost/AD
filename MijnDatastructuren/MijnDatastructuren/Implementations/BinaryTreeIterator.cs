using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MijnDatastructuren.Interfaces;

namespace MijnDatastructuren.Implementations
{
	public abstract class BinaryTreeIterator<T>
	{
		protected class StNode
		{
			public int timesPopped;
			public BinaryNode<T> node;

			public StNode(BinaryNode<T> n)
			{
				timesPopped = 0;
				node = n;
			}
		}

		/// <summary>
		///  Set current position to first node, and advance.
		/// </summary>
		public void First()
		{
			stack.Clear();
			if (Tree.GetRoot() != null)
			{
				stack.Push(new StNode(Tree.GetRoot()));
				Advance();
			}
		}

		virtual public void Advance()
		{
			if (stack.IsEmpty())
			{
				if (CurrentNode == null)
					throw new ArgumentNullException();
				CurrentNode = null;
				return;
			}
		}
		
		protected Stack<StNode> stack { get; set; }
		protected BinaryTree<T> Tree { get; }
		protected BinaryNode<T> CurrentNode { get; set; }

		public BinaryTreeIterator(BinaryTree<T> t)
		{
			Tree = t;
			CurrentNode = null;
			stack = new Stack<StNode>();
			stack.Push(new StNode(t.GetRoot()));
		}

		public bool isValid() => CurrentNode != null;

		public T Retrieve()
		{
			if (CurrentNode == null)
				throw new Exception();
			return CurrentNode.Element;
		}

		public virtual void Print()
		{
			while (!stack.IsEmpty())
			{
				Advance();
				Console.WriteLine(CurrentNode);
			}
		}
	}
}
