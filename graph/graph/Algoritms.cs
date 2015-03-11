// Created by SharpDevelop.
// User: Миха
// Date: 31.03.2009
// Time: 18:19

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace graph
{
	public partial class Algoritms : Form
	{
		public bool cancel = false;
		public List<Graph> GRAPHS;
		public int nowGraph = 0;
		
		public Algoritms()
		{
			InitializeComponent();
			tabControl1.TabPages.RemoveAt(1);
			//gNames = new string[];
		}
		
		void AlgoritmsShown(object sender, EventArgs e)
		{
			UpdateNames();
			labelExplainIsomorphism.Text = "Теорема: Графы изоморфны тогда и только тогда, " +
				"когда их матрицы смежности вершин получаются друг из друга " +
				"одновременными перестановками строк и столбцов, т.е. одновременно с перестановкой " +
				"i и j строки переставляются i и j столбец.";
			labelExplainAlgFleri.Text = "Связный граф называется Эйлеровым, если он " +
				"содержит цикл включающий все ребра графа.\n" +
				"Теорема: Связный граф называется Эйлеровым тогда и только тогда, " +
				"когда степени всех его вершин четные.\n" +
				"Алгоритм Флери, для Эйлерова графа, находит Эйлеров цикл, причем пронумерованые ребра " +
				"соответствуют последовательности обхода цикла.";
			labelExplainAlgFloyd.Text = "Алгоритм Флойда предназначен для нахождения кратчайших " +
				"путей в графе, причем по составленной матрице можно найти кратчайший путь " +
				"от любой вершины до любой другой.\n" +
				"Строки означают начальную вершину, столбцы конечную, вершины до которых невозможно дойти " +
				"обозначены '_' ";
			labelExplainGamiltonov.Text = "Граф называется Гамильтоновым, если он имеет один простой " +
				"цикл содержащий каждую вершину этого графа.\n" +
				"Теорема Оре: Если любой пары не смежных вершин x и y в графе выше 3-го порядка выполняется " +
				"условие: P(x) + P(y) >= n, то граф является гамильтоновым.\n" +
				"Следствие: Если граф имеет порядок выше 3-го и для любой его вершины x: P(x) >= n/2, " +
				"то граф является гамильтоновым.";
		}
		
		void UpdateNames()
		{
			int saveindx1 = comboBox1.SelectedIndex;  // don't touch this 
			int saveindx2 = comboBox2.SelectedIndex;  // KocTb|Jlb
			comboBox1.Items.Clear();
			comboBox2.Items.Clear();
			foreach(Graph g in GRAPHS){
				comboBox1.Items.Add(g.Name);
				comboBox2.Items.Add(g.Name);
			}
			if (comboBox1.Items.Count != 0){
				comboBox1.SelectedIndex = saveindx1;
				comboBox2.SelectedIndex = saveindx2;
			}
		}
		
		void AlgoritmsFormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing){
				cancel = true;
				e.Cancel = true;
				this.Hide();
			}
		}
		
		void ButtonCheckIsomorphismClick(object sender, EventArgs e)
		{
			//UpdateNames();
			if (nowGraph == -1){
				MessageBox.Show("Before do it you must make graph", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (Equals(comboBox1.SelectedItem, null) || Equals(comboBox2.SelectedItem, null) ){
				MessageBox.Show("Please select Graph names to check their izomorfizm", "Error",
				                MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBox1.SelectedItem.ToString() == comboBox2.SelectedItem.ToString()){
				MessageBox.Show(comboBox1.SelectedItem.ToString() + " equal " + comboBox2.SelectedItem.ToString(), "Izomorf",
				                MessageBoxButtons.OK, MessageBoxIcon.Information);
			}else{
				Graph g1 = new Graph("€");
				Graph g2 = new Graph("$");
				foreach(Graph g in GRAPHS){
					if (g.Name == comboBox1.SelectedItem.ToString())
						g1 = g;
					if (g.Name == comboBox2.SelectedItem.ToString())
						g2 = g;
				}
				string s = "";
				if (g1.Izvomorfen(g2))
					s = " isomorphing ";
				else
					s = " not isomorphing ";
				
				MessageBox.Show(comboBox1.SelectedItem.ToString() + s + comboBox2.SelectedItem.ToString(), "Izomorf",
					          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		
		
		
		void ButtonFloydClick(object sender, EventArgs e)
		{
			if (nowGraph == -1){
				MessageBox.Show("Before do it you must make graph", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			MessageBox.Show("For graph " + GRAPHS[nowGraph].Name + ":\n Matrix min weights:\n" + 
			                GRAPHS[nowGraph].FloydToString() + "\n Matrix points:\n" +
			                GRAPHS[nowGraph].FloidPointsToString() , "Floyd array",
			                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		
		void ButtonGamiltonClick(object sender, EventArgs e)
		{
			if (nowGraph == -1){
				MessageBox.Show("Before do it you must make graph", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			string s = "";
			if (! GRAPHS[nowGraph].Gamilton())
				s = " NOT";
			
			MessageBox.Show("Graf " + GRAPHS[nowGraph].Name + s + " gamiltonov. \n" 
			                /* +GRAPHS[nowGraf].GamilToString(GRAPHS[nowGraf].gamil_check)*/, "Gamilton",
			                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		
		void ButtonFleriClick(object sender, EventArgs e)
		{
			MessageBox.Show("Этот алгоритм находится в разработке.");
//			if (nowGraph == -1){
//				MessageBox.Show("Before do it you must make graph", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//				return;
//			}
//			string s = "";
//			if (! GRAPHS[nowGraph].Fleri() )
//				s = "n't";
//			MessageBox.Show("This graph " + GRAPHS[nowGraph].Name + " is" + s + " Euler graph.", "Check Euler",
//				               MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			
		}
		
		void ComboBox2MouseDown(object sender, MouseEventArgs e)
		{
			UpdateNames();
		}
		
		void ComboBox1MouseDown(object sender, MouseEventArgs e)
		{
			UpdateNames();
		}
	}
}
