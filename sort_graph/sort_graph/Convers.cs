using AForge.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort_graph
{
    class Convers
    {

        public List<int> A;
        public List<int> B;
        public List<int> C;
        Complex[] A_comp;
        Complex[] B_comp;
        public Complex[] C_comp;
        public int timeFFT;
        public int timeLinear;



        public Convers(int x)
        {
            Random rnd = new Random();
            A = new List<int>();
            B = new List<int>();
            C = new List<int>();
            
            for (int i = 0; i < x; i++)
            {
                A.Add(rnd.Next(1000));
                B.Add(rnd.Next(1000));            
            }

            int n = 2 * x - 1;
            int N2;
            // длина свертки
            N2 = 2;
            while ( N2 < n ) N2 = N2 * 2;

            for (int i = 0; i < N2; i++)
            {
                if (i>=x)
                {
                    A.Add(0);
                    B.Add(0);
                }
                C.Add(0);
            }

            A_comp = A.Select(sample => new Complex((double)sample, 0.0)).ToArray();
            B_comp = B.Select(sample => new Complex((double)sample, 0.0)).ToArray();
            C_comp = C.Select(sample => new Complex((double)sample, 0.0)).ToArray();
            timeFFT = Environment.TickCount;
            AForge.Math.FourierTransform.FFT(A_comp, FourierTransform.Direction.Forward);
            AForge.Math.FourierTransform.FFT(B_comp, FourierTransform.Direction.Forward);
            for (int i = 0; i < N2; ++i)
            {
                C_comp[i] =N2* A_comp[i] * B_comp[i];
                //tmp = svd_re[i] * svk_re[i] – svd_im[i] * swk_im[i];
                //svd_im[i] = svd_re[i] * svk_im[i] + svd_im[i] * swk_re[i];
                //svd_re[i] = tmp;
            }
            AForge.Math.FourierTransform.FFT(C_comp, FourierTransform.Direction.Backward);
            timeFFT = Environment.TickCount - timeFFT;

            timeLinear = Environment.TickCount;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    C[i + j] += A[i] * B[j];
                }

            }
            timeLinear = Environment.TickCount - timeLinear;
        }        



    }
}
