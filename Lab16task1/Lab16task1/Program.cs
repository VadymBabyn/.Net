using System;
using System.Collections.Generic;
using System.IO;

namespace lab16
{
    class Program
    {

        static void Main(string[] args)
        {
            //зчитуємо з файлу приклад
            string path = "1.txt";
            var A = new Stack<char>();
            var B = File.ReadAllText(path).ToCharArray();
            int count = 0;
            //шукаємо дужки з масиву з нашого прикладу 
            foreach (var item in B)
            {
                //якщо відкрита дужка то закидуємо в стек
                if (item == '(')
                {
                    A.Push('(');
                }
                //якщо закрита дужка то перевіряємо чи в стеці є її пара
                else if (item == ')')
                {
                    if (A.Contains('('))
                    {
                        A.Pop();
                    }
                    else { Console.WriteLine("There is a balance of parentheses in the given expression"); }
                }

            }
            //якщо все добре то виводиться відповідне повідомлення
            if (A.Count != 0)
            {
                Console.WriteLine("There isn`t a balance of parentheses in the given expression");
            }
            else
            {
                //виводимо сам масив з перерахунком кількості дужок
                Console.WriteLine(B);
                for (int i = 0; i < B.Length; i++)
                {
                    if (B[i] == ')') { count++; Console.WriteLine($"Count of ')' : {count}"); }
                }
            }

        }
    }
}
