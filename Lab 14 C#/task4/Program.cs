using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._4
{
    internal class Program
    {
        public static void Print(Dictionary<string, int> a)//Ф-ція для виводу словника
        {
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;//для укр мови
            Dictionary<string, int> a = new Dictionary<string, int>()//Створення словника
            {
                {"Понеділок", 1},
                {"Вівторок", 2},
                {"Середа", 3},
                {"Четвер", 4},
                {"Пятниця", 5},
                {"Субота", 6}, 
            };
            Print(a);
            //Додавання елемента
            Console.WriteLine("\nДодавання елемента");
            a.Add("Неділя", 7);//Додавання до словника Неділя значення якої 7
            Print(a);
            //Видалення елемента
            Console.WriteLine("\nВидалення елемента");
            a.Remove("Понеділок");//Видалння понеділка з словника
            Print(a);
            //К-сть елементів у словнику
            Console.WriteLine("\nК-сть елементів у словнику");
            var b = a.Count();//К-сть елементів в словнику
            Console.WriteLine(b);
            //Перевірка по ключу
            Console.WriteLine("\nПеревірка по ключу");
            var flag = a.ContainsKey("Четвер");//# Перевірка по ключю Субота якщо True значить такий ключ є в словнику якщо False тоді такого ключа немає
            var flag1 = a.ContainsKey("Понеділок");//
            Console.WriteLine(flag);
            Console.WriteLine(flag1);
            //Перевірка по значенню
            Console.WriteLine("\nПеревірка по значенню");
            flag = a.ContainsValue(5);//#Перевірка по значенню 4 в словнику якщо True значить таке значення є в словнику якщо False тоді такого значення нема
            flag1 = a.ContainsValue(10);//
            Console.WriteLine(flag);
            Console.WriteLine(flag1);
            //Очищення словника
            Console.WriteLine("\nОчищення словника");
            a.Clear();//Очищає словник повністю
            Print(a);
        }
    }
}
