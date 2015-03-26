using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Hard
    {
        public int n = 5;//количество матриц
        public int[] sizes;//размеры матриц 12,10,7,4 => значит 3 матрицы размерами 12x10,10x7,7x4
        public int up;
        public string[] poryadok;
        public int[,] matrix;
        public int maxmop = 0;

        public Hard(int size)
        {
            this.n = size;
            sizes = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                sizes[i] = i;
            }

            up = n - 2;
            poryadok = new string[n - 1];
            matrix = new int[n, n];
        }

        private string FormStr(int i, int j, int k)
        {
            string s, s1;
            if (i == k)
                s = "(" + "A"+ i + ")";
            else s = "(" + "A" + i + ", " + "A" + k + ")";

            if (j == k + 1)
                s1 = "(" + "A" + j + ")";
            else s1 = "(" + "A" + (k + 1) + ", " + "A" + j + ")";
            return (s + "*" + s1);
        }

        void orders(int i, int j)
        {
            //рекурсивная процедура формирования порядка умножений
            int k = matrix[j, i];
            poryadok[up] = FormStr(i, j, k);
            up--;
            if (i != k) orders(i, k);
            if ((k + 1) != j) orders(k + 1, j);

        }

        public void Ords()
        {
            orders(0, n - 1);
        }

        void EvalMopAndNop(int i, int j, ref int m, ref int n)
        {

            //нахождение на отрезке (i,j) минимального числа умножений 
            //и номера матрицы, где этот минимум достигается 
            int min = maxmop, num = 0;
            int m1 = 0;
            for (int k = i; k < j; k++)
            {
                m1 = matrix[i, k] + matrix[k + 1, j] + sizes[i] * sizes[k + 1] * sizes[j + 1];
                if (m1 <= min)
                {
                    min = m1; num = k;
                }
            }
            m = min; n = num;
        }

        int MaxM()
        {
            //возвращает максимально возможное значение mop 
            int max = sizes[0];
            for (int i = 1; i <= n; i++)
                if (sizes[i] > max) max = sizes[i];
            return (max * max * max);
        }

        public void MopAndNop()
        {
            maxmop = MaxM();
            //заполнение матрицы mop 
            //главная диагональ заполняется нулями 
            for (int i = 0; i < n; i++)
                matrix[i, i] = 0;
            //цикл по диагоналям 
            for (int i = 1; i < n; i++)
                //диагональ i заполняется элементами mop 
                //симметричная диагональ - элементами nop
                //цикл по элементам диагонали 
                for (int j = 0; j + i < n; j++)
                    EvalMopAndNop(j, j + i, ref matrix[j, j + i], ref matrix[j + i, j]);
        }

    }
}
