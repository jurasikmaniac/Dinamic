using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Plane
{
    class Vertix
    {
        public Point Location;
        public int width = 50;
        public int height = 50;
        private int _dh=int.MaxValue;
        private int _dv=int.MaxValue;
        private int diagX1, diagX2, diagY1, diagY2;

        Font drawFont;
        SolidBrush drawBrush;
        StringFormat drawFormat = new StringFormat();
        Pen p;

        List<Edge> from = new List<Edge>();
        List<Edge> to = new List<Edge>();

        private int _row;
        private int _column;

        public int dh
        {
            get
            {
                return _dh;
            }
            set
            {
                _dh = value;
            }
        }
        public int dv
        {
            get
            {
                return _dv;
            }
            set
            {
                _dv = value;
            }
        }

        public int Row
        {
            get
            {
                return _row;
            }
        }
        public int Column
        {
            get
            {
                return _column;
            }
        }
        public List<Edge> From
        {
            get
            {
                return from;
            }
        }
        public List<Edge> To
        {
            get
            {
                return to;
            }
        }
        public string getID()
        {
            return _row.ToString() + _column.ToString();
        }

        public void addFrom(Edge e)
        {
            from.Add(e);
        }
        public void addTo(Edge e)
        {
            to.Add(e);
        }

        public Vertix(Point location, int r, int c)
        {
            this.Location = location;
            _row = r;
            _column = c;
            calcDiagonal();
            initDrawStaff();
        }
        public void draw(Graphics g)
        {
            g.DrawEllipse(p, Location.X, Location.Y, width, height);
            g.DrawLine(p, diagX2,diagY1, diagX1, diagY2);
            g.DrawString(_dv.ToString(), drawFont, drawBrush, Location.X + width / 3, Location.Y + height / 3, drawFormat);
            g.DrawString(_dh.ToString(), drawFont, drawBrush, Location.X + 2*width / 3, Location.Y + 2*height / 3, drawFormat);
            //g.DrawString("r"+_row.ToString(), drawFont, drawBrush, Location.X + width / 3, Location.Y + height / 3, drawFormat);
            //g.DrawString("c"+_column.ToString(), drawFont, drawBrush, Location.X + 2 * width / 3, Location.Y + 2 * height / 3, drawFormat);

        }
        private void calcDiagonal()
        {
            double d = Math.Sqrt(width * width + height * height);
            diagX1 = Location.X + ((int)d - width) / 2;
            diagX2 = Location.X + width - ((int)d - width) / 2;
            diagY1 = Location.Y + ((int)d - height) / 2;
            diagY2 = Location.Y + height - ((int)d - height) / 2;
        }
        private void initDrawStaff()
        {
            p= new Pen(Color.Black, 1);
            drawBrush = new SolidBrush(Color.Black);
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            drawFont = new Font("Arial", 11);
        }
        public void setColor(Color c)
        {
            p.Color = c;
        }
        public int getSum()
        {
            return _dv + _dh;
        }
    }
}
