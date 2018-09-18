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
		public int[][] MapArray { get; private set; }

		private int _Width;
		private int _Height;
		private int MijnY;
		private int MijnX;



		Coordinates RandomTopLeft;
		Coordinates RandomTopRight;
		Coordinates RandomBottomLeft;
		Coordinates RandomBottomRight;

		public Map(int width, int height)
		{
			this._Width = width;
			this._Height = height;
			MijnX = _Width / 2;
			MijnY = _Height / 2;

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

		public void DrawMap()
		{
			Random rnd = new Random();

			RandomTopLeft = new Coordinates();
			RandomTopLeft.x = rnd.Next(MijnX);
			RandomTopLeft.y = rnd.Next(MijnY, MijnY * 2);
			RandomTopLeft.Name = "A";

			RandomTopRight = new Coordinates();
			RandomTopRight.x = rnd.Next(MijnX, 2 * MijnX);
			RandomTopRight.y = rnd.Next(MijnY, 2 * MijnY);
			RandomTopRight.Name = "B";

			RandomBottomLeft = new Coordinates();
			RandomBottomLeft.x = rnd.Next(MijnX);
			RandomBottomLeft.y = rnd.Next(MijnY);
			RandomBottomLeft.Name = "C";

			RandomBottomRight = new Coordinates();
			RandomBottomRight.x = rnd.Next(MijnX, 2 * MijnX);
			RandomBottomRight.y = rnd.Next(MijnY);
			RandomBottomRight.Name = "D";

			for (int y = MapArray.Length - 1; y >= 0; y--)
			{

				if (y < 10)
					Console.Write($" {y}");
				else
					Console.Write($"{y}");

				Console.Write("\t");

				foreach (var x in MapArray[y])
				{
					if (y == MijnY && x == MijnX)
					{
						Console.Write("[M]");
					}
					else if (y == RandomTopLeft.y && x == RandomTopLeft.x)
					{
						Console.Write($"[{RandomTopLeft.Name}]");
					}
					else if (y == RandomTopRight.y && x == RandomTopRight.x)
					{
						Console.Write($"[{RandomTopRight.Name}]");
					}
					else if (y == RandomBottomLeft.y && x == RandomBottomLeft.x)
					{
						Console.Write($"[{RandomBottomLeft.Name}]");
					}
					else if (y ==RandomBottomRight.y && x ==RandomBottomRight.x)
					{
						Console.Write($"[{RandomBottomRight.Name}]");
					}
					else
					{
						Console.Write(" . ");
					}
				}

				Console.Write("\n");
			}


			Console.Write("\t");

			for (int i = 0; i < _Height + 1; i++)
			{
				if (i < 10)
					Console.Write($" {i} ");
				else if (i < 100)
					Console.Write($" {i}");
				else if (i < 1000)
					Console.Write($"{i}");
			}
		}
	}
}
