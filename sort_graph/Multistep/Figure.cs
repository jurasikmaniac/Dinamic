using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multistep
{
    public class Figure
    {
        public string name;
        public int level;
        public Point coord;
        public Figure(string Name, int X, int Y,int Level)
        {
            this.name = Name;
            this.coord = new Point(X, Y);
            this.level = Level;
        }
    }
}
