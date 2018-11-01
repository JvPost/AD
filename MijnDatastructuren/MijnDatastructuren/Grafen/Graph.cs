using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Grafen
{
	public class Graph : IGraph
	{
		public static readonly double INFINITY = -1;
		Dictionary<string, Vertex> _vertexMap = new Dictionary<string, Vertex>();

		public void AddEdge(string source, string destination, double cost)
		{
			Vertex v = GetVertex(source);
			Vertex w = GetVertex(destination);
			v.Adjecent.Add(new Edge(w, cost));
		}

		public Vertex GetVertex(string name)
		{
			Vertex v;
			try
			{
				v = _vertexMap[name];
			}
			catch (KeyNotFoundException)
			{
				v = new Vertex(name);
				_vertexMap.Add(name, v);
			}

			if (v == null)
			{
				throw new Exception( "could not add vertex" );
			}
			return v;
		}

		public override string ToString()
		{
			string str = "";
			for (int i = 0; i < _vertexMap.Count; i++)
			{
				string iStr = $"v{i}";
				str += $"{_vertexMap[iStr].ToString()}\n";
			}
			return str.ToUpper();
		}
	}
}
