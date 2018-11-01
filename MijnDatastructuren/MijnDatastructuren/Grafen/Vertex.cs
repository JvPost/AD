using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Grafen
{
	public class Vertex : IVertex
	{
		public string Name { get; set; }
		public List<Edge> Adjecent { get; set; }
		public double Dist { get; set; }
		public Vertex Prev { get; set; }
		public int Scratch { get; set; }

		public Vertex(string name)
		{
			Name = name;
			Adjecent = new List<Edge>();
			Reset();
		}

		public void Reset()
		{
			Dist = Graph.INFINITY;
			Prev = null;
			Scratch = 0;
		}

		public override string ToString()
		{
			string str = $"{Name} --> ";
			
			foreach (var adj in Adjecent)
			{
				str += $"{adj.Dest.Name}({adj.Cost}) ";
			}

			return str;
		}
	}
}
