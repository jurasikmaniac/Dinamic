using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lesenka
{
    public partial class Form1 : Form
    {
        public int[] data = new int[] { 1, -2, -3, 4, -3, -5, -8, 1, -3, 2 };
        public int[] answer;
        List<int> path;
        public Form1()
        {
            answer = new int[data.Length];
            path = new List<int>();
            InitializeComponent();
            lesenka();
        }
        public void lesenka()
        {
            answer[0] = data[0];
            answer[1] = data[0] + data[1];
            for (int i = 2; i < data.Length; i++)
            {
                int temp = Math.Max(answer[i - 1], answer[i - 2]);                
                answer[i] = data[i] + temp;
            }
            path.Add(data.Length-1);
            for (int i = data.Length-1; i >0; )
            {
                
                if (answer[i]==data[i]+answer[i-1])
                {
                    path.Add(i - 1);
                    i--;
                }
                else
                {
                    path.Add(i-2);
                    i = i - 2;
                }
            }
            path.Reverse();
        }

    }
}
