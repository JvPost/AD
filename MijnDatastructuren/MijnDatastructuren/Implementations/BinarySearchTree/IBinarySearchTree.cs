using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Implementations.BinarySearchTree
{
	interface IBinarySearchTree<T> where T : IComparable
	{
		void Insert(T x);
		void Remove(T x);
		void RemoveMin();
		T FindMin();
		string InOrder();
		string ToString();
	}
}
