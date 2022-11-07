using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basis_K_L
{
    class Functions
    {
        public static double[,] SVD(double[,] A, out double[,] U, out double[,] V)
        {
            int M = A.GetLength(0);
            int N = A.GetLength(1);
            double[] W;
            alglib.rmatrixsvd(A, M, N, 2, 2, 2, out W, out U, out V);

            V = Transp(V);
            double[,] result = new double[M, N];
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    result[i, j] = (i == j) ? W[i] : 0;
                }
            }

            return result;
        }
        public static double[,] Reverse(double[,] A)
        {
            int M = A.GetLength(0);
            int N = A.GetLength(1);
            double[,] U, V, result;
      
            var sigma = SVD(A,out U, out V);

            for(int i = 0; (i < M)&&(i < N); i++)
            {
                sigma[i, i] = 1 / sigma[i, i];
            }

            result = MultMatrix(MultMatrix(V, Transp(sigma)),Transp(U));

            return result;
        }

        public static double[,] Transp(double[,] A)
        {
            int M = A.GetLength(0);
            int N = A.GetLength(1);
            double[,] At = new double[N, M];

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    At[j, i] = A[i, j];
                }
            }
            return At;
        }

        public static double[,] MultMatrix(double[,] A, double[,] B)
        {
            if(A.GetLength(1) != B.GetLength(0))
            {
                throw new ArgumentException("Похоже умножение матриц разбился");
            }
            double[,] R = new double[A.GetLength(0), B.GetLength(1)];

            Parallel.For(0, A.GetLength(0), (i) =>
            {
                Parallel.For(0, B.GetLength(1), (j) =>
                {
                    R[i, j] = 0;
                    for(int k = 0; k < A.GetLength(1); k++)
                    {
                        R[i, j] += A[i, k] * B[k, j];
                    }
                });
            });

            return R;
        }

        public static double getDet(double[,] A)
        {
            int M = A.GetLength(0);
            int N = A.GetLength(1);

            double[,] getM(double[,] Matrix, int p)
            {
                double[,] result = new double[M-1,N-1];
                for (int i = 0; i < M - 1; i++)
                {
                    for (int j = 0; j < N - 1; j++)
                    {
                        result[i, j] = Matrix[i + 1, (j < p) ? j : j + 1];
                    }
                }
                return result;
            }

            if (M <= N)
            {
                double det = 0;

                if (M == 1)
                {
                    for (int i = 0; i < N; i++)
                    {
                        det += A[0, i] * ((i % 2 == 0) ? 1 : -1);
                    }
                    return det;
                }

                for (int i = 0; i < N; i++)
                    det += ((i % 2 == 0) ? 1 : -1) * A[0, i] * getDet(getM(A, i));
                return det;
            }
            else
            {
                return getDet(Transp(A));
            }   
        }
    }
}
