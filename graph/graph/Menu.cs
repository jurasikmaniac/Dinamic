// Created by SharpDevelop.
// User: Миха
// Date: 27.03.2009
// Time: 19:33


using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace graph
{

	public partial class MainForm
	{
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void CloseToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (nowGraph == -1)
				return;
			if (MessageBox.Show("Save it?", "Save graph?", 
			                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				SaveToolStripMenuItemClick(sender, null);
			
			if (nowGraph < 0)
				return;
			moveMe = null;
			letsMakeLine = null;
			forChange = null;
			usingLine = null;
			textBoxToSetLabel.Text = "";
			textBoxToSetWeight.Text = "";
			toolStripStatusLabel2.Text = "";
			buttonWeightSet.Enabled = false;
			buttonDeletePoint.Enabled = false;
			buttonLabelSet.Enabled = false;
			
			GRAPHS.RemoveAt(nowGraph);
			pictures.RemoveAt(nowGraph);
			tabControl1.TabPages.RemoveAt(nowGraph);
			//nowGraph--;
		}
		
		void QuitToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("This program made for you in #develop 3.0.0.3800; \n" +
			                "Licensed by GNU GPL: \n" +
			                "\thttp://www.gnu.org/copyleft/gpl.html\n" +
			                "Developer:\n" +
			                "\tMike Shatohin; \n" +
			                "Version: \n" +
			                "\tGraphs_and_algoritms 0.2; \n\n" +
			                "Thanks to: \n" +
			                "\tMamaev Sergey (who test this program);\n" +
			                "\tBuyanov Max (just for fun);",
			                "About myGraph", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		
		void ToolStripMenuItem1Click(object sender, EventArgs e)
		{
			MessageBox.Show("For make point: double click on light gray list;\n" +
			                "For make line: click on point and click on other point, or check it on checkBoxList;\n" +
			                "Red text (top left corner) - min massa to go to this point from checked point;\n" +
			                "Black text (top right corner) - label of checked point;\n",
			                "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		
		void NewToolStripMenuItemClick(object sender, EventArgs e)
		{
			// Bidlo COD
			string[] names = new string[GRAPHS.Count];
			for(int i=0; i < GRAPHS.Count; i++){
				names[i] = GRAPHS[i].Name;
			}
			newG.Names = names;
			newG.GraphName = "Graph[" + tabControl1.TabPages.Count + "]";
			newG.ShowDialog();
			if (! newG.Cancel){
				tabControl1.TabPages.Add(new TabPage(newG.GraphName));
				
				GRAPHS.Add(new Graph(newG.GraphName));
				pictures.Add(new PictureBox());
				UpdatePictures();
				tabControl1.SelectTab(tabControl1.TabCount - 1);
				if (nowGraph < 0) 
					nowGraph = 0;
				UpdateEvents(nowGraph);
				// new KOSTIL
				//PicEnabledFalse();
				//pictures[nowGraph].Enabled = true;
				
				ReFillAll();
			}
		}
		
		void GraphfToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (nowGraph == -1)
				return;
			MessageBox.Show(GRAPHS[nowGraph].GraphArrayToString(), "Get Graph", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			//gGraph.Show();
		}
		
		void PointsToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (nowGraph == -1)
				return;
			Vertex p = GRAPHS[nowGraph].V_Root.Next;
			string s = " ";
			while (! Equals(p, null) ){
				s += "X=" + p.X + ", Y=" + p.Y + " label = " + p.Label +"\n";
				p = p.Next;
			}
			MessageBox.Show("Points: \n" + s);
		}
		
		void MakeLinesToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			makeLines = makeLinesToolStripMenuItem.Checked;
			toolStripLabelMakeLine.Visible = false;
			ReFillAll();
		}
		
		void ShowWeightsToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			showWeight = showWeightsToolStripMenuItem.Checked;
			ReFillAll();
		}
		
		void ShowLabelsToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			showLabels = showLabelsToolStripMenuItem.Checked;
			ReFillAll();
		}
		
		void ShowWeightsFromNowPointToolStripMenuItemClick(object sender, EventArgs e)
		{
			showWeightFromPoint = showWeightsFromNowPointToolStripMenuItem.Checked;
			ReFillAll();
		}
		
		void ShowNumsFleriToolStripMenuItemClick(object sender, EventArgs e)
		{
			showNumsFleri = showNumsFleriToolStripMenuItem.Checked;
			ReFillAll();
		}
		
		void OrientedToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			isOriented = orientedToolStripMenuItem.Checked;
			ReFillAll();
		}
		
		void ClearToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (nowGraph == -1)
				return;
			GRAPHS[nowGraph].Reset();
			ReFillAll();
		}
		
		void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			while(true) {
				try{
					if (nowGraph == -1)
						return;
					saveFileDialog1.FileName = GRAPHS[nowGraph].Name + ".graph";
					if(saveFileDialog1.ShowDialog() == DialogResult.OK){
						if (saveFileDialog1.FilterIndex == 1){
							SaveAsGraph();
						}else{
							SaveAsBmp();
						}
					}
					return;
				}catch{
					DialogResult dr = MessageBox.Show("Some happens wrong...", "Error",
					                                  MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
					if (dr == DialogResult.Abort){
						MainForm.ActiveForm.Close();
						//return;
					}else if( dr == DialogResult.Ignore)
						return;
				}
			}
		}
		
		void SaveAsBmp()
		{// Save --> Save as Image
			//if (saveFileDialog1.ShowDialog() == DialogResult.OK){
			//	string s = ;
				pictures[nowGraph].Image.Save(saveFileDialog1.FileName);
			//}
		}
		
		void GraphNameToolStripMenuItemClick(object sender, EventArgs e)
		{ 
			if (nowGraph == -1)
				return;
			newG.GraphName = GRAPHS[nowGraph].Name;
			// Bidlo COD
			string[] names = new string[GRAPHS.Count];
			for(int i=0; i < GRAPHS.Count; i++){
				names[i] = GRAPHS[i].Name;
			}
			newG.Names = names;
			newG.ShowDialog();
			GRAPHS[nowGraph].Name = newG.GraphName;
			tabControl1.TabPages[nowGraph].Text = newG.GraphName;
			
		}
		
//		void PicEnabledFalse()
//		{
//			foreach(PictureBox p in pictures)
//				p.Enabled = false;
//		}
		
		void TestToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (nowGraph == -1)
				return;
			MessageBox.Show(GRAPHS[nowGraph].forTesting());
		}
		
		void AlgoritmsToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (nowGraph == -1)
				return;
			algoritmsG.GRAPHS = GRAPHS;
			algoritmsG.nowGraph = nowGraph;
			algoritmsG.Show();
		}
		
	}
}