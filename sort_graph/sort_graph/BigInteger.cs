using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort_graph
{
    public class BigInteger
    {
        int BASE = 10;
        public int[] values;

        public BigInteger(){

        }

        public BigInteger(string str)
        {
            values = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                var s = (str[str.Length- i-1]);
                values[i] = Convert.ToInt32(s.ToString());
            }
            
        }

        public override string ToString()
        {
            string str="";
            for (int i = 0; i < values.Length; i++)
            {
                str += values[values.Length - i - 1];
            }
            return str;
        }

        static public void Normalize(BigInteger l)
        {
            /*Нормализация числа - приведение каждого разряда в соответствие с системой счисления.
            *
            */
            for (int i = 0; i < l.values.Length - 1; ++i)
            {
                if (l.values[i] >= l.BASE)
                { //если число больше максимального, то организовавается перенос
                    int carryover = l.values[i] / l.BASE;
                    l.values[i + 1] += carryover;
                    l.values[i] -= carryover * l.BASE;
                }
                else if (l.values[i] < 0)
                { //если меньше - заем
                    int carryover = (l.values[i] + 1) / l.BASE - 1;
                    l.values[i + 1] += carryover;
                    l.values[i] -= carryover * l.BASE;
                }
            }
        }

        static public BigInteger Multi(BigInteger a, BigInteger b)
        {
            BigInteger product = new BigInteger(); //результирующее произведение

            product.values = new int[a.values.Length + b.values.Length-1];



            for (int i = 0; i < a.values.Length; ++i)
                for (int j = 0; j < b.values.Length; ++j)
                {
                    product.values[i + j] += a.values[i] * b.values[j];
                }

            Normalize(product); //конечная нормализация числа

            return product;

        }

        
    }
}
