namespace завдання_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string employ = textBox1.Text;
            double salary1 =Convert.ToDouble(textBox2.Text);
            double salary2 = Convert.ToDouble(textBox3.Text);
            double salary3 = Convert.ToDouble(textBox4.Text);
            double salary4 = Convert.ToDouble(textBox5.Text);
            double salary5 = Convert.ToDouble(textBox6.Text);
            double salary6 = Convert.ToDouble(textBox7.Text);
            double bonus = Convert.ToDouble(textBox8.Text);
            var salarcort = (salary1, salary2, salary3, salary4, salary5, salary6);
            Get_salary(employ, salarcort, bonus);
        }
        public  void Get_salary(string empploy,(double, double, double, double, double, double) salaeycort, double bonus)
        {
            double ser = (salaeycort.Item1 + salaeycort.Item2 + salaeycort.Item3 + salaeycort.Item4 + salaeycort.Item5 + salaeycort.Item6) / 6;
            double salary = 0.75 * ser + 1.15 * bonus;
            MessageBox.Show($"Ринкова вартість продукту {empploy} становить: {Math.Round(salary,2)}", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
