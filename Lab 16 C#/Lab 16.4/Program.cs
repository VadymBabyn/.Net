using System;
using System.Collections.Generic;

namespace laba_sharp16._4
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
            //вузли
            var a = new GraphVertex("a");
            var b = new GraphVertex("b");
            var c = new GraphVertex("c");
            var d = new GraphVertex("d");
            var e = new GraphVertex("e");
            var f = new GraphVertex("f");
            GraphVertex[] Vertexes = {a, b, c, d, e, f};
            graph.AddVertex(Vertexes);
            //ребра
            graph.AddEdge(1, a, a);
            graph.AddEdge(2, a, b);
            graph.AddEdge(3, a, d);
            graph.AddEdge(4, a, e);
            graph.AddEdge(5, b, c);
            graph.AddEdge(6, b, e);
            graph.AddEdge(7, c, e);
            graph.AddEdge(8, c, f);
            graph.AddEdge(9, e, d);
            graph.AddEdge(10, e, f);
            graph.AddEdge(11, f, f);
            
            Console.WriteLine(graph.AdjacencyMatrix());
            Console.WriteLine(new string('=',100));
            //матриця інцидентності
            Console.WriteLine(graph.Matrix());
            Console.WriteLine(new string('=', 100));
            //список ребер
            Console.WriteLine(graph.ToString());


        }
    }
    
}
