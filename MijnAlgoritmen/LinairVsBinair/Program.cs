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
			int[] halfArr = new int[arr.Length / 2];
			int index = arr[arr.Length / 2];
			int position = getal.CompareTo(index);


			while (position != 0)
			{
				

				if (position < 0)
				{
					arr.CopyTo(halfArr, index);
					index -= halfArr[halfArr.Length / 2];
				}
				else 
				{
					index += halfArr[halfArr.Length / 2];
					
				}
			}

			return position;
		}
	}
}
