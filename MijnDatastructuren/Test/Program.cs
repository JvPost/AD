using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MijnDatastructuren;


namespace MijnDatastructuren.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			//
			// Linked List
			//

			//LinkedList<string> LL = new LinkedList<string>();

			//for (int i = 0; i < 10; i++)
			//{
			//	LL.Push($"newNode{i}");
			//}

			//Console.WriteLine(LL);

			//LL.Add(2, "newNodeASD");

			//Console.WriteLine(LL);

			//LL.RemoveAtIndex(5);

			//Console.WriteLine(LL.Contains("newNode8"));
			//Console.WriteLine(LL.Contains("newNode9"));
			//Console.WriteLine(LL.Contains("newNode10"));

			//Console.WriteLine(LL);
			//Console.ReadKey();

			//
			// Array List
			//

			ArrayList<int> AL = new ArrayList<int>();

			for (double i = 1; i <= 10; i++)
			{
				AL.Push((int)Math.Ceiling(i));
				AL.Push(420);
			}

			Console.WriteLine(AL);

			AL.Remove(420);

			Console.WriteLine(AL);

			Console.ReadKey();
		}
	}
}
