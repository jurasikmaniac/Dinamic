// Created by SharpDevelop.
// User: Миха
// Date: 27.03.2009
// Time: 19:13


using System;
using System.Drawing;
using System.Windows.Forms;

namespace graph
{

	public partial class MainForm : Form
	{
		// КОСТЫЛЬ (((
//		int incremMD = 0;
//		int incremDC = 0;
//		int incremMM = 0;
		// end КОСТЫЛЬ
		void PictureBoxMouseDoubleClick(object sender, MouseEventArgs e)
		{
			// КОСТЫЛЬ (((
//			incremDC++;
//			if(incremDC > 1) 
//				return;
			//end КОСТЫЛЬ (((
			
			if (e.Button != MouseButtons.Left)
				return;
			if (! Equals(FindMe(e.Location) , null) )  // have points here and not to make it
				return;
			int X = e.X;
			int Y = e.Y;
			//string label = "G" + IncrementLabel.ToString();
			GRAPHS[nowGraph].Add(e.Location);
			//IncrementLabel++;
			ReFillAll();
		}
		
		
		void PictureBoxMouseDown(object sender, MouseEventArgs e)
		{
			
			//MessageBox.Show(sender.GetType().ToString());
			
			// не работающий костыль...
			//if (! Equals( (sender as PictureBox), pictures[nowGraph] ) )
			//	return;
			
			// КОСТЫЛЬ плохо работающий (((
//			incremMD++;
//			if (incremMD > 1) 
//				return;
//			label6.Text = "incremMD = " + incremMD.ToString() + 
//				"\nincremMM = " + incremMM.ToString() +
//				"\nincremDC = " + incremDC.ToString();
			// end КОСТЫЛЬ (((
			
			whereIsMouseOnMouseDown = e.Location;
			checkedListBox1.Items.Clear();
			//adjacent.Clear();
			
			Vertex NowP = FindMe(e.Location);
			if(Equals(NowP, null)){
				moveMe = null;
				letsMakeLine = null;
				forChange = null;
				usingLine = null;
				textBoxToSetLabel.Text = "";
				toolStripStatusLabel2.Text = "";
				//Graph[nowGraph].needToUpdateFloyd = true;
				ReFillAll();
				return;
			}
			
			moveMe = NowP;
			
			if(Equals(letsMakeLine, null)){
				letsMakeLine = NowP;
			}else {
				//
				// NowP and UseMe is Exists here
				//
				if (makeLines){
					Edge ed = FindEdge(NowP, letsMakeLine);
					if ( ed == null )
						GRAPHS[nowGraph].AddLine(letsMakeLine, NowP, 1.0, true);
					else
						GRAPHS[nowGraph].AddLine(letsMakeLine, NowP, 1.0, ! ed.iAmFirstLine);
				}
				letsMakeLine = null;
			}
			forChange = moveMe;
			toolStripStatusLabel2.Text = "Using point.Label = " + forChange.Label;
			ReFillAll();
		}
		
		void PictureBoxMouseUp(object sender, MouseEventArgs e)
		{
			if (forChange == null){
				buttonLabelSet.Enabled = false;
				buttonDeletePoint.Enabled = false;
				buttonWeightSet.Enabled = false;
				//Graph[nowGraph].needToUpdateFloyd = true;
			}
			if (moveMe == null)
				return;
			textBoxToSetLabel.Text = moveMe.Label;
			buttonLabelSet.Enabled = true;
			buttonDeletePoint.Enabled = true;
			forChange = moveMe;
			
			UpdateLabelsInCheckedList();
			UpdateLabelsCheckInCheckedList();
			CheckedListBox1MouseUp(sender, null);
				
			moveMe = null;
			label6.Text = GRAPHS[nowGraph].GraphArrayToString();
			ReFillAll();
		}
		
		void UpdateLabelsInCheckedList()
		{
			if (nowGraph == -1) 
				return;
			checkedListBox1.Items.Clear();
			Vertex v = GRAPHS[nowGraph].V_Root.Next;
			while(! Equals(v, null) ){
				checkedListBox1.Items.Add(v.Label, false);
				v = v.Next;
			}
		}
		
		void UpdateLabelsCheckInCheckedList()
		{
			if (forChange == null){
				checkedListBox1.Items.Clear();
				return;
			}
			//UpdateLabelsInCheckedList();
			Edge ed = GRAPHS[nowGraph].E_Root.Next; 
			while(ed != null){
				if (ed.V_from == forChange){
					int thatToCheck = checkedListBox1.FindString(ed.V_where.Label);
					checkedListBox1.SetItemChecked(thatToCheck, true);
				}
				ed = ed.Next;
			}
		}
		
		
		Random needPaint = new Random();
		
		void PictureBoxMouseMove(object sender, MouseEventArgs e)
		{
			toolStripStatusLabel1.Text = string.Format("X = {0}, Y = {1}  ", e.X, e.Y);
			
			if (Equals(moveMe, null) )
				return;
			
		//	if (Equals((sender as PictureBox), pictures[nowGraph] ))
		//		MessageBox.Show("Hello there: " + tabControl1.TabPages[nowGraph].Text);
			
			if (! Equals(whereIsMouseOnMouseDown, e.Location)){
				Point p = e.Location;
				if (e.X < 0)
					p.X = 1;
				if (e.X > pictures[nowGraph].Width)
					p.X = pictures[nowGraph].Width;
				
				if (e.Y < 0)
					p.Y = 1;
				if (e.Y > pictures[nowGraph].Height)
					p.Y = pictures[nowGraph].Height;
				moveMe.P = p;
				toolStripStatusLabel1.Text = string.Format("X = {0}, Y = {1}  ", p.X, p.Y);
			}
			//if (needPaint.Next(2) == 0){
				ReFillAll();
			//}
			
			if (!Equals(forChange, null) )
				label6.Text = GRAPHS[nowGraph].GraphArrayToString() + "\n" + forChange.Label + " = " + forChange.key;
		}
		
		void PictureBoxMouseLeave(object sender, EventArgs e)
		{
			toolStripStatusLabel1.Text = string.Format("{0,30}", " ");
		}
		
//		void PictureBoxPaint(object sender, PaintEventArgs e)
//		{
//			if (! Equals(im, null) )
//				e.Graphics.DrawImage(im,0,0);
//		}
		
		void PictureBoxKeyPress(object sender, KeyEventArgs e)
		{
//			if (e.KeyCode == Keys.D)
//				ButtonDeleteClick(sender, null);
		}
	}
}