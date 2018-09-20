using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinaten
{

	class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();


			int width = 30;
			int height = width;


			int punt_x = rnd.Next(width);
			int punt_y = rnd.Next(height);


			Map map = new Map(width, height, punt_x, punt_y);

			int[][] coords = map.DrawMap(punt_x, punt_y);
			int max = 10;

			Stopwatch sw = new Stopwatch();

			sw.Start();
			int dichtstBijzijnde = map.Dichtsbijzijnd(coords, punt_x, punt_y, max);
			sw.Stop();
			long timeSpent = sw.ElapsedMilliseconds;

			Console.WriteLine($"items: {(height + 1 )*( width + 1)} => TimeSpent: {timeSpent}");


			Console.ReadLine();
		}
	}
}
