using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Grafen
{
	public class Path : IComparable
	{
		public IVertex Dest { get; set; }
		public double Cost { get; set; }

		public Path(IVertex dest, double cost)
		{
			Dest = dest;
			Cost = cost;
		}
		
		public int CompareTo(object obj)
		{
			Path other = (Path)obj;
			double otherCost = other.Cost;
			return Cost < otherCost ? -1 : Cost > otherCost ? 1 : 0;
		}

		public override string ToString()
		{
			return Dest.ToString();
		}
	}
}
