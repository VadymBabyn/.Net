using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

//Починаємо роботу з текстовими файлами в C#. Це файли з розширенням .txt, а не документи Word із розширенням .docx! 
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
            string s1, s2, fl1;
            int i, j, k;
            
            //fl1 - ім'я файлу, створюваного у даному проекті!
            fl1 = textBox1.Text;
            k = int.Parse(textBox2.Text);
            //Файл створюється й обробляється у потоці (FileStream).
            FileStream fs = File.Create(fl1);
            //Переходимо до запису до файлу. РЕЖИМИ ЧИТАННЯ Й ЗАПИСУ - НЕСУМІСНІ!!!
            //У потоці найменший блок запису до файлу та читання з нього - рядок. 
            StreamWriter SW = new StreamWriter(fs);/*Цей об'єкт відкриває можливість
            запису до нового файлу. Він, як бачите, робить це через FileStream.*/
            for (i = 0; i < k; i++)
            {
                //Далі -команда введення тексту та команда його запису до файлу.
                s1 = Microsoft.VisualBasic.Interaction.InputBox("");
                SW.WriteLine(s1);
            }
            //Запис завершено - закриваємо файл для запису
            SW.Close();
            //і створюємо потоковий засіб ЧИТАННЯ з файлу.
            j = 0;
            using (StreamReader sr = new StreamReader(fl1))/*А це - об'єкт для читання з файлу.*/
            {
                while (sr.Peek() >= 0)// Або sr.Peek()>-1.
            /*sr.Peek() читає один за другим усі символи файлу, але при цьому визначає тільки одне:
             * чи досягнуто кінець файлу. Це важливо при читанні нового файлу, де кількість рядків
             * зарані невідома.*/ 
                {
                    s2 = sr.ReadLine();
                    //Усі прочитані рядки виводимо по черзі до вікна списку.
                    listBox1.Items.Add(s2);
                    j++;
                }
                //Читання завершене - закриваємо файл.         
            }         
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
