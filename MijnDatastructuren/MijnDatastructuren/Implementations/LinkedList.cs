using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MijnDatastructuren.Interfaces;

namespace MijnDatastructuren
{
	public sealed class LinkedList<T> : Collection<T>, LinkedListItarable<T>
	{
		public class Node
		{
			public T Data { get; set; }
			public Node Next { get; set; }
			public Node Previous { get; set; }

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
		public Node HeaderNode;
		public Node TailNode;

		public LinkedList()
		{
			HeaderNode = new Node();
			TailNode = new Node();
			HeaderNode.Next = TailNode;
			TailNode.Previous = HeaderNode;
			Length = 0;
		}

		public void Push(T item)
		{
			Node newNode = new Node(item);

			newNode.Previous = TailNode.Previous;
			newNode.Next = TailNode;

			TailNode.Previous.Next = newNode;
			TailNode.Previous = newNode;
			
			Length++;
		}

		public void Insert(int index, T item)
		{
			Node previousNode = this.GetNode(index - 1);
			Node newNode = new Node(item);

			// Move previous node 1 up the linked list.
			previousNode.Next.Previous = newNode;

			// set new node links.
			newNode.Next = previousNode.Next;
			newNode.Previous = previousNode;

			// Reconnect previous node to rest of linkedlist.
			previousNode.Next = newNode;
		}

		public void AddFirst(T item)
		{
			Insert(0, item);
		}

		public void Set(int index, T item)
		{
			if (index > Length || index < 0)
			{
				throw new IndexOutOfRangeException();
			}
			
			Node newNode = new Node(item);
			LinkedListIterator<T> iterator = this.Iterator();

			if (index == 0)
			{
				// empty linked list
				if (!iterator.HasNext())
				{
					HeaderNode.Next = newNode;
					TailNode = newNode;
				}
				else // Add newNode to first item
				{
					newNode.Next = HeaderNode.Next;
					HeaderNode.Next = newNode;
				}
			}
			else if (index == Length)
			{
				Push(item);
			}
			// Add item somewhere in the middle.
			else
			{
				while (iterator.HasNext() && iterator.CurrentIndex < index)
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
				RemoveFirst();
			}
			else
			{
				LinkedListIterator<T> iter = this.Iterator();
				while (iter.CurrentIndex < index)
				{
					iter.Next();
				}
				
				iter.Remove();

				Length--;
			}
		}

		public void Remove(T item)
		{
			LinkedListIterator<T> iter = this.Iterator();
			
			while (iter.HasNext())
			{
				if (iter.Next().Equals(item))
				{
					iter.Remove();
					Length--;
				}
			}
		}
		
		public T Pop()
		{
			if (Length == 0)
			{
				throw new EmptyLinkedListException("Can't perform this action on an empty linked list.");
			}
			T data = TailNode.Previous.Data;

			TailNode.Previous.Previous.Next = TailNode;
			TailNode.Previous = TailNode.Previous.Previous;
			Length--;

			return data;
		}

		public bool IsEmpty()
		{
			if (HeaderNode.Next == null)
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
			LinkedListIterator<T> iter = this.Iterator();
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
			HeaderNode.Next = TailNode;
			TailNode.Previous = HeaderNode.Next;
		}

		public T[] ToArray()
		{
			T[] array = new T[Length];

			LinkedListIterator<T> iter = this.Iterator();
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

			LinkedListIterator<T> iter = this.Iterator();			
			while (iter.HasNext())
			{
				str += $"{iter.Next()}, ";
				if (iter.CurrentIndex >= Length)
					break;
			}
			return $"[{str}]";
		}

		public LinkedListIterator<T> Iterator()
		{
			return new LinkedListIterator(this);
		}

		public T Get(int index)
		{
			LinkedListIterator<T> itr = Iterator();
			T item = default(T);

			while (itr.CurrentIndex < index && itr.HasNext())
			{
				item = itr.Next();
			}
			return item;
		}

		public void RemoveFirst()
		{
			HeaderNode.Next = HeaderNode.Next.Next;
			HeaderNode.Next.Previous = HeaderNode;
		}

		public T GetFirst()
		{
			return HeaderNode.Next.Data;
		}

		// ******************************** //
		//		Private Helper Methods		//
		// ******************************** //
		/// <summary>
		/// Gets a node on an index;
		/// </summary>
		/// <param name="index">index of node to get.</param>
		/// <returns></returns>
		private Node GetNode(int index)
		{
			if (index > Length)
			{
				throw new IndexOutOfRangeException();
			}
			LinkedListIterator<T> itr = Iterator(); 

			while (index >= itr.CurrentIndex)
			{
				if (!itr.HasNext())
					throw new IndexOutOfRangeException();
				else
					itr.Next();
			}
			return itr.CurrentNode;
		}

		public T Last()
		{
			return TailNode.Previous.Data;
		}

		/// <summary>
		/// Iterator implementation specifically for linkedlists.
		/// </summary>
		private sealed class LinkedListIterator : LinkedListIterator<T>
		{
			public Node CurrentNode { get; private set; }
			public int CurrentIndex { get; private set; }

			public T Data
			{
				get { return this.CurrentNode.Data; }
				set
				{
					if (value is T)
						this.CurrentNode.Data = value;
				}
			}

			public LinkedListIterator(LinkedList<T> linkedList)
			{
				CurrentNode = linkedList.HeaderNode;
				CurrentIndex = 0;
			}

			public bool HasNext()
			{
				bool check = false;
				if (CurrentNode.Next != null)
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
				CurrentNode = CurrentNode.Next;
				CurrentIndex++;
				return CurrentNode.Data;
			}

			public void Remove()
			{
				CurrentNode.Previous.Next = CurrentNode.Next;
			}
		}
	}

	public class EmptyLinkedListException : Exception
	{
		public EmptyLinkedListException()
		{
		}

		public EmptyLinkedListException(string message) : base(message)
		{
		}

		public EmptyLinkedListException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
