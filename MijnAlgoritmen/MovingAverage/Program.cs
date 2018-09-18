using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingAverage
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = 10000000;
			int[] arr = new int[n];
			Random rnd = new Random();



			for (int i = 0; i < n; i++)
			{
				int j = rnd.Next(1, 20);
				arr[i] = j;
			}

			Stopwatch sw = new Stopwatch();
			sw.Start();

			IterativeMovingAverage(arr);

			sw.Stop();
			long elapsed = sw.ElapsedMilliseconds;
			Console.ReadLine();
		}

		static void IterativeMovingAverage(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				// Average devider;
				int ad = 4;
				int som = 0;
				string somString = "";


				switch (i)
				{
					case 0:
						ad = 1;
						break;
					case 1:
						ad = 2;
						break;
					case 2:
						ad = 3;
						break;
					default:
						break;
				}

				for (int j = ad - 1; j >= 0; j--)
				{
					somString += $" + {arr[i - j]}";
					som += arr[i - j];
				}

				decimal avg = (decimal)som / (decimal)ad;
				//Console.WriteLine($"{somString} / {ad} = {avg}");
			}
		}
	}
}
