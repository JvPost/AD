using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren
{
	public class DoublyLinkedList <T>
	{
		public class DoubleLinkedNode
		{
			public T Data;
			public DoubleLinkedNode Next;
			public DoubleLinkedNode Previous;

			public DoubleLinkedNode()
			{

			}

			public DoubleLinkedNode(T data)
			{
				Data = data;
			}

			public DoubleLinkedNode(T data, DoubleLinkedNode next, DoubleLinkedNode prev)
			{
				Data = data;
				Next = next;
				Previous = prev;
			}
		}

		DoubleLinkedNode Header;
		DoubleLinkedNode Tail;

		public DoublyLinkedList()
		{
			Header = new DoubleLinkedNode(default(T), Tail, null);
			Tail = new DoubleLinkedNode(default(T), null, Header);
			Header.Next = Tail;
		}

		public bool IsEmpty()
		{
			return Header.Next == null;
		}

		public void MakeEmpty()
		{
			Header.Next = null;
		}

		public DoubleLinkedListIterator GetByIndex(int index)
		{
			return new DoubleLinkedListIterator(index, Header);
		}

		public DoubleLinkedListIterator Zeroth()
		{
			return new DoubleLinkedListIterator(Header);
		}

		public DoubleLinkedListIterator First()
		{
			return new DoubleLinkedListIterator(Header.Next);
		}

		public DoubleLinkedListIterator Find(T item)
		{
			DoubleLinkedNode itr = Header.Next;

			while (itr != null && !itr.Data.Equals(item))
				itr = itr.Next;

			return new DoubleLinkedListIterator(itr);
		}

		public void Remove(T item)
		{
			DoubleLinkedListIterator p = FindPrevious(item);

			if (p.Current != null)
				p.Current.Next = p.Current.Next.Next;
		}

		public DoubleLinkedListIterator FindPrevious(T item)
		{
			DoubleLinkedNode itr = Header;

			while (itr != null && !itr.Next.Data.Equals(item))
				itr = itr.Next;

			return new DoubleLinkedListIterator(itr);
		}

		public override string ToString()
		{
			string str = "[";
			if (!IsEmpty())
			{
				DoubleLinkedListIterator itr = First();
				for (; itr.IsValid() && itr.Current != Tail; itr.Advance())
				{
					str += itr.Retrieve().ToString() + ",";
				}
			}
			return str += "]";
		}

		public void Push(T item)
		{
			Insert(item, new DoubleLinkedListIterator(Tail.Previous));
		}
		/// <summary>
		/// Insert after previousNode
		/// </summary>
		/// <param name="item">Data for the node iserted.</param>
		/// <param name="p">Location after which the item and node should be located.</param>
		public void Insert(T item, DoubleLinkedListIterator p)
		{
			if (item != null && p != null)
			{
				DoubleLinkedNode newNode = new DoubleLinkedNode();
				newNode.Data = item;

				p.Current.Next = newNode;
				Tail.Previous = newNode;

				newNode.Next = Tail;
				newNode.Previous = p.Current;
			}
		}


		/// <summary>
		/// Linked list iterator
		/// </summary>
		public class DoubleLinkedListIterator
		{
			public DoubleLinkedNode Current;
			int CurrentIndex = 0;

			public DoubleLinkedListIterator(DoubleLinkedNode node)
			{
				Current = node;
			}

			public DoubleLinkedListIterator(int index, DoubleLinkedNode start)
			{
				
				Current = start;

				while (CurrentIndex < index)
					Advance();
			}
			
			public bool IsValid()
			{
				return Current != null;
			}

			public T Retrieve()
			{
				return IsValid() ? Current.Data : default(T);
			}

			public void Advance()
			{
				if (IsValid())
				{
					Current = Current.Next;
					CurrentIndex++;
				}
			}

			public void Retreat()
			{
				if (IsValid())
					Current = Current.Previous;
			}
		}
	}
}
