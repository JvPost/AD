using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Hashing
{
	public static class HashFunctions
	{
		public static int Hash(string key, int tableSize)
		{
			int hashVal = 0;
			for (int i = 0; i < key.Length; i++)
			{
				int k = key[i];
				hashVal = (hashVal * 128 + k) % tableSize;
			}
			return hashVal;
		}
	}
}
