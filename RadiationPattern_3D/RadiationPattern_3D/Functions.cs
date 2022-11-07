using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Numerics;

namespace RadiationPattern_3D
{
    internal class Functions
    {
        static List<Point3D> GetAntennaPositions(bool[,] AntennaData, double d) 
        {
            List<Point3D> result = new List<Point3D>();

            int size = AntennaData.GetLength(0);

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (AntennaData[x, y])
                    {
                        result.Add(new Point3D(x * d - 0.5 * d * size, y * d - 0.5 * d * size, 0));
                    }
                }
            }

            return result;
        }

        static double GetIntencity(List<Point3D> positions, Point3D target, double lambda) 
        {
            Complex result = Complex.Zero;

            foreach(Point3D pos in positions) 
            {
                double r = (target - pos).Length;

                result += Complex.Exp(-Complex.ImaginaryOne * Math.Tau / lambda * r) / r;
            }  

            return result.Magnitude * result.Magnitude;
        }

        public static double[,] GetRadiationPattern(bool[,] AntennaData, int R, double d, double lambda, out double max) 
        {
            double[,] result = new double[R * 2 + 1, R * 2 + 1];
            max = 0;

            List<Point3D> positions = GetAntennaPositions(AntennaData, d);

            for (int x = -R; x <= R; x++)
            {
                for (int y = -R; y <= R; y++)
                {
                    double z_sqr = R * R - x * x - y * y;
                    
                    if (z_sqr < 0) 
                    {
                        result[x + R, y + R] = -1;
                        continue;
                    }

                    result[x + R, y + R] = GetIntencity(positions, new Point3D(x, y, Math.Sqrt(z_sqr)), lambda);
                    if (result[x + R, y + R] > max) max = result[x + R, y + R];
                }
            }

            return result;
        }
    }
}
