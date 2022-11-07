using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LSPaAF
{
    class HJM:BackgroundWorker
    {
        // Значения условий (задаются извне):
        public double[] impSigData, convolutionData;
        public double accuracy;
        public int maxIterates = 2000000;

        // Локальные векторы:
        private double[] prevPoint, currPoint, nextPoint, lastPoint, hi;

        // Результаты:
        public double currDeviation;
        public int counter;

        public HJM():base()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
            DoWork += Iterate;
        }
        public void Init(int seed)
        {
            int n = impSigData.Length;
            counter = 0;

            var rand = new Random(seed);
            double[] startPoint = new double[n];
            startPoint[0] = 1.0;
            for (int i = 1; i < n; i++)
                startPoint[i] = (2 * rand.NextDouble() - 1) / 100;
            currDeviation = Functional(startPoint, impSigData, convolutionData);

            prevPoint = new double[n];
            startPoint.CopyTo(prevPoint, 0);

            currPoint = new double[n];
            startPoint.CopyTo(currPoint, 0);

            nextPoint = new double[n];
            startPoint.CopyTo(nextPoint, 0);

            lastPoint = new double[n];
            startPoint.CopyTo(lastPoint, 0);

            hi = new double[n];
            for (int i = 0; i < n; i++)
                hi[i] = 10.0;

            counter = 0;
        }

        public void Iterate(object sender, DoWorkEventArgs e)
        {
            int n = impSigData.Length;
            var diff = false;
            counter++;

            for (int i = 0; i < n; i++)
            {
                double temp = currDeviation;
                currPoint[i] = prevPoint[i] + hi[i];
                currDeviation = Functional(currPoint, impSigData, convolutionData);

                if (currDeviation >= temp)
                {
                    currPoint[i] = prevPoint[i] - hi[i];
                    currDeviation = Functional(currPoint, impSigData, convolutionData);
                    if (currDeviation >= temp)
                    {
                        currPoint[i] = prevPoint[i];
                        currDeviation = temp;
                        hi[i] /= 10;
                    }
                    else diff = true;

                }
                else diff = true;
            }
            
            var stop = true;
            for (int i = 0; i < n; i++)
            {
                if (hi[i] > accuracy)
                {
                    stop = false;
                    break;
                }
            }
 
            if (stop || (counter >= maxIterates - 1)|| CancellationPending)
            {
                counter++;
                e.Result = true;
                return;
            }      

            double nextDeviation, lastDeviation, prevDeviation = currDeviation;
            while (diff)
            {
                if (CancellationPending)
                {
                    e.Result = true;
                    return;
                }

                ReportProgress(1, currPoint);

                for (int i = 0; i < n; i++)
                {
                    double value = prevPoint[i] + 2 * (currPoint[i] - prevPoint[i]);
                    nextPoint[i] = value;
                    lastPoint[i] = value;
                }
                nextDeviation = Functional(nextPoint, impSigData, convolutionData);
                lastDeviation = nextDeviation;

                for (int i = 0; i < n; i++)
                {
                    double temp = lastDeviation;
                    lastPoint[i] = nextPoint[i] + hi[i];
                    lastDeviation = Functional(lastPoint, impSigData, convolutionData);
                    if (lastDeviation >= temp)
                    {
                        lastPoint[i] = nextPoint[i] - hi[i];
                        lastDeviation = Functional(lastPoint, impSigData, convolutionData);
                        if (lastDeviation >= temp)
                        {
                            lastPoint[i] = nextPoint[i];
                            lastDeviation = temp;
                        }
                    }
                }
                
                prevDeviation = currDeviation;
                if (lastDeviation < currDeviation)
                {
                    lastPoint.CopyTo(currPoint, 0);
                    currDeviation = lastDeviation;
                }
                else break;
            }

            currPoint.CopyTo(prevPoint, 0);
            currDeviation = prevDeviation;
            counter++;
            e.Result = false;
        }
        public double[] GetRecSignal() { return RecSignal(currPoint, impSigData); }

        public static double[] RecSignal(double[] point, double[] initData)
        {
            int n = initData.Length;
            var result = new double[n];

            for (int i = 0; i < n; i++)
            {
                double pow = -1.0;

                for (int j = 0; j < n; j++)
                {
                    pow -= point[j] * initData[(n + j - i) % n];
                }  

                result[i] = Math.Exp(pow);
            }

            return result;
        }

        public static double Functional(double[] point, double[] impsigData, double[] convolutionData)
        {
            int n = impsigData.Length;
            var recoveredData = RecSignal(point, impsigData);
            var recoveredConvolutiongData = Functions.Convolution(recoveredData, impsigData);
            double result = 0;

            for (int i = 0; i < n; i++)
                result += (recoveredConvolutiongData[i] - convolutionData[i]) * (recoveredConvolutiongData[i] - convolutionData[i]);

            return result;
        }
    }
    
}
