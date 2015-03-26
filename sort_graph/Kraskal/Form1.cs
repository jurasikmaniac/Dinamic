using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;

namespace Kraskal
{
    public partial class Form1 : Form
    {
        int n = 1;
        float[,] a, a1;
        bool flagpaint = true, flagload = true, flagsave = true, flagbuild = false, flagstop = false;
        bool[,] v;
        ArrayList koord = new ArrayList();
        Point p1 = new Point(0, 0), p2 = new Point(0, 0);

        public Form1()
        {
            InitializeComponent();
        }

        private void control() 
        {
            flagstop = false;
            flagload = true;
            a = new float[n, n];
            a1 = new float[n, n];
            bool flag = false;
            for (short i = 0; i < n; i++)
                for (short j = 0; j < n; j++)
                    try
                    {
                        a[i, j] = Convert.ToSingle(dataGridView1[j, i].Value);
                    }
                    catch
                    {
                        a[i, j] = 0;
                        flag = true;
                    }
            if (flag)
            {
                flagstop = true;
                return;
            }
            for (short i = 0; i < n; i++)
                for (short j = 0; j < n; j++)
                    a1[i, j] = Convert.ToSingle(dataGridView2[j, i].Value);
        }

        void autoresize()
        {
            dataGridView2.AutoResizeColumns();
            dataGridView1.AutoResizeColumns();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            bool[,] v1 = new bool[n, n];
            for (short i = 0; i < n; i++)
                for (short j = 0; j < n; j++)
                    v1[i, j] = v[i, j];
            int t;
            flagpaint = true;
            flagsave = false;
            if (n > numericUpDown1.Value)
            {
                try
                {
                    koord.RemoveAt(koord.Count - 1);
                }
                catch { }
            }
            t = n;
            n = (int)numericUpDown1.Value;
            int x = (t > n) ? n : t;
            v = new bool[n, n];
            for (int i = 0; i < x; i++)
                for (int j = 0; j < x; j++)
                    v[i, j] = v1[i, j];
            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = n;
            dataGridView2.ColumnCount = n;
            dataGridView2.RowCount = n;
            for (short i = 0; i < n; i++)
            {
                dataGridView1[i, i].Style.BackColor = Color.Gray;
                dataGridView1[i, i].Value = 0;
                dataGridView1[i, i].ReadOnly = true;
                dataGridView2[i, i].Style.BackColor = Color.Gray;
                dataGridView2[i, i].Value = 0;
                dataGridView2[i, i].ReadOnly = true;
            }
            autoresize();
            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reset();
            numericUpDown1_ValueChanged(sender, e);
            autoresize();
            button1.Enabled = false;
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            button4.Enabled = true;
            int t;
            flagpaint = true;
            control();
            t = n;
            numericUpDown1.Value = 1;
            numericUpDown1.Value = t;            
            koord.Clear();
            Random z1 = new Random();
            Point x1 = new Point();
            for (int i = 0; i < n; i++)
            {
                x1.X = z1.Next(20, pictureBox1.ClientSize.Width - 20);
                x1.Y = z1.Next(20, pictureBox1.ClientSize.Height - 20);                
                koord.Add(x1);
            }
            button5_Click(sender, e);
            pictureBox1.Invalidate();           
        }

        private void button3_Click(object sender, EventArgs e)
        {            
                reset();            
        }

        void reset()
        {
           
            button1.Enabled = false;
            button5.Enabled = false;
            button4.Enabled = false;
            flagbuild = false;
            flagload = true;
            koord.Clear();
            n = 1;
            numericUpDown1.Value = n;
            a = new float[n, n];
            a1 = new float[n, n];
            v = new bool[n, n];
            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
            button1.Enabled = false;
            flagpaint = true;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == e.RowIndex)
                e.Cancel = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            flagsave = false;
            flagpaint = true;
            bool flag1 = false;
            button1.Enabled = true;
            try
            {
                Convert.ToDouble(dataGridView1[e.ColumnIndex, e.RowIndex].Value);
                dataGridView1[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Black;
                v[e.RowIndex, e.ColumnIndex] = false;
            }
            catch            {
                
                v[e.RowIndex, e.ColumnIndex] = true;
            }
            if (v[e.RowIndex, e.ColumnIndex])
                dataGridView1[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Red;
            else
                dataGridView1[e.RowIndex, e.ColumnIndex].Value = dataGridView1[e.ColumnIndex, e.RowIndex].Value;
            for (short i = 0; i < n; i++)
                for (short j = 0; j < n; j++)
                    flag1 = (v[i, j]) ? true : flag1;
            if (flag1)
            {
                
                button1.Enabled = false;
            }
            else
            {
               
                button1.Enabled = true;
            }
            
            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flagpaint = false;
            tabControl1.SelectedIndex = 1;            
            control();
            if (flagstop)
            {
                MessageBox.Show("Введенное вами значение имеет некорректный формат", "Ошибка ввода");
                return;
            }
            a1 = new float[n, n]; //Матрица весов окончательной матрицы
            short[,] b = new short[n, n]; //Массив компонент (двумерный)
            float[] c; //Массив ребер
            for (short i = 0; i < n; i++)
                for (short j = 0; j < n; j++)
                    b[i, j] = -1;
            //Заполнение массива компонент (первая строка)
            for(short i = 0; i < n; i++)
	            b[0, i] = i;
            short re = 0;
            //Проверка числа ребер
            for(short i = 0; i < n; i++)
            	for(short j = 0; j < i; j++)
	                if(a[i, j] != 0)
	            		re++;
            c = new float[re];
            re = 0;
            //Добавление ребер в массив ребер
            for(short i = 0; i < n; i++)
                for(short j = 0; j < i; j++)
             		if(a[i, j] != 0)
	               		{
	            			c[re] = a[i, j];
	            			re++;
	            		}
            //Упорядочение массива ребер по возрастанию
            float g; //Обменник
            short l;
            while(true)
    	        {
	            l = 0;
	            for(short i = 1; i < re; i++)
		            {
			            if(c[i] < c[i - 1])
				            {
					            g = c[i - 1];
					            c[i - 1] = c[i];
    					        c[i] = g;
	    				        l++;
		    		        }
		            }
    	        if(l == 0)
	    	        break;
	            }
            //Выполнение алгоритма
            short com1 = 0, com2 = 0, n3;
            bool flag = false, flagend;
            l = (short)n;
            for(short k = 0; k < re; k++)
            {	//Поиск ребра в матрице весов                
                flagend = false;
	            for (short i = 0; i < n; i++)
                {
                    for (short j = 0; j < i; j++)
                    {
                        if (c[k] == a[i, j] && c[k] != a1[i, j])
                        {
                            //Проверка вершин на принадлежность разным компонентам
                            flag = false;
                            for (short n1 = 0; n1 < n; n1++)
                            {
                                for (short n2 = 0; n2 < n; n2++)
                                    if (i == b[n1, n2])
                                    {
                                        com1 = n2;
                                        flag = true;
                                    }
                                if (flag)
                                    break;
                            }
                            flag = false;
                            for (short n1 = 0; n1 < n; n1++)
                            {
                                for (short n2 = 0; n2 < n; n2++)
                                    if (j == b[n1, n2])
                                    {
                                        com2 = n2;
                                        flag = true;
                                    }
                                if (flag)
                                    break;
                            }
                            if (com1 != com2)
                            {	//Добавление ребра в остовый лес
                                a1[i, j] = c[k];
                                a1[j, i] = c[k];
                                flagend = true;
                                //Обьединение двух соединенных компонент в одну
                                n3 = 0;
                                l--;
                                for (short t = 0; t < n; t++)
                                    if (b[t, com1] == -1)
                                    {
                                        while (b[n3, com2] != -1)
                                        {
                                            b[n3 + t, com1] = b[n3, com2];
                                            b[n3, com2] = -1;
                                            n3++;
                                        }
                                        break;
                                    }
                            }
                            if (l == 1 || flagend)
                                break;
                        }
                    }
                    if (l == 1 || flagend)
                        break;
                }     
			//Изьятие использованного ребра из массива ребер        
            c[k] = 0;
            if (l == 1)
                break;
        }
        //На выходе получаем матрицу остовного леса
        for (short i = 0; i < n; i++)
            for (short j = 0; j < i; j++)
            {
                if (a1[i, j] != 0)
                    dataGridView2[i, j].Value = a1[i, j];
                
            }
       
        autoresize();
        
        pictureBox2.Invalidate();
        }  

        

        

        public void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (koord.Count != n)
                return;
            Point[] pnt = (Point[])koord.ToArray(typeof(Point));
            Font ft = new Font("Times New Roman", 14);
            Size sz = new Size(6, 6);
            Size sz2 = new Size(12, 12);
            int k = 0;
            control();
            e.Graphics.Clear(pictureBox1.BackColor);
            foreach (Point pt in koord)
            {
                e.Graphics.FillEllipse(Brushes.Gray, new Rectangle(pt, sz));                
                e.Graphics.DrawString((k + 1).ToString(), ft, Brushes.Black, pt.X - 17, pt.Y - 17);
                k++;
            }
            for (short i = 0; i < n; i++)
                for (short j = 0; j < n; j++)
                    if (a[i, j] != 0)
                    {
                        e.Graphics.DrawLine(Pens.Gray, pnt[i].X + 3, pnt[i].Y + 3, pnt[j].X + 3, pnt[j].Y + 3);
                    }
            e.Graphics.FillEllipse(Brushes.Green, new Rectangle(pnt[p1.X], sz2));
            e.Graphics.FillEllipse(Brushes.Green, new Rectangle(pnt[p1.Y], sz2));
            try
            {
                if (a[p1.X, p1.Y] != 0)
                    e.Graphics.DrawLine(Pens.Green, pnt[p1.X].X + 6, pnt[p1.X].Y + 6, pnt[p1.Y].X + 6, pnt[p1.Y].Y + 6);
            }
            catch { };
            ft.Dispose();
        }

        public void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            button4.Enabled = true;
            button5.Enabled = true;
            if (n != numericUpDown1.Maximum)
            {
                flagsave = false;
                flagpaint = true;
                if (e.Button == MouseButtons.Left)
                {
                    koord.Add(e.Location);
                }
                numericUpDown1.Value = koord.Count;;
                pictureBox1.Invalidate();
            }
            
        }

        private void pictureBox2_Paint_1(object sender, PaintEventArgs e)
        {
            if (koord.Count != n)
                return;
            Point[] pnt = (Point[])koord.ToArray(typeof(Point));
            Font ft = new Font("Times New Roman", 14);
            Size sz = new Size(6, 6);
            Size sz2 = new Size(12, 12);
            int k = 0;
            control();
            e.Graphics.Clear(pictureBox2.BackColor);
            foreach (Point pt in koord)
            {
                e.Graphics.FillEllipse(Brushes.Gray, new Rectangle(pt, sz));                
                e.Graphics.DrawString((k + 1).ToString(), ft, Brushes.Black, pt.X - 17, pt.Y - 17);
                k++;
            }
            for (short i = 0; i < n; i++)
                for (short j = 0; j < n; j++)
                    if (a1[i, j] != 0)
                    {
                        e.Graphics.DrawLine(Pens.Gray, pnt[i].X + 3, pnt[i].Y + 3, pnt[j].X + 3, pnt[j].Y + 3);
                    }
            e.Graphics.FillEllipse(Brushes.Green, new Rectangle(pnt[p2.X], sz2));
            e.Graphics.FillEllipse(Brushes.Green, new Rectangle(pnt[p2.Y], sz2));
            try
            {
                if (a1[p2.X, p2.Y] != 0)
                    e.Graphics.DrawLine(Pens.Green, pnt[p2.X].X + 6, pnt[p2.X].Y + 6, pnt[p2.Y].X + 6, pnt[p2.Y].Y + 6);
            }
            catch { };
            ft.Dispose();
        }

        private void button2_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 1 && flagpaint)
                button1_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            control();
            if (flagstop)
            {
                MessageBox.Show("Введенное вами значение имеет некорректный формат", "Ошибка ввода");
                return;
            }
            
            Point[] pnt = (Point[])koord.ToArray(typeof(Point));
            double mass;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < i; j++)
                {
                    mass = Math.Sqrt(Math.Pow(pnt[i].X - pnt[j].X, 2) + Math.Pow(pnt[i].Y - pnt[j].Y, 2));
                    a[i, j] = Convert.ToSingle(mass);
                    a[j, i] = Convert.ToSingle(mass);
            
                }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < i; j++)
                {
                    dataGridView1[j, i].Value = a[i, j];            
                }
            autoresize();            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            p2.X = e.ColumnIndex;
            p2.Y = e.RowIndex;
            pictureBox2.Invalidate();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            p1.X = e.ColumnIndex;
            p1.Y = e.RowIndex;
            pictureBox1.Invalidate();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2_CellClick(sender, e);
        }

        
    }
}