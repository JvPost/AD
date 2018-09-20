using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinairVsBinair
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] arr = new int[] { 1,2,3,4,5,6,7,8,9 };

			int index = BinairZoeken(8, arr);

			Console.ReadLine();
		}


		static int LineairZoeken(int getal, int[] arr)
		{
			int index = -1;

			return index;
		}

		static int BinairZoeken(int getal, int[] arr)
		{
			int low = 0;
			int high = arr.Length - 1;
			int mid;

			while (low <= high)
			{
				mid = (low + high) / 2;

				if (arr[mid].CompareTo(getal) < 0)
					low = mid + 1;
				else if (arr[mid].CompareTo(getal) > 0)
					high = mid - 1;
				else return mid;
			}

			return -1;
		}
	}
}
