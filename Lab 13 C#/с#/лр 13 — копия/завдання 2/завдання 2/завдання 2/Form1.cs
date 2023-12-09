namespace завдання_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Floor number = (Floor)Convert.ToInt32(textBox1.Text);
            switch(number)
            {
                case Floor.Parking:
                {
                        MessageBox.Show("Назва: парковка\nІнформація: платна автостоянка", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
                case Floor.Supermarket:
                    {
                        MessageBox.Show("Назва: супермаркет\nІнформація: продукти та товари для дому", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case Floor.Techmarket:
                    {
                        MessageBox.Show("Назва: магазини техніки\nІнформація: побутова та ІТ техніка, мобільні телефони", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case Floor.Boutique:
                    {
                        MessageBox.Show("Назва: бутики\nІнформація: одяг, взуття та косметика", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case Floor.Spa:
                    {
                        MessageBox.Show("Назва: спортивний спа-центр\nІнформація: басейн, каток, спортзал, спа-салон", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case Floor.Entertaiment:
                    {
                        MessageBox.Show("Назва: поверх розваг\nІнформація: бар, нічний клуб", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case Floor.Observation:
                    {
                        MessageBox.Show("Назва: оглядова площадка\nІнформація: ресторан", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                default: 
                    {
                        MessageBox.Show("Некоректно введені дані", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    enum Floor
    {
        Parking = 0,
        Supermarket,
        Techmarket,
        Boutique,
        Spa,
        Entertaiment,
        Observation
    }
    
}