using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plane
{
    public partial class Form1 : Form
    {
        private List<TextBox> edgesTextBoxList = new List<TextBox>();
        private List<Label> vertixesLabelList = new List<Label>();
        private List<Vertix> vertixList = new List<Vertix>();
        private List<Edge> edges = new List<Edge>();
        private int labelOffset = 150;
        private int graphWidth = 5;
        private int graphHeight = 3;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < graphWidth; i++)
            {
                for (int j = 0; j <graphHeight; j++)
                {
                    Vertix v = new Vertix(new Point(i * labelOffset, (graphHeight - 1) * labelOffset -j*labelOffset), i, j);
                    
                    vertixList.Add(v);
                }
            }
            for (int i = 0; i < graphWidth; i++)
            {
                for (int j = 0; j < graphHeight; j++)
                {
                    Vertix v = vertixList.Find(x => x.getID() == (i.ToString() + j.ToString()));
                    Vertix vTop = vertixList.Find(x => x.getID() == (i.ToString() + (j+1).ToString()));
                    if (vTop != null)
                    {
                        Edge e1 = new Edge(vTop, 0, v.getID() + vTop.getID());
                        Edge e2 = new Edge(v, 0, v.getID() + vTop.getID());
                        edges.Add(e1);
                        edges.Add(e2);
                        createTextBox(v.getID() + vTop.getID(), new Point(15 + i * labelOffset,15+ (graphHeight - 1) * labelOffset - (j * labelOffset + labelOffset / 2)));
                        v.addTo(e1);
                        vTop.addFrom(e2);

                    }
                    Vertix vRight = vertixList.Find(x => x.getID() == ((i+1).ToString() + j.ToString()));
                    if (vRight != null)
                    {

                        Edge e1 = new Edge(vRight, 0, v.getID() + vRight.getID());
                        Edge e2 = new Edge(v, 0, v.getID() + vRight.getID());
                        edges.Add(e1);
                        edges.Add(e2);
                        createTextBox(v.getID() + vRight.getID(), new Point(15 + i * labelOffset + labelOffset / 2, 15 + (graphHeight - 1) * labelOffset - (j * labelOffset)));
                        v.addTo(e1);
                        vRight.addFrom(e2);
                    }
                    Vertix vDiag = vertixList.Find(x => x.getID() == ((i + 1).ToString() + (j + 1).ToString()));
                    if (vDiag != null)
                    {
                        Edge e1 = new Edge(vDiag, 0, v.getID() + vDiag.getID());
                        Edge e2 = new Edge(v, 0, v.getID() + vDiag.getID());
                        edges.Add(e1);
                        edges.Add(e2);
                        createTextBox(v.getID() + vDiag.getID(), new Point(15 + i * labelOffset + labelOffset / 2, 15 + (graphHeight - 1) * labelOffset - (j * labelOffset + labelOffset / 2)));
                        v.addTo(e1);
                        vDiag.addFrom(e2);
                    }
                }
            }
            randomize();
        }

        private void createTextBox(string id, Point location){
                                    TextBox t = new TextBox();
                        t.Width = 20;
                        t.Name = id;
                        t.Location = location;
                        t.TextChanged += weightChanged;

                        edgesTextBoxList.Add(t);
        }

        void weightChanged(object sender, EventArgs e)
        {
            string id = ((TextBox)sender).Name;
            List<Edge> el = edges.FindAll(x => x.getID() == id);
            int w;
            if (int.TryParse(((TextBox)sender).Text, out w))
            {
                foreach (Edge ed in el)
                {
                    ed.Weight = w;
                }
                
            }
            
            calcGraphValues();
            this.Invalidate();
            //MessageBox.Show(id);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           this.Controls.AddRange(edgesTextBoxList.ToArray());
           button1.Location = new Point(0, (graphHeight) * labelOffset);
           

        }
        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            foreach (Vertix v in vertixList)
            {
                v.draw(e.Graphics);
            }
        }
        private void calcGraphValues()
        {
            foreach (Vertix v in vertixList)
            {
                v.dh = int.MaxValue;
                v.dv = int.MaxValue;
                v.setColor(Color.Black);
            }
            Vertix start = vertixList[0];
            start.dv = 0;
            Vertix finish = vertixList[vertixList.Count - 1];
            finish.dh = 0;
            recursiveCalcDv(0, start.To);
            recursiveCalcDh(0, finish.From);

            foreach (Vertix v in vertixList.FindAll(x => x.getSum() == start.dh))
            {
                v.setColor(Color.Red);
            }

        }
        private void recursiveCalcDv(int cur, List<Edge> el)
        {
            foreach (Edge e in el)
            {
                if (e.Vertix.dv>cur+e.Weight)
                {
                    e.Vertix.dv = cur + e.Weight;
                    recursiveCalcDv(e.Vertix.dv, e.Vertix.To);
                }
            }
        }
        private void recursiveCalcDh(int cur, List<Edge> el)
        {
            foreach (Edge e in el)
            {
                if (e.Vertix.dh > cur + e.Weight)
                {
                    e.Vertix.dh = cur + e.Weight;
                    recursiveCalcDh(e.Vertix.dh, e.Vertix.From);
                }
            }
        }
        private void randomize()
        {
            Random r = new Random();
            foreach (TextBox t in edgesTextBoxList)
            {
                t.Text = r.Next(10).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            randomize();
        }
    }
}
