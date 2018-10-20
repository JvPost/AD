using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnAlgoritmen
{
	public class Les3
	{
		public static int Sum(int n)
		{
			string nStr = n.ToString();

			char[] charArr = nStr.ToCharArray();

			if (charArr.Length == 1)
				return Convert.ToInt32(charArr[0].ToString());
			else
			{
				string newNStr = "";
				for (int i = 0; i < charArr.Length - 1; i++)
					newNStr += charArr[i];

				return Sum(Convert.ToInt32(newNStr)) + Convert.ToInt32(charArr.Last().ToString());
			}
		}

		public static string Reverse(string s)
		{
			return s.Length <= 1 ? s : Reverse(s.Substring(1)) + s.ElementAt(0).ToString();
		}

		public static void PrintDecimal(long n)
		{
			if (n >= 10)
				PrintDecimal(n / 10);
			Console.WriteLine((char) ('0' + (n % 10)));
		}

		private static readonly string DIGIT_TABLE = "0123456789abcdef";
		private static readonly int MAX_LENGTH = DIGIT_TABLE.Length;

		private static void PrintIntRec(long n, int baseNr)
		{
			if (n >= baseNr)
				PrintInt(n / baseNr, baseNr);
			Console.Write(DIGIT_TABLE.ElementAt((int) (n % baseNr)));
		}

		public static void PrintInt(long n, int baseNr)
		{
			if (baseNr > MAX_LENGTH || baseNr <= 1)
				throw new Exception("Invaled base nr, must be 1 >= baseNr <= MAX_Length");
			else
			{
				if (n < 0)
				{
					n = -n;
					Console.Write("-");
				}
				PrintIntRec(n, baseNr);
			}
		}

		public static long BadFib(long n)
		{
			return n <= 1 ? n : BadFib(n - 1) + BadFib(n - 2);
		}

		public static void BadFibTest(int amount)
		{
			for (int i = 0; i < amount; i++)
			{
				Stopwatch sw = new Stopwatch();
				sw.Start();
				BadFib(i);
				sw.Stop();
				Console.WriteLine($"{i}: {sw.ElapsedMilliseconds}");
			}
		}

		public static void GoodFibTest(int amount)
		{
			int[] fiboRow = new int[amount];
			fiboRow[0] = 0;
			fiboRow[1] = 1;

			for (int i = 2; i < amount; i++)
			{
				Stopwatch sw = new Stopwatch();
				sw.Start();
				fiboRow[i] = fiboRow[i - 1] + fiboRow[i - 2];
				sw.Stop();
				Console.WriteLine($"{i}: {sw.ElapsedMilliseconds}");
			}
		}

		public static long FactorialRec(long n)
		{
			return n <= 1 ? 1 : n * FactorialRec(n - 1);
		}

		public static long OmEnOm(int n)
		{
			return n <= 1 ? n : OmEnOm(n - 2) + n;
		}

		public static int Enen(int n)
		{
			return n % 2 == 1 ? EnenRec(n - 1) + 1 : EnenRec(n);
		}

		private static int EnenRec(int n)
		{
			if (n <= 1)
				return 1;
			else
			{
				return 2;
			}
		}

		public static long FactorialLoop(long n)
		{
			long result = 1;
			for (int i = 1; i <= n; i++)
			{
				result *= i;
			}
			return result;
		}

		public static void PrintForward(List<int> theList, int i)
		{
			if (i < theList.Count())
			{
				Console.Write(theList[i] + " ");
				PrintForward(theList, i + 1);
			}
			else
				return;
		}

		public static void PrintBackwards(List<int> theList, int i)
		{
			if (theList.Count <= i)
			{
				return;
			}
			else
			{
				Console.Write($"{theList.Last()} ");
				PrintBackwards(theList.GetRange(0, theList.Count() - 1), i);
			}
		}
	}
}
