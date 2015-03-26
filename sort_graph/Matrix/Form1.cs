using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix
{
    public partial class Form1 : Form
    {
        Hard yahu;
        public Form1()
        {
            InitializeComponent();
                                    
            
        }

        private void updateDataGrid()
        {
            dataGridViewSizes.Rows.Clear();
            dataGridViewSizes.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridViewSizes.AutoGenerateColumns = true;
            dataGridViewSizes.EditMode = DataGridViewEditMode.EditOnEnter;
            string[] s = new string[yahu.n + 1];
            for (int i = 0; i < yahu.n + 1; i++)
            {
                dataGridViewSizes.Columns.Add(i.ToString(), "A" + i.ToString());
                s[i] = yahu.sizes[i].ToString();
            }
            dataGridViewSizes.Rows.Add(s);
            //dataGridViewSizes.DataSource = yahu.sizes.Select(x => new { IntValue = x }).ToList();

            for (int i = 0; i < yahu.n; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), "A" + i.ToString());
            }
            dataGridView1.Rows.Add(yahu.n);
            int rowNumber = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "A" + rowNumber;
                rowNumber = rowNumber + 1;
            }

            for (int i = 0; i < yahu.n; i++)
            {
                for (int j = 0; j < yahu.n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = yahu.matrix[i, j].ToString();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            yahu = new Hard(Decimal.ToInt32(numericUpDown1.Value));
            updateDataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < yahu.n+1; i++)
            {
                yahu.sizes[i] = Convert.ToInt32( dataGridViewSizes.Rows[0].Cells[i].Value );
            }
            yahu.MopAndNop();
            yahu.Ords();
            textBox1.Lines = yahu.poryadok;
            updateDataGrid();
        }
    }
}
