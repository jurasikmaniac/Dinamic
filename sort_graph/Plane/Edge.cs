using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    class Edge
    {
        private Vertix _vertix;
        private int _weight;
        private string _id;
        public string getID()
        {
            return _id;
        }
        public Vertix Vertix
        {
            get
            {
                return _vertix;
            }
        }
        public int Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }
        public Edge(Vertix v, int w, string id)
        {
            _vertix = v;
            _weight = w;
            _id = id;
        }
    }
}
