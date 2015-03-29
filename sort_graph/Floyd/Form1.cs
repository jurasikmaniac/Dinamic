using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Floyd
{
    public partial class Form1 : Form
    {
        List<Edge> edges;
        int n;//количество вершин        
        int s = 0;//номер стартовой вершины
        int t = 0;//номер конеччной вершины   
        int[,] path;
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
            updateDataGrid();
        }

        void autoresize()
        {
            dataGridView3.AutoResizeColumns();
            dataGridView2.AutoResizeColumns();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            n = (int)numericUpDown1.Value;
            dataGridView2.ColumnCount = n;
            dataGridView2.RowCount = n;
            dataGridView3.ColumnCount = n;
            dataGridView3.RowCount = n;
            for (short i = 0; i < n; i++)
            {
                dataGridView2[i, i].Style.BackColor = Color.Gray;
                dataGridView2[i, i].Value = 0;
                dataGridView2[i, i].ReadOnly = true;
                dataGridView3[i, i].Style.BackColor = Color.Gray;
                dataGridView3[i, i].Value = 0;
                dataGridView3[i, i].ReadOnly = true;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        dataGridView2[i, j].Style.BackColor = Color.Bisque;
                        dataGridView2[i, j].Value = "INF";                        
                        dataGridView2[i, j].ReadOnly = true;
                    }
                }
            }
            if (edges != null)
            {
                foreach (var item in edges)
                {
                    if (item.a<n&&item.b<n)
                    {
                        dataGridView2[item.b, item.a].Value = item.cost;
                        //для ненаправленного графа
                        dataGridView2[item.a, item.b].Value = item.cost;
                    }
                    
                }
            }
            autoresize();            
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
            numericUpDown1_ValueChanged(sender, e);
            updateDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] matrix = new int[n, n];
            path = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dataGridView2[j, i].Value.ToString() == "INF")
                    {
                        matrix[i, j] = INF;
                    }
                    else
                    {
                        matrix[i, j] = (int)dataGridView2[j, i].Value;
                    }
                    path[i,j] = i;
                }
            }
            for (int k = 0; k < n; ++k)
                for (int i = 0; i < n; ++i)
                    for (int j = 0; j < n; ++j)
                        if (matrix[i, k] < INF && matrix[k, j] < INF)
                        {
                            if (matrix[i, j] > matrix[i, k] + matrix[k, j]) path[i, j] = path[k, j];
                            matrix[i, j] = Math.Min(matrix[i, j], matrix[i, k] + matrix[k, j]);
                        }
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == INF)
                    {
                        dataGridView3[j, i].Value = "INF";
                    }
                    else
                    {
                        dataGridView3[j, i].Value = matrix[i, j];
                    }
                }
            }
            autoresize();
            s = (int)numericUpDown2.Value;
            t = (int)numericUpDown3.Value;
            if (n != 0)
            {
                if (matrix[s, t] < INF )
                {
                    textBox2.Text += "Path from " + s + " to " + t + ": ";
                    
                    Travel(t);
                    textBox2.Text += "Length=" + matrix[s, t];
                    textBox2.Text += Environment.NewLine;
                }
            }
        }
        
        void Travel(int v)
        {
            if (v == s)
            {
                textBox2.Text += v  + " ";
            }
            else
            {
                Travel(path[s,v]);
                textBox2.Text += v  + " ";
            }
        }
    }
}
