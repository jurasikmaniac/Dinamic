using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort_graph
{
    static class MyArray
    {   
        static public int move, comp; // Перестановки, сравнения
        static public List<string> print=new List<string>();


        static public void ResetMC()
        {
            move = comp = 0;
        }

        static public void FillArray(out List<int> arr, int _size){
            arr = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < _size; i++)
            {
                arr.Add(rand.Next(_size));
                //arr.Add(_size - i);
            }
            //arr.Add(3);
            //arr.Add(7);
            //arr.Add(5);
            //arr.Add(4);
            //arr.Add(2);
            //arr.Add(6);
            //arr.Add(8);
            //arr.Add(1);
        }
        #region "Select"
        static public void SelectSort(ref List<int> list)
        {
            move = 0;
            comp = 0;

            for (int i = 0; i < list.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    comp++; // Считаем сравнения
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }
                int dummy = list[i];
                list[i] = list[min];
                list[min] = dummy;
                move += 3; // Считаем перестановки
            }
        }
        #endregion

        #region "merge sort"


        static public List<int> MergeSort(List<int> m)
        {
            List<int> result = new List<int>();
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            if (m.Count <= 1)
                return m;


            int middle = m.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                left.Add(m[i]);
                move++;
            }
            for (int i = middle; i < m.Count; i++)
            {
                right.Add(m[i]);
                move++;
            }           
                
            

            left = MergeSort(left);
            right = MergeSort(right);
            if (left.Count > 1 && right.Count > 1)
            {
                string str = "";
                foreach (var item in left)
                {
                    str += item.ToString();
                }
                print.Add(str);

                str = "";
                foreach (var item in right)
                {
                    str += item.ToString();
                }
                print.Add(str);
            }

            comp++;
            if (left[left.Count - 1] <= right[0])
                return append(left, right);

            //print.Add(Environment.NewLine);


            result = merge(left, right);


            return result;
        }


        static private List<int> append(List<int> a, List<int> b)
        {
            List<int> result = new List<int>(a);

            foreach (int x in b)
            {
                move++;
                result.Add(x);
            }
            
            return result;
        }

        static private List<int> merge(List<int> a, List<int> b)
        {
            List<int> s = new List<int>();
            while (a.Count > 0 && b.Count > 0)
            {
                comp++;
                if (a[0] < b[0])
                {
                    move++;
                    s.Add(a[0]);
                    a.RemoveAt(0);
                }
                else
                {
                    move++;
                    s.Add(b[0]);
                    b.RemoveAt(0);
                }
            }
            while (a.Count > 0)
            {
                move++;
                s.Add(a[0]);
                a.RemoveAt(0);
            }

            while (b.Count > 0)
            {
                move++;
                s.Add(b[0]);
                b.RemoveAt(0);
            }
            
            return s;
        }

#endregion

        #region "buble"

        static public void BubbleSort(ref List<int> arr)
        {
            int i, j;
            int swap;

            // Перестановки, сравнения
            move = 0;
            comp = 0;

            for (i = 1; i < arr.Count; i++)
            {
                bool asdf = false;
                for (j = arr.Count - 1; j >= i; j--)
                {
                    comp++; // Сравнения
                    if (arr[j - 1] > arr[j])
                    {
                        swap = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = swap;
                        move += 3; // Перестановки
                        asdf = true;
                    }
                }
                if (!asdf) break;
            }
        }

        #endregion
    }
}
