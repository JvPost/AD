using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MijnDatastructuren;
using MijnAlgoritmen;


namespace MijnDatastructuren.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine(Les2.CheckBrackets(""));
			//Console.WriteLine(Les3.Sum(123));
			//Console.WriteLine(Les3.Reverse("ASD"));

			//List<int> theList = new List<int>()
			//{
			//	0,1,2,3,4,5,6,7,8,9
			//};

			//Les3.PrintForward(theList, 3);
			//Console.WriteLine();
			//Les3.PrintBackwards(theList, 3);


			//Console.WriteLine();

			//// Arrange
			//while (true)
			//{
			//	Console.Write("enter power: ");
			//	string powerstr = Console.ReadLine();
			//	double power;
			//	long amount = 0;
			//	if (double.TryParse(powerstr, out power))
			//		amount = (long)(1 * Math.Pow(10, power));
			//	else
			//		Console.WriteLine("unsupported value");

			//	int[] unsortedArr = new int[amount];

			//	Random rnd = new Random();
			//	for (int i = 0; i < amount; i++)
			//	{
			//		unsortedArr[i] = rnd.Next((int)amount);
			//	}

			//	// Act
			//	Stopwatch sw = new Stopwatch();
			//	Console.WriteLine($"N = {amount} => {nameof(Sorting<int>.QuickSort)}({amount})");
			//	sw.Start();
			//	Sorting<int>.QuickSort(unsortedArr);
			//	sw.Stop();


			//	// Assert
			//	decimal ms = sw.ElapsedMilliseconds;
			//	Console.WriteLine($"T(N) = {ms}ms");
			//}

			TreeNode NodeA = new TreeNode("A");
			TreeNode NodeB = new TreeNode("B");
			TreeNode NodeC = new TreeNode("C");
			TreeNode NodeD = new TreeNode("D");
			TreeNode NodeE = new TreeNode("E");
			TreeNode NodeF = new TreeNode("F");

			NodeA.AddChild(NodeB);
			NodeA.AddChild(NodeE);
			NodeA.AddChild(NodeF);
			NodeB.AddChild(NodeC);
			NodeB.AddChild(NodeD);

			GenericTree genericTree = new GenericTree(NodeA);
			Console.WriteLine(TreeNode.Size(NodeA));
			Console.ReadKey();
		}
	}
}
