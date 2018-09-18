using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinaten
{

	class Program
	{
		static void Main(string[] args)
		{
			Map map = new Map(20, 20);
			map.DrawMap();
			Console.ReadLine();
		}
	}
}
