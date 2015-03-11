// Created by SharpDevelop.
// User: Миха
// Date: 01.04.2009
// Time: 10:10


namespace graph
{
	public class Edge // : Graph
	{
		double massa = double.NaN;
		
		Vertex v_from = null;
		Vertex v_where = null;
		Edge next = null;
		
		public int numForFleri = -1;
		public bool isDeleted = false; // for Fleri
		
		public bool iAmFirstLine = true;
		
		public Edge () {}
		public Edge ( double massa, Vertex v_from, Vertex v_where) 
		{
			this.massa = massa; 
			this.v_from = v_from;
			this.v_where = v_where;
		}
		
		public Edge ( double massa, Vertex v_from, Vertex v_where, bool iAmFirst) 
		{
			this.massa = massa; 
			this.v_from = v_from;
			this.v_where = v_where;
			this.iAmFirstLine = iAmFirst;
		}
		
		public Edge (double massa, Vertex v_from, Vertex v_where, Edge next, bool iAmFirst)
		{
			this.massa = massa;
			this.v_from = v_from;
			this.v_where = v_where;
			this.next = next;
			this.iAmFirstLine = iAmFirst;
		}
		
		
		
		public override bool Equals(object o)
		{
			if(! (o is Edge) )
			    return false;
			Edge ed = o as Edge;
			if (this.massa == ed.massa &&
			   	this.v_from == ed.v_from && 
			  	this.v_where == ed.v_where)
				return true;
			return false;
		}
		
		public static bool operator != (Edge g1, Edge g2)
		{
			if (Equals(g1, g2) )
				return false;
			else 
				return true;
		}
		
		public static bool operator == (Edge g1, Edge g2)
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
		
		public double Massa 
		{
			get { return massa; }
			set { massa = value; }
		}
		
		public Vertex V_from
		{
			get { return v_from; }
			set { v_from = value; }
		}
		
		public Vertex V_where
		{
			get { return v_where; }
			set { v_where = value; }
		}
		
		public Edge Next
		{
			get { return next; }
			set { next = value; }
		}
	}
}