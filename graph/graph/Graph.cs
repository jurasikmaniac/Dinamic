// Created by SharpDevelop.
// User: Миха
// Date: 20.03.2009
// Time: 20:02

using System;
using System.Drawing;  // for use Point
using System.Windows.Forms;
//using System.Collections;
//using System.Collections.Generic;

namespace graph
{
	//====================================================//
	//----------------------GRAPH--------------------------//
	
	public class Graph
	{
				
		Vertex v_root = new Vertex("ROOT", new Point(0, 0));
		Edge e_root = new Edge(); // root Edge
		
		 int nowKey = 0;
		 int IncrementLabel = 0;
		
		
		
		string name;
		public string Name
		{
			get{ return name; }
			set{ name = value; }
		}
		public Graph(string name)
		{
			this.name = name;
		}
		
		public Vertex V_Root
		{
			get{ return v_root; }
		}
		
		public Edge E_Root
		{
			get{ return e_root; }
		}
		
		int numPoints = 0;
		public int NumberOfPoints
		{
			get{ return numPoints; }
		}
		
		public void Add (string label, Point p)
		{
			Vertex v_buf = v_root.Next;
			Vertex v = new Vertex(label, p, v_buf, nowKey);
			v_root.Next = v;
			
			IncrementLabel++;
			nowKey++;
			numPoints++;
			needToUpdateFloyd = true;
		}
		
		public void Add (Point p)
		{
			Vertex v_buf = v_root.Next;
			string label = "G" + IncrementLabel;
			Vertex v = new Vertex(label, p, v_buf, nowKey);
			v_root.Next = v;
			IncrementLabel++;
			nowKey++;
			numPoints++;
			needToUpdateFloyd = true;
		}
		
		public void Add (string label, int key, int x, int y)
		{
			Vertex v_buf = v_root.Next;
			Vertex v = new Vertex(label, new Point(x, y), v_buf, key);
			v_root.Next = v;
			
			IncrementLabel++;
			nowKey++;
			numPoints++;
			needToUpdateFloyd = true;
		}
		
		public void Add (Vertex v)
		{
			Vertex v_buf = v_root.Next;
			v.Next = v_buf;
			v_root.Next = v;
			
			IncrementLabel++;
			nowKey++;
			numPoints++;
			needToUpdateFloyd = true;
		}
		
		public void AddLine (Vertex GPfrom, Vertex GPwhere, double massa, bool iAmFirstLine)
		{
			if ( GPwhere == null || GPfrom == null )
				throw new ArgumentNullException("Can't AddLine from or to null");
			if (CheckExistsEdge(GPfrom, GPwhere))
				return;
			
			Edge e_buf = e_root.Next;
			Edge e = new Edge(massa, GPfrom, GPwhere, e_buf, iAmFirstLine);
			e_root.Next = e;
			needToUpdateFloyd = true;
		}
		
		public void AddLine (Edge ed)
		{
			Edge e_buf = e_root.Next;
			ed.Next = e_buf;
			e_root.Next = ed;
			needToUpdateFloyd = true;
		}
		
		bool CheckExistsEdge(Vertex v_from, Vertex v_where)
		{
			Edge e = e_root.Next;
			while (e != null) {
				if (e.V_from == v_from && e.V_where == v_where){
					return true;
				}
				e = e.Next;	
			}
			return false;
		}
		
		public void DeleteLine (Edge deleteMe)
		{
			if (deleteMe == null) return;
			Edge ed = e_root;
			while (ed.Next != null) {
				if (ed.Next == deleteMe){
					ed.Next = ed.Next.Next;
				}else 
					ed = ed.Next;
			}
			needToUpdateFloyd = true;
		}
		
		public void DeletePoint(Vertex DeleteMe)
		{
			if (DeleteMe == null) return;
			int deletedKey = DeleteMe.key;
			UpdateKeys(deletedKey);
			
			Edge ed = e_root;
			while (ed != null && ed.Next != null){
				if (ed.Next.V_from == DeleteMe || ed.Next.V_where == DeleteMe)
					ed.Next = ed.Next.Next; // i have many lines with point to delete
				else		
					ed = ed.Next;
			}
			
			Vertex v = v_root;
			while (v.Next != null){
				if (v.Next == DeleteMe){
					v.Next = v.Next.Next; 
					break;	// i have only one point to delete
				}
				v = v.Next;
			}
			
			numPoints--;
			needToUpdateFloyd = true;
		}
		
		void UpdateKeys(int deletedKey)
		{
			Vertex v = v_root;
			while(v != null){
				if (v.key == nowKey-1){
					v.key = deletedKey;
					nowKey--;
					return;
				}
				v = v.Next;
			}
		}
		
		public string GraphArrayToString()
		{
			string[] labels = new string[numPoints];
			
			Vertex v = v_root.Next;
			while(v != null){
				labels[v.key] = v.Label;
				v = v.Next;
			}
			
			string res = "    ";
			foreach(string s in labels)
				res += s + "|";
			res += "\n";
			
			double[,] g_arr = GraphToArray(this);
			for(int i=0; i < numPoints; i++){
				res += labels[i] + ":";
				for(int j=0; j < numPoints; j++){
					res += " " +g_arr[i,j] + "  ";
				}
				res += "\n";
			}
			return res;
		}
		
//		Vertex FindMe (string label)
//		{
//			Vertex v = root.Next;
//			while (! Equals(v, null) ) {
//				if (v.Label == label) 
//					return v;
//				v = v.Next;
//			}
//			return null;
//		}
		
		public void Reset()
		{
			v_root = new Vertex("ROOT", new Point(0,0));
			e_root = new Edge();
			IncrementLabel = 0;
			numPoints = 0;
			nowKey = 0;
			needToUpdateFloyd = true;
		}
		
		double[,] GraphToArray(Graph g)
		{
			double[,] res = new double[g.numPoints, g.numPoints];
			Edge ed = g.e_root;
			while (ed != null){
				if (ed.V_from != null && ed.V_where != null)
					res[ed.V_from.key, ed.V_where.key] = ed.Massa;
				ed = ed.Next;
			}
			return res;
		}
		
		public string ArrayToString(double[,] arr)
		{
			string res = "";
			int len = (int)Math.Sqrt(arr.Length);
			for(int i=0; i < len; i++){
				for(int j=0; j < len; j++){
					res += " " + arr[i, j] + "  ";
				}
				res += "\n";
			}
			return res;
		}
		
		public string forTesting()
		{
			string res = "";
			double[,] garr = GraphToArray(this);
			res += ArrayToString(garr);
			ChangeLinesAndColumns(ref garr, 0, 1);
			res += "\n";
			res += ArrayToString(garr);
			return res;
		}
		
		//-----------IZOMORFNOST------------
		
		public bool Izvomorfen(Graph g)
		{
			if (this.numPoints != g.numPoints)
				return false;
			
			double[,] g1_arr = GraphToArray(this);
			double[,] g2_arr = GraphToArray(g);
			if (g1_arr.Length != g2_arr.Length)
				return false;
			if (ArrayEquals(g1_arr, g2_arr) )
				return true;
			
			int len = (int)Math.Sqrt(g1_arr.Length);
			Random r = new Random();
			for(int i=0; i < 3000; i++){
				if (ArrayEquals(g1_arr, g2_arr) )
					return true;
				ChangeLinesAndColumns(ref g2_arr, r.Next(len), r.Next(len) );
			}
			
			
//			for(int k=0; k < len; k++){
//				for(int i=0; i < len; i++){
//					double[,] g2_clone = g2_arr.Clone() as double[,];
//					for(int j=0; j < len; j++){
//						if (i == j) continue;
//						ChangeLinesAndColumns(ref g2_clone, i, j);
//						if (ArrayEquals(g1_arr, g2_clone))
//							return true;
//					}
//					ChangeLinesAndColumns(ref g2_arr, k, i);
//				}
//			}
			return false;
		}
		
		bool ArrayEquals(double[,] d1, double[,] d2)
		{
			if (d1.Length != d2.Length)
				return false;
			int len = (int)Math.Sqrt(d1.Length);
			for(int i=0; i < len; i++){
				for(int j=0; j < len; j++){
					if (d1[i,j] != d2[i,j])
						return false;
				}
			}
			return true;
		}
		
		void ChangeLinesAndColumns(ref double[,] arr, int fr, int to)
		{
			// Change lines
			int len = (int)Math.Sqrt(arr.Length);
			for(int i=0; i < len; i++){
				double buf = arr[fr, i];
				arr[fr, i] = arr[to, i];
				arr[to, i] = buf;
			}
			
			// Change columns
			for(int i=0; i < len; i++){
				double buf = arr[i, fr];
				arr[i, fr] = arr[i, to];
				arr[i, to] = buf;
			}
		}
		
		
		//--------FLOYD-------------
		double[,] floyd;
		int?[,] floyd_points;
		public bool needToUpdateFloyd = true;
		
		void UpdateFloyd()
		{
			floyd = GraphToArray(this);
			for(int j=0; j < numPoints; j++){
				for(int i=0; i < numPoints; i++){
					if (floyd[i,j] == 0) 
						floyd[i,j] = double.PositiveInfinity;
				}
			}
					
			floyd_points = new int?[numPoints, numPoints];
			for (int i=0; i<numPoints; i++) {
				for (int j=0; j<numPoints; j++) {
					floyd_points[i,j] = null;
				}
			}
			
			for(int k=0; k < numPoints; k++){
				for(int j=0; j < numPoints; j++){
					for(int i=0; i < numPoints; i++){
						if (floyd[i,j] > floyd[i, k] + floyd[k, j]){
							floyd[i, j] = floyd[i, k] + floyd[k, j];
							floyd_points[i, j] = k;
						}
					}
				}
			}
			
			needToUpdateFloyd = false;
		}
		
		void UpdateFloyd(Graph g)
		{
			floyd = GraphToArray(g);
			for(int j=0; j < g.numPoints; j++){
				for(int i=0; i < g.numPoints; i++){
					if (floyd[i,j] == 0) 
						floyd[i,j] = double.PositiveInfinity;
				}
			}
					
			floyd_points = new int?[g.numPoints, g.numPoints];
			for (int i=0; i < g.numPoints; i++) {
				for (int j=0; j < g.numPoints; j++) {
					floyd_points[i,j] = null;
				}
			}
			
			for(int k=0; k < g.numPoints; k++){
				for(int j=0; j < g.numPoints; j++){
					for(int i=0; i < g.numPoints; i++){
						if (floyd[i,j] > floyd[i, k] + floyd[k, j]){
							floyd[i, j] = floyd[i, k] + floyd[k, j];
							floyd_points[i, j] = k;
						}
					}
				}
			}
			
			//needToUpdateFloyd = false;
		}
		
		// syncronize floyd and edines
		public void SyncFloydMasses(Vertex v_from)
		{
			Vertex v;
			if (v_from == null){
				// make null all
				v = V_Root.Next;
				while(v != null){
					v.MassaFromNowPoint = double.PositiveInfinity;
					v = v.Next;
				}
				return;
			}
				
			if (needToUpdateFloyd)
				UpdateFloyd();
			
			v = V_Root.Next;
			while(v != null){
				v.MassaFromNowPoint = floyd[v_from.key, v.key];
				v = v.Next;
			}
		}
		
		public string FloydToString()
		{
			if (numPoints == 0) 
				return "Empty graph.";
			
			if (needToUpdateFloyd)
				UpdateFloyd();
			string[] labels = new string[numPoints];
			
			Vertex v = v_root.Next;
			while(v != null){
				labels[v.key] = v.Label;
				v = v.Next;
			}
			
			string res = "    ";
			foreach(string s in labels)
				res += s + "|";
			res += "\n";
			
			for(int i=0; i < numPoints; i++){
				res += labels[i] + ":";
				for(int j=0; j < numPoints; j++){
					if (floyd[i,j] == double.PositiveInfinity)
						res += " _  ";
					else
						res += " " + floyd[i,j] + "  ";
				}
				res += "\n";
			}
			return res;
		}
		
		
		public string FloidPointsToString()
		{
			if (numPoints == 0) 
				return "Empty graph.";
			
			if (needToUpdateFloyd)
				UpdateFloyd();
			string[] labels = new string[numPoints];
			
			Vertex v = v_root.Next;
			while(v != null){
				labels[v.key] = v.Label;
				v = v.Next;
			}
			
			string res = "    ";
			foreach(string s in labels)
				res += s + "|";
			res += "\n";
			
			for(int i=0; i < numPoints; i++){
				res += labels[i] + ":";
				for(int j=0; j < numPoints; j++){
					if (floyd_points[i,j] == null)
						res += " _  ";
					else
						res += " " + floyd_points[i,j] + "  ";
				}
				res += "\n";
			}
			return res;
		}
		
		//-----------------GAMILTONOV---------------//
		public int[] gamil_check;
		public bool Gamilton()
		{
			if (numPoints < 3)
				return false;
			gamil_check = new int[numPoints];
			Edge ed = e_root.Next;
			while( ed != null ){
				gamil_check[ed.V_from.key]++;
				ed = ed.Next;
			}
			foreach(int a in gamil_check){
				if ( (double)a < (double)numPoints / 2 )
					return false;
			}
			return true;
		}
		
		public string GamilToString(int[] gam)
		{
			string res = "";
			foreach(int a in gam)
				res += a + "  ";
			res += "\n numPoints = " + numPoints.ToString();
			return res;
		}
		
		public bool Fleri()
		{
			if (numPoints < 0 || ! IsEuler())
				return false;
			int numEd = 0;
			Edge ed = e_root.Next;
			while(ed != null){
				numEd++;
				ed = ed.Next;
			}
			if (numEd == 0)
				return false;
//			bool[] deleted_edges = new bool[numEd+21];
//			
//			for(int i=0; i <= numEd; i++)
//				deleted_edges[i] = false; // need it???
//			
			int numFleri = 0;
			ed = e_root.Next;
			ed.numForFleri = numFleri;
			ed.isDeleted = true;
			//deleted_edges[numFleri] = true;
			numFleri++;
			
			//int ix=0;
			Edge ed_find = ed.Next;
			while(ed_find != null){
				if (! ed_find.isDeleted && ed_find.V_from == ed.V_where && 	// если не удаленное ребро и откуда == куда
				      ed_find.V_where != ed.V_from && ! IsMost(ed_find) ){		// и куда != откуда и не мост
					//deleted_edges[ix] = true;
					ed_find.isDeleted = true;
					ed_find.numForFleri = numFleri;
					numFleri++;
					ed = ed_find;
					ed_find = e_root.Next;
					//ix = 0;
				}
				ed_find = ed_find.Next;
				//ix++;
			}
			
			ed = e_root.Next;
			while(ed != null){
				ed.isDeleted = false;
				ed = ed.Next;
			}
			
			return true;
		}
		
		bool IsMost(Edge ed) // Ребро - мост?
		{
			bool res = true;
			Graph g = this;
			g.DeleteLine(ed);
			if (IsConnected(g))
				res = false;
			g.AddLine(ed);
			return res;
		}
		
		public bool IsConnected()
		{
			return IsConnected(this);
		}
		
		bool IsConnected(Graph g)  // Граф связный?
		{
			if (g.numPoints == 0)
				return false;
			needToUpdateFloyd = true;
			UpdateFloyd(g);
			for (int i = 0; i < g.numPoints; i++) {
				for (int j = 0; j < g.numPoints; j++) {
					if (! floyd_points[i,j].HasValue && floyd[i,j] == double.PositiveInfinity)
						return false;
				}
			}
			return true;
		}
		
		bool IsEuler()	// Граф Эйлеров?
		{
			int[] euler_check = new int[numPoints];
			Edge ed = e_root.Next;
			while( ed != null ){
				euler_check[ed.V_from.key]++;
				ed = ed.Next;
			}
			foreach(int a in euler_check){
				if ( (double) a % 2 != 0 )
					return false;
			}
			return true;
		}
	}
}
