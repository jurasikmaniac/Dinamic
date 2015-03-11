// Created by SharpDevelop.
// User: Миха
// Date: 29.03.2009
// Time: 12:46

using System;
using System.Collections.Generic;
using System.Text;

namespace graph
{
	public class GraphXml
	{
		private string name;
		public string Name 
		{
			get{ return name; }
			set{ name = value; }
		}
		
		private int numPoints;
		public int NumPoints
		{
			get{ return numPoints; }
			set{ numPoints = value; }
		}
	}
}
