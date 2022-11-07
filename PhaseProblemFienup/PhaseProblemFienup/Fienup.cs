using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PhaseProblemFienup
{
    class Fienup
    {
        double[] phaseSpectreData, amplitudeSpectreData;
        Complex[] lastData;
        public int count = 0;
        public double[] init(Complex[] AmpSpectreData)
        {
            int n = AmpSpectreData.Length;

            amplitudeSpectreData = new double[n];
            phaseSpectreData = new double[n];

            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                // Случайные значения начальной фазы
                phaseSpectreData[i] = 2 * Math.PI * rand.NextDouble();

                // Амплитудный спектр
                amplitudeSpectreData[i] = AmpSpectreData[i].Magnitude;
            }

            Complex[] spectreData = new Complex[n];

            for (int i = 0; i < n; i++)
            {
                spectreData[i] = amplitudeSpectreData[i] * Complex.Exp(Complex.ImaginaryOne * phaseSpectreData[i]);
            }

           lastData = Fourier.FFourier(spectreData, false);

            return phaseSpectreData;
        }

        public double iterate(ref Complex[] signalData, ref Complex[] phaseData)
        {
            double accuracy = 0;
            int n = phaseSpectreData.Length;

            Complex[] spectreData = new Complex[n];
            phaseData = new Complex[n];

            for (int i = 0; i < n; i++)
            {
                spectreData[i] = amplitudeSpectreData[i] * Complex.Exp(Complex.ImaginaryOne * phaseSpectreData[i]);
            }

            Complex[] newData = Fourier.FFourier(spectreData, false);

            for (int i = 0; i < n; i++)
            {
                if (newData[i].Real < 0)
                {
                    newData[i] = Complex.Zero;
                }
                else
                {
                    newData[i] = newData[i].Real;
                }
            }

            spectreData = Fourier.FFourier(newData, true);

            for (int i = 0; i < n; i++)
            {
                phaseSpectreData[i] = spectreData[i].Phase;
                accuracy += (newData[i].Real - lastData[i].Real) * (newData[i].Real - lastData[i].Real);
                phaseData[i] = phaseSpectreData[i];
            }

            count++;
            lastData = newData;
            signalData = newData;
            return accuracy;
        }
    }
}
