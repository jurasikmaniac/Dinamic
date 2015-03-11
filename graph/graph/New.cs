// Created by SharpDevelop.
// User: Миха
// Date: 29.03.2009
// Time: 15:58

using System;
using System.Drawing;
using System.Windows.Forms;

namespace graph
{
	public partial class New : Form
	{
		public New()
		{
			InitializeComponent();
			textBox1.Text = GraphName;
			
			this.Hide();
		}
		
		private bool cancel = false; // to check if i close form New and cancel add new Graph
		public bool Cancel
		{
			get{ return cancel; }
		}
		
		private string[] names;
		public string[] Names
		{
			set{ names = value; }
		}
		
		private string graphName;
		public string GraphName
		{
			get{ return graphName; }
			set{ graphName = value; }
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			cancel = false;
			if (textBox1.Text == ""){
				MessageBox.Show("Error: Name.Length must be > 0", "Error", 
				                MessageBoxButtons.OK, MessageBoxIcon.Error);
			}else{
				// 
				GraphName = textBox1.Text;
				if (CheckOnExists())
					MessageBox.Show("Error: Graph with this name: '" + GraphName + "' is exists", "Error",
				                MessageBoxButtons.OK, MessageBoxIcon.Error);
				else
					this.Hide();
			}
		}
		
		
		bool CheckOnExists()
		{
			foreach(string s in names){
				if (s == GraphName)
					return true;
			}
			return false;
		}
		
		void NewFormClosing(object sender, FormClosingEventArgs e)
		{
			if( e.CloseReason == CloseReason.UserClosing){
				e.Cancel = true;
				cancel = true; 
				this.Hide();
			}
		}
		
		void NewShown(object sender, EventArgs e)
		{
			
			textBox1.Text = graphName;
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			cancel = true;
			this.Hide();
		}
	}
}
