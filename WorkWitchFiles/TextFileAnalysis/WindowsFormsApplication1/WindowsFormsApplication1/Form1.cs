using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        String name = "cont.txt";//Ім'я текстового файлу.
        private void button1_Click(object sender, EventArgs e)
        {
            String s1;
            int i, c;
            FileStream fs = File.Create(name);//Створюємо потік, а у ньомку створюємо файл.
            StreamWriter SW = new StreamWriter(fs);//Створюємо засіб запису до файлу.

            for (i = 0; i < 6; i++)
            {
                s1 = "as df gr";//Цей текст  записуємо до файлу.
                SW.WriteLine(s1);/*fs.Write(s1,0,s1.Length); інша команда запису
                із вказанням номерів першого і останнього символів у рядку.*/
                //SW.
            }
            SW.Close();//Закрили текстовий файл.
            c=0;
            s1 = "   ";
            StreamReader str = new StreamReader(name);
            //*Створюємо засіб читання з файлу, відкриваємо файл для читання з нього.
            str=File.OpenText(name);
            
            while ((s1=str.ReadLine())!=null)//Доки не дійшли до кінця файлу, читаємо рядки з нього.
            {
                    c++;
                    listBox1.Items.Add(s1 +" "+Convert.ToString(c));
                    if (s1.Substring(0, 2) == "as")//Якщо перші два символи рядка s1 - це as.
                        listBox2.Items.Add("as");
            }
             str.Close();
             label3.Text="Number of lines in file is "+Convert.ToString(c);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}