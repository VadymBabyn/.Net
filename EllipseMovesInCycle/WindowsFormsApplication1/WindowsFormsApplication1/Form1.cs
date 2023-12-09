using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
/*Програмуємо рух еліпса під кутом до координатних осей екрану.
Використовуємо цикл. Для затримки на екрані зображень, які малюємо власним кольором, а потім, для стирання, кольором фону
додаємо до списку бібліотек останню в ньому - System.Threading.
Це дозволить записувати процедуру в циклі Thread.Sleep(t), 
де в дужках - час затримки (у мілісекундах) перед виконанням наступної команди.*/
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
            int xinit, xend, x, yinit, y, w, h, dx,dy; /*У списку - стартові координати xinit, yinit лівого верхнього кута прямокутника,
            до якого вписано еліпс, поточні координати цього кута x,y, ширина цього прямокутника w та його висота h;
            довжини кроку, на які пересувається зображення dx та dy. Всі вхідні дані введемо з текстових вікон.*/
            Graphics g = CreateGraphics();

            this.BackColor = Color.White;
            xinit = int.Parse(textBox1.Text);
            xend= int.Parse(textBox2.Text);
            yinit= int.Parse(textBox3.Text);
            dx= int.Parse(textBox5.Text);
            dy = int.Parse(textBox6.Text);
            w= int.Parse(textBox7.Text);
            h= int.Parse(textBox8.Text);
            y = yinit;
            for(x= xinit;x<= xend;x+= dx)
            {
                g.DrawEllipse(Pens.Black, x, y, w, h);
                Thread.Sleep(200);
                //g.DrawEllipse(Pens.White, x, y, w, h);
                /*Цю команду можна замінити наступною - Refresh():
                замість малювання еліпса кольором фону можна просто стерти його командою очищення екрану 
                від малюнків, створених МЕТОДАМИ (елементи управління не стираються!).*/
                Refresh();
                y += dy;//Цикл написано по x, тому значення y треба змінювати в циклі окремою командою.
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}