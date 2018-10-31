using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MijnDatastructuren.Implementations;

namespace MijnDatastructuren.Interfaces
{
	public interface BinaryTree<T>
	{
		BinaryNode<T> GetRoot();
		int Size();
		int Heigh();

		void PrintPreOrder();
		void PrintInOrder();
		void PrintPostOrder();

		void MakeEmpty();
		bool IsEmpty();
		void Merge(T rootItem, Implementations.BinaryTree<T> t1, Implementations.BinaryTree<T> t2);
	}
}
