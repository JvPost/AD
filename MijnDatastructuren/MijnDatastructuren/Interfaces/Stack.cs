using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Interfaces
{
	interface Stack<T>
	{
		int Length { get; }
		void Push(T data);
		T Pop();
		T Top();
		void Clear();
		bool IsEmpty();
	}
}
