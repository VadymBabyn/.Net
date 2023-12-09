using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace laba_sharp16._4
{
    public class GraphEdge
    {
        public GraphVertex Vertex1 { get; }
        public GraphVertex Vertex2 { get; }
        public int Number { get; }
        public GraphEdge(int number, GraphVertex vertex1, GraphVertex vertex2)
        {
            Number = number;
            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }
    }
    
    public class GraphVertex
    {
        public string Name { get; }
        public GraphVertex(string vertexName)
        {
            Name = vertexName;
        }
        public override string ToString() => Name;
    }
    
    public class Graph
    {
        public List<GraphEdge> Edges { get; }
        public List<GraphVertex> Vertexes { get; }
        public Graph()
        {
            Edges = new List<GraphEdge>();
            Vertexes = new List<GraphVertex>();
        }
        
        public void AddEdge(int number, GraphVertex vertex1, GraphVertex vertex2)
        {
            Edges.Add(new GraphEdge(number, vertex1, vertex2));
        }
        
        public void AddVertex(GraphVertex[] name)
        {
            foreach (var item in name)
            {
                Vertexes.Add(item);
            }
        }
        //матриця суміжності
        public string AdjacencyMatrix()
        {
            string k = "\t\ta\tb\tc\td\te\tf\n";
            var matrix = new int[Vertexes.Count, Vertexes.Count];
            for (int i = 0; i < Vertexes.Count; i++)
            {
                k += $"\t{Vertexes[i].Name}";
                for (int j = 0; j < Vertexes.Count; j++)
                {
                    IEnumerable<GraphEdge> Edd = Edges.Where(x => (x.Vertex1 == Vertexes[i]) && (x.Vertex2 == Vertexes[j]));
                    matrix[i, j] = Edd.Count();
                    k += $"\t{matrix[i, j]}";
                }
                k += "\n";
            }
            return k;
        }
        //матриця інцидентності
        public string Matrix()
        {
            string k = "\t\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\t11\t12\n";
            var matrix = new int[Vertexes.Count, Edges.Count];
            for (int i = 0; i < Vertexes.Count; i++)
            {
                k += $"\t{Vertexes[i].Name}";
                for (int j = 0; j < Edges.Count; j++)
                {
                    if (Edges[j].Vertex1 == Vertexes[i])
                    {
                        matrix[i, j] = -1;
                    }
                    else if (Edges[j].Vertex2 == Vertexes[i])
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                    k += $"\t{matrix[i, j]}";
                }                k += "\n";
            }
            return k;
        }
        // списком ребер
        public override string ToString()
        {
            string k  = "List edges of this graph:\n";
            foreach (var item in Edges)
            {
                k += $"{item.Number})  {item.Vertex1.Name} -->  {item.Vertex2.Name} \n";
            }
            return k;
        }
    }
}
