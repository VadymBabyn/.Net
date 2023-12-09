namespace завдання_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kil = 0;
            var tuple = (("Петрик", 120, "Гарний", 121), ("Паша", 121, "Руденко", 122), ("Влад", 140, "Петров", 121), ("Василь", 180, "Планик", 111), ("Анастасія", 150, "Велика", 125), ("Ярослав", 120, "Мудрий", 145), ("Олег", 170, "Кришевич", 134), ("Стів", 190, "Джобс", 121), ("Тарас", 130, "Шевченко", 121), ("Діма", 140, "Жомер", 121), ("Настя", 110, "Ляшко", 121), ("Ян", 130, "Бужак", 121), ("Дмитро", 150, "Василів", 121));
            var tuple1=tuple.Item1;
            var tuple2 = tuple.Item2;
            var tuple3 = tuple.Item3;
            var tuple4 = tuple.Item4;
            var tuple5 = tuple.Item5;
            var tuple6 = tuple.Item6;
            var tuple7 = tuple.Item7;
            var tuple8 = tuple.Item8;
            var tuple9 = tuple.Item9;
            var tuple10 = tuple.Item10;
            var tuple11 = tuple.Item11;
            var tuple12 = tuple.Item12;
            var tuple13 = tuple.Item13;
            double ser = (tuple1.Item2 + tuple2.Item2 + tuple3.Item2 + tuple4.Item2 + tuple5.Item2 + tuple6.Item2 + tuple7.Item2 + tuple8.Item2 + tuple9.Item2+ tuple10.Item2+ tuple11.Item2+ tuple12.Item2+ tuple13.Item2)/13;
            if (tuple1.Item2 >= ser)
                kil++;
            if (tuple2.Item2 >= ser)
                kil++;
            if (tuple3.Item2 >= ser)
                kil++;
            if (tuple4.Item2 >= ser)
                kil++;
            if (tuple5.Item2 >= ser)
                kil++;
            if (tuple6.Item2 >= ser)
                kil++;
            if (tuple7.Item2 >= ser)
                kil++;
            if (tuple8.Item2 >= ser)
                kil++;
            if (tuple9.Item2 >= ser)
                kil++;
            if (tuple10.Item2 >= ser)
                kil++;
            if (tuple11.Item2 >= ser)
                kil++;
            if (tuple12.Item2 >= ser)
                kil++;
            if (tuple13.Item2 >= ser)
                kil++;
            MessageBox.Show($"Кількість студентів що поїдуть на олімпіаду: {kil}", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}