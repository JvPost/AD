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
			Console.WriteLine(Les2.CheckBrackets(""));
			Console.WriteLine(Les3.Sum(123));
			Console.WriteLine(Les3.Reverse("ASD"));

			List<int> theList = new List<int>()
			{
				0,1,2,3,4,5,6,7,8,9
			};

			Les3.PrintForward(theList, 3);
			Console.WriteLine();
			Les3.PrintBackwards(theList, 3);
			

			Console.WriteLine();

			// Arrange
			while (true)
			{
				Console.Write("enter power: ");
				string powerstr = Console.ReadLine();
				double power;
				long amount = 0;
				if (double.TryParse(powerstr, out power))
					amount = (long)(1 * Math.Pow(10, power));
				else
					Console.WriteLine("wrong value");

				int[] unsortedArr = new int[amount];
				//int maxVal = amount == 10 ? 10 : (int)(amount * 0.1);


				Random rnd = new Random();
				for (int i = 0; i < amount; i++)
				{
					unsortedArr[i] = rnd.Next((int)amount);
				}

				// Act
				Stopwatch sw = new Stopwatch();
				Console.WriteLine($"N = {amount} => {nameof(Algoritmen<int>.MergeSort)}({amount})");
				sw.Start();
				Algoritmen<int>.MergeSort(unsortedArr);
				sw.Stop();


				// Assert
				decimal ms = sw.ElapsedMilliseconds;
				Console.WriteLine($"T(N) = {ms}ms");
			}

			//
			// Array List
			//

			//ArrayList<int> AL = new ArrayList<int>();

			//for (double i = 1; i <= 10; i++)
			//{
			//	AL.Push((int)Math.Ceiling(i));
			//	AL.Push(420);
			//}

			//Console.WriteLine(AL);

			//AL.Remove(420);

			//Console.WriteLine(AL);

			//Console.ReadKey();
		}
	}
}
