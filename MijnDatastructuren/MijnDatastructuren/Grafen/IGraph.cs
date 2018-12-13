using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Grafen
{
	interface IGraph
	{
		Vertex GetVertex(string name);
		void AddEdge(string source, string destination, double cost);
		string ToString();
		
	}
}
