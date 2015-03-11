// Created by SharpDevelop.
// User: Миха
// Date: 18.03.2009
// Time: 20:32

namespace graph
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxToSetLabel = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonLabelSet = new System.Windows.Forms.Button();
			this.buttonDeletePoint = new System.Windows.Forms.Button();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonClickMe = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonWeightSet = new System.Windows.Forms.Button();
			this.textBoxToSetWeight = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.makeLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showWeightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.orientedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showWeightsFromNowPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showNumsFleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.algoritmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.getToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.GraphfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.GraphNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorForVertexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorForUsingVertexAndEdgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripLabelMakeLine = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxToSetLabel
			// 
			this.textBoxToSetLabel.Location = new System.Drawing.Point(6, 37);
			this.textBoxToSetLabel.MaxLength = 7;
			this.textBoxToSetLabel.Name = "textBoxToSetLabel";
			this.textBoxToSetLabel.Size = new System.Drawing.Size(67, 20);
			this.textBoxToSetLabel.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 12);
			this.label2.TabIndex = 8;
			this.label2.Text = "Label:";
			// 
			// buttonLabelSet
			// 
			this.buttonLabelSet.Enabled = false;
			this.buttonLabelSet.Location = new System.Drawing.Point(79, 37);
			this.buttonLabelSet.Name = "buttonLabelSet";
			this.buttonLabelSet.Size = new System.Drawing.Size(44, 23);
			this.buttonLabelSet.TabIndex = 9;
			this.buttonLabelSet.Text = "set";
			this.buttonLabelSet.UseVisualStyleBackColor = true;
			this.buttonLabelSet.Click += new System.EventHandler(this.ButtonLabelSetClick);
			// 
			// buttonDeletePoint
			// 
			this.buttonDeletePoint.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonDeletePoint.Enabled = false;
			this.buttonDeletePoint.Location = new System.Drawing.Point(3, 415);
			this.buttonDeletePoint.Name = "buttonDeletePoint";
			this.buttonDeletePoint.Size = new System.Drawing.Size(130, 23);
			this.buttonDeletePoint.TabIndex = 10;
			this.buttonDeletePoint.Text = "Delete Point";
			this.buttonDeletePoint.UseVisualStyleBackColor = true;
			this.buttonDeletePoint.Click += new System.EventHandler(this.ButtonDeleteClick);
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(5, 276);
			this.trackBar1.Maximum = 60;
			this.trackBar1.Minimum = 10;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(117, 45);
			this.trackBar1.TabIndex = 11;
			this.trackBar1.Value = 15;
			this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1Scroll);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(5, 260);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(117, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Radius:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonClickMe);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.buttonWeightSet);
			this.groupBox1.Controls.Add(this.textBoxToSetWeight);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.checkedListBox1);
			this.groupBox1.Controls.Add(this.trackBar1);
			this.groupBox1.Controls.Add(this.buttonDeletePoint);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.buttonLabelSet);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBoxToSetLabel);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(136, 441);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Vertex";
			// 
			// buttonClickMe
			// 
			this.buttonClickMe.BackColor = System.Drawing.Color.Transparent;
			this.buttonClickMe.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonClickMe.Location = new System.Drawing.Point(120, 398);
			this.buttonClickMe.Name = "buttonClickMe";
			this.buttonClickMe.Size = new System.Drawing.Size(1, 1);
			this.buttonClickMe.TabIndex = 0;
			this.buttonClickMe.TabStop = false;
			this.buttonClickMe.Text = "clickMe";
			this.buttonClickMe.UseVisualStyleBackColor = false;
			this.buttonClickMe.Click += new System.EventHandler(this.Button1Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 63);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 23);
			this.label1.TabIndex = 20;
			this.label1.Text = "Edges:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonWeightSet
			// 
			this.buttonWeightSet.Enabled = false;
			this.buttonWeightSet.Location = new System.Drawing.Point(83, 229);
			this.buttonWeightSet.Name = "buttonWeightSet";
			this.buttonWeightSet.Size = new System.Drawing.Size(39, 23);
			this.buttonWeightSet.TabIndex = 16;
			this.buttonWeightSet.Text = "set";
			this.buttonWeightSet.UseVisualStyleBackColor = true;
			this.buttonWeightSet.Click += new System.EventHandler(this.ButtonWeightSetClick);
			// 
			// textBoxToSetWeight
			// 
			this.textBoxToSetWeight.Location = new System.Drawing.Point(10, 232);
			this.textBoxToSetWeight.Name = "textBoxToSetWeight";
			this.textBoxToSetWeight.Size = new System.Drawing.Size(67, 20);
			this.textBoxToSetWeight.TabIndex = 15;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("DejaVu Sans Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(6, 328);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(117, 47);
			this.label6.TabIndex = 19;
			this.label6.Text = "alpha = ";
			this.label6.Visible = false;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(5, 214);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(117, 15);
			this.label5.TabIndex = 14;
			this.label5.Text = "Weight:";
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.checkedListBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(10, 89);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(113, 122);
			this.checkedListBox1.Sorted = true;
			this.checkedListBox1.TabIndex = 13;
			this.checkedListBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CheckedListBox1MouseUp);
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.optionsToolStripMenuItem,
									this.algoritmsToolStripMenuItem,
									this.getToolStripMenuItem,
									this.setToolStripMenuItem,
									this.aboutToolStripMenuItem,
									this.toolStripMenuItem1,
									this.clearToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(741, 24);
			this.menuStrip1.TabIndex = 21;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.newToolStripMenuItem,
									this.saveToolStripMenuItem,
									this.openToolStripMenuItem,
									this.closeToolStripMenuItem,
									this.exitToolStripMenuItem,
									this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItemClick);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.closeToolStripMenuItem.Text = "Close graph";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItemClick);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.exitToolStripMenuItem.Text = "Exit program";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Visible = false;
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItemClick);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.makeLinesToolStripMenuItem,
									this.showWeightsToolStripMenuItem,
									this.showLabelsToolStripMenuItem,
									this.orientedToolStripMenuItem,
									this.showWeightsFromNowPointToolStripMenuItem,
									this.showNumsFleriToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// makeLinesToolStripMenuItem
			// 
			this.makeLinesToolStripMenuItem.Checked = true;
			this.makeLinesToolStripMenuItem.CheckOnClick = true;
			this.makeLinesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.makeLinesToolStripMenuItem.Name = "makeLinesToolStripMenuItem";
			this.makeLinesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.makeLinesToolStripMenuItem.Text = "Make edges";
			this.makeLinesToolStripMenuItem.Click += new System.EventHandler(this.MakeLinesToolStripMenuItemClick);
			// 
			// showWeightsToolStripMenuItem
			// 
			this.showWeightsToolStripMenuItem.Checked = true;
			this.showWeightsToolStripMenuItem.CheckOnClick = true;
			this.showWeightsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showWeightsToolStripMenuItem.Name = "showWeightsToolStripMenuItem";
			this.showWeightsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.showWeightsToolStripMenuItem.Text = "Show weights";
			this.showWeightsToolStripMenuItem.Click += new System.EventHandler(this.ShowWeightsToolStripMenuItemClick);
			// 
			// showLabelsToolStripMenuItem
			// 
			this.showLabelsToolStripMenuItem.Checked = true;
			this.showLabelsToolStripMenuItem.CheckOnClick = true;
			this.showLabelsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showLabelsToolStripMenuItem.Name = "showLabelsToolStripMenuItem";
			this.showLabelsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.showLabelsToolStripMenuItem.Text = "Show labels";
			this.showLabelsToolStripMenuItem.Click += new System.EventHandler(this.ShowLabelsToolStripMenuItemClick);
			// 
			// orientedToolStripMenuItem
			// 
			this.orientedToolStripMenuItem.Checked = true;
			this.orientedToolStripMenuItem.CheckOnClick = true;
			this.orientedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.orientedToolStripMenuItem.Name = "orientedToolStripMenuItem";
			this.orientedToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.orientedToolStripMenuItem.Text = "Oriented";
			this.orientedToolStripMenuItem.Visible = false;
			this.orientedToolStripMenuItem.Click += new System.EventHandler(this.OrientedToolStripMenuItemClick);
			// 
			// showWeightsFromNowPointToolStripMenuItem
			// 
			this.showWeightsFromNowPointToolStripMenuItem.CheckOnClick = true;
			this.showWeightsFromNowPointToolStripMenuItem.Name = "showWeightsFromNowPointToolStripMenuItem";
			this.showWeightsFromNowPointToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.showWeightsFromNowPointToolStripMenuItem.Text = "Show min weights";
			this.showWeightsFromNowPointToolStripMenuItem.Click += new System.EventHandler(this.ShowWeightsFromNowPointToolStripMenuItemClick);
			// 
			// showNumsFleriToolStripMenuItem
			// 
			this.showNumsFleriToolStripMenuItem.Checked = true;
			this.showNumsFleriToolStripMenuItem.CheckOnClick = true;
			this.showNumsFleriToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showNumsFleriToolStripMenuItem.Name = "showNumsFleriToolStripMenuItem";
			this.showNumsFleriToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.showNumsFleriToolStripMenuItem.Text = "Show nums Fleri";
			this.showNumsFleriToolStripMenuItem.Visible = false;
			this.showNumsFleriToolStripMenuItem.Click += new System.EventHandler(this.ShowNumsFleriToolStripMenuItemClick);
			// 
			// algoritmsToolStripMenuItem
			// 
			this.algoritmsToolStripMenuItem.Name = "algoritmsToolStripMenuItem";
			this.algoritmsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.algoritmsToolStripMenuItem.Text = "Algoritms";
			this.algoritmsToolStripMenuItem.Click += new System.EventHandler(this.AlgoritmsToolStripMenuItemClick);
			// 
			// getToolStripMenuItem
			// 
			this.getToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.GraphfToolStripMenuItem,
									this.pointsToolStripMenuItem,
									this.testToolStripMenuItem});
			this.getToolStripMenuItem.Name = "getToolStripMenuItem";
			this.getToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.getToolStripMenuItem.Text = "Get";
			// 
			// GraphfToolStripMenuItem
			// 
			this.GraphfToolStripMenuItem.Name = "GraphfToolStripMenuItem";
			this.GraphfToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.GraphfToolStripMenuItem.Text = "Graph";
			this.GraphfToolStripMenuItem.Click += new System.EventHandler(this.GraphfToolStripMenuItemClick);
			// 
			// pointsToolStripMenuItem
			// 
			this.pointsToolStripMenuItem.Name = "pointsToolStripMenuItem";
			this.pointsToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.pointsToolStripMenuItem.Text = "Points";
			this.pointsToolStripMenuItem.Click += new System.EventHandler(this.PointsToolStripMenuItemClick);
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.testToolStripMenuItem.Text = "test";
			this.testToolStripMenuItem.Visible = false;
			this.testToolStripMenuItem.Click += new System.EventHandler(this.TestToolStripMenuItemClick);
			// 
			// setToolStripMenuItem
			// 
			this.setToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.GraphNameToolStripMenuItem,
									this.fontToolStripMenuItem,
									this.colorForVertexToolStripMenuItem,
									this.colorForUsingVertexAndEdgeToolStripMenuItem});
			this.setToolStripMenuItem.Name = "setToolStripMenuItem";
			this.setToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.setToolStripMenuItem.Text = "Set";
			// 
			// GraphNameToolStripMenuItem
			// 
			this.GraphNameToolStripMenuItem.Name = "GraphNameToolStripMenuItem";
			this.GraphNameToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.GraphNameToolStripMenuItem.Text = "Graph name";
			this.GraphNameToolStripMenuItem.Click += new System.EventHandler(this.GraphNameToolStripMenuItemClick);
			// 
			// fontToolStripMenuItem
			// 
			this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
			this.fontToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.fontToolStripMenuItem.Text = "Font";
			this.fontToolStripMenuItem.Click += new System.EventHandler(this.FontToolStripMenuItemClick);
			// 
			// colorForVertexToolStripMenuItem
			// 
			this.colorForVertexToolStripMenuItem.Name = "colorForVertexToolStripMenuItem";
			this.colorForVertexToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.colorForVertexToolStripMenuItem.Text = "Color for vertex, edge and labels";
			this.colorForVertexToolStripMenuItem.Click += new System.EventHandler(this.ColorForVertexToolStripMenuItemClick);
			// 
			// colorForUsingVertexAndEdgeToolStripMenuItem
			// 
			this.colorForUsingVertexAndEdgeToolStripMenuItem.Name = "colorForUsingVertexAndEdgeToolStripMenuItem";
			this.colorForUsingVertexAndEdgeToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.colorForUsingVertexAndEdgeToolStripMenuItem.Text = "Color for using vertex and edge";
			this.colorForUsingVertexAndEdgeToolStripMenuItem.Click += new System.EventHandler(this.ColorForUsingVertexAndEdgeToolStripMenuItemClick);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
			this.toolStripMenuItem1.Text = "?";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1Click);
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.clearToolStripMenuItem.Text = "Clear";
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItemClick);
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.White;
			this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.tabPage1.Cursor = System.Windows.Forms.Cursors.Cross;
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(596, 415);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Graph 0";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.HotTrack = true;
			this.tabControl1.ItemSize = new System.Drawing.Size(10, 18);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(604, 441);
			this.tabControl1.TabIndex = 22;
			this.tabControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TabControl1MouseDoubleClick);
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1SelectedIndexChanged);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "graph";
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "Graph|*.graph";
			this.openFileDialog1.Title = "Open graph";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "Graph|*.graph|BitMapPictures|*.bmp";
			this.saveFileDialog1.Title = "Save graph";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripStatusLabel1,
									this.toolStripStatusLabel2,
									this.toolStripLabelMakeLine});
			this.statusStrip1.Location = new System.Drawing.Point(0, 465);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(741, 22);
			this.statusStrip1.TabIndex = 23;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(76, 17);
			this.toolStripStatusLabel1.Text = "                       ";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
			this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
			// 
			// toolStripLabelMakeLine
			// 
			this.toolStripLabelMakeLine.ForeColor = System.Drawing.Color.Red;
			this.toolStripLabelMakeLine.Name = "toolStripLabelMakeLine";
			this.toolStripLabelMakeLine.Size = new System.Drawing.Size(650, 17);
			this.toolStripLabelMakeLine.Spring = true;
			this.toolStripLabelMakeLine.Text = "Lets make edge";
			this.toolStripLabelMakeLine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripLabelMakeLine.Visible = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
			this.splitContainer1.Panel1MinSize = 0;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Panel2MinSize = 0;
			this.splitContainer1.Size = new System.Drawing.Size(741, 441);
			this.splitContainer1.SplitterDistance = 604;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 24;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(741, 487);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("DejaVu Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(400, 420);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Graphs and algoritms";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.SizeChanged += new System.EventHandler(this.MainFormSizeChanged);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button buttonClickMe;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.ToolStripMenuItem colorForUsingVertexAndEdgeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem colorForVertexToolStripMenuItem;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showNumsFleriToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem showWeightsFromNowPointToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem algoritmsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel toolStripLabelMakeLine;
		private System.Windows.Forms.ToolStripMenuItem GraphNameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TextBox textBoxToSetLabel;
		private System.Windows.Forms.TextBox textBoxToSetWeight;
		private System.Windows.Forms.Button buttonLabelSet;
		private System.Windows.Forms.Button buttonDeletePoint;
		private System.Windows.Forms.Button buttonWeightSet;
		private System.Windows.Forms.ToolStripMenuItem pointsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem GraphfToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem getToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem orientedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showLabelsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showWeightsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem makeLinesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label label2;
	}
}
