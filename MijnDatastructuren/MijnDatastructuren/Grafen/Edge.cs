using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Grafen
{
	public class Edge
	{
		public Vertex Dest { get; set; }
		public double Cost { get; set; }

		public Edge(Vertex destination, double cost)
		{
			Dest = destination;
			Cost = cost;
		}
	}
}
