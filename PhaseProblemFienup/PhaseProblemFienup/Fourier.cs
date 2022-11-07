using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PhaseProblemFienup
{
    class Fourier
    {
        public static Complex[] FFourier(Complex[] data, bool mode)
        {
            int i, j, istep;
            int m, mmax;
            int n = data.Length;
            double r, r1, theta, w_r, w_i, temp_r, temp_i;
            Complex[] result = new Complex[n];
            data.CopyTo(result, 0);

            r = Math.PI * (mode?(-1):(1));
            j = 0;
            for (i = 0; i < n; i++)
            {
                if (i < j)
                {
                    temp_r = result[j].Real;
                    temp_i = result[j].Imaginary;
                    result[j] = result[i];
                    result[i] = new Complex (temp_r, temp_i);
                }
                m = n >> 1;
                while (j >= m) { j -= m; m = (m + 1) / 2; }
                j += m;
            }
            mmax = 1;
            while (mmax < n)
            {
                istep = mmax << 1;
                r1 = r / mmax;
                for (m = 0; m < mmax; m++)
                {
                    theta = r1 * m;
                    w_r = Math.Cos(theta);
                    w_i = Math.Sin(theta);
                    for (i = m; i < n; i += istep)
                    {
                        j = i + mmax;
                        temp_r = w_r * result[j].Real - w_i * result[j].Imaginary;
                        temp_i = w_r * result[j].Imaginary + w_i * result[j].Real;
                        result[j] = new Complex (result[i].Real - temp_r, result[i].Imaginary - temp_i);
                        result[i] += new Complex (temp_r, temp_i);
                    }
                }
                mmax = istep;
            }
            if (!mode)
                for (i = 0; i < n; i++)
                {
                    result[i] /= (double)n;
                }

            return result;
        }
    }
}
