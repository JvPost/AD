using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Implementations
{
	public class InOrder<T> : BinaryTreeIterator<T>
	{


		public InOrder(BinaryTree<T> tree) : base(tree)
		{
		}

		public override void Advance()
		{
			base.Advance();
			StNode cnode;

			for(; ; )
			{
				cnode = stack.Pop();

				if (++cnode.timesPopped == 2)
				{
					CurrentNode = cnode.node;
					if (cnode.node.Right != null)
						stack.Push(new StNode(cnode.node.Right));
					return;
				}
				stack.Push(cnode);
				if (cnode.node.Left != null)
					stack.Push(new StNode(cnode.node.Left));
			}
		}

		public string InOrderString()
		{
			string str = "";
			First();
			while (!stack.IsEmpty())
			{
				str += $"[{CurrentNode.Left} {CurrentNode.Element} {CurrentNode.Right}]";
				Advance();
			}
			return str;
		}
	}
}
