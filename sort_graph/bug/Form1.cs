using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bag
{
    public partial class Form1 : Form
    {
        private int bugWeight;
        List<Product> stuff = new List<Product>();
        List<Product> ansver;
        public Form1()
        {
            InitializeComponent();
            bugWeight = Decimal.ToInt32(numericUpDownBugWeight.Value);
            stuff.Add(new Product(3, 8));
            stuff.Add(new Product(5, 14));
            stuff.Add(new Product(8, 23));
            updateDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calc();
        }

        private void updateDataGrid()
        {

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            if (stuff != null)
            {
                foreach (var p in stuff)
                {
                    dataGridView1.Rows.Add(new string[] { p.weight.ToString(), p.price.ToString() });
                }
            }
            if (ansver != null)
            {
                int sum = 0;
                int mass = 0;
                foreach (var p in ansver)
                {
                    dataGridView2.Rows.Add(new string[] { p.weight.ToString(), p.price.ToString() });
                    sum += p.price;
                    mass += p.weight;
                }
                label5.Text = mass.ToString();
                label6.Text = sum.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int w = Convert.ToInt32(textBoxW.Text);
            int p = Convert.ToInt32(textBoxP.Text);
            var s = new Product(w, p);
            stuff.Add(s);
            updateDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stuff = new List<Product>();
            updateDataGrid();
        }

        private void numericUpDownBugWeight_ValueChanged(object sender, EventArgs e)
        {
            Calc();
        }
        private void Calc()
        {
            ansver = new List<Product>();
            bugWeight = Decimal.ToInt32(numericUpDownBugWeight.Value);
            int[] dp = new int[bugWeight + 1];
            dp[0] = 0;
            for (int w = 1; w <= bugWeight; w++)
            {
                dp[w] = dp[w - 1];
                for (int i = 0; i < stuff.Count; i++)
                {
                    if (stuff[i].weight <= w)
                    {
                        dp[w] = Math.Max(dp[w], dp[w - stuff[i].weight] + stuff[i].price);
                    }
                }
            }
            int otvet = dp[bugWeight];
            int W = bugWeight;
            List<int> count = new List<int>();
            foreach (var item in stuff)
            {
                count.Add(0);
            }
            while (W > 0)
            {
                int indexLastStuff = -1;
                for (int i = 0; i < stuff.Count; i++)
                {
                    if (stuff[i].weight <= W)
                    {
                        if (dp[W] == (dp[W - stuff[i].weight] + stuff[i].price))
                        {
                            indexLastStuff = i;
                        }
                    }
                }
                if (indexLastStuff == -1)
                {
                    break;
                }
                ansver.Add(stuff[indexLastStuff]);
                count[indexLastStuff]++;
                W = W - stuff[indexLastStuff].weight;
            }
            textBox1.Text = "";
            int c=0;
            foreach (var item in count)
            {
                textBox1.Text += "W" + stuff[c].weight + " " + "S" + stuff[c].price + "=" + count[c];
                    c++;
                    textBox1.Text += Environment.NewLine;
            }
            updateDataGrid();
        }

    }
}
