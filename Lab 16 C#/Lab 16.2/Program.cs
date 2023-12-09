using Nito.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lab16_2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var deq = new Deque<int>(array);
            deq.AddToFront(10);
            Console.WriteLine(Str(deq));
            deq.AddToBack(12);
            Console.WriteLine(Str(deq));
            deq.RemoveFromFront();
            Console.WriteLine(Str(deq));
            deq.RemoveFromBack();
            Console.WriteLine(Str(deq));
            Console.WriteLine(deq[0]+"\n");
            Console.WriteLine(deq[deq.Count-1]+"\n");
            Console.WriteLine(deq.Count+"\n");
            deq.Clear();
            Console.WriteLine(deq.Count);

        }
        public static string Str(Deque<int> deq)
        {
            string k = "";
            foreach (var item in deq)
            {
                k += item+"\t";
            }
            return k+"\n\n";
        }
    }
}
