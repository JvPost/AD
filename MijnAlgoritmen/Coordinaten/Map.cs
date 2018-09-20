using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Coordinaten
{
	public class Coordinates
	{
		public int y { get; set; }
		public int x { get; set; }
		public string Name { get; set; }
	}

	public class Map
	{
		private string[] letters = new string[] {"A", "B","C", "D", "E", "F", "G",
			"H",
			"I", "J","K","L","M","N","O","P","Q","R","S",
			"T","U","V","W","Y","Z" };

		public int[][] MapArray { get; private set; }
		public Coordinates[] Coordinates { get; set; }

		Random rnd = new Random();
		private int _Width;
		private int _Height;

		public Map(int width, int height, int punt_x, int punt_y)
		{
			this._Width = width;
			this._Height = height;


			MapArray = new int[height + 1][];

			int y = 0;
			foreach (var yPoint in MapArray)
			{
				int[] xArr = new int[width + 1];
				for (int x = 0; x <= width; x++)
					xArr[x] = x;
				MapArray[y] = xArr;
				y++;
			}
		}

		public int[][] DrawMap(int punt_x, int punt_y)
		{
			int RandomPointsAmount = rnd.Next(1, 10);
			Coordinates = new Coordinates[RandomPointsAmount];

			// randompoints
			for (int i = 0; i < RandomPointsAmount; i++)
			{
				Coordinates pointToFind = new Coordinates();
				pointToFind.x = rnd.Next(_Width);
				pointToFind.y = rnd.Next(_Height);
				pointToFind.Name = letters[i];
				Coordinates[i] = pointToFind;
			}

			Console.WriteLine("Y");

			int items = (_Width + 1) * (_Height + 1);

			int[][] coords = new int[items][];

			int item = 0;
			for (int y = MapArray.Length - 1; y >= 0; y--)
			{
				// Write y coordinate
				if (y < 10)
					Console.Write($" {y}");
				else
					Console.Write($"{y}");

				Console.Write("\t");

				foreach (var x in MapArray[y])
				{
					coords[item] = new int[2];
					coords[item][0] = x;
					coords[item][1] = y;

					#region
					if (y == punt_y && x == punt_x)
					{
						Console.Write("[X]");
					}
					else if (Coordinates.Any(c => c.x == x && c.y == y))
					{
						Console.Write($"[{Coordinates.Where(c => c.x == x && c.y == y).First().Name}]");
					}
					else
					{
						Console.Write("|_ ");
					}
					#endregion

					item++;
				}

				Console.Write("\n");
			}


			Console.Write("\t");

			// Write x coordinate
			for (int i = 0; i < _Width + 1; i++)
			{
				if (i < 10)
					Console.Write($" {i} ");
				else if (i < 100)
					Console.Write($" {i}");
				else if (i < 1000)
					Console.Write($"{i}");
			}

			Console.WriteLine("\tX\n");
			return coords;
		}

		public int Dichtsbijzijnd(int[][] coords, int x, int y, int max)
		{
			double kortsteAfstand = 0;
			int kortsteAftandIndex = -1;

			int coordIndex = 0;
			foreach (var coord in coords)
			{
				if (Coordinates.Any(c => c.x == coord[0] && c.y == coord[1]))
				{
					double langeXZijde = 0;
					double langeYZijde = 0;

					if (coord[0] > x)
					{
						langeXZijde = coord[0] - x;
					}
					if (coord[0] < x)
					{
						langeXZijde = x - coord[0];
					}
					if (coord[1] > y)
					{
						langeYZijde = coord[1] - y;
					}
					if (coord[1] < y)
					{
						langeYZijde = y - coord[1];
					}

					double afstand = Math.Sqrt(Math.Pow(langeXZijde, 2) + Math.Pow(langeYZijde, 2));
					if ((kortsteAfstand == 0 || afstand < kortsteAfstand))
					{
						kortsteAfstand = afstand;
						kortsteAftandIndex = coordIndex;
					}
				}

				coordIndex++;
			}


			if (kortsteAftandIndex != -1)
			{
				int[] kortsteAfstandCoords = coords[kortsteAftandIndex];
				Console.WriteLine($"Dichtsbijzijnd: {kortsteAfstandCoords[0]}, {kortsteAfstandCoords[1]} met index {kortsteAftandIndex}");
			}

			return kortsteAftandIndex;
		}
	}
}
