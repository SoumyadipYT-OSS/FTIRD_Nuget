using System.Numerics;
using FTIRD.NUMIN.Core;

namespace FTIRD.NUMIN.Utils
{
    public static class NDArrayInitialization
    {
        public static NDArray<T> ZerosUtils<T>(int[] shape) where T : INumber<T>
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape), "Shape cannot be null.");
            
            foreach (var dim in shape)
            {
                if (dim <= 0)
                    throw new ArgumentException("All dimensions must be positive.", nameof(shape));
            }

            NDArray<T> array = new(shape);
            for (int i = 0; i < array.Data.Length; i++)
            {
                array.Data[i] = T.Zero; // Assign zero to each element
            }

            return array;
        }

        public static NDArray<T> OnesUtils<T>(int[] shape) where T : INumber<T>
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape), "Shape cannot be null.");

            foreach (var dim in shape)
            {
                if (dim <= 0)
                    throw new ArgumentException("All dimensions must be positive.", nameof(shape));
            }

            NDArray<T> array = new(shape);
            for (int i = 0; i < array.Data.Length; i++)
            {
                array.Data[i] = T.One; // Assign one to each element
            }

            return array;
        }

        public static NDArray<T> IdentityUtils<T>(int size) where T : INumber<T>
        {
            if (size <= 0)
                throw new ArgumentException("Size must be positive.", nameof(size));

            int[] shape = [size, size];
            NDArray<T> array = new(shape);
            for (int i = 0; i < size; i++)
            {
                array[i, i] = T.One; // Assign one to the diagonal elements
            }

            return array;
        }

        public static NDArray<double> RandomUtils(int[] shape)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape), "Shape cannot be null.");

            foreach (var dim in shape)
            {
                if (dim <= 0)
                    throw new ArgumentException("All dimensions must be positive.", nameof(shape));
            }

            NDArray<double> array = new(shape);
            Random random = new();
            for (int i = 0; i < array.Data.Length; i++)
            {
                array.Data[i] = random.NextDouble(); // Assign random double values
            }

            return array;
        }

        public static NDArray<T> FullUtils<T>(int[] shape, T value) where T : INumber<T>
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape), "Shape cannot be null.");

            foreach (var dim in shape)
            {
                if (dim <= 0)
                    throw new ArgumentException("All dimensions must be positive.", nameof(shape));
            }

            NDArray<T> array = new(shape);
            for (int i = 0; i < array.Data.Length; i++)
            {
                array.Data[i] = value; // Assign the specified value to each element
            }

            return array;
        }
    }
}