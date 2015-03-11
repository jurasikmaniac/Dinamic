using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sort_graph
{
    public partial class Form1 : Form
    {
        List<int> arrUnsort;
        List<int> arrSort;
        Convers MyMegaCool;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void updateDataGrid()
        {
            
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            dataGridView6.Rows.Clear();
            int i = 0;
            if (arrUnsort != null)
            {
                foreach (var p in arrUnsort)
                {
                    dataGridView1.Rows.Add(new string[] { i.ToString(), p.ToString() });
                    i++;
                }
            }
            
            i = 0;
            if (arrSort != null)
            {
                foreach (var p in arrSort)
                {
                    dataGridView2.Rows.Add(new string[] { i.ToString(), p.ToString() });
                    i++;
                }
            }
            
            if (MyMegaCool!=null)
            {
                i = 0;
                foreach (var p in MyMegaCool.A)
                {
                    if (i < Convert.ToInt32(textBox1.Text)  )
                    {
                        dataGridView3.Rows.Add(new string[] { i.ToString(), p.ToString() });
                        i++;
                    }
                }
                i = 0;
                foreach (var p in MyMegaCool.B)
                {
                    if (i < Convert.ToInt32(textBox1.Text)  )
                    {
                        dataGridView4.Rows.Add(new string[] { i.ToString(), p.ToString() });
                        i++;
                    }
                }
                i = 0;
                foreach (var p in MyMegaCool.C)
                {
                    if (i<Convert.ToInt32(textBox1.Text)*2-1)
                    {
                        dataGridView6.Rows.Add(new string[] { i.ToString(), p.ToString() });
                        i++;
                    }
                    
                }
                i = 0;
                foreach (var p in MyMegaCool.C_comp)
                {

                    if (i < Convert.ToInt32(textBox1.Text) * 2 - 1)
                    {
                        dataGridView5.Rows.Add(new string[] { i.ToString(), ((int)(Math.Round(p.Re))).ToString() });
                        i++;
                    }
                }
                labelTimeFFT.Text = MyMegaCool.timeFFT.ToString() + " ms";
                labelTimeLinear.Text = MyMegaCool.timeLinear.ToString() + " ms";
            }
            labelComp.Text = "Сравнений " + MyArray.comp.ToString();
            labelMove.Text = "Перестановок" + MyArray.move.ToString();
            MyArray.ResetMC();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            arrSort = new List<int>(arrUnsort);            
            arrSort = MyArray.MergeSort(arrSort);
            updateDataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyArray.FillArray(out arrUnsort, Decimal.ToInt32( numericUpDown1.Value));
            updateDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            arrSort = new List<int>(arrUnsort);
            MyArray.SelectSort(ref arrSort);
            updateDataGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            arrSort = new List<int>(arrUnsort);
            MyArray.BubbleSort(ref arrSort);
            updateDataGrid();
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            MyMegaCool = new Convers(Convert.ToInt32(textBox1.Text));
            updateDataGrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BigInteger num1 = new BigInteger(textBox2.Text);
            BigInteger num2 = new BigInteger(textBox3.Text);
            BigInteger mul = BigInteger.Multi(num1, num2);
            label7.Text = mul.ToString();
        }

    }
}
