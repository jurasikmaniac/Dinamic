using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kruskal
{
    public partial class Form1 : Form
    {
        Solver s;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            s = new Solver();
            s.addEdge(new Edge(1, 2, 20));
            s.addEdge(new Edge(1, 7, 1));
            s.addEdge(new Edge(1, 6, 23));
            s.addEdge(new Edge(2, 3, 6));
            s.addEdge(new Edge(2, 7, 4));
            s.addEdge(new Edge(3, 4, 3));
            s.addEdge(new Edge(3, 7, 9));
            s.addEdge(new Edge(4, 5, 17));
            s.addEdge(new Edge(4, 7, 16));
            s.addEdge(new Edge(5, 6, 20));
            s.addEdge(new Edge(5, 7, 25));
            s.addEdge(new Edge(6, 7, 36));
            updateDataGrid();
        }
        private DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int from = Convert.ToInt32(textBoxFrom.Text);
            int to = Convert.ToInt32(textBoxTo.Text);
            int cost=Convert.ToInt32(textBox1.Text);
            s.addEdge(new Edge(from, to, cost));
            updateDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ConvertListToDataTable(s.getResult());
            dataGridView1.AutoResizeColumns();
        }

        private void updateDataGrid()
        {
            dataGridView2.Rows.Clear();
            int i = 0;
            if (s.graph != null)
            {
                foreach (var p in s.graph)
                {
                    dataGridView2.Rows.Add(new string[] { p.v1.ToString(), p.v2.ToString(), p.Weight.ToString() });
                    i++;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            s = new Solver();
            updateDataGrid();
        }
    }
}
