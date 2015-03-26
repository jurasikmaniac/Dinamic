using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multistep
{
    public partial class Form1 : Form
    {
        Graph graph;
        List<Figure> figureGraph;
        List<Point> path;       
        Pen blackPen = new Pen(Color.Black, 1);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        // Create rectangle.
        Rectangle rect = new Rectangle(0, 0, 20, 20);
        int currentLevel = 0;
        int curL=0;

        public Form1()
        {
            InitializeComponent();
            InitGraph();
            figureGraph = new List<Figure>();
            path = new List<Point>();
            InitFigureGraph();
            numericUpDown1.Maximum=new decimal(5);
        }

        public void InitFigureGraph()
        {
            int startX = 50;
            int startY = 50;
            for (int i = 0; i < graph.vertexs.Length; i++)
            {
                int stepY = 0;
                foreach (var item in graph.vertexs[i])
                {
                    figureGraph.Add(new Figure(item.name, startX + i * 100, startY + stepY, i));
                    stepY += 100;
                }
            }
        }

        public void InitGraph()
        {
            graph = new Graph(6);
            graph.addVertex("S0", 0);

            graph.addVertex("S1", 1);
            graph.addVertex("S2", 1);
            graph.addVertex("S3", 1);

            graph.addVertex("S4", 2);
            graph.addVertex("S5", 2);
            graph.addVertex("S6", 2);
            graph.addVertex("S7", 2);

            graph.addVertex("S8", 3);
            graph.addVertex("S9", 3);
            graph.addVertex("S10", 3);
            graph.addVertex("S11", 3);

            graph.addVertex("S12", 4);
            graph.addVertex("S13", 4);
            graph.addVertex("S14", 4);

            graph.addVertex("S15", 5);
            graph.addVertex("S16", 5);

            graph.addVertex("S18", 3);
            graph.addPair("S7", "S18", 1);
            graph.addPair("S18", "S14", 1);

            graph.addPair("S0", "S1", 4);
            graph.addPair("S0", "S2", 5);
            graph.addPair("S0", "S3", 6);

            graph.addPair("S1", "S4", 6);
            graph.addPair("S1", "S5", 8);
            graph.addPair("S1", "S6", 7);

            graph.addPair("S2", "S6", 8);
            graph.addPair("S2", "S7", 9);

            graph.addPair("S3", "S6", 6);
            graph.addPair("S3", "S7", 7);

            graph.addPair("S4", "S8", 4);

            graph.addPair("S5", "S8", 5);
            graph.addPair("S5", "S9", 5);

            graph.addPair("S6", "S9", 6);
            graph.addPair("S6", "S10", 5);
            graph.addPair("S6", "S11", 6);

            graph.addPair("S7", "S10", 4);
            graph.addPair("S7", "S11", 5);

            graph.addPair("S8", "S12", 7);

            graph.addPair("S9", "S12", 6);
            graph.addPair("S9", "S13", 8);

            graph.addPair("S10", "S13", 7);
            graph.addPair("S10", "S14", 6);

            graph.addPair("S11", "S14", 7);

            graph.addPair("S12", "S15", 9);

            graph.addPair("S13", "S15", 8);

            graph.addPair("S14", "S16", 7);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString("YEAH!", Font, Brushes.DarkOrchid, 10, 20);
            int i = 1;
            int temp = 0;
            foreach (var item in figureGraph)
            {
                if (temp != item.level)
                {
                    temp = item.level;
                    i = 1;
                }
                //e.Graphics.DrawRectangle(blackPen, item.coord.X, item.coord.Y, 20, 20);
                e.Graphics.FillRectangle(blackBrush, item.coord.X, item.coord.Y, 20, 20);
                e.Graphics.DrawString("S" + item.level.ToString() + "." + i.ToString(), Font, Brushes.Chocolate, item.coord.X, item.coord.Y - 15);
                e.Graphics.DrawEllipse(blackPen, item.coord.X, item.coord.Y+20, 25, 25);
                e.Graphics.DrawString(graph.searchVertexByName(item.name).sum.ToString(), Font, Brushes.DarkOrchid, item.coord.X+5, item.coord.Y+25);                
                i++;
            }
            foreach (var item in graph.pairs)
            {
                int x = 0; int y = 0;
                int x1 = 0; int y1 = 0;

                foreach (var line in figureGraph)
                {
                    if (item.from.name.Equals(line.name))
                    {
                        x = line.coord.X;
                        y = line.coord.Y;
                    }
                    if (item.to.name.Equals(line.name))
                    {
                        x1 = line.coord.X;
                        y1 = line.coord.Y;
                    }

                }
                e.Graphics.DrawLine(blackPen, x, y, x1, y1);
                e.Graphics.DrawString(item.value.ToString(), Font, Brushes.Cyan, x+(x1-x)/3, y+(y1-y)/3);
            }

            Point[] p=new Point[path.Count];
            int c = 0;
            foreach (var item in path)
            {
                p[c] = item;
                c++;
            }
            if (p.Length > 1) 
            { 
                e.Graphics.DrawLines(new Pen(Color.Red, 5), p);
                for (int j = 0; j < p.Length; j++)
                {
                    e.Graphics.FillRectangle(Brushes.DarkSeaGreen, p[j].X, p[j].Y, 20, 20);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            foreach (var item in graph.vertexs[currentLevel])
            {
                int ch=0;
                foreach (var k in graph.pairs)
                {
                    if (k.to==item)
                    {
                        if (ch==0)
                        {
                            k.to.sum = k.from.sum + k.value;
                            ch = 1;
                        }
                        else
                        {
                            if (k.from.sum + k.value<k.to.sum)
                            {
                                k.to.sum = k.from.sum + k.value; 
                            }
                        }
                    }
                }
            }
            currentLevel++;
            if (currentLevel>=graph.vertexs.Length)
            {
                currentLevel = 0;
            }
            this.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            path = new List<Point>();
            curL = Decimal.ToInt32(numericUpDown1.Value);
            int ch = 0;
            
            Vertex temp=null;
            Point t = new Point();
            foreach (var item in graph.vertexs[curL])
            {
                if (ch == 0)
                {
                    temp = item;
                    ch = 1;
                }
                else
                {
                    if (temp.sum>item.sum)
                    {
                        temp = item;
                    }
                }
            }
            foreach (var item in figureGraph)
            {
                if (temp.name.Equals(item.name))
                {
                    t = item.coord;
                }
            }
            path.Add(t);

            for (int i = curL-1; i >= 0; i--)
            {
                foreach (var pair in graph.pairs)
                {
                    if (pair.to.name.Equals(temp.name) && pair.from.sum + pair.value == temp.sum)
                    {
                        temp = pair.from;
                        foreach (var item in figureGraph)
                        {
                            if (temp.name.Equals(item.name))
                            {
                                t = item.coord;
                            }
                        }
                        path.Add(t);
                        break;
                    }
                }
            }

            this.Invalidate();
        }

        


    }
}
