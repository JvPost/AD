using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MijnDatastructuren.Interfaces;

namespace MijnDatastructuren
{
	public class FCSNSNode<T>
	{

	}

	class FCNSTree<T> : IFCNSTree<T>
	{
		LinkedList<FCSNSNode<T>> FCNSLinkedList;
		FCSNSNode<T> Root;

		public FCNSTree()
		{
			FCNSLinkedList = new LinkedList<FCSNSNode<T>>();
		}

		public void PrintPreOrder()
		{
			throw new NotImplementedException();
		}

		public int Size()
		{
			throw new NotImplementedException();
		}
	}
}
