using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MijnDatastructuren.Interfaces;

namespace MijnDatastructuren
{
	public sealed class ArrayList<T> : Collection<T>, Iterable<T> 
	{
		public T[] BaseArray;
		public int Length { get; set; }
		public int BaseArrayLength => BaseArray.Length;

		public ArrayList()
		{
			Clear();
		}

		public T Get(int index)
		{
			if (index > Length)
				throw new IndexOutOfRangeException();
			else
				return BaseArray[index];
		}

		public void Add(int index, T item)
		{
			NewItem(index, item);

			if (index == Length)
			{
				Length++;
			}
		}

		
		public void Clear()
		{
			Length = 0;
			BaseArray = new T[10];
		}

		public bool Contains(T item)
		{
			Iterator<T> iter = this.Iterator(0);
			do
			{
				if (iter.Next().Equals(item))
					return true;
			} while (iter.HasNext());

			return false;
		}

		public bool IsEmpty()
		{
			return Length == 0;
		}

		public Iterator<T> Iterator(int position)
		{
			T[] arr = new T[Length];
			BaseArray.CopyTo(arr, position);
			return new ArrayListIterator(position, this);
		}

		public void Pop()
		{
			BaseArray[Length - 1] = default(T);
		}
		
		public void Push(T item)
		{
			this.NewItem(Length, item);
			Length++;
		}

		public void Remove(T item)
		{
			Iterator<T> it = this.Iterator(0);
			do
			{
				if (it.Next().Equals(item))
				{
					it.Remove();
				}
			} while (it.HasNext());
		}

		public void RemoveAtIndex(int index)
		{
			BaseArray[index] = default(T);
		}

		public int Size()
		{
			return Length;
		}

		public T[] ToArray()
		{
			T[] arr = new T[Length];
			Array.Copy(BaseArray, arr, Length);
			return arr;
		}

		public override string ToString()
		{
			string str = "";

			for (int i = 0; i < Length; i++)
			{
				str += $"{BaseArray[i]},";
			}

			return $"[{str}]";
		}

		// ******************************** //
		//			Private Helpers			//
		// ******************************** //
		
		private void NewItem(int index, T item)
		{
			try
			{
				if (Length == BaseArray.Length)
				{
					BaseArray = DoubleSize();
				}
				BaseArray[index] = item;
			}
			catch (Exception)
			{
				throw new Exception();
			}
		}

		private T[] DoubleSize()
		{
			T[] newArray = new T[BaseArray.Length * 2];
			BaseArray.CopyTo(newArray, 0);
			return newArray;
		}



		private sealed class ArrayListIterator : Iterator<T>
		{
			public int Index { get; private set; }
			public T Data
			{
				get => _BaseArrayList.BaseArray[Index];
				set
				{
					if (_BaseArrayList == null || Index <= _BaseArrayList.Length)
						throw new IndexOutOfRangeException();
					else if (value is T)
						_BaseArrayList.Add(Index, value);
					else
						throw new ArrayTypeMismatchException("Trying to add a value of the wrong type.");
				}
			}
			private ArrayList<T> _BaseArrayList;

			public ArrayListIterator(int position, ArrayList<T> arrayList)
			{
				_BaseArrayList = arrayList;

				if (position < 0 || position >= arrayList.BaseArray.Length)
					throw new IndexOutOfRangeException();

				Index = position;
			}

			public bool HasNext()
			{
				return Index < _BaseArrayList.BaseArray.Length;
			}

			public T Next()
			{
				if (!this.HasNext())
					throw new IndexOutOfRangeException();
				return _BaseArrayList.BaseArray[Index++];				
			}

			public void Remove()
			{
				_BaseArrayList.BaseArray[--Index] = default(T);
			}
		}
	}
}
