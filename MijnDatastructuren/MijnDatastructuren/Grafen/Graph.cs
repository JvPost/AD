using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnDatastructuren.Grafen
{
	public class Graph : IGraph
	{
		public static readonly double INFINITY = double.MaxValue;
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

		private void ClearAll()
		{
			foreach (var v in _vertexMap)
				v.Value.Reset();
		}


		/// <summary>
		/// Recursive routine to print shortest path to dest
		/// after running shortest path algorith,. The path
		/// is known to exist.
		/// </summary>
		/// <param name="destination"></param>
		private void PrintPath(IVertex destination)
		{
			if (destination.Prev != null)
			{
				PrintPath(destination.Prev);
				Console.Write(" to ");
			}
			Console.Write(destination.Name);
		}
		
		/// <summary>
		/// Driver routine to handle unreachables and print total cost.
		/// It calls recursive routine to print shortest path to
		/// destNode after a shortest path algorithm has run.
		/// </summary>
		/// <param name="destName"></param>
		public void PrintPath(string destName)
		{
			Vertex w = _vertexMap[destName];
			if (w == null)
				throw new KeyNotFoundException();
			else if (w.Dist == INFINITY)
				Console.WriteLine($"{destName} is unreachable.");
			else
			{
				Console.WriteLine($"(Cost is {w.Dist})");
				PrintPath(w);
				Console.WriteLine();
			}
		}

		public void UnWeighted(string startName)
		{
			ClearAll();

			Vertex start = _vertexMap[startName];
			if (start == null)
				throw new KeyNotFoundException("Start vertex not found.");

			Queue<Vertex> q = new Queue<Vertex>();
			q.Enqueue(start);
			start.Dist = 0;

			while (q.Any())
			{
				Vertex v = q.Dequeue();
				foreach (Edge e in v.Adjecent)
				{
					Vertex w = e.Dest;
					if (w.Dist == INFINITY)
					{
						w.Dist = v.Dist + 1;
						w.Prev = v;
						q.Enqueue(w);
					}
				}
			}
		}
		
		/// <summary>
		/// Single-source weighted shortest-path algorithm
		/// </summary>
		/// <param name="startName"></param>
		public void Dijkstra(string startName)
		{
			PriorityQueue<Path> pq = new PriorityQueue<Path>();

			IVertex start = _vertexMap[startName];
			if (start == null)
				throw new KeyNotFoundException("Start vertex not found.");

			ClearAll();
			pq.Add(new Path(start, 0));
			start.Dist = 0;

			int nodesSeen = 0;
			while (!pq.IsEmpty() && nodesSeen < _vertexMap.Count())
			{
				Path vrec = pq.Remove();
				IVertex v = vrec.Dest;
				if (v.Scratch != 0)
					continue;

				v.Scratch = 1;
				nodesSeen++;

				foreach (Edge e in v.Adjecent)
				{
					IVertex w = e.Dest;
					double cvw = e.Cost;

					if (cvw < 0)
						throw new GraphException("Graph has negative edges.");
					if (w.Dist > (v.Dist + cvw))
					{
						w.Dist = v.Dist + cvw;
						w.Prev = v;
						pq.Add(new Path(w, w.Dist));
					}
				}
			}
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

	public class GraphException : Exception
	{
		public GraphException(string message) : base(message) { }
	}
}
