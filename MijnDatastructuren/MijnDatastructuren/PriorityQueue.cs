//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MijnDatastructuren.Interfaces;

//namespace MijnDatastructuren
//{
//	public class PriorityQueue<T>
//	{
//		private int _currentSize;
//		private T[] _arr;
//		private Comparer<T> _cmp;

//		private static readonly int DEFAULT_CAPACITY = 100;

//		public PriorityQueue()
//		{
//			_currentSize = 0;
//			_cmp = null;
//			_arr = new T[DEFAULT_CAPACITY];
//		}

//		public PriorityQueue(Comparer<T> c)
//		{
//			_currentSize = 0;
//			_cmp = c;
//			_arr = new T[DEFAULT_CAPACITY];
//		}

//		/// <summary>
//		/// Constructor for priority queue with a my implementation of the collection interface.
//		/// </summary>
//		/// <param name="coll"></param>
//		public PriorityQueue(Collection<T> coll)
//		{
//			_cmp = null;
//			_currentSize = coll.Length;
//			_arr = new T[(_currentSize + 2) * 11 / 10];

//			for (int i = 0; i < coll.Length; i++)
//				_arr[i] = coll.Get(i);
//			BuildHeap();
//		}

//		public int Size() => _currentSize;

//		public void Clear()
//		{
//			_currentSize = 0;
//		}

//		//
//		// Potentially make iterator
//		//

//		public T Element()
//		{
//			if ()
//		}

//		public bool Add(T x)
//		{
//		}

//		public T Remove()
//		{
//		}

//		private void PercolateDown(int hole) { }
//		private void BuildHeap() { }

//		private void DoubleArray() { }
//		private int Compare(T lgh, T rhs) { }
//	}
//}
