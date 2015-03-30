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
        const double PI = 3.1415926;
        List<double> wnk_re;
        List<double> wnk_im;


        public Convers(int x)
        {
            Random rnd = new Random();
            A = new List<int>();
            List<double> Arem = new List<double>();
            List<double> Aimm = new List<double>();
            B = new List<int>();
            List<double> Brem = new List<double>();
            List<double> Bimm = new List<double>();
            C = new List<int>();
            List<double> Crem = new List<double>();
            List<double> Cimm = new List<double>();
            
            for (int i = 0; i < x; i++)
            {
                A.Add(rnd.Next(10));
                B.Add(rnd.Next(10));            
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
                Arem.Add(A[i]);
                Brem.Add(B[i]);
                Crem.Add(C[i]);
                Aimm.Add(0);
                Bimm.Add(0);
                Cimm.Add(0);
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

           // fft_t(true, Arem, Aimm, N2);
           // fft_t(false, Arem, Aimm, N2);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    C[i + j] += A[i] * B[j];
                }

            }
            timeLinear = Environment.TickCount - timeLinear;
        }

        void init_wnk(int N)
        {
            wnk_re = new List<double>();
            wnk_im = new List<double>();
            double v = 2.0 * PI / N;
            for (int i = 0; i < N; i++)
            {
                wnk_re.Add(Math.Cos(v * (double)i));
                wnk_im.Add(-Math.Sin(v * (double)i));
            }
        }

        void fft_t(bool ind, List<double> rem, List<double> imm, int NN)
        {
            init_wnk(NN);
            double re, im;
            int i, j, k, n12, kn12;
            n12 = 1;
            for (i = 2 ; i <= NN; i += i)
            {
                for (k = 0; k < n12; k++)
                {
                    for (j = k; j < NN; j += i)
                    {
                        // индекс элемента второй подпоследовательности
                        kn12 = j + n12;
                        // X * WNk
                        re = rem[kn12] * wnk_re[j] - imm[kn12] * wnk_im[j];
                        im = imm[kn12] * wnk_re[j] + rem[kn12] * wnk_im[j];

                        // для обратного БПФ
                        if (ind == false) im = -im;

                        rem[kn12] = rem[j] - re;    // второй элемент
                        imm[kn12] = imm[j] - im;
                        rem[j] = rem[j] + re;        // первый элемент
                        imm[j] = imm[j] + im;
                    }
                }
                n12 = i;
            }
            if (ind == false)                       // для обратного БПФ
                for (i = 0; i < NN; i++)
                {
                    rem[i] /= (double)NN;
                    imm[i] /= (double)NN;
                }
        }



    }
}
