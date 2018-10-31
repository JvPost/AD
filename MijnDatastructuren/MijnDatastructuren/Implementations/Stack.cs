using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren
{
	public class Stack<T> : MijnDatastructuren.Interfaces.Stack<T>
	{
		ArrayList<T> ArrayList { get; set; }
		public int Length => ArrayList.Length;

		public Stack()
		{
			ArrayList = new ArrayList<T>();
		}

		public void Push(T data)
		{
			ArrayList.Push(data);
		}

		/// <summary>
		/// Returns and removes last item from stack.
		/// </summary>
		/// <returns></returns>
		public T Pop()
		{
			return ArrayList.Pop();
		}

		/// <summary>
		/// Returns last item from stack.
		/// </summary>
		/// <returns></returns>
		public T Top()
		{
			return ArrayList.Last();
		}

		public override string ToString()
		{
			return ArrayList.ToString();
		}

		public void Clear()
		{
			ArrayList.Clear();
		}

		public bool IsEmpty() => ArrayList.IsEmpty();
	}
}
