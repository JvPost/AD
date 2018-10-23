using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren
{
	public class TreeNode
	{
		public object Data { get; set; }
		public ArrayList<TreeNode> Children = new ArrayList<TreeNode>();

		public TreeNode() { }
		public TreeNode(object data)
		{
			Data = data;
		}

		public void AddChild(TreeNode newChild)
		{
			Children.Push(newChild);
		}

		public bool HasChildren()
		{
			return !Children.IsEmpty();
		}

		public static int Size(TreeNode node)
		{
			int size = 1;
			if (node == null)
			{
				return 0;
			}
			if (node.HasChildren())
			{
				// TODO : Make ArrayList & Iterator easier to use in external classes.
				//while (node.Children.Iterator().HasNext())
				//{
				//	TreeNode currentNode = node.Children.Iterator().Next();
				//	if (currentNode == null)
				//		break;
				//	size += Size(currentNode);
				//}
				for (int i = 0; i < node.Children.Size(); i++)
				{
					TreeNode currentNode = node.Children.Get(i);
					if (currentNode == null)
						break;
					size += Size(currentNode);
				}
			}
			return size;
		}

		public void PrintPreOrder()
		{

		}
	}

	public class GenericTree
	{
		public TreeNode Root { get; set; }

		public GenericTree(TreeNode root)
		{
			Root = root;
		}
	}
}
