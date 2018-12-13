using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren
{
	public class PriorityQueue<T> where T : IComparable
	{
		int currentSize;
		IComparer<T> cmp;
		public T[] arr;

		static readonly int DEFAULT_CAP = 100;

		public PriorityQueue()
		{
			currentSize = 0;
			cmp = null;
			arr = new T[DEFAULT_CAP + 1];
		}

		public PriorityQueue(Comparer<T> c)
		{
			currentSize = 0;
			cmp = c;
			arr = new T[DEFAULT_CAP + 1];
		}

		public PriorityQueue(ICollection<T> coll)
		{
			cmp = null;
			currentSize = coll.Count();
			arr = new T[(currentSize + 2) * 11 / 10];

			int i = 1;
			foreach(var item in coll)
				arr[i++] = item;
			
			BuildHeap();
		}

		

		public T Element()
		{
			if (IsEmpty())
				throw new ArgumentOutOfRangeException();
			return arr[1];
		}

		public bool IsEmpty()
		{
			return currentSize == 0;
		}

		public bool Add(T x)
		{
			if (currentSize + 1 == arr.Length)
				DoubleArray();

			currentSize++;
			int hole = currentSize;
			arr[0] = x;

			for (; x.CompareTo(arr[hole / 2]) < 0; hole /= 2)
				arr[hole] = arr[hole / 2];
			arr[hole] = x;
			arr[0] = default(T);

			return true;
		}

		private void DoubleArray()
		{
			T[] copy = new T[arr.Length * 2];
			arr.CopyTo(copy, 0);
			arr = copy;
		}

		public bool CheckValidity()
		{
			for (int i = 0; i <= currentSize / 2; i++)
				if (arr[i].CompareTo(arr[i * 2]) > 0 || arr[i].CompareTo(arr[i * 2 + 1]) > 0)
					return false;
			return true;
		}

		public T Remove()
		{
			T minItem = Element();
			arr[1] = arr[currentSize--];
			PercolateDown(1);

			return minItem;
		}

		private void BuildHeap()
		{
			for (int i = currentSize / 2; i > 0; i--)
			{
				PercolateDown(i);
			}
		}

		private void PercolateDown(int hole)
		{
			int child;
			T tmp = arr[hole];

			for(; hole * 2 <= currentSize; hole = child)
			{
				child = hole * 2;
				if (child != currentSize && arr[child + 1].CompareTo(arr[child]) < 0)
					child++;
				if (arr[child].CompareTo(tmp) < 0)
					arr[hole] = arr[child];
				else
					break;
			}
			arr[hole] = tmp;
		}

		public int Size()
		{
			return currentSize; 
		}

		public override string  ToString()
		{
			string str = "";
			foreach (var i in arr)
				str += $"{i}, ";
			return str;
		}
	}
}
