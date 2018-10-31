using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MijnDatastructuren.Implementations;

namespace MijnDatastructuren.Interfaces
{
	public interface TreeNode<T>
	{
		T Element { get; set; }

		int Size();
		int Height();
		TreeNode<T> Duplicate();

		void PrintPreOrder();
		void PrintPostOrder();
		void PrintInOrder();
	}
}
