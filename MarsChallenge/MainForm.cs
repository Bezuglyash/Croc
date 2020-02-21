using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MarsChallenge
{
    public partial class MainForm : Form
    {
        private const int max = 100;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Pair> list = new List<Pair>();

            // Перебор всех пар чисел от 2 до 99
            for (int a = 2; a < max; a++)
            {
                for (int b = a + 1; b < max; b++)
                {
                    if (a + b < max)
                    {
                        list.Add(new Pair(a, b));
                    }
                }
            }
            // Группируем по суммам
            foreach(var group in list.GroupBy(a => a.Sum).ToList())
            {
                if (group.Count() == 1)
                {
                    list.Remove(list.First(a => a.Sum == group.Key));
                }
            }

            foreach (var group in list.GroupBy(a => a.Mul).ToList())
            {
                if (group.Count() == 1)
                {
                    list.Remove(list.First(a => a.Mul == group.Key));
                }
            }

            foreach (var group in list.GroupBy(a => a.Sum).ToList())
            {
                if (group.Count() > 1)
                {
                    foreach(var item in group)
                    {
                        list.Remove(item);
                    }
                }
            }

            foreach (var group in list.GroupBy(a => a.Mul).ToList())
            {
                if (group.Count() > 1)
                {
                    foreach (var item in group)
                    {
                        list.Remove(item);
                    }
                }
            }
            MessageBox.Show($"Пара: {list[0].A} и {list[0].B}");
        }
    }
}