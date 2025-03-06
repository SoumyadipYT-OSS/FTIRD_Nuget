using System.Numerics;
using FTIRD.NUMIN.Core;


namespace FTIRD.NUMIN.Linalg
{
    /// <summary>
    /// Provides linear algebra operations for NDArrays.
    /// </summary>
    public static class NDArrayLinearAlgebra
    {
        public static NDArray<T> MatMul_LinAlg<T>(this NDArray<T> array1, NDArray<T> array2) where T : INumber<T>
        {
            if (array1.Shape.Length != 2 || array2.Shape.Length != 2)
                throw new ArgumentException("Both arrays must be 2-dimensional.");

            if (array1.Shape[1] != array2.Shape[0])
                throw new ArgumentException("Incompatible shapes for matrix multiplication.");

            int m = array1.Shape[0];
            int n = array2.Shape[1];
            int p = array1.Shape[1];
            NDArray<T> result = new([m, n]);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    T sum = T.Zero;
                    for (int k = 0; k < p; k++)
                    {
                        sum += array1[i, k] * array2[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        public static NDArray<T> Transpose_LinAlg<T>(this NDArray<T> array) where T : INumber<T>
        {
            if (array.Shape.Length != 2)
                throw new ArgumentException("Array must be 2-dimensional to transpose.");

            int rows = array.Shape[0];
            int cols = array.Shape[1];
            NDArray<T> result = new([cols, rows]);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[j, i] = array[i, j];
                }
            }
            return result;
        }

        public static T DotProduct_LinAlg<T>(this NDArray<T> array1, NDArray<T> array2) where T : INumber<T>
        {
            if (array1.Shape.Length != 1 || array2.Shape.Length != 1)
                throw new ArgumentException("Both arrays must be 1-dimensional.");

            if (array1.Shape[0] != array2.Shape[0])
                throw new ArgumentException("Arrays must have the same shape.");

            T result = T.Zero;
            for (int i = 0; i < array1.Shape[0]; i++)
            {
                result += array1[i] * array2[i];
            }
            return result;
        }

        public static T Determinant_LinAlg<T>(this NDArray<T> array) where T : INumber<T>
        {
            if (array.Shape.Length != 2 || array.Shape[0] != array.Shape[1])
                throw new ArgumentException("Array must be a 2-dimensional square matrix to compute the determinant.");

            int n = array.Shape[0];
            if (n == 1)
            {
                return array[0, 0];
            }
            if (n == 2)
            {
                return array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0];
            }

            T determinant = T.Zero;
            for (int p = 0; p < n; p++)
            {
                NDArray<T> subMatrix = CreateSubMatrix(array, 0, p);
                determinant += array[0, p] * Determinant_LinAlg(subMatrix) * (p % 2 == 0 ? T.One : -T.One);
            }
            return determinant;
        }

        public static NDArray<T> Inverse_LinAlg<T>(this NDArray<T> array) where T : INumber<T>
        {
            if (array.Shape.Length != 2 || array.Shape[0] != array.Shape[1])
                throw new ArgumentException("Array must be a 2-dimensional square matrix to compute the inverse.");

            int n = array.Shape[0];
            NDArray<T> result = new NDArray<T>(new int[] { n, n });

            // Initialize the result as an identity matrix
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = i == j ? T.One : T.Zero;
                }
            }

            // Perform Gaussian elimination to convert the matrix to row echelon form
            for (int i = 0; i < n; i++)
            {
                // Find the pivot element
                T pivot = array[i, i];
                if (pivot == T.Zero)
                    throw new ArgumentException("Matrix is singular and cannot be inverted.");

                // Normalize the pivot row
                for (int j = 0; j < n; j++)
                {
                    array[i, j] /= pivot;
                    result[i, j] /= pivot;
                }

                // Eliminate the other rows
                for (int k = 0; k < n; k++)
                {
                    if (k != i)
                    {
                        T factor = array[k, i];
                        for (int j = 0; j < n; j++)
                        {
                            array[k, j] -= factor * array[i, j];
                            result[k, j] -= factor * result[i, j];
                        }
                    }
                }
            }

            return result;
        }

















        private static NDArray<T> CreateSubMatrix<T>(this NDArray<T> array, int excludeRow, int excludeCol) where T : INumber<T>
        {
            int n = array.Shape[0];
            NDArray<T> subMatrix = new NDArray<T>(new int[] { n - 1, n - 1 });

            int subi = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == excludeRow) continue;
                int subj = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == excludeCol) continue;
                    subMatrix[subi, subj] = array[i, j];
                    subj++;
                }
                subi++;
            }
            return subMatrix;
        }
    }
}