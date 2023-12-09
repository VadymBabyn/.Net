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
            String path, filename;
            int n,i;
            n=int.Parse(textBox1.Text);
            filename=textBox2.Text;
            path = System.IO.Path.GetFullPath(filename);//Автоматично визначаємо шлях до файлу по його імені та розширенню.
            string[] createText = new string[n];//Задаємо масив рядків для запису до файлу.
            for (i = 0; i < n;i++ )
            {
                createText[i]=Microsoft.VisualBasic.Interaction.InputBox("");/*Записуємо до цього масиву 
                наступний зміст текстового файлу. Файл автоматично записується до папки Debug проекта. усі рядки файлу   
                попередньо копіюються до listBox1. ІНШИЙ СПОСІБ: можна записати до textBox довгий рядок із пропусками,
             розщепити цей рядок на масив і вводити (копіювати) його елементи до listBox. */
                listBox1.Items.Add(createText[i]);
            }
             File.WriteAllLines(path, createText);//Записали (скопіювали) масив до файлу.
            /*Тепер читаємо елементи з файлу і виводимо (копіюємо) їх до listBox2.*/
             string[] readText = File.ReadAllLines(path);/* Копіюємо всі рядки з файлу до елементів масиву readText. 
             * У кожному елементі масиву - один рядок файлу.*/
             foreach (string s in readText)/*Для контролю копіюємо всі елементи масиву до listBox2. Якщо в обох списках
                 один і той же набір значень, запис та читання виконано вірно. Можна визначити, скільки значень у
                 readText (readText.Count()) і використати звичайний цикл for.*/                            
                listBox2.Items.Add(s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}