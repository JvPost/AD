using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren
{
	public class Stack<T> : MijnDatastructuren.Interfaces.Stack<T>
	{
		LinkedList<T> LinkedList { get; set; }
		public int Length => LinkedList.Length;

		public Stack()
		{
			LinkedList = new LinkedList<T>();
		}

		public void Push(T data)
		{
			LinkedList.Push(data);
		}

		public T Pop()
		{
			return LinkedList.Pop();
		}

		public override string ToString()
		{
			return LinkedList.ToString();
		}
	}
}
