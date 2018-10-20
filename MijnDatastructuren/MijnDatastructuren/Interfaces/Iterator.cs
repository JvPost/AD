using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Interfaces
{
	public interface Iterator<T>
	{
		int CurrentIndex { get; }
		T Data { get; set;}
		bool HasNext();
		T Next();
		void Remove();
	}

	public interface LinkedListIterator<T> : Iterator<T>
	{
		LinkedList<T>.Node CurrentNode { get; }
	}
}
