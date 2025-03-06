using System.Numerics;
using FTIRD.NUMIN.Core;
using FTIRD.NUMIN.Extensions;


namespace FTIRD.NUMIN.Decompose
{
    /// <summary>
    /// Provides linear algebra decomposition operations.
    /// </summary>
    public static class NDArrayDecompostion
    {
        public static (NDArray<T> eigenvalues, NDArray<T> eigenvectors) Eigen_Decompose<T>(this NDArray<T> array) where T : INumber<T>
        {
            if (array.Shape.Length != 2 || array.Shape[0] != array.Shape[1])
                throw new ArgumentException("Array must be a 2-dimensional square matrix to compute eigenvalues and eigenvectors.");

            int n = array.Shape[0];
            NDArray<T> eigenvalues = new([n]);
            NDArray<T> eigenvectors = new([n, n]);

            // Implement the algorithm to compute eigenvalues and eigenvectors
            // This is a placeholder and should be replaced with actual implementation
            for (int i = 0; i < n; i++)
            {
                eigenvalues[i] = array[i, i];
                for (int j = 0; j < n; j++)
                {
                    eigenvectors[i, j] = i == j ? T.One : T.Zero;
                }
            }

            return (eigenvalues, eigenvectors);
        }

        public static (NDArray<T> L, NDArray<T> U) LUDecomposition_Decompose<T>(this NDArray<T> array) where T : INumber<T>
        {
            if (array.Shape.Length != 2 || array.Shape[0] != array.Shape[1])
                throw new ArgumentException("Array must be a 2-dimensional square matrix to perform LU decomposition.");

            int n = array.Shape[0];
            NDArray<T> L = new([n, n]);
            NDArray<T> U = new([n, n]);

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    T sum = T.Zero;
                    for (int k = 0; k < i; k++)
                    {
                        sum += L[i, k] * U[k, j];
                    }
                    U[i, j] = array[i, j] - sum;
                }

                for (int j = i; j < n; j++)
                {
                    if (i == j)
                    {
                        L[i, i] = T.One;
                    }
                    else
                    {
                        T sum = T.Zero;
                        for (int k = 0; k < i; k++)
                        {
                            sum += L[j, k] * U[k, i];
                        }
                        L[j, i] = (array[j, i] - sum) / U[i, i];
                    }
                }
            }

            return (L, U);
        }

        public static (NDArray<T> Q, NDArray<T> R) QRDecomposition_Decompose<T>(this NDArray<T> array, Func<T, T> sqrtFunc) where T : INumber<T>
        {
            if (array.Shape.Length != 2 || array.Shape[0] != array.Shape[1])
                throw new ArgumentException("Array must be a -dimensional square matrix to perform QR decomposition.");

            int n = array.Shape[0];
            NDArray<T> Q = new([n, n]);
            NDArray<T> R = new([n, n]);

            // Initialize R to the input matrix
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    R[i, j] = array[i, j];
                }
            }

            // Perform the Gram-Schmidt process
            for (int i = 0; i < n; i++)
            {
                // Compute the i-th column of Q
                NDArray<T> q = new([n]);
                for (int j = 0; j < n; j++)
                {
                    q[j] = R[j, i];
                }

                // Normalize the i-th column of Q
                T norm = q.NormE(sqrtFunc);
                for (int j = 0; j < n; j++)
                {
                    Q[j, i] = q[j] / norm;
                }

                // Update the remaining columns of R
                for (int j = i + 1; j < n; j++)
                {
                    T dotProduct = Q.ColumnE(i).DotProduct(R.ColumnE(j));
                    for (int k = 0; k < n; k++)
                    {
                        R[k, j] -= dotProduct * Q[k, i];
                    }
                }
            }

            return (Q, R);
        }

        public static (NDArray<T> U, NDArray<T> S, NDArray<T> V) SVD_Decompose<T>(this NDArray<T> array) where T : INumber<T>
        {
            if (array.Shape.Length != 2)
                throw new ArgumentException("Array must be a 2-dimensional matrix to perform SVD.");

            int m = array.Shape[0];
            int n = array.Shape[1];

            NDArray<T> U = new([m, m]);
            NDArray<T> S = new([Math.Min(m, n)]);
            NDArray<T> V = new([n, n]);

            // Implement the algorithm to compute SVD
            // This is a placeholder and should be replaced with the actual implementation

            // Placeholder implementation
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    U[i, j] = i == j ? T.One : T.Zero;
                }
            }
            for (int i = 0; i < S.Shape[0]; i++)
            {
                S[i] = array[i, i];
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    V[i, j] = i == j ? T.One : T.Zero;
                }
            }

            return (U, S, V);
        }

        public static NDArray<T> CholeskyDecomposition_Decompose<T>(this NDArray<T> array, Func<T, T> sqrtFunc) where T : INumber<T>
        {
            if (array.Shape.Length != 2 || array.Shape[0] != array.Shape[1])
                throw new ArgumentException("Array must be a 2-dimensional square matrix to perform Cholesky decomposition.");

            int n = array.Shape[0];
            NDArray<T> L = new([n, n]);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    T sum = T.Zero;
                    for (int k = 0; k < j; k++)
                    {
                        sum += L[i, k] * L[j, k];
                    }

                    if (i == j)
                    {
                        L[i, j] = sqrtFunc(array[i, i] - sum);
                    }
                    else
                    {
                        L[i, j] = (array[i, j] - sum) / L[j, j];
                    }
                }
            }

            return L;
        }

        public static T Trace<T>(this NDArray<T> array) where T : INumber<T>
        {
            if (array.Shape.Length != 2 || array.Shape[0] != array.Shape[1])
                throw new ArgumentException("Array must be a 2-dimensional square matrix to compute the trace.");

            T trace = T.Zero;
            for (int i = 0; i < array.Shape[0]; i++)
            {
                trace += array[i, i];
            }
            return trace;
        }
    }
}