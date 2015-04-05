using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal
{
    class Edge : IComparable<Edge>, IEquatable<Edge>
    {
        private int _v1, _v2, _component, _weight;
        public Edge(int v1, int v2, int weight)
        {
            _v1 = v1;
            _v2 = v2;
            _weight = weight;
        }
        public int v1
        {
            get { return _v1; }
        }
        public int v2
        {
            get { return _v2; }
        }
        public int Component
        {
            get { return _component; }
            set { _component = value; }
        }
        public override string ToString()
        {
            return "("+_v1.ToString() + ", " + _v2.ToString()+")";
        }
        public int Weight
        {
            get { return _weight; }
        }
        public int CompareTo(Edge other)
        {
            if (other == null)
                return 1;

            else
                return this.Weight.CompareTo(other.Weight);
        }
        public bool connected(Edge e)
        {
            return _v1 == e._v2 || _v2 == e._v1 || _v1 == e._v1 || _v2 == e._v2;
        }

        public bool Equals(Edge other)
        {
            return _v1 == other._v1 && _v2 == other._v2;
        }
    }
}
