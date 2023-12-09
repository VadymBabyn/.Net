namespace завдання_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text=="" || textBox3.Text=="" || textBox7.Text == "")
                MessageBox.Show("Заповніть поля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                char[] zifri = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                int kilzif = 0;
                string nim = textBox2.Text;
                for (int i = 0; i < nim.Length; i++)
                {
                    for (int j = 0; j < zifri.Length; j++)
                    {
                        if (nim[i] == zifri[j])
                            kilzif++;
                    }
                }
                if (kilzif == nim.Length)
                {
                    string city = textBox1.Text;
                    int num = Convert.ToInt32(textBox2.Text);
                    string endcity = textBox7.Text;
                    string distance = textBox3.Text;
                    Itinerary itineraty = new Itinerary (city, endcity, num, distance);
                    itineraty.Add();
                }
                else MessageBox.Show("Некоректно заповненне поле \"Номер рейсу\"", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string city = textBox1.Text;
            int num =0;
            string distance = textBox3.Text;
            string endcity = textBox7.Text;
            Itinerary itineraty = new Itinerary(city, endcity, num, distance);
            itineraty.search();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            string v = File.ReadAllText("C:/Users/pimoc/Desktop/labs and dz 2 kurs/ПКПЗ/лаба 13 C#/с#/лр 13 — копия/завдання 1/завдання 1/база.txt");
            string[] s = v.Split("\n");
            for (int i=0; i<s.Length-1; i++)
            {
                string[] s1 = s[i].Split(";");
                textBox4.Text += s1[0] + "\r\n";
                textBox8.Text += s1[1] + "\r\n";
                textBox5.Text += s1[2] + "\r\n";
                textBox6.Text += s1[3] + "\r\n";
            }

            string[] cityarr = textBox4.Text.Split("\r\n");
            string[] numarr = textBox5.Text.Split("\r\n");
            string[] distancearr = textBox6.Text.Split("\r\n");
            string[] endcityarr = textBox8.Text.Split("\r\n");
            for (int i=0; i<s.Length-1; i++)
            {
                for(int j=0; j<s.Length-2; j++)
                {
                    if (cityarr[i] != "" && numarr[i] != "" && distancearr[i] != "")
                    {
                        if (Convert.ToInt32(numarr[j]) > Convert.ToInt32(numarr[j + 1]))
                        {
                            string rnum = numarr[j];
                            string rcity = cityarr[j];
                            string rtype = distancearr[j];
                            string etype = endcityarr[j];
                            numarr[j] = numarr[j + 1];
                            numarr[j + 1] = rnum;
                            cityarr[j] = cityarr[j + 1];
                            cityarr[j + 1] = rcity;
                            distancearr[j] = distancearr[j + 1];
                            distancearr[j + 1] = rtype;
                            endcityarr[j] = endcityarr[j + 1];
                            endcityarr[j + 1] = etype;
                        }
                    }
                      
                }
            }
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            StreamWriter p = new StreamWriter("C:/Users/pimoc/Desktop/labs and dz 2 kurs/ПКПЗ/лаба 13 C#/с#/лр 13 — копия/завдання 1/завдання 1/база.txt", false);
            for (int i = 0; i < s.Length; i++)
            {
                if(cityarr[i]!="" && numarr[i]!="" && distancearr[i]!="")
                {
                    p.Write(cityarr[i] + ";" + endcityarr[i] + ";"+ numarr[i] + ";" + distancearr[i] + "\n");
                    textBox4.Text += cityarr[i] + "\r\n";
                    textBox5.Text += numarr[i] + "\r\n";
                    textBox6.Text += distancearr[i] + "\r\n";
                    textBox8.Text += endcityarr[i] + "\r\n";
                }
            }
            p.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public struct Itinerary /*: /*IComparable<Itinerary>*/
    {
        public string city;
        public string endcity;
        public int num;
        public string distance;

        public Itinerary ( string nam, string endcty, int nom,string tip)
        {
            city= nam;
            endcity= endcty;   
            num= nom;
            distance= tip;
        }
        public void Add()
        {

            StreamWriter p = new StreamWriter("C:/Users/pimoc/Desktop/labs and dz 2 kurs/ПКПЗ/лаба 13 C#/с#/лр 13 — копия/завдання 1/завдання 1/база.txt", true);
            p.Write(city + ";"+ endcity + ";" + num.ToString() + ";" + distance +"\r\n");
            p.Close();

        }
        
        public void search()
        {
            Form2 form= new Form2();
            string v = File.ReadAllText("C:/Users/pimoc/Desktop/labs and dz 2 kurs/ПКПЗ/лаба 13 C#/с#/лр 13 — копия/завдання 1/завдання 1/база.txt");
            string[] s = v.Split("\n");
            for (int i = 0; i < s.Length; i++)
            {
                string[] sear= s[i].Split(";");
                if(sear[0] ==city)
                {
                    form.textBox1.Text+=sear[2]+"\r\n";
                    form.textBox2.Text+=sear[3]+"\r\n";
                }
            }
            form.ShowDialog();
        }

        //public int CompareTo(Itinerary other)
        //{
        //    if (other.num<this.num)
        //        return 1;
        //    else if (other.num > this.num)
        //        return -1;
        //    else
        //        return 0;
        //        //throw new Exception("asdasd");
        //}

    }
}