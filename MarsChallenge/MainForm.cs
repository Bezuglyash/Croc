using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MarsChallenge
{
    public partial class MainForm : Form
    {
        private const int max = 100;
        private List<Pair> list = new List<Pair>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Группируем по суммам
            MessageBox.Show($"Пара: {list[0].A} и {list[0].B}");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            for (int a = 2; a < max; a++)
            {
                for (int b = a + 1; b < max; b++)
                {
                    if (a + b < max)
                    {
                        list.Add(new Pair(a, b));
                        SetColor(a, b, Color.Blue);
                    }
                }
            }
        }

        private string getName(int a, int b)
        {
            return $"cell{a:000}{b:000}";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            foreach (var group in list.GroupBy(a => a.Sum).ToList())
            {
                if (group.Count() == 1)
                {
                    var pair = list.First(a => a.Sum == group.Key);
                    list.Remove(pair);
                    SetColor(pair.A, pair.B, Color.Blue);
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            foreach (IGrouping<int, Pair> group in list.GroupBy(a => a.Mul).ToList())
            {
                if (group.Count() == 1)
                {
                    var pair = list.First(a => a.Mul == group.Key);
                    list.Remove(pair);
                    SetColor(pair.A, pair.B, Color.Blue);
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            foreach (var group in list.GroupBy(a => a.Sum).ToList())
            {
                if (group.Count() > 1)
                {
                    foreach (var item in group)
                    {
                        list.Remove(item);
                        SetColor(item.A, item.B, Color.Blue);
                    }
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            foreach (var group in list.GroupBy(a => a.Mul).ToList())
            {
                if (group.Count() > 1)
                {
                    foreach (var item in group)
                    {
                        list.Remove(item);
                        SetColor(item.A, item.B, Color.Yellow);
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int a = 2; a < max; a++)
            {
                for (int b = 2; b < max; b++)
                {
                    var lbl = new Label();
                    lbl.Size = new System.Drawing.Size(4, 4);
                    lbl.Location = new System.Drawing.Point(a * 4, b * 4 + tool.Height);
                    lbl.BackColor = Color.Yellow;
                    lbl.Name = getName(a, b);
                    Controls.Add(lbl);
                }
            }
        }

        private void SetColor(int x, int y, Color color)
        {
            string name = getName(x, y);
            Label lbl = (Label)Controls[name];
            lbl.BackColor = color;
        }
    }
}