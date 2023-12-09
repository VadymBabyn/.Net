using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _14._3
{
    internal class Program
    {
        public static void Print(HashSet<int> a)//Ф-ція просто для виводу множин
        {
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var a = new HashSet<int>()//Створення множини а з елементими
            {1,2,3,4,5,6,7,8};
            var b = new HashSet<int>()//Створення множини b з елементими
            {3, 4, 5, 2, 1, 10, 11, 12};
            var c = a.ToHashSet();//В змінну c копіюється множина а
            Print(c);
            Console.WriteLine("Множина а");
            Print(a);//Вивід множин за допомоги ф-ці Print
            Console.WriteLine("Множина b");
            Print(b);//Вивід множин за допомоги ф-ці Print
            //Перетин множин a i b
            Console.WriteLine("\nПеретин множин a i b");
            a.IntersectWith(b);//Тут знаходиться перетин множини а і б тобто всі спільні значення
            Print(a);
            a = c.ToHashSet();//Перезапис множини а тому що вона записала в себе множини які перетнулися для того і потрібно перезаписувати
            //Обєднання множин а і б
            Console.WriteLine("\nОбєднання множин а і b");
            a.UnionWith(b);//Тут обєднуються множити в результаті вийде що вісі елементи візмуться тільик 1 раз
            Print(a);
            a = c.ToHashSet();//Перезапис множини а тому що вона записала в себе множини які обєдналися
            //Різниця множини а і б
            Console.WriteLine("\nРізниця множини а і b");
            a.ExceptWith(b);//Тут від множини а віднімається спільні елементи множини b і записується тільке те чого немає в множині b а є в множині a
            Print(a);
            a = c.ToHashSet();//Перезапис множини а тому що вона записала в себе множини різниці
            //Симетрична різниця
            Console.WriteLine("\nСиметрична різниця a i b");
            a.SymmetricExceptWith(b);//Тут беруться ті елементи які є в множині а але нема в b і навпаки
            Print(a);
        }
    }
}
