using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Implementations.BinarySearchTree
{
	public class BinaryNode<T> where T : IComparable 
	{
		public T Element { get; set; }

		public BinaryNode<T> Left { get; set; }
		public BinaryNode<T> Right { get; set; }

		public BinaryNode(T element)
		{
			Element = element;
		}
	}
}
