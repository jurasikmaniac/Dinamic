// Created by SharpDevelop.
// User: Миха
// Date: 01.04.2009
// Time: 10:10

using System.Drawing;

namespace graph
{
	public class Vertex //: Graph
	{
		string label = null;
		//Edge adj = new Edge(); // null Edge;
		Vertex next = null;
		Point p = new Point(0, 0); // started position
		public int key = -1;
		
		double massaFromPoint = double.PositiveInfinity;
		public double MassaFromNowPoint
		{
			get{ return massaFromPoint; }
			set{ massaFromPoint = value; }
		}
		
		public Vertex () {}
		public Vertex (string label, Point p) 
		{
			this.label = label; 
			this.P = p;
		}
		public Vertex (string label, Point p, Vertex next)
		{
			this.label = label;
			this.p = p;
			this.next = next;
		}
		
		public Vertex (string label, Point p, Vertex next, int key)
		{
			this.label = label;
			this.p = p;
			this.key = key;
			this.next = next;
		}
		
		public override bool Equals(object o)
		{
			if(! (o is Vertex) )
			    return false;
			Vertex v = o as Vertex;
			if (this.p == v.p && 
			    this.label == v.label &&
			    this.key == v.key)
				return true;
			return false;
		}
		
		public static bool operator != (Vertex g1, Vertex g2)
		{
			if (Equals(g1, g2) )
				return false;
			else 
				return true;
		}
		
		public static bool operator == (Vertex g1, Vertex g2)
		{
			if (Equals(g1, g2) )
				return true;
			else 
				return false;
		}
		// for ==
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public string Label 
		{
			get { return label; }
			set { label = value; }
		}
		
//		public Edge Adjacent 
//		{
//			get { return adj; } 
//			set { adj = value; }
//		}
		
		public Vertex Next 
		{
			get { return next; }
			set { next = value; }
		}
		
		public Point P
		{
			get { return p; }
			set { p = value; }
		}
		
		public int X
		{
			get { return p.X; }
			set { p.X = value; }
		}
		
		public int Y
		{
			get { return p.Y; }
			set { p.Y = value; }
		}
	}
}