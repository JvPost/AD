using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MijnDatastructuren.Implementations;
using MijnDatastructuren.Interfaces;

namespace MijnDatastructuren
{
	public class FCNSTree<T> : Interfaces.FCNSTree<T>
	{
		public class FCNSNode
		{
			public T Element { get; set; }
			public FCNSNode FirstChild { get; set; }
			public FCNSNode NextSibling { get; set; }

			public FCNSNode()
			{
			}

			public FCNSNode(T element)
			{
				Element = element;
			}

			public void PrintPreOrder()
			{
				Console.WriteLine(Element);
				if (FirstChild != null)
					FirstChild.PrintPreOrder();
				if (NextSibling != null)
					NextSibling.PrintPreOrder();
			}

			public int Size()
			{
				return Size(this);
			}

			public static int Size(FCNSNode n)
			{
				if (n == null)
					return 0;
				else
					return 1 + Size(n.FirstChild) + Size(n.NextSibling);
			}
		}

		public FCNSNode Root { get; private set; }

		public FCNSTree()
		{
			Root = null;
		}

		public FCNSTree(T rootElement)
		{
			Root = new FCNSNode(rootElement);
		}

		public FCNSTree(FCNSNode rootNode)
		{
			Root = rootNode;
		}

		public void PrintPreOrder()
		{
			Root.PrintPreOrder();
		}

		public int Size()
		{
			return Root.Size();
		}
	}
}
