using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
	class Program
	{
		static void Main(string[] args)
		{
			LinkedList<string> LL = new LinkedList<string>();
			LL.Push("First");
			LL.Push("Second");
			LL.Push("Third");

			Console.WriteLine($"Length: {LL.Length} => {LL.ToString()}");

			LL.Add(0, "newNode1");
			LL.Add(2, "newNode2");
			LL.Add(4, "newNode3");

			Console.WriteLine($"Length: {LL.Length} => {LL.ToString()}");

			LL.RemoveAtIndex(5);

			Console.WriteLine($"Length: {LL.Length} => {LL.ToString()}");

			LL.RemoveAtIndex(2);

			Console.WriteLine($"Length: {LL.Length} => {LL.ToString()}");

			LL.Remove("newNode1");

			Console.WriteLine($"Length: {LL.Length} => {LL.ToString()}");

			Console.ReadLine();
		}
	}
}
