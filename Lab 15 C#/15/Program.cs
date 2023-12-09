using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15
{
    internal class Program
    {
        static void Main()
        {

            Console.WriteLine("Виберiть: \n1.Робота з однозвязним списком \n2.Робота з двозвяним списком");
            LinkedList<string> studentss = new LinkedList<string>();
            int k = Int32.Parse(Console.ReadLine());
            var Device = new List<string> { "234A", "432", "143", "143B", "243Online" }; 
            LinkedList<string> devices = new LinkedList<string>(Device);
            if (k == 1)
            {
                Console.WriteLine("\nФормування та перегляд списку:");
                foreach (string device in devices)
                {
                    Console.WriteLine(device);
                }

                Console.WriteLine("\nКiлькiсть елементiв - " + devices.Count);
                string isEmpty;
                if (devices.Count == 0)
                {
                    isEmpty = "True";

                }
                else isEmpty = "False";
                Console.WriteLine("\nПеревiрка на вiдсутнiсть - " + isEmpty);


                Console.WriteLine("\nВставка на початок -");
                devices.AddFirst("111");
                foreach (var device in devices)
                {
                    Console.WriteLine(device);
                }
                Console.WriteLine("\nВставка на кiнець - ");
                devices.AddLast("666");
                foreach (var device in devices)
                {
                    Console.WriteLine(device);
                }

                Console.WriteLine("\nВставка пiсля - ");
                devices.AddAfter(devices.Find("111"), "543");
                foreach (var device in devices)
                {
                    Console.WriteLine(device);
                }
                Console.WriteLine("\nВидалення конкретного елемента за iндексом (першого) - ");
                devices.Remove(devices.First());
                foreach (var device in devices)
                {
                    Console.WriteLine(device);
                }
                Console.WriteLine("\nВидалення конкретного елемента за значенням (OS) - ");
                devices.Remove("432");
                foreach (var device in devices)
                {
                    Console.WriteLine(device);
                }
                Console.WriteLine("\nВидалення всiх елементiв - виконано");
                devices.Clear();
                devices.AddFirst("111");
                devices.AddFirst("123");
                devices.AddFirst("234");
                devices.AddFirst("345");
                foreach (var device in devices)
                {
                    Console.WriteLine(device);
                }

                Console.WriteLine("\nРедагування списку: \n1.Видалення(за значенням)\n2.Вставка(на початок)\n3.Замiна(за значенням останнього елемента)");
                int n = Int16.Parse(Console.ReadLine());
                if (n == 1)
                {
                    devices.Remove(Console.ReadLine());

                }
                else if (n == 2)
                {
                    devices.AddFirst(Console.ReadLine());

                }
                else if (n == 3)
                {
                    devices.Last.Value = Console.ReadLine();

                }
                Console.WriteLine();
                foreach (var device in devices)
                {
                    Console.WriteLine(device);
                }
                Console.WriteLine("\nЗамiна елементiв списку - ");
                devices.Find("123").Value = Console.ReadLine();
                Console.WriteLine();
                foreach (var device in devices)
                {
                    Console.WriteLine(device);
                }
                Console.WriteLine("\nПошук елементiв - ");
                string search = Console.ReadLine();
                foreach (var device in devices)
                {
                    if (search == device)
                    {
                        Console.WriteLine("Present in list");
                    }

                }
                Console.WriteLine("\nСортування - ");
                List<string> Devices = new List<string>();
                foreach (var device in devices)
                {
                    Devices.Add(device);
                }
                Devices.Sort();
                foreach (var device in Devices)
                {
                    Console.WriteLine(device);
                }
                Console.WriteLine("\nЗбереження у файл - виконано");
                File.AppendAllLines(@"C:\Users\vadim\Desktop\пкпз\Lab 15\15\Lab 15 C#\15\result.txt", Devices);
                Console.WriteLine("\nЗчитати файл - ");
                string[] file = File.ReadAllLines(@"C:\Users\vadim\Desktop\пкпз\Lab 15\15\Lab 15 C#\15\result.txt");
                for (int i = 0; i < file.Length; i++)
                {
                    Console.WriteLine(file[i]);
                }
            }
            else if (k == 2)
            {

                DoublyLinkedList<string> students = new DoublyLinkedList<string>();

                students.Add("SamsungS10");
                students.AddFirst("Iphone11");
                students.Add("MotorolaE7");
                students.Add("Xiaomi9A");
                students.Add("SamsungNote10");

                Console.WriteLine("\nФормування та перегляд списку:");
                foreach (var student in students)
                {
                    studentss.AddFirst(student);
                    Console.WriteLine(student);
                }
                Console.WriteLine("\nКiлькiсть елементiв - " + students.Count);
                Console.WriteLine("\nПеревiрка на вiдсутнiсть - " + students.IsEmpty);
                Console.WriteLine("\nВставка на початок -");
                students.AddFirst("Iphone13ProMax");
                foreach (var student in students)
                {

                    Console.WriteLine(student);
                }
                Console.WriteLine("\nВставка на кiнець - ");
                studentss.AddLast("BBC");
                foreach (var student in studentss)
                {
                    Console.WriteLine(student);
                }
                Console.WriteLine("\nВставка пiсля - ");
                studentss.AddAfter(studentss.Find("SamsungNote10"), "XiaomiMi11");
                foreach (var student in studentss)
                {
                    Console.WriteLine(student);
                }
                Console.WriteLine("\nВидалення конкретного елемента за iндексом (першого) - ");
                studentss.Remove(studentss.First());
                foreach (var student in studentss)
                {
                    Console.WriteLine(student);
                }
                Console.WriteLine("\nВидалення конкретного елемента за значенням (Liverpul) - ");
                studentss.Remove("SamsnungA53");
                foreach (var student in studentss)
                {
                    Console.WriteLine(student);
                }
                Console.WriteLine("\nВидалення всiх елементiв - виконано");
                studentss.Clear();
                studentss.AddFirst("Redmi9");
                studentss.AddFirst("Samsung A04");
                studentss.AddFirst("Iphone7");
                studentss.AddFirst("SamsungM32");
                foreach (var student in studentss)
                {
                    Console.WriteLine(studentss);
                }
                Console.WriteLine("\nРедагування списку: \n1.Видалення(за значенням)\n2.Вставка(на початок)\n3.Замiна(за значенням останнього елемента)");
                int l = Int16.Parse(Console.ReadLine());
                if (l == 1)
                {
                    studentss.Remove(Console.ReadLine());

                }
                else if (l == 2)
                {
                    studentss.AddFirst(Console.ReadLine());

                }
                else if (l == 3)
                {
                    studentss.Last.Value = Console.ReadLine();

                }
                Console.WriteLine();
                foreach (var student in studentss)
                {
                    Console.WriteLine(student);
                }
                Console.WriteLine("\nЗамiна елементiв списку - ");
                studentss.Find("SamsungM32").Value = Console.ReadLine();
                Console.WriteLine();
                foreach (var student in studentss)
                {
                    Console.WriteLine(student);
                }
                Console.WriteLine("\nПошук елементiв - ");
                string search_ = Console.ReadLine();
                foreach (var student in studentss)
                {
                    if (search_ == student)
                    {
                        Console.WriteLine("Present in list");
                    }

                }
                Console.WriteLine("\nСортування - ");
                List<string> Studentss = new List<string>();
                foreach (var student in studentss)
                {
                    Studentss.Add(student);
                }
                Studentss.Sort();
                foreach (var Student in Studentss)
                {
                    Console.WriteLine(Student);
                }
                Console.WriteLine("\nЗбереження у файл - виконано");
                File.AppendAllLines(@"C:\Users\vadim\Desktop\пкпз\Lab 15\15\Lab 15 C#\15\result2.txt", Studentss);
                Console.WriteLine("\nЗчитати файл - ");
                string[] file_ = File.ReadAllLines(@"C:\Users\vadim\Desktop\пкпз\Lab 15\15\Lab 15 C#\15\result2.txt");
                for (int i = 0; i < file_.Length; i++)
                {
                    Console.WriteLine(file_[i]);
                }
            }
        }
    }
}
