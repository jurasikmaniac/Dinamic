// Created by SharpDevelop.
// User: Миха
// Date: 18.03.2009
// Time: 20:32

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace graph
{
	
	//
	// Windows presentation foundation
	//

	public partial class MainForm : Form
	{
		int Radius = 15;
		
		List<PictureBox> pictures = new List<PictureBox>();
		//List<Image> images = new List<Image>();
		//List<Graphics> graphics = new List<Graphics>();
		Graphics g;
		
		int nowGraph = 0;
		
		Pen black_p = new Pen(Color.Black, 1);
		Pen red_p = new Pen(Color.Red, 2);
		Pen green_p = new Pen(Color.Green, 1);
		Brush green_b = new SolidBrush(Color.DarkGreen);
		Brush black_b = new SolidBrush(Color.Black);
		Brush red_b = new SolidBrush(Color.Red);
		
		bool makeLines = true;
		bool showLabels = true;
		bool showWeight = true;
		bool showWeightFromPoint = false;
		bool showNumsFleri = false;
		bool isOriented = true;
			
		
		Vertex moveMe = null;
		Vertex letsMakeLine = null;
		Vertex forChange = null;
		Edge usingLine = null;
		
		//Vertex MoveMe = null;
		//bool IsCtrlPressing = false;
		Point whereIsMouseOnMouseDown;
		//int IncrementLabel = 0;
		Font font;
		//============================================//
		public List<Graph> GRAPHS = new List<Graph>();
		//============================================//
		New newG;
		Algoritms algoritmsG;
		
		public MainForm()
		{
			InitializeComponent();
			
			newG = new New();
			AddOwnedForm(newG);
			
			algoritmsG = new Algoritms();
			AddOwnedForm(algoritmsG);
			
			
			
			
			font = (Font)this.Font.Clone();
			
			pictures.Add(new PictureBox());
			UpdatePictures();
			UpdateEvents(nowGraph);
			GRAPHS.Add( new Graph("Graph[0]"));
			tabControl1.TabPages[0].Text = "Graph[0]";
			toolStripStatusLabel1.Text = string.Format("{0,30}", " ");
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			MainFormSizeChanged(sender, e);
		}
		
		void MainFormSizeChanged(object sender, EventArgs e)
		{
			
			int h = this.Height - tabControl1.Location.Y - 50;
			int w = this.Width - tabControl1.Location.X - 150;
			if (h <= 0) h = 1;
			if (w <= 0) w = 2;
			try{
				if ( splitContainer1.Panel1MinSize < w && w < splitContainer1.Width - splitContainer1.Panel2MinSize)
					splitContainer1.SplitterDistance = w;
			}catch(Exception ex){
				MessageBox.Show("Some problems with SplitterDistance = " + w.ToString() + "\n" + ex.ToString());
			}
			
			
			foreach(PictureBox p in pictures){
				p.Width = tabControl1.TabPages[0].Width;
				p.Height = tabControl1.TabPages[0].Height;
			}
			tabControl1.Height = h;
			tabControl1.Width = w;
			
			UpdatePictures();
			
			//groupBox1.Location.X = w + pictureBox1.Location.X;
			
			ReFillAll(); 
		}
		
		void UpdateEvents(int indxPicture)
		{
			pictures[indxPicture].MouseDoubleClick 		+= new MouseEventHandler(this.PictureBoxMouseDoubleClick);
			pictures[indxPicture].MouseDown 			+= new MouseEventHandler(this.PictureBoxMouseDown);
			pictures[indxPicture].MouseUp 				+= new MouseEventHandler(this.PictureBoxMouseUp);
			pictures[indxPicture].MouseMove 			+= new MouseEventHandler(this.PictureBoxMouseMove);
			pictures[indxPicture].MouseLeave 			+= new EventHandler(this.PictureBoxMouseLeave);
//			pictures[indxPicture].Paint 				+= new PaintEventHandler(this.PictureBoxPaint);
			pictures[indxPicture].KeyUp					+= new KeyEventHandler(this.PictureBoxKeyPress);
		}
		
		void UpdatePictures()
		{
			for(int i=0; i < pictures.Count; i++){
				pictures[i].Parent = 	tabControl1.TabPages[i];
				pictures[i].Width = 	tabControl1.Width - 10;
				pictures[i].Height = 	tabControl1.Height - 25;
				pictures[i].BackColor = Color.Gainsboro;
				pictures[i].Image = 	new Bitmap(pictures[i].Width, pictures[i].Height);
				tabControl1.TabPages[i].BorderStyle = BorderStyle.Fixed3D;
				tabControl1.TabPages[i].Cursor = Cursors.Cross;
			}
		}
		
		Vertex FindMe(Point find_me)
		{
			Vertex p = GRAPHS[nowGraph].V_Root.Next;
			while (! Equals(p, null) ){
				int x = find_me.X - p.X;
				int y = find_me.Y - p.Y;
				if ( x*x + y*y <= Radius*Radius){
					return p;
				}
				p = p.Next;
			}
			return null;
		}
		
	
		
		Vertex FindMe(int key, Graph gr)
		{
			Vertex p = gr.V_Root.Next;
			while (! Equals(p, null) ){
				if (p.key == key)
					return p;
				p = p.Next;
			}
			return null;
		}
		
		Vertex FindMe(string label)
		{
			Vertex p = GRAPHS[nowGraph].V_Root.Next;
			while (! Equals(p, null) ){
				if (p.Label == label)
					return p;
				p = p.Next;
			}
			return null;
		}
		
		Edge FindEdge(Vertex v_from, Vertex v_where)
		{
			Edge ed = GRAPHS[nowGraph].E_Root.Next;
			while (ed != null){
				if (ed.V_from == v_from && ed.V_where == v_where){
					return ed;
				}
				ed = ed.Next;
			}
			return null;
		}
		
		void TrackBar1Scroll(object sender, EventArgs e)
		{
			Radius = trackBar1.Value;
			ReFillAll();
		}
		
		void ButtonLabelSetClick(object sender, EventArgs e)
		{
			if (Equals(forChange, null))
				return;
			if(!Equals(FindMe(textBoxToSetLabel.Text), null) ){
				MessageBox.Show("Point with this label is exists: " + textBoxToSetLabel.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
				//throw new ArgumentException("Point with this label is exists: " + textBox1.Text);
			forChange.Label = textBoxToSetLabel.Text;
			moveMe = null;
			ReFillAll();
			UpdateLabelsInCheckedList();
		}
		
		void ButtonWeightSetClick(object sender, EventArgs e)
		{
			if (forChange == null || Equals(checkedListBox1.SelectedItem, null) )
				return;
			
			double massa;
			try{
				massa = Convert.ToDouble(textBoxToSetWeight.Text);
			}catch{
				MessageBox.Show("Wrong input: massa","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			Edge ed = GRAPHS[nowGraph].E_Root.Next;
			Vertex v_find = FindMe(checkedListBox1.SelectedItem.ToString());
			while (ed != null){
				if (ed.V_from == forChange && ed.V_where == v_find){
					ed.Massa = massa;
					break;
				}
				ed = ed.Next;
			}
			GRAPHS[nowGraph].needToUpdateFloyd = true;
			ReFillAll();
		}
		
		void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (forChange == null)
				return;
			
			GRAPHS[nowGraph].DeletePoint(forChange);
			
			moveMe = null;
			letsMakeLine = null;
			forChange = null;
			usingLine = null;
			textBoxToSetLabel.Text = "";
			textBoxToSetWeight.Text = "";
			toolStripStatusLabel2.Text = "";
			
			buttonWeightSet.Enabled = false;
			buttonLabelSet.Enabled = false;
			UpdateLabelsCheckInCheckedList();
			
			ReFillAll();
		}
		
		
		//List<object> adjacent;
		
		void CheckedListBox1MouseUp(object sender, MouseEventArgs e)
		{
			if (checkedListBox1.SelectedIndex == -1){
				usingLine = null;
				return;
			}
			Edge ed = null;
			Vertex v = null;
			
			//string s = "";
			for(int i=0; i < GRAPHS[nowGraph].NumberOfPoints; i++){
				//label6.Text = Graph[nowGraph].NumberOfPoints.ToString();
				if (checkedListBox1.GetItemChecked(i)){
					v = FindMe(checkedListBox1.Items[i].ToString());
					ed = FindEdge(v, forChange);
					if ( ed == null)
						GRAPHS[nowGraph].AddLine(forChange, v, 1.0, true);
					else
						GRAPHS[nowGraph].AddLine(forChange, v, 1.0, ! ed.iAmFirstLine);
				}else{
					v = FindMe(checkedListBox1.Items[i].ToString());
					ed = FindEdge(forChange, v);
					//if (ed != null)
					GRAPHS[nowGraph].DeleteLine(ed);
				}
			}
			
			v = FindMe(checkedListBox1.SelectedItem.ToString());
			usingLine = FindEdge(forChange, v);
			
			if (usingLine != null) {
				textBoxToSetWeight.Text = usingLine.Massa.ToString();
			} else {
				textBoxToSetWeight.Text = "";
			}
			
			if (checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex)){
				buttonWeightSet.Enabled = true;
				//Vertex v = FindMe(checkedListBox1.SelectedItem.ToString());
				//ed = FindEdge(ForChange, v);
				if (usingLine == null || usingLine.V_where == null) // for tobe :)
					textBoxToSetWeight.Text = "";
				else
					textBoxToSetWeight.Text = usingLine.Massa.ToString();
			}else{
				buttonWeightSet.Enabled = false;
				textBoxToSetWeight.Text = "";
			}
						
			//MessageBox.Show(s); // for Testing
			UpdateLabelsCheckInCheckedList();
			ReFillAll();
		}
		
		
		
		void TabControl1SelectedIndexChanged(object sender, EventArgs e)
		{
			nowGraph = tabControl1.SelectedIndex;
			algoritmsG.nowGraph = nowGraph;
			
			moveMe = null;
			letsMakeLine = null;
			forChange = null;
			usingLine = null;
			textBoxToSetLabel.Text = "";
			textBoxToSetWeight.Text = "";
			toolStripStatusLabel2.Text = "";
			buttonWeightSet.Enabled = false;
			
			//PicEnabledFalse();
			//pictures[nowGraph].Enabled = true;
			
			ReFillAll();
		}
		
		
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
//			if (e.KeyCode == Keys.Delete)
//				ButtonDeleteClick(sender, null);
		}
		
		void FontToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(fontDialog1.ShowDialog() == DialogResult.OK){
				font = fontDialog1.Font;
				ReFillAll();
			}
		}
		
		void ColorForVertexToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.OK){
				black_b = new SolidBrush(colorDialog1.Color);
				black_p = new Pen(colorDialog1.Color, 1);
				ReFillAll();
			}
		}
		
		void ColorForUsingVertexAndEdgeToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.OK){
				red_b = new SolidBrush(colorDialog1.Color);
				red_p = new Pen(colorDialog1.Color, 2);
				ReFillAll();
			}
		}
		
		void TabControl1MouseDoubleClick(object sender, MouseEventArgs e)
		{
			//NewToolStripMenuItemClick(sender, null);
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			MessageBox.Show("Hello...");
		}
	}
}