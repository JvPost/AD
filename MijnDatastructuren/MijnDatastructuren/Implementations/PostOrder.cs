using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Implementations
{
	/// <summary>
	/// Process nodes recursivly in the following order: Left-, Right-, CurrentNode (starts with root).
	/// </summary>
	/// <typeparam name="T">Type of BinaryNode element.</typeparam>
	public class PostOrder<T> : BinaryTreeIterator<T>
	{
		public PostOrder(BinaryTree<T> tree) : base(tree)
		{
		}

		public override void Advance()
		{
			base.Advance();
			StNode cnode;

			for(; ; )
			{
				cnode = stack.Pop();
				
				// Process current node
				if (++cnode.timesPopped == 3)
				{
					CurrentNode = cnode.node;
					// Here should be the function that we want to do,
					// on the element of the node.
					break;
				}

				stack.Push(cnode);
				if (cnode.timesPopped == 1) // Recursively process left node.
				{
					if (cnode.node.Left != null)
						stack.Push(new StNode(cnode.node.Left));
				}
				else // cnode.timesPopped = 2; Recursively Process right node.
				{
					if (cnode.node.Right != null)
						stack.Push(new StNode(cnode.node.Right));
				}
			}
		}
	}
}
