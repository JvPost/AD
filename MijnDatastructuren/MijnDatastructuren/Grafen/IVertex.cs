using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Grafen
{
	public interface IVertex
	{
		string Name { get; set; }
		List<Edge> Adjecent { get; set; }
		double Dist { get; set; }
		IVertex Prev { get; set; }
		int Scratch { get; set; }

		void Reset();
		string ToString();
	}
}
