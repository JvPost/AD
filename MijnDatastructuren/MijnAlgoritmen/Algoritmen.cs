using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnAlgoritmen
{
	public static class Algoritmen<T> where T : IComparable
	{
		public static void InsertionSort(T[] arr)
		{
			for (int p = 1; p < arr.Length; p++)
			{
				T tmp = arr[p];
				int j = p;

				for (; j > 0 && tmp.CompareTo( arr[j - 1] ) < 0; j--)
					arr[j] = arr[j - 1];
				arr[j] = tmp;
			}
		}

		public static void Shellsort(T[] arr)
		{
			for (int gap = arr.Length / 2; gap > 0; gap = gap == 2 ? 1 : (int)(gap / 2.2))
			{
				for (int i = gap; i < arr.Length; i++)
				{
					T tmp = arr[i];
					int j = i;

					for (; j >= gap && tmp.CompareTo(arr[j - gap]) < 0; j -= gap)
						arr[j] = arr[j - gap];
					arr[j] = tmp;
				}
			}
		}

		/// <summary>
		/// MergeSort started method
		/// </summary>
		/// <param name="arr">array to sort</param>
		public static void MergeSort(T[] arr)
		{
			T[] tmpArr = new T[arr.Length];
			MergeSort(arr, tmpArr, 0, arr.Length - 1);
		}

		/// <summary>
		/// Mergesort with all the necesarry parameters
		/// </summary>
		/// <param name="arr"> array to sort </param>
		/// <param name="tmpArr"> an array to place the merge results </param>
		/// <param name="left"> the left-most index of the subarray </param>
		/// <param name="right"> the right-most index of the subarray </param>
		private static void MergeSort(T[] arr, T[] tmpArr, int left, int right)
		{
			if (left < right)
			{
				int center = (left + right) / 2;
				MergeSort(arr, tmpArr, left, center);
				MergeSort(arr, tmpArr, center + 1, right);
				Merge(arr, tmpArr, left, center + 1, right);
			}
		}

		/// <summary>
		/// Internal method that merges two sorted halves of a subarray
		/// </summary>
		/// <param name="arr"> an array of compratables </param>
		/// <param name="tmpArr"> an array to place the merged result</param>
		/// <param name="leftPos"> the left-most index of the subarray </param>
		/// <param name="rightPos"> the index of the start of the second half </param>
		/// <param name="rightEnd"> the rightmostindex of the subarray </param>
		private static void Merge(T[] arr, T[] tmpArr, int leftPos, int rightPos, int rightEnd )
		{
			int leftEnd = rightPos - 1;
			int tmpPos = leftPos;
			int numElements = rightEnd - leftPos + 1;

			// main loop
			while (leftPos <= leftEnd && rightPos <= rightEnd)
			{
				if (arr[leftPos].CompareTo(arr[rightPos]) <= 0)
				{
					tmpArr[tmpPos++] = arr[leftPos++];
				}
				else
				{
					tmpArr[tmpPos++] = arr[rightPos++];
				}
			}

			while (leftPos <= leftEnd) // copy rest of first half
			{
				tmpArr[tmpPos++] = arr[leftPos++];
			}

			while(rightPos <= rightEnd) // copy rest of right half
			{
				tmpArr[tmpPos++] = arr[rightPos++];
			}

			for (int i = 0; i < numElements; i++, rightEnd--)
			{
				arr[rightEnd] = tmpArr[rightEnd];
			}
		}

		public static void QuickSort(T[] arr)
		{
			QuickSort(arr, 0, arr.Length - 1);
		}

		private static void QuickSort(T[] arr, int low, int high)
		{
			int CUTOFF = 2;
			if (low + CUTOFF > high)
			{
				//TODO: fix sort
				//InsertionSort(arr, low, high);
			}
			else
			{
				// sort low, middle, high
				int middle = (low + high) / 2;
				if (arr[middle].CompareTo(arr[low]) < 0)
				{
					// SwapReference(arr, low, middle);
				}
				if (arr[high].CompareTo(arr[low]) < 0)
				{
					// SwapReference(arr, low, high);
				}
				if (arr[high].CompareTo(arr[middle]) < 0)
				{
					// SwapReference(arr, middle, high );
				}

				// place pivot at position high - 1
				//SwapReference(a, middle, high - 1)
				T pivot = arr[high - 1];

				int i, j;
				for(i = low, j = high-1; ;)
				{
					while (arr[++i].CompareTo(pivot) < 0)
						;
					while (pivot.CompareTo(arr[--j]) < 0)
						;
					if (i >= j)
						break;
					// SwapReference(arr, i, j)
				}

				// Restor pivot
				QuickSort(arr, low, i - 1); // Sort small elements
				QuickSort(arr, i + 1, high); // sort large elements
			}
		}
	}
}
