using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MijnDatastructuren.Interfaces;

namespace MijnDatastructuren
{
	public sealed class LinkedList<T> : Collection<T>, Iterable<T>
	{
		public class Node
		{
			public T Data { get; set; }
			public Node Next { get; set; }
			
			public Node()
			{
				Next = null;
			}

			public Node(T data)
			{
				Data = data;
				Next = null;
			}
		}

		public int Length { get; private set; }
		public Node VirtualFirst;
		public Node Last;

		public LinkedList()
		{
			VirtualFirst = new Node();
			Last = VirtualFirst;
			Length = 0;
		}

		public void Push(T item)
		{
			Node newNode = new Node(item);
			if (Length == 0)
			{
				VirtualFirst.Next = newNode;
				Last = newNode;
			}
			else
			{
				Last.Next = newNode;
				Last = newNode;
			}
			Length++;
		}

		public void Add(int index, T item)
		{
			if (index > Length || index < 0)
			{
				throw new IndexOutOfRangeException();
			}


			Node newNode = new Node(item);
			Iterator<T> iterator = this.Iterator(0);

			if (index == 0)
			{
				// empty linked list
				if (!iterator.HasNext())
				{
					VirtualFirst.Next = newNode;
					Last = newNode;
				}
				else // Add newNode to first item
				{
					newNode.Next = VirtualFirst.Next;
					VirtualFirst.Next = newNode;
				}
			}
			else if (index == Length)
			{
				Push(item);
			}
			// Add item somewhere in the middle.
			else
			{
				while (iterator.HasNext() && iterator.Index < index)
				{
					iterator.Next();
				}
				iterator.Data = item;
			}
		}

		public void RemoveAtIndex(int index)
		{
			if (index > Length - 1)
				throw new IndexOutOfRangeException();
			else if (index == Length - 1)
			{
				Pop();
			}
			else if (index == 0)
			{
				VirtualFirst.Next = VirtualFirst.Next.Next;
			}
			else
			{
				Iterator<T> iter = this.Iterator(0);
				while (iter.Index < index)
				{
					iter.Next();
				}
				
				iter.Remove();

				Length--;
			}
		}

		public void Remove(T item)
		{
			Iterator<T> iter = this.Iterator(0);
			
			while (iter.HasNext())
			{
				if (iter.Next().Equals(item))
				{
					iter.Remove();
					Length--;
				}
			}
		}
		
		public void Pop()
		{
			Node current = VirtualFirst.Next;

			do
			{
				if (current != null)
				{
					if (current.Next.Next == null)
					{
						current.Next = null;
					}
					else
					{
						current = current.Next;
					}
				}
				else
				{
					throw new NullReferenceException("List is empty.");
				}
			} while (current.Next != null);
		}

		public bool IsEmpty()
		{
			if (VirtualFirst.Next == null)
				return true;
			else
				return false;
		}

		public int Size()
		{
			return Length;
		}

		public bool Contains(T item)
		{
			bool contains = false;
			Iterator<T> iter = this.Iterator(0);
			while (iter.HasNext())
			{
				if (iter.Next().Equals(item))
				{
					contains = true;
					break;
				}
			}

			return contains;
		}

		public void Clear()
		{
			VirtualFirst.Next = null;
		}

		public T[] ToArray()
		{
			T[] array = new T[Length];

			Iterator<T> iter = this.Iterator(0);
			int index = 0;

			while (iter.HasNext())
			{
				array[index] = iter.Next();
				index++;
			}
			return array;
		}


		public override string ToString()
		{
			string str = "";

			Iterator<T> iter = this.Iterator(0);

			while (iter.HasNext())
			{
				str += $"{iter.Next()}, ";
			}
			return $"[{str}]";
		}

		public Iterator<T> Iterator(int position)
		{
			return new LinkedListIterator(this);
		}

		public T Get(int index)
		{
			throw new NotImplementedException();
		}

		private sealed class LinkedListIterator : Iterator<T>
		{
			LinkedList<T> _ListToIterate;
			Node _Current;
			Node _Previous;

			public int Index { get; private set; }

			public T Data
			{
				get { return this._Current.Data; }
				set
				{
					if (value is T)
						this._Current.Data = value;
				}
			}

			public LinkedListIterator(LinkedList<T> linkedList)
			{
				_ListToIterate = linkedList;
				_Current = _ListToIterate.VirtualFirst;
				_Previous = _ListToIterate.VirtualFirst;
				Index = 0;
			}

			public bool HasNext()
			{
				bool check = false;
				if (_Current.Next != null)
					check = true;
				return check;
			}

			/// <summary>
			///		Returns Next item in linkedlist, adds 1 to index and moves Previous an Current private variables up 1 item in linkedlist.
			/// </summary>
			/// <returns>
			///		Next item in LinkedList of Type T.
			/// </returns>
			public T Next()
			{
				_Previous = _Current;
				_Current = _Current.Next;
				Index++;
				return _Current.Data;
			}

			public void Remove()
			{
				_Previous.Next = _Current.Next;
			}
		}
	}
}
