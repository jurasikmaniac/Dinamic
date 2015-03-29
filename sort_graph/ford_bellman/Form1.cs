using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ford_bellman
{
    
 
    public partial class Form1 : Form
    {
        List<Edge> edges;
        int n;//количество вершин
        int m;//количество ребер
        int v=0;//номер стартовой вершины
        int t = 0;//номер конеччной вершины

        const int INF = 1000000000;

        public Form1()
        {                       
            edges = new List<Edge>();            
            edges.Add(new Edge(0, 1, 25));
            edges.Add(new Edge(0, 2, 15));
            edges.Add(new Edge(0, 3, 7));
            edges.Add(new Edge(0, 4, 2));
            edges.Add(new Edge(1, 2, 6));
            edges.Add(new Edge(2, 3, 4));
            edges.Add(new Edge(3, 4, 3));
            InitializeComponent();
            numericUpDown1.Value = Convert.ToDecimal(5);
            updateDataGrid();
        }

        void Форд()
        {
            List<int> d = new List<int>(n);
            m = edges.Count;
            for (int i = 0; i < n; i++)
            {
                d.Add(INF);
            }
            d[v] = 0;
            List<int> p = new List<int>(n);
            for (int i = 0; i < n; i++)
            {
                p.Add(-1);
            }
            
            for (; ; )
            {
                bool any = false;
                for (int j = 0; j < m; ++j)
                {
                    if (d[edges[j].a] < INF)
                        if (d[edges[j].b] > d[edges[j].a] + edges[j].cost)
                        {
                            d[edges[j].b] = d[edges[j].a] + edges[j].cost;
                            p[edges[j].b] = edges[j].a;
                            any = true;
                        }
                    if (d[edges[j].b] < INF)
                        if (d[edges[j].a] > d[edges[j].b] + edges[j].cost)
                        {
                            d[edges[j].a] = d[edges[j].b] + edges[j].cost;
                            p[edges[j].a] = edges[j].b;
                            any = true;
                        }
                }
                
                if (!any) break;

            }
            foreach (var item in d)
            {
                textBox2.Text += item.ToString() + " ";

            }
            textBox2.Text += Environment.NewLine;
            if (d[t] == INF)
                textBox2.Text += "No path from " + v + " to " + t + ".";
            else
            {
                List<int> path = new List<int>();
                for (int cur = t; cur != -1; cur = p[cur])
                {
                    path.Add(cur);
                }
                path.Reverse();

                textBox2.Text += "Path from " + v + " to " + t + ": ";
                for (int i = 0; i < path.Count; ++i)
                {
                    textBox2.Text += path[i] + " ";
                }
            }
            textBox2.Text += Environment.NewLine;
            // вывод d, например, на экран
        }

        private void button3_Click(object sender, EventArgs e)
        {
            edges = new List<Edge>();
            updateDataGrid();
        }

        private void updateDataGrid()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            if (edges != null)
            {
                foreach (var p in edges)
                {
                    dataGridView1.Rows.Add(new string[] { p.a.ToString(), p.b.ToString(), p.cost.ToString() });
                    i++;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edges.Add(new Edge(Convert.ToInt32(textBoxFrom.Text), Convert.ToInt32(textBoxTo.Text), Convert.ToInt32(textBox1.Text)));
            updateDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = Decimal.ToInt32(numericUpDown1.Value);
            v = Decimal.ToInt32(numericUpDown2.Value);
            t = Decimal.ToInt32(numericUpDown3.Value);
            Форд();
        }
    }
}
