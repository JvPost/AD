using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MijnDatastructuren;
using MijnAlgoritmen;
using MijnDatastructuren.Implementations;
using MijnDatastructuren.Implementations.BinarySearchTree;


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


			// Generic Tree
			//TreeNode NodeA = new TreeNode("A");
			//TreeNode NodeB = new TreeNode("B");
			//TreeNode NodeC = new TreeNode("C");
			//TreeNode NodeD = new TreeNode("D");
			//TreeNode NodeE = new TreeNode("E");
			//TreeNode NodeF = new TreeNode("F");

			//NodeA.AddChild(NodeB);
			//NodeA.AddChild(NodeE);
			//NodeA.AddChild(NodeF);
			//NodeB.AddChild(NodeC);
			//NodeB.AddChild(NodeD);

			//TreeNode.PrintPreOrder(NodeA);
			//Console.ReadKey();

			// Binary Tree
			//BinaryNode<int> Node1 = new BinaryNode<int>(1, null, null);
			//BinaryNode<int> Node2 = new BinaryNode<int>(2, null, null);
			//BinaryNode<int> Node3 = new BinaryNode<int>(3, null, null);
			//BinaryNode<int> Node4 = new BinaryNode<int>(4, null, null);
			//BinaryNode<int> Node5 = new BinaryNode<int>(5, null, null);
			//BinaryNode<int> Node6 = new BinaryNode<int>(6, null, null);
			//BinaryNode<int> Node7 = new BinaryNode<int>(7, null, null);

			//Node1.Left = Node2;
			//Node1.Right = Node3;

			//Node2.Left = Node4;
			//Node2.Right = Node5;

			//Node3.Left = Node6;
			//Node3.Right = Node7;

			//BinaryTree<int> binaryTree = new BinaryTree<int>(Node1);

			//BinaryTreeIterator<int> treeIterator = new PostOrder<int>(binaryTree);
			//treeIterator.Print();

			//Console.WriteLine();

			//treeIterator = new InOrder<int>(binaryTree);
			//treeIterator.Print();

			//Console.WriteLine("Opdracht 4");
			//Console.WriteLine(binaryTree.ToString());


			//// FCNS Tree
			//FCNSTree<string>.FCNSNode fCNSNodeA = new FCNSTree<string>.FCNSNode("A");
			//FCNSTree<string>.FCNSNode fCNSNodeB = new FCNSTree<string>.FCNSNode("B");
			//FCNSTree<string>.FCNSNode fCNSNodeC = new FCNSTree<string>.FCNSNode("C");
			//FCNSTree<string>.FCNSNode fCNSNodeD = new FCNSTree<string>.FCNSNode("D");
			//FCNSTree<string>.FCNSNode fCNSNodeE = new FCNSTree<string>.FCNSNode("E");
			//FCNSTree<string>.FCNSNode fCNSNodeF = new FCNSTree<string>.FCNSNode("F");
			//FCNSTree<string>.FCNSNode fCNSNodeG = new FCNSTree<string>.FCNSNode("G");
			//FCNSTree<string>.FCNSNode fCNSNodeH = new FCNSTree<string>.FCNSNode("H");
			//FCNSTree<string>.FCNSNode fCNSNodeI = new FCNSTree<string>.FCNSNode("I");
			//FCNSTree<string>.FCNSNode fCNSNodeJ = new FCNSTree<string>.FCNSNode("J");
			//FCNSTree<string>.FCNSNode fCNSNodeK = new FCNSTree<string>.FCNSNode("K");

			//fCNSNodeA.FirstChild = fCNSNodeB;
			//fCNSNodeB.FirstChild = fCNSNodeF;
			//fCNSNodeF.NextSibling = fCNSNodeG;
			//fCNSNodeB.NextSibling = fCNSNodeC;
			//fCNSNodeC.NextSibling = fCNSNodeD;
			//fCNSNodeD.FirstChild = fCNSNodeH;
			//fCNSNodeD.NextSibling = fCNSNodeE;
			//fCNSNodeE.FirstChild = fCNSNodeI;
			//fCNSNodeI.NextSibling = fCNSNodeJ;
			//fCNSNodeJ.FirstChild = fCNSNodeK;


			//FCNSTree<string> fCNSTree = new FCNSTree<string>(fCNSNodeA);
			//Console.WriteLine(fCNSTree.Size());
			//fCNSTree.PrintPreOrder();

			//Console.ReadKey();

			Implementations.BinarySearchTree.BinaryNode<int> Root = new Implementations.BinarySearchTree.BinaryNode<int>(6);
			Implementations.BinarySearchTree.BinaryNode<int> Node1 = new Implementations.BinarySearchTree.BinaryNode<int>(6);
			Implementations.BinarySearchTree.BinaryNode<int> Node2 = new Implementations.BinarySearchTree.BinaryNode<int>(6);
			Implementations.BinarySearchTree.BinaryNode<int> Node3 = new Implementations.BinarySearchTree.BinaryNode<int>(6);
			Implementations.BinarySearchTree.BinaryNode<int> Node4 = new Implementations.BinarySearchTree.BinaryNode<int>(6);

			Root.Left = Node1;
			Root.Right = Node2;

			Node1.Left = Node3;
			Node1.Right = Node4;


			BinarySearchTree<int> bst = new BinarySearchTree<int>(Root);
			Console.WriteLine(bst.InOrder());

			Console.ReadKey();
		}
	}
}
