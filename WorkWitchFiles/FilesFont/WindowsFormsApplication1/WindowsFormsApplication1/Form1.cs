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
using Microsoft.VisualBasic;

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
            int i, n;
            string[] sin, sout;
            string filename,path;
            filename = textBox1.Text;
            path=Path.GetFullPath(filename);//Визначаємо повний шлях до файлу за його іменем і розширенням на даному віртуальному диску.
            n = int.Parse(textBox2.Text);
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            sin = new string[n];
            sout=new string[n];
            for (i=0;i<sin.Length;i++)
            {
                sin[i] = Interaction.InputBox("");
                listBox1.Items.Add(sin[i]);
            }
            File.WriteAllLines(path, sin);//Записуємо (копіюємо за значеннями) елементи введеного масиву до текстового файлу.
            sout=File.ReadAllLines(path);//Читаємо (копіюємо за значеннями) рядки з текстового фау до іншого масиву.
            for (i = 0; i < sout.Length; i++)
                listBox2.Items.Add(sout[i]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
