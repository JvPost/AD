using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren
{
	public class GenericNode
	{
		public object Data { get; set; }
		public ArrayList<GenericNode> Children = new ArrayList<GenericNode>();
		
		public GenericNode() { }
		public GenericNode(object data)
		{
			Data = data;
		}

		public void AddChild(GenericNode newChild)
		{
			Children.Push(newChild);
		}

		public bool HasChildren()
		{
			return !Children.IsEmpty();
		}

		public int Size() => GenericNode.Size(this);

		public static int Size(GenericNode node)
		{
			int size = 1;
			if (node == null)
			{
				return 0;
			}
			if (node.HasChildren())
			{
				for (int i = 0; i < node.Children.Size(); i++)
				{
					GenericNode currentNode = node.Children.Get(i);
					if (currentNode == null)
						break;
					size += Size(currentNode);
				}
			}
			return size;
		}

		public void PrintPreOrder()
		{
			PrintPreOrder(this);
		}
		
		public static void PrintPreOrder(GenericNode node)
		{
			Console.WriteLine(node.Data);

			if (node.HasChildren())
			{
				for (int i = 0; i < node.Children.Size(); i++)
				{
					GenericNode currentNode = node.Children.Get(i);
					if (currentNode == null)
						break;
					PrintPreOrder(currentNode);
				}
			}
		}
	}

	public class GenericTree
	{
		public GenericNode Root { get; set; }

		public GenericTree(GenericNode root)
		{
			Root = root;
		}

		public int Size() => Size(this);

		public static int Size(GenericTree tree)
		{
			return GenericNode.Size(tree.Root);
		}

		public void PrintPreOrder()
		{
			PrintPreOrder(this);
		}

		public static void PrintPreOrder(GenericTree tree)
		{
			GenericNode.PrintPreOrder(tree.Root);
		}
	}
}
