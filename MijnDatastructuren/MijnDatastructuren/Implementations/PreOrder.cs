using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Implementations
{
	public class PreOrder<T> : BinaryTreeIterator<T>
	{
		public PreOrder(BinaryTree<T> tree) : base(tree)
		{
		}

		public override void Advance()
		{
			base.Advance();
			CurrentNode = stack.Pop().node;

			if (CurrentNode.Right != null)
				stack.Push(new StNode(CurrentNode.Right));
			if (CurrentNode.Left != null)
				stack.Push(new StNode(CurrentNode.Left));
		}
	}
}
