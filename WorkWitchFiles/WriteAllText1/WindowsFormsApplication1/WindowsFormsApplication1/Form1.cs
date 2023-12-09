using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string  fln, path,s1,s2="";
            int c=0, n,i;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            fln = textBox1.Text;//Задаємо ім'я й розширення файлу.
            path = System.IO.Path.GetFullPath(fln);//Визначаємо повний шлях до файлу по його імені й розширенню.
            s1= textBox2.Text;//Читаємо довге слово, яке розщепимо до масиву; елементи масиву стануть рядками файлу.
            File.WriteAllText(path,s1);
            listBox1.Items.Add(s1);
            /*У процедурах WriteAllLines, WriteAllText може бути і третій параметр: він задає кодування тексту.
             Наприклад, Encoding.UTF8, формат UniCode. Якщо такого параметра немає - формат за умовчанням текстовий.*/
            /*Тут  ВЕСЬ ТЕКСТ файлу автоматично читається (копіюється) до змінної readText і з неї виводиться до вікна списку.*/
             s2 = File.ReadAllText(path);
             listBox2.Items.Add(s2);;
        }
                private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
/*ЗАСТЕРЕЖЕННЯ! WriteAllText, ReadAllText коректно працюють із файлом, який містить ОДИН рядок!
Тому пропоную працювати з ReadAllLines, WriteAllLines.*/