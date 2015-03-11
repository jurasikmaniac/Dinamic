// Created by SharpDevelop.
// User: Миха
// Date: 04.04.2009
// Time: 15:20

using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;


namespace graph
{
	public partial class MainForm
	{	
		
		Vertex FindMe(int key)
		{
			Vertex p = GRAPHS[nowGraph].V_Root.Next;
			while (! Equals(p, null) ){
				if (p.key == key)
					return p;
				p = p.Next;
			}
			return null;
		}

		void SaveAsGraph()
		{
			// Save --> Save as GraphXml
			//saveFileDialog1.DefaultExt = "graph";
			//if (saveFileDialog1.ShowDialog() != DialogResult.OK){
			//	return;
			//}
			
			Graph g = GRAPHS[nowGraph];
			StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
			sw.WriteLine("<GRAPH>");
			sw.WriteLine("  <Name>" + g.Name + "</Name>");
			//sw.WriteLine("  <NumPoints>" + g.NumberOfPoints.ToString() + "</NumPoints>");
			sw.WriteLine("");
			Vertex v = g.V_Root.Next;
			while(v != null){
				sw.WriteLine("  <Vertex>");
				sw.WriteLine("    <Label>"+ v.Label +"</Label>");
				sw.WriteLine("    <Key>" + v.key + "</Key>");
				sw.WriteLine("    <X>" + v.X + "</X>" );
				sw.WriteLine("    <Y>" + v.Y + "</Y>" );
				sw.WriteLine("  </Vertex>");
				v = v.Next;
			}
			sw.WriteLine("");
			Edge ed = g.E_Root.Next;
			while(ed != null) {
				sw.WriteLine("  <Edge>");
				sw.WriteLine("    <From>" + ed.V_from.key + "</From>");
				sw.WriteLine("    <Where>" + ed.V_where.key + "</Where>");
				sw.WriteLine("    <Massa>" + ed.Massa.ToString() + "</Massa>");
				sw.WriteLine("    <IamFirstLine>" + ed.iAmFirstLine.ToString() + "</IamFirstLine>");
				sw.WriteLine("  </Edge>");
				ed = ed.Next;
			}
			sw.WriteLine("</GRAPH>");
			sw.Close();
		}
		
		bool IsExistsGraphByName(string name)
		{
			foreach(Graph g in GRAPHS){
				if(g.Name == name)
					return true;
			}
			return false;
		}
		
		bool RegexForReadLine(string input, out string name)
		{
			name = "";
			Regex rg = new Regex(@"[^<>]*<([^<>]+)>[^<>]*");
			Match m = rg.Match(input);
			if (m.Value != "" && m.Groups.Count > 0 && m.Groups[1].Value != ""){
					name = m.Groups[1].Value;
					return true;
			}
			return false;
		}
	
		bool RegexForReadLine(string input, out string name, out string val)
		{
			name = "";
			val = "";
			Regex rg = new Regex(@"[^<>]*<([^<>]+)>([^<>]+)</([^<>]+)>[^<>]*");
			Match m = rg.Match(input);
			if (m.Value != "" && m.Groups.Count > 2 && m.Groups[1].Value != "" && m.Groups[2].Value != "" && m.Groups[3].Value != ""
			    && m.Groups[1].Value == m.Groups[3].Value){
					name = m.Groups[1].Value;
					val = m.Groups[2].Value;
					return true;
			}
			return false;
		}
		
		void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
			
			if(openFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			
			StreamReader sr;
			try{
				sr = new StreamReader(openFileDialog1.FileName);
			}catch{
				MessageBox.Show("Some with file is wrong.", "Error", 
				               MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			Graph gr = new Graph("temp");
			Vertex v = null;
			Edge ed = null;
			bool mustMakeGraph = false;
			
			while(! sr.EndOfStream  && ! error){
				string line = sr.ReadLine();
				//MessageBox.Show(line);
				Regex rg = new Regex(@"//.*"); // if comment then replace they from line
				rg.Replace(line, "");
				
				string name = "", val = "";
				if (RegexForReadLine(line, out name, out val) ){//&& mustMakeGraph){
					//MessageBox.Show("line: &&" + line + "&&\nname: &&" + name + "&&\nval: &&" + val + "&&\n");
					if (name.ToLower() == "name"){
						if (! IsExistsGraphByName(val))
							gr.Name = val;
						else{
							string name_n = GraphNameIsExists_ShowDialogToChangeIt(val);
							if (name_n != null)
								gr.Name = name_n;
							else
								ShowError("Graph name error, line: " + line);
							
						}
					}else if (v == null && ed == null)
						ShowError("v == null, ed == null, line: " + line);
					else if (v != null && ed == null){ 
						// edit vertex
						switch(name.ToLower()){
							case "label":
								v.Label = val;
								break;
							case "key":
								try{
									v.key = Convert.ToInt32(val);
								}catch{
									ShowError("Don't understand line: " + line);
								}
								break;
							case "x":
								try{
									v.X = Convert.ToInt32(val);
								}catch{
									ShowError("Don't understand line: " + line);
								}
								break;
							case "y":
								try{
									v.Y = Convert.ToInt32(val);
								}catch{
									ShowError("Don't understand line: " + line);
								}
								break;
							default:
								ShowError("Don't understand line: " + line);
								break;
						}
					}else if (ed != null){
						// edit edge
						
						//MessageBox.Show("GRAPH:\n" + gr.GraphArrayToString());
						
						
						switch(name.ToLower()){
							case "from":
								try{
									int from_key = Convert.ToInt32(val);
									Vertex vx_buf = FindMe(from_key, gr);
									if (vx_buf != null)
										ed.V_from = vx_buf;
									else
										throw new Exception("ERROR!!!");
								}catch{
									ShowError("Don't understand or can't find vertex line: " + line);
								}
								break;
							case "where":
								try{
									int from_key = Convert.ToInt32(val);
									Vertex vx_buf = FindMe(from_key, gr);
									if (vx_buf != null)
										ed.V_where = vx_buf;
									else
										throw new Exception("ERROR!!!");
								}catch{
									ShowError("Don't understand or can't find vertex line: " + line);
								}
								break;
							case "massa":
								try{
									ed.Massa = Convert.ToDouble(val);
								}catch{
									ShowError("Don't understand line: " + line);
								}
								break;
							case "iamfirstline":
								try{
									ed.iAmFirstLine = Convert.ToBoolean(val);
								}catch{
									ShowError("Don't understand line: " + line);
								}
								break;
							default:
								ShowError("Don't understand line: " + line);
								break;
						}
					}
				}else if (RegexForReadLine(line, out name)){
					//MessageBox.Show(line + "\n&&" + name + "&&");
					if (name.ToLower() == "graph")
						mustMakeGraph = true;
					else if (name.ToLower() == "vertex"){
						if (v == null)
							v = new Vertex();
						else
							ShowError("Error while reading vertex, line: " + line);
					}
					else if (name.ToLower() == "edge"){
						if (ed == null)
							ed = new Edge();
						else
							ShowError("Error while reading edge, line: " + line);
					} else if (name.ToLower() == "/vertex"){
						if (v != null){
							gr.Add(v);
							v = null;
						}else
							ShowError("Haven't any vertex to add, line: " + line);
					} else if (name.ToLower() == "/edge"){
						if (ed != null){
							gr.AddLine(ed);
							ed = null;
						}else
							ShowError("Haven't any edge to add, line: " + line);
					}else if (name.ToLower() == "/graph"){
						//mustMakeGraph = false;
						break;
					}
				}
				
			}
			
			if (! error && mustMakeGraph){
				MessageBox.Show("Lets make graph");
				MakeGraph(gr);
			}
			
			sr.Close();
			ReFillAll();
//			}catch{
//				MessageBox.Show("Some happens wrong...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//				return;
//			}
		}
		
		bool error = false;
		void ShowError(string error_message)
		{
			MessageBox.Show("Some error while reading file: " + error_message + ".\nGraph read cancel.", "Error", 
			               MessageBoxButtons.OK, MessageBoxIcon.Error);
			error = true;
		}
		
		
		string GraphNameIsExists_ShowDialogToChangeIt(string name)
		{
			if (MessageBox.Show("This graph: " + name + " just using.\nChange name graf?", "that to do?",
			                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK){
				string[] names = new string[GRAPHS.Count];
				for(int i=0; i < GRAPHS.Count; i++){
					names[i] = GRAPHS[i].Name;
				}
				newG.Names = names;
				Regex rg = new Regex(@"([^\\/]+.graph)$");
				Match m = rg.Match(openFileDialog1.FileName);
				if (m.Groups[1].Value != "")
					newG.GraphName = name + "_" + m.Groups[1].Value;
				else
					newG.GraphName = name + "_new";
				newG.ShowDialog();
				if (newG.Cancel)
					return null;
				return newG.GraphName;
			}
			return null;
		}
		
		void MakeGraph(Graph gr)
		{
			GRAPHS.Add(gr);
			pictures.Add(new PictureBox());
			tabControl1.TabPages.Add(new TabPage(gr.Name));
			UpdatePictures();
			tabControl1.SelectTab(tabControl1.TabCount - 1);
			if (nowGraph == -1)
				nowGraph = 0;
			UpdateEvents(nowGraph);
		}
	}
}