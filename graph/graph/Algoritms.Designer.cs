// Created by SharpDevelop.
// User: Миха
// Date: 31.03.2009
// Time: 18:19

namespace graph
{
	partial class Algoritms
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
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.buttonCheckIsomorpism = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.labelExplainIsomorphism = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.labelExplainAlgFleri = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonFleri = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.labelExplainAlgFloyd = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonFloyd = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.labelExplainGamiltonov = new System.Windows.Forms.Label();
			this.buttonGamilton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(296, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Check isomorphism:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(17, 128);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComboBox1MouseDown);
			// 
			// comboBox2
			// 
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(160, 128);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(121, 21);
			this.comboBox2.TabIndex = 2;
			this.comboBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComboBox2MouseDown);
			// 
			// buttonCheckIsomorpism
			// 
			this.buttonCheckIsomorpism.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonCheckIsomorpism.Location = new System.Drawing.Point(3, 165);
			this.buttonCheckIsomorpism.Name = "buttonCheckIsomorpism";
			this.buttonCheckIsomorpism.Size = new System.Drawing.Size(296, 23);
			this.buttonCheckIsomorpism.TabIndex = 3;
			this.buttonCheckIsomorpism.Text = "Check";
			this.buttonCheckIsomorpism.UseVisualStyleBackColor = true;
			this.buttonCheckIsomorpism.Click += new System.EventHandler(this.ButtonCheckIsomorphismClick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(310, 217);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.labelExplainIsomorphism);
			this.tabPage1.Controls.Add(this.comboBox1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.buttonCheckIsomorpism);
			this.tabPage1.Controls.Add(this.comboBox2);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(302, 191);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Isomorphism";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// labelExplainIsomorphism
			// 
			this.labelExplainIsomorphism.Location = new System.Drawing.Point(17, 26);
			this.labelExplainIsomorphism.Name = "labelExplainIsomorphism";
			this.labelExplainIsomorphism.Size = new System.Drawing.Size(264, 99);
			this.labelExplainIsomorphism.TabIndex = 4;
			this.labelExplainIsomorphism.Text = "--";
			this.labelExplainIsomorphism.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.labelExplainAlgFleri);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this.buttonFleri);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(302, 191);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Algoritm Fleri";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// labelExplainAlgFleri
			// 
			this.labelExplainAlgFleri.Location = new System.Drawing.Point(25, 28);
			this.labelExplainAlgFleri.Name = "labelExplainAlgFleri";
			this.labelExplainAlgFleri.Size = new System.Drawing.Size(254, 134);
			this.labelExplainAlgFleri.TabIndex = 2;
			this.labelExplainAlgFleri.Text = "--";
			this.labelExplainAlgFleri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(3, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(296, 25);
			this.label2.TabIndex = 1;
			this.label2.Text = "Algoritm Fleri:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonFleri
			// 
			this.buttonFleri.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonFleri.Location = new System.Drawing.Point(3, 165);
			this.buttonFleri.Name = "buttonFleri";
			this.buttonFleri.Size = new System.Drawing.Size(296, 23);
			this.buttonFleri.TabIndex = 0;
			this.buttonFleri.Text = "Lets find it";
			this.buttonFleri.UseVisualStyleBackColor = true;
			this.buttonFleri.Click += new System.EventHandler(this.ButtonFleriClick);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.labelExplainAlgFloyd);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Controls.Add(this.buttonFloyd);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(302, 191);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Algoritm Floyd";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// labelExplainAlgFloyd
			// 
			this.labelExplainAlgFloyd.Location = new System.Drawing.Point(20, 26);
			this.labelExplainAlgFloyd.Name = "labelExplainAlgFloyd";
			this.labelExplainAlgFloyd.Size = new System.Drawing.Size(258, 136);
			this.labelExplainAlgFloyd.TabIndex = 2;
			this.labelExplainAlgFloyd.Text = "--";
			this.labelExplainAlgFloyd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(3, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(296, 23);
			this.label3.TabIndex = 1;
			this.label3.Text = "Algoritm Floyd:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonFloyd
			// 
			this.buttonFloyd.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonFloyd.Location = new System.Drawing.Point(3, 165);
			this.buttonFloyd.Name = "buttonFloyd";
			this.buttonFloyd.Size = new System.Drawing.Size(296, 23);
			this.buttonFloyd.TabIndex = 0;
			this.buttonFloyd.Text = "Lets find it";
			this.buttonFloyd.UseVisualStyleBackColor = true;
			this.buttonFloyd.Click += new System.EventHandler(this.ButtonFloydClick);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.labelExplainGamiltonov);
			this.tabPage4.Controls.Add(this.buttonGamilton);
			this.tabPage4.Controls.Add(this.label4);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(302, 191);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Gamiltonov";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// labelExplainGamiltonov
			// 
			this.labelExplainGamiltonov.Location = new System.Drawing.Point(18, 26);
			this.labelExplainGamiltonov.Name = "labelExplainGamiltonov";
			this.labelExplainGamiltonov.Size = new System.Drawing.Size(262, 136);
			this.labelExplainGamiltonov.TabIndex = 2;
			this.labelExplainGamiltonov.Text = "--";
			this.labelExplainGamiltonov.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonGamilton
			// 
			this.buttonGamilton.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonGamilton.Location = new System.Drawing.Point(3, 165);
			this.buttonGamilton.Name = "buttonGamilton";
			this.buttonGamilton.Size = new System.Drawing.Size(296, 23);
			this.buttonGamilton.TabIndex = 1;
			this.buttonGamilton.Text = "Check it";
			this.buttonGamilton.UseVisualStyleBackColor = true;
			this.buttonGamilton.Click += new System.EventHandler(this.ButtonGamiltonClick);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(3, 3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(296, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "Gamiltonov graph";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Algoritms
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(310, 217);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Algoritms";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Algoritms";
			this.Shown += new System.EventHandler(this.AlgoritmsShown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlgoritmsFormClosing);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button buttonFloyd;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonGamilton;
		private System.Windows.Forms.Label labelExplainGamiltonov;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Label labelExplainAlgFloyd;
		private System.Windows.Forms.Button buttonFleri;
		private System.Windows.Forms.Label labelExplainAlgFleri;
		private System.Windows.Forms.Button buttonCheckIsomorpism;
		private System.Windows.Forms.Label labelExplainIsomorphism;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
	}
}
