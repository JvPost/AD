using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
	public class LinkedList <T>
	{
		public class Node
		{
			public T Data { get; set; }
			public Node Next { get; set; }

			public Node(object data)
			{
				Data = (T)data;
				Next = null;
			}
		}

		public int Length { get; set; }
		Node _VirtualFirst;
		Node _Last;


		public LinkedList()
		{
			_VirtualFirst = new Node(null);
			_Last = _VirtualFirst;
			Length = 0;
		}

		public void Push(T item)
		{
			Node newNode = new Node(item);
			if (Length == 0)
			{
				_VirtualFirst.Next = newNode;
				_Last = newNode;
			}
			else
			{
				_Last.Next = newNode;
				_Last = newNode;
			}
			Length++;
		}

		public void Add(int index, T item)
		{
			Node newNode = new Node(item);
			if (index > Length - 1)
			{
				throw new IndexOutOfRangeException();
			}

			if (index == 0)
			{
				// empty linked list
				if (_VirtualFirst == _Last)
				{
					_VirtualFirst.Next = newNode;
					_Last = newNode;
				}
				else // Add newNode to first item
				{
					newNode.Next = _VirtualFirst.Next;
					_VirtualFirst.Next = newNode;
				}
			}	
			else
			{
				Node currentNode = _VirtualFirst.Next;
				int currentIndex = 0;

				while (currentIndex != index - 1)
				{
					currentNode = currentNode.Next;
					currentIndex++;
				}

				newNode.Next = currentNode.Next;
				currentNode.Next = newNode;
			}

			Length++;
		}

		public void RemoveAtIndex(int index)
		{
			if (index > Length - 1)
				throw new IndexOutOfRangeException();

			Node currentNode = _VirtualFirst;
			int currentIndex = 0; 

			while (currentIndex < index)
			{
				currentNode = currentNode.Next;
				currentIndex++;
			}

			// We're removing currentNode.next, because the index of currentNode.next == paramenter index
			currentNode.Next = currentNode.Next.Next;

			Length--;
		}

		public void Remove(T item)
		{
			Node currentNode = _VirtualFirst;
			int index = 0;

			while (currentNode.Next != null)
			{
				if (currentNode.Next.Data.Equals(item))
				{
					currentNode.Next = currentNode.Next.Next;
					Length--;
				}
				else
				{
					currentNode = currentNode.Next;
				}
				index++;
			}
		}

		public Node First()
		{
			return _VirtualFirst.Next;
		}

		public Node Last()
		{
			return _Last;
		}

		public void Pop()
		{
			Node current = _VirtualFirst.Next;

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


		public override string ToString()
		{
			Node currentNode = _VirtualFirst.Next;
			string str = "";
			while (currentNode != null)
			{
				str += $"{currentNode.Data.ToString()}, ";
				currentNode = currentNode.Next;
				if (currentNode == null)
					break;
			}
			return $"[{str}]";
		}
	}
}
