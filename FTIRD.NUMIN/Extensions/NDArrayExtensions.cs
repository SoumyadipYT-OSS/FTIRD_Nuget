using System.Numerics;
using FTIRD.NUMIN.Core;

namespace FTIRD.NUMIN.Extensions
{
    /// <summary>
    /// Provides extension methods for the NDArray class.
    /// </summary>
    public static class NDArrayExtensions
    {
        public static NDArray<T> ApplyFunctionE<T>(this NDArray<T> array, Func<T, T> func) where T : INumber<T>
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "NDArray cannot be null.");
            if (func == null)
                throw new ArgumentNullException(nameof(func), "Function cannot be null.");

            NDArray<T> result = new NDArray<T>(array.Shape);
            for (int i = 0; i < array.Data.Length; i++)
            {
                result.Data[i] = func(array.Data[i]);
            }

            return result;
        }

        public static NDArray<T> SquareE<T>(this NDArray<T> array) where T : INumber<T>
        {
            return array.ApplyFunctionE(x => x * x);
        }

        public static T SumE<T>(this NDArray<T> array) where T : INumber<T>
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "NDArray cannot be null.");

            T sum = T.Zero;
            for (int i = 0; i < array.Data.Length; i++)
            {
                sum += array.Data[i];
            }

            return sum;
        }

        public static double MeanE<T>(this NDArray<T> array) where T : INumber<T>
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "NDArray cannot be null.");

            T sum = array.SumE();
            return Convert.ToDouble(sum) / array.Data.Length;
        }

        public static T MaxE<T>(this NDArray<T> array) where T : INumber<T>
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "NDArray cannot be null.");

            T max = array.Data[0];
            for (int i = 1; i < array.Data.Length; i++)
            {
                if (array.Data[i] > max)
                {
                    max = array.Data[i];
                }
            }

            return max;
        }

        public static T MinE<T>(this NDArray<T> array) where T : INumber<T>
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "NDArray cannot be null.");

            T min = array.Data[0];
            for (int i = 1; i < array.Data.Length; i++)
            {
                if (array.Data[i] < min)
                {
                    min = array.Data[i];
                }
            }

            return min;
        }

        public static NDArray<T> NormalizeE<T>(this NDArray<T> array, T min, T max) where T : INumber<T>
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "NDArray cannot be null.");

            T arrayMin = array.MinE();
            T arrayMax = array.Max()!;
            T scale = max - min;
            T range = arrayMax - arrayMin;

            return array.ApplyFunctionE(x => (x - arrayMin) / range * scale + min);
        }

        public static T DotE<T>(this NDArray<T> a, NDArray<T> b) where T : INumber<T>
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a), "First NDArray cannot be null.");
            if (b == null)
                throw new ArgumentNullException(nameof(b), "Second NDArray cannot be null.");
            if (a.Shape.Length != 1 || b.Shape.Length != 1)
                throw new ArgumentException("Both NDArrays must be one-dimensional for dot product.");
            if (a.Data.Length != b.Data.Length)
                throw new ArgumentException("The lengths of both NDArrays must be equal for dot product.");

            T dotProduct = T.Zero;
            for (int i = 0; i < a.Data.Length; i++)
            {
                dotProduct += a.Data[i] * b.Data[i];
            }

            return dotProduct;
        }

        public static NDArray<T> Transpose2DMatE<T>(this NDArray<T> array) where T : INumber<T>
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "NDArray cannot be null.");
            if (array.Shape.Length != 2)
                throw new ArgumentException("NDArray must be 2-dimensional for transposition.");

            int rows = array.Shape[0];
            int cols = array.Shape[1];
            NDArray<T> transposed = new([cols, rows]);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transposed[j, i] = array[i, j];
                }
            }

            return transposed;
        }

        public static T NormE<T>(this NDArray<T> array, Func<T, T> sqrtFunc) where T : INumber<T>
        {
            if (array.Shape.Length != 1)
                throw new ArgumentException("Norm can only be computed for 1-dimensional arrays.");

            T sum = T.Zero;
            for (int i = 0; i < array.Shape[0]; i++)
            {
                sum += array[i] * array[i];
            }
            return sqrtFunc(sum);
        }

        public static NDArray<T> ColumnE<T>(this NDArray<T> array, int columnIndex) where T : INumber<T>
        {
            if (array.Shape.Length != 2)
                throw new ArgumentException("Column can only be extracted from 2-dimensional arrays.");

            int rows = array.Shape[0];
            NDArray<T> column = new([ rows ]);

            for (int i = 0; i < rows; i++)
            {
                column[i] = array[i, columnIndex];
            }
            return column;
        }


        // Add more extension methods as needed...
    }
}
