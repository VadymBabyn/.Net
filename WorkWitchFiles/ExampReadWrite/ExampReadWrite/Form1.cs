﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ExampReadWrite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*ТЕКСТОВИЙ ФАЙЛ - послідовність символів, яка має ім'я та розширення і зберігається на фізичному носії.
         * Розширення таких файлів - txt. Від файлів Word із розширенням docx вони відрізняються 
         * кількістю доступних символів (текстовий формат - як правило, 256 символів), обсягом пам'яті на символ (1 байт).
         * Із цими файлами можна виконувати три основні операції: ЗАПИС до них (копіювання до файлу значень зовнішніх змінних),
         * ЧИТАННЯ з них (ТІЛЬКИ послідовне, крок за кроком, від початку до кінця файлу; це копіювання 
         * записаних у файлі значень до зовнішніх змінних; 
         * перескакування через змінні та повернення до прочитаного раніше - НЕМОЖЛИВІ!)
         * та ДОЗАПИС до файлу.
         * Всі ці режими НЕСУМІСНІ один із одним: можна або читати з файлу, або записувати до нього, або дописувати до нього. 
         * Різниця між записом та дозаписом суттєва: якщо відкрити для ЗАПИСУ файл, де раніше було щось записане,
         * все записане буте стерте, вказівник запису буде встановлений на початку файлу.
         * ПРИ ДОЗАПИСУ записане раніше не стирається, вказівник встановлюється у кінці файлу.
         * Всі рядки текстового файлу автоматично завершуються символом, що визначає кінець рядка. 
         * Якщо цей рядок у файлі останній, після символа кінця рядка автоматично додається символ кінця файлу.
         * Якщо ж рядок не останній, то після символа кінця рядка 
         * автоматично додається символ переведення курсору на наступний рядок.
         *  У проекті описано методи створення текстового файлу (ТФ), запису до нього, читання з нього.
         Використано ТРИ методи запису та аналогічні ним методи читання. 
         * УВАГА!
         1. Деякі коди закоментовано через  несумісність різних методів запису між собою
         і аналогічно - різних методів читання.
         2. Запис та читання, описані нижче, виконано різними методами.
         3. Коди відділено від рядків коментарів порожніми рядками.
         4. Щоб переглянути, як працює будь-який із вказаних трьох засобів, інші засоби слід закоментувати!!!*/
        private void button1_Click(object sender, EventArgs e)
        {
            string s1, s2, fln, path;
            int c, i, j;

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            c = int.Parse(textBox1.Text);
            fln = textBox2.Text;//Задаємо ім'я і розширення файла.

            path = System.IO.Path.GetFullPath(fln);//Визначаємо повний шлях до файла по його імені та розширенню.

           /* string[] createText = { "Hello", "And", "Welcome" };//Задаємо масив рядків для запису до файлу...
            File.WriteAllLines(path, createText);//і записуємо до нього весь цей масив.
            це - перший спосіб запису до файлу.*/
            //ДРУГИЙ СПОСІБ.
            //string  "Hello and Welcome" + Environment.NewLine;//Створюємо текст  для запису до файлу.
            //Клас Environment надає інформацію про поточне середовище та платформу, засоби для управління ними. 
            //File.WriteAllText(path, createText1);//Заносимо до файлу текст, заданий попередньою командою.*/
           /*Такий другий спосіб запису до файлу.

            ЧОМУ ЦЕЙ СПОСІБ ЗАКОМЕНТОВАНО??!!
            ТОМУ, ЧТО БУДЬ-ЯКИЙ ІЗ ТРЬОХ СПОСОБІВ НЕСУМІСНИИЙ ІЗ БУДЬ-ЯКИМ ІНШИМ!
            У ДАНОМУ ОБРОБНИКУ ПОДІЇ МОЖНА ПРАЦЮВАТИ ТІЛЬКИ З ОДНИМ ІЗ НИХ - ЗАКОМЕНТУВАВШИ ІНШІ ДВА!!
            У процедурах WriteAllLines, WriteAllText може бути і третій параметр: він задає кодування тексту.
             Наприклад, Encoding.UTF8. Якщо такого параметра немає - формат за умовчанням текстовий.
            
            Тепер запишемо до файлу кілька рядків (ТРЕТІЙ спосіб запису до нього).
            Для цього використовуємо потоковий засіб запису - StreamWriter. 
            Його параметр - потокова змінна fs.*/
          
            FileStream fs = File.Create(fln);//Створюємо потокову змінну для роботи з файлом.
            StreamWriter SW = new StreamWriter(fs);
            for (i = 0; i < c; i++)
            {
                //Далі -команда введення тексту та команда його запису до файлу.
                s1 = Microsoft.VisualBasic.Interaction.InputBox("");
                SW.WriteLine(s1);//ВАЖЛИВО!!! БУДЬ-ЯКИЙ запис - копіювання до файлу  значень зовнішніх змінних!!!
            }
            /*Запис завершено - закриваємо файл для запису. Таке закриття не потрібне для інших
            засобів запису: після їх команд файл автоматично закриється!*/
            
            SW.WriteLine("Hello");
            SW.Close();
            /*Читання з файлу.
             * Приведемо три засоби - аналоги відповідних засобів запису до файлі.
             * ЯК І ПРИ ЗАПИСУ, ВСІ ЦІ ЗАСОБИ - НЕСУМІСНІ ОДИН З ОДНИМ:
             * МОЖНА ВИКОРИСТОВУВАТИ ТІЛЬКИ ОДИН ІЗ НИХ!!
             * 
             * Почнемо з аналогу першого способу запису. 
             * Тут файл автоматично читається (КОПІЮЄТЬСЯ!) до масиву,
             всі елементи цього масиву виводяться в окремі рядки вікна списку.*/

            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
                listBox2.Items.Add(s);
            /*Аналог другого засобу запису.
                      * Тут файл автоматично читається до змінної readText1
                        і з неї виводиться до вікна списку.*/
            Convert.ToBase64CharArray(Array2[i]);
            //string readText1 = File.ReadAllText(path);
            //listBox2.Items.Add(readText1);

            /*Аналог третього засобу запису.
             *Створюємо потоковий засіб ЧИТАННЯ з файлу.*/

            //j = 0;//j - Лічильник кількості рядків.
            //using (StreamReader sr = new StreamReader(fs))
            //{
            //  while (sr.Peek() >= 0)// Або ж while (sr.Peek() >-1)
            /*sr.Peek() читає кожний наступний символ і при цьому тільки визначає, чи досягнуто 
             * кінець файлу: файл закінчується символом, який визначає кінець рядка.*/
            //Це важливо при читанні з файлу, якщо кількість рядків у файлі нам не відома. 
                {
                   /*s2 = sr.ReadLine();//Читаємо черговий рядок - копіюємо його з файлу до змінної s2.
                    Всі прочитані рядки виводимо до вікна списку.
                    listBox2.Items.Add(s2);
                    j++;*/
                }
                //Після циклу можна вивести значення j.
                //Читання завершене - закриваємо файл.
                //sr.Close();
            }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        }
    }
