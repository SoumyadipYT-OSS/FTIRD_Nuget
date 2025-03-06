using System.Collections;
using System.Numerics;
using FTIRD.NUMIN.Utils;
using FTIRD.NUMIN.Extensions;
using FTIRD.NUMIN.Linalg;
using FTIRD.NUMIN.Decompose;

namespace FTIRD.NUMIN.Core
{

    /* Necessary Utils part */

    /// <summary>
    /// Represents a multidimensional array designed for numerical computations,
    /// serving as the foundational data structure for the FTIRD.NUMIN library.
    /// Mimics the behavior of numpy.ndarray (v1.23.0) for low-level array instantiation.
    /// </summary>
    public class NDArray<T> : IEnumerable<T> where T : INumber<T>
    {
        // Add static methods for initialization
        /// <summary>
        /// Creates a new NDArray filled with zeros.
        /// </summary>
        /// <param name="shape">The shape (dimensions) of the NDArray.</param>
        /// <returns>An NDArray filled with zeros.</returns>
        public static NDArray<T> Zeros(int[] shape)
        {
            return NDArrayInitialization.ZerosUtils<T>(shape);
        }
        /// <summary>
        /// Creates a new NDArray filled with ones.
        /// </summary>
        /// <param name="shape">The shape (dimensions) of the NDArray.</param>
        /// <returns>An NDArray filled with ones.</returns>
        public static NDArray<T> Ones(int[] shape)
        {
            return NDArrayInitialization.OnesUtils<T>(shape);
        }
        /// <summary>
        /// Creates a new 2D identity matrix.
        /// </summary>
        /// <param name="size">The size of the identity matrix (number of rows and columns).</param>
        /// <returns>A 2D NDArray representing the identity matrix.</returns>
        public static NDArray<T> Identity(int size)
        {
            return NDArrayInitialization.IdentityUtils<T>(size);
        }
        /// <summary>
        /// Creates a new NDArray filled with random values.
        /// </summary>
        /// <param name="shape">The shape (dimensions) of the NDArray.</param>
        /// <returns>An NDArray filled with random values.</returns>
        public static NDArray<double> Random(int[] shape)
        {
            return NDArrayInitialization.RandomUtils(shape);
        }
        /// <summary>
        /// Creates a new NDArray filled with a specified constant value.
        /// </summary>
        /// <param name="shape">The shape (dimensions) of the NDArray.</param>
        /// <param name="value">The constant value to fill the NDArray with.</param>
        /// <returns>An NDArray filled with the specified constant value.</returns>
        public static NDArray<T> Full(int[] shape, T value)
        {
            return NDArrayInitialization.FullUtils(shape, value);
        }




        /* Necessary Extensions part */

        /// <summary>
        /// Applies a specified function to each element of the NDArray.
        /// </summary>
        /// <param name="array">The NDArray on which to apply the function.</param>
        /// <param name="func">The function to apply to each element.</param>
        /// <returns>A new NDArray with the function applied to each element.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the NDArray or function is null.</exception>
        public static NDArray<T> ApplyFunction(NDArray<T> array, Func<T, T> func)
        {
            return NDArrayExtensions.ApplyFunctionE(array, func);
        }

        /// <summary>
        /// Computes the element-wise square of the NDArray.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array">The NDArray to square.</param>
        /// <returns>A new NDArray with each element squared.</returns>
        public static NDArray<T> Square(NDArray<T> array)
        {
            return NDArrayExtensions.SquareE(array);
        }

        /// <summary>
        /// Computes the sum of all elements in the NDArray.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array">The NDArray to sum.</param>
        /// <returns>The sum of all elements in the NDArray.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the NDArray is null.</exception>
        public static T Sum(NDArray<T> array)
        {
            return NDArrayExtensions.SumE(array);
        }

        /// <summary>
        /// Computes the mean (average) of all elements in the NDArray.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array">The NDArray to compute the mean for.</param>
        /// <returns>The mean of all elements in the NDArray.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the NDArray is null.</exception>
        public static double Mean(NDArray<T> array)
        {
            return NDArrayExtensions.MeanE(array);
        }

        /// <summary>
        /// Finds the maximum element in the NDArray.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array">The NDArray to find the maximum element for.</param>
        /// <returns>The maximum element in the NDArray.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the NDArray is null.</exception>
        public static T Max(NDArray<T> array)
        {
            return NDArrayExtensions.MaxE(array);
        }

        /// <summary>
        /// Finds the minimum element in the NDArray.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array">The NDArray to find the minimum element for.</param>
        /// <returns>The minimum element in the NDArray.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the NDArray is null.</exception>
        public static T Min(NDArray<T> array)
        {
            return NDArrayExtensions.MinE(array);
        }

        /// <summary>
        /// Normalizes the elements of the NDArray to a specified range.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array">The NDArray to normalize.</param>
        /// <param name="min">The minimum value of the normalized range.</param>
        /// <param name="max">The maximum value of the normalized range.</param>
        /// <returns>A new NDArray with elements normalized to the specified range.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the NDArray is null.</exception>
        public static NDArray<T> Normalize(NDArray<T> array, T min, T max)
        {
            return NDArrayExtensions.NormalizeE(array, min, max);
        }

        /// <summary>
        /// Computes the dot product of two NDArrays.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="a">The first NDArray.</param>
        /// <param name="b">The second NDArray.</param>
        /// <returns>The dot product of the two NDArrays.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the NDArray is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the shapes of the NDArrays are not compatible for dot product.</exception>
        public static T Dot(NDArray<T> a, NDArray<T> b)
        {
            return NDArrayExtensions.DotE(a, b);
        }

        /// <summary>
        /// Transposes the 2D NDArray (swaps rows and columns).
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array">The 2D NDArray to transpose.</param>
        /// <returns>A new transposed 2D NDArray.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the NDArray is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the NDArray is not 2D.</exception>
        public static NDArray<T> Transpose2DMatrix(NDArray<T> array)
        {
            return NDArrayExtensions.Transpose2DMatE(array);
        }




        /* Necessary Linear Algebra part */

        /// <summary>
        /// Performs matrix multiplication on two NDArrays.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array1">The first NDArray.</param>
        /// <param name="array2">The second NDArray.</param>
        /// <returns>A new NDArray representing the result of the matrix multiplication.</returns>
        /// <exception cref="ArgumentException">Thrown if the arrays have incompatible shapes for matrix multiplication.</exception>
        public NDArray<T> MatMul(NDArray<T> other)
        {
            return NDArrayLinearAlgebra.MatMul_LinAlg(this, other);
        }
        /// <summary>
        /// Computes the transpose of a 2D NDArray.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="none">Automatically fetch the ndarray</param>
        /// <returns>A new NDArray representing the transposed matrix.</returns>
        /// <exception cref="ArgumentException">Thrown if the array is not 2-dimensional.</exception>
        public NDArray<T> Transpose2DMat()
        {
            return NDArrayLinearAlgebra.Transpose_LinAlg(this);
        }
        /// <summary>
        /// Computes the dot product of two 1D NDArrays.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array1">The first NDArray.</param>
        /// <param name="array2">The second NDArray.</param>
        /// <returns>The dot product of the two NDArrays.</returns>
        /// <exception cref="ArgumentException">Thrown if the arrays do not have the same shape or are not 1-dimensional.</exception>
        public T DotProduct(NDArray<T> other)
        {
            return NDArrayLinearAlgebra.DotProduct_LinAlg(this, other);
        }
        /// <summary>
        /// Computes the determinant of a 2D square NDArray.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array">The 2D NDArray to compute the determinant of.</param>
        /// <returns>The determinant of the 2D square NDArray.</returns>
        /// <exception cref="ArgumentException">Thrown if the array is not 2-dimensional or not square.</exception>
        public T Determinant(NDArray<T> array)
        {
            return NDArrayLinearAlgebra.Determinant_LinAlg(array);
        }
        /// <summary>
        /// Computes the inverse of a 2D square NDArray.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array">The 2D NDArray to compute the inverse of.</param>
        /// <returns>A new NDArray representing the inverse of the original matrix.</returns>
        /// <exception cref="ArgumentException">Thrown if the array is not 2-dimensional or not square, or if the matrix is singular (non-invertible).</exception>
        public NDArray<T> Inverse(NDArray<T> array)
        {
            return NDArrayLinearAlgebra.Inverse_LinAlg(array);
        }




        /* Necessary Decomposition part */

        /// <summary>
        /// Computes the eigenvalues and eigenvectors of a 2D square NDArray.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array">The 2D NDArray to compute the eigenvalues and eigenvectors of.</param>
        /// <returns>A tuple containing the eigenvalues and eigenvectors.</returns>
        /// <exception cref="ArgumentException">Thrown if the array is not 2-dimensional or not square.</exception>
        public (NDArray<T> eigenvalues, NDArray<T> eigenvectors) Eigen()
        {
            return NDArrayDecompostion.Eigen_Decompose(this);
        }
        /// <summary>
        /// Computes the LU decomposition of a 2D square NDArray.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array">The 2D NDArray to decompose.</param>
        /// <returns>A tuple containing the lower triangular matrix (L) and the upper triangular matrix (U).</returns>
        /// <exception cref="ArgumentException">Thrown if the array is not 2-dimensional or not square.</exception>
        public (NDArray<T> L, NDArray<T> U) LUDecomposition()
        {
            return NDArrayDecompostion.LUDecomposition_Decompose(this);
        }
        /// <summary>
        /// Computes the QR decomposition of a 2D square NDArray.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array">The 2D NDArray to decompose.</param>
        /// <param name="sqrtFunc">A delegate to compute the square root of a value of type T.</param>
        /// <returns>A tuple containing the orthogonal matrix (Q) and the upper triangular matrix (R).</returns>
        /// <exception cref="ArgumentException">Thrown if the array is not 2-dimensional or not square.</exception>
        public (NDArray<T> Q, NDArray<T> R) QRDecompostion(Func<T, T> sqrtFunc)
        {
            return NDArrayDecompostion.QRDecomposition_Decompose(this, sqrtFunc);
        }
        /// <summary>
        /// Computes the Singular Value Decomposition (SVD) of a 2D square NDArray.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array">The 2D NDArray to decompose.</param>
        /// <returns>A tuple containing the left singular vectors (U), the singular values (S), and the right singular vectors (V).</returns>
        /// <exception cref="ArgumentException">Thrown if the array is not 2-dimensional or not square.</exception>
        public (NDArray<T> U, NDArray<T> S, NDArray<T> V) SVD_Decomposition()
        {
            return NDArrayDecompostion.SVD_Decompose(this);
        }
        /// <summary>
        /// Computes the Cholesky decomposition of a 2D positive-definite square NDArray.
        /// </summary>
        /// <typeparam name="T">The numeric type of the array elements.</typeparam>
        /// <param name="array">The 2D NDArray to decompose.</param>
        /// <param name="sqrtFunc">A delegate to compute the square root of a value of type T.</param>
        /// <returns>The lower triangular matrix (L) such that array = L * L^T.</returns>
        /// <exception cref="ArgumentException">Thrown if the array is not 2-dimensional, not square, or not positive-definite.</exception>
        public NDArray<T> CholeskyDecomposition(Func<T, T> sqrtFunc)
        {
            return NDArrayDecompostion.CholeskyDecomposition_Decompose(this, sqrtFunc);
        }












        /*  NDArray Main Class properties and methods */

        /// <summary>
        /// Gets the shape (dimensions) of the array.
        /// </summary>
        public int[] Shape { get; }

        /// <summary>
        /// Gets the underlying one-dimensional data storage for the array.
        /// </summary>
        public T[] Data { get; }

        /// <summary>
        /// Gets the strides (step sizes) used for multi-dimensional indexing.
        /// </summary>
        public int[] Strides { get; }

        // Internal offset in the underlying data array.
        private readonly int _offset;

        /// <summary>
        /// Initializes a new instance of the <see cref="NDArray"/> class.
        /// This constructor mimics the low-level numpy.ndarray interface.
        /// </summary>
        /// <param name="shape">
        /// An array of positive integers representing the dimensions of the array.
        /// </param>
        /// <param name="dtype">
        /// (Optional) A <see cref="Type"/> that represents the data type of the array.
        /// It is ignored in this implementation; only <see cref="T"/> is supported.
        /// Defaults to <c>null</c> (interpreted as <see cref="T"/>).
        /// </param>
        /// <param name="buffer">
        /// (Optional) An external <see cref="T"/> array to be used as the underlying data store.
        /// If <c>null</c>, the data array is allocated internally.
        /// </param>
        /// <param name="offset">
        /// (Optional) The offset within the buffer from which the data starts.
        /// Defaults to 0.
        /// </param>
        /// <param name="strides">
        /// (Optional) An array of integers representing the strides for each dimension.
        /// If not provided, strides are computed based on the <paramref name="order"/> parameter.
        /// </param>
        /// <param name="order">
        /// (Optional) A character indicating the desired memory layout:
        /// 'C' for row-major (C-style, default) or 'F' for column-major (Fortran-style).
        /// Ignored if <paramref name="strides"/> is provided.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="shape"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="shape"/> parameter is empty,
        /// contains non-positive integers, if the provided <paramref name="dtype"/> is unsupported,
        /// or if the lengths of strides, or buffer length validation fails.
        /// </exception>
        /// <exception cref="OverflowException">
        /// Thrown when the total number of elements exceeds the limits of an integer.
        /// </exception>
        public NDArray(
            int[] shape,
            Type? dtype = null,
            T[]? buffer = null,
            int offset = 0,
            int[]? strides = null,
            char order = 'C')
        {
            // Validate the shape.
            if (shape == null)
                throw new ArgumentNullException(nameof(shape), "Shape cannot be null.");
            if (shape.Length == 0)
                throw new ArgumentException("Shape must be a non-empty array.", nameof(shape));
            for (int i = 0; i < shape.Length; i++)
            {
                if (shape[i] <= 0)
                {
                    throw new ArgumentException(
                        $"Dimension at index {i} is {shape[i]}, but it must be a positive integer.",
                        nameof(shape));
                }
            }

            // Validate dtype.
            // In this implementation, we only support T.
            if (dtype != null && dtype != typeof(T))
            {
                throw new ArgumentException("Only the T data type is supported in this NDArray implementation.", nameof(dtype));
            }

            // Clone the shape to prevent external modifications.
            Shape = (int[])shape.Clone();

            // Compute the total number of elements with overflow checking.
            int totalSize = 1;
            for (int i = 0; i < Shape.Length; i++)
            {
                try
                {
                    totalSize = checked(totalSize * Shape[i]);
                }
                catch (OverflowException ex)
                {
                    throw new OverflowException("The total number of elements in the NDArray is too large for an integer.", ex);
                }
            }

            // Compute or validate strides.
            if (strides != null)
            {
                if (strides.Length != Shape.Length)
                    throw new ArgumentException("Strides array length must match shape length.", nameof(strides));
                Strides = (int[])strides.Clone();
            }
            else
            {
                Strides = new int[Shape.Length];
                if (order == 'F' || order == 'f')
                {
                    // Fortran (column-major) order
                    Strides[0] = 1;
                    for (int i = 1; i < Shape.Length; i++)
                    {
                        Strides[i] = Strides[i - 1] * Shape[i - 1];
                    }
                }
                else if (order == 'C' || order == 'c')
                {
                    // C (row-major) order
                    Strides[Shape.Length - 1] = 1;
                    for (int i = Shape.Length - 2; i >= 0; i--)
                    {
                        Strides[i] = Strides[i + 1] * Shape[i + 1];
                    }
                }
                else
                {
                    throw new ArgumentException("Order must be either 'C' for row-major or 'F' for column-major.", nameof(order));
                }
            }

            // Validate the offset.
            if (offset < 0)
                throw new ArgumentException("Offset must be non-negative.", nameof(offset));

            // Assign the offset
            _offset = offset;

            // If a buffer is provided, validate its adequacy.
            if (buffer != null)
            {
                if (offset >= buffer.Length)
                    throw new ArgumentException("Offset is greater than or equal to the buffer length.", nameof(offset));
                if (buffer.Length - offset < totalSize)
                    throw new ArgumentException("The provided buffer does not have enough elements from the specified offset.", nameof(buffer));
                Data = buffer;
            }
            else
            {
                // Allocate a new buffer of the appropriate size.
                Data = new T[totalSize];
            }
        }



        // Future expansions (like multi-dimensional indexing, slicing, operator overloads, etc.) can be built on top of this low-level constructor.

        /// <summary>
        /// Provides multi-dimensional indexing into the NDArray, mapping indices to a flat array index.
        /// The flat index is computed as: _offset + ∑(indices[i] * Strides[i]).
        /// </summary>
        /// <param name="indices">A variable number of indices, one for each dimension.</param>
        /// <returns>The element at the specified multi-dimensional indices.</returns>
        /// <exception cref="ArgumentNullException">If indices is null.</exception>
        /// <exception cref="ArgumentException">
        /// If the number of indices does not match the number of dimensions in the shape.
        /// </exception>
        /// <exception cref="IndexOutOfRangeException">
        /// If any index is out of bounds for its corresponding dimension.
        /// </exception>
        public T this[params int[] indices]
        {
            get
            {
                if (indices == null)
                    throw new ArgumentNullException(nameof(indices), "Indices cannot be null.");
                if (indices.Length != Shape.Length)
                    throw new ArgumentException($"Expected {Shape.Length} indices but received {indices.Length}.", nameof(indices));

                int flatIndex = _offset;
                for (int i = 0; i < indices.Length; i++)
                {
                    int index = indices[i];
                    if (index < 0 || index >= Shape[i])
                    {
                        throw new IndexOutOfRangeException($"Index {index} out of bounds for dimension {i} with size {Shape[i]}.");
                    }
                    flatIndex += index * Strides[i];
                }
                return Data[flatIndex];
            }
            set
            {
                if (indices == null)
                    throw new ArgumentNullException(nameof(indices), "Indices cannot be null.");
                if (indices.Length != Shape.Length)
                    throw new ArgumentException($"Expected {Shape.Length} indices but received {indices.Length}.", nameof(indices));

                int flatIndex = _offset;
                for (int i = 0; i < indices.Length; i++)
                {
                    int index = indices[i];
                    if (index < 0 || index >= Shape[i])
                    {
                        throw new IndexOutOfRangeException($"Index {index} out of bounds for dimension {i} with size {Shape[i]}.");
                    }
                    flatIndex += index * Strides[i];
                }
                Data[flatIndex] = value;
            }
        }


        /// <summary>
        /// Extracts a subarray (slice) from the current NDArray.
        /// </summary>
        /// <param name="startIndices">
        /// An array of starting indices (inclusive) for each dimension.
        /// </param>
        /// <param name="endIndices">
        /// An array of ending indices (exclusive) for each dimension.
        /// </param>
        /// <returns>A new NDArray representing the sliced subarray.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="startIndices"/> or <paramref name="endIndices"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the lengths of <paramref name="startIndices"/> and <paramref name="endIndices"/>
        /// do not match the number of dimensions, or if a range is invalid.
        /// </exception>
        public NDArray<T> Slice(int[] startIndices, int[] endIndices)
        {
            if (startIndices is null)
                throw new ArgumentNullException(nameof(startIndices), "Start indices cannot be null.");
            if (endIndices is null)
                throw new ArgumentNullException(nameof(endIndices), "End indices cannot be null.");
            if (startIndices.Length != Shape.Length || endIndices.Length != Shape.Length)
                throw new ArgumentException("Start and end indices must match the number of dimensions.");

            int[] newShape = new int[Shape.Length];
            for (int i = 0; i < Shape.Length; i++)
            {
                if (startIndices[i] < 0 || endIndices[i] > Shape[i] || startIndices[i] >= endIndices[i])
                    throw new ArgumentException($"Invalid slice range for dimension {i}.");
                newShape[i] = endIndices[i] - startIndices[i];
            }

            NDArray<T> result = new(newShape);
            // Recursively copy data from this array to the sliced result.
            CopySliceRecursive(result, new int[Shape.Length], startIndices, 0);
            return result;
        }

        /// <summary>
        /// Recursively copies elements from the current NDArray into the target sliced NDArray.
        /// </summary>
        /// <param name="target">The target NDArray that receives the sliced data.</param>
        /// <param name="currentIndices">
        /// The current multi-dimensional index of the target NDArray (relative indices in the slice).
        /// </param>
        /// <param name="startIndices">
        /// The starting indices (absolute base) used to compute the corresponding index in the source array.
        /// </param>
        /// <param name="dim">The current dimension being processed.</param>
        private void CopySliceRecursive(NDArray<T> target, int[] currentIndices, int[] startIndices, int dim)
        {
            if (dim == Shape.Length)
            {
                // Compute source indices for this element.
                int[] sourceIndices = new int[Shape.Length];
                for (int i = 0; i < Shape.Length; i++)
                    sourceIndices[i] = currentIndices[i] + startIndices[i];
                target[currentIndices] = this[sourceIndices];
                return;
            }

            for (int i = 0; i < target.Shape[dim]; i++)
            {
                currentIndices[dim] = i;
                CopySliceRecursive(target, currentIndices, startIndices, dim + 1);
            }
        }


        /// <summary>
        /// Performs element-wise addition on two NDArrays.
        /// </summary>
        /// <param name="a">The left-hand NDArray operand.</param>
        /// <param name="b">The right-hand NDArray operand.</param>
        /// <returns>A new NDArray containing the element-wise sum.</returns>
        /// <exception cref="ArgumentException">Thrown if the shapes of the arrays do not match.</exception>
        public static NDArray<T> operator +(NDArray<T> a, NDArray<T> b)
        {
            if (!AreShapesEqual(a.Shape, b.Shape))
                throw new ArgumentException("Shapes must match for element-wise addition.");

            NDArray<T> result = new(a.Shape);
            for (int i = 0; i < a.Data.Length; i++)
            {
                result.Data[i] = a.Data[i] + b.Data[i];
            }
            return result;
        }

        /// <summary>
        /// Performs element-wise subtraction on two NDArrays.
        /// </summary>
        /// <param name="a">The left-hand NDArray operand.</param>
        /// <param name="b">The right-hand NDArray operand.</param>
        /// <returns>A new NDArray containing the element-wise difference.</returns>
        /// <exception cref="ArgumentException">Thrown if the shapes of the arrays do not match.</exception>
        public static NDArray<T> operator -(NDArray<T> a, NDArray<T> b)
        {
            if (!AreShapesEqual(a.Shape, b.Shape))
                throw new ArgumentException("Shapes must match for element-wise subtraction.");

            NDArray<T> result = new(a.Shape);
            for (int i = 0; i < a.Data.Length; i++)
            {
                result.Data[i] = a.Data[i] - b.Data[i];
            }
            return result;
        }

        /// <summary>
        /// Performs element-wise multiplication on two NDArray<T>s.
        /// </summary>
        /// <param name="a">The left-hand NDArray<T> operand.</param>
        /// <param name="b">The right-hand NDArray<T> operand.</param>
        /// <returns>A new NDArray<T> containing the element-wise product.</returns>
        /// <exception cref="ArgumentException">Thrown if the shapes of the arrays do not match.</exception>
        public static NDArray<T> operator *(NDArray<T> a, NDArray<T> b)
        {
            if (!AreShapesEqual(a.Shape, b.Shape))
                throw new ArgumentException("Shapes must match for element-wise multiplication.");

            NDArray<T> result = new(a.Shape);
            for (int i = 0; i < a.Data.Length; i++)
            {
                result.Data[i] = a.Data[i] * b.Data[i];
            }
            return result;
        }

        /// <summary>
        /// Performs element-wise division on two NDArray<T>s.
        /// </summary>
        /// <param name="a">The numerator NDArray<T> operand.</param>
        /// <param name="b">The denominator NDArray<T> operand.</param>
        /// <returns>A new NDArray<T> containing the element-wise quotient.</returns>
        /// <exception cref="ArgumentException">Thrown if the shapes of the arrays do not match.</exception>
        /// <exception cref="DivideByZeroException">Thrown if an element in the divisor array is zero.</exception>
        public static NDArray<T> operator /(NDArray<T> a, NDArray<T> b)
        {
            if (!AreShapesEqual(a.Shape, b.Shape))
                throw new ArgumentException("Shapes must match for element-wise division.");

            NDArray<T> result = new(a.Shape);
            for (int i = 0; i < a.Data.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(b.Data[i], T.Zero))
                    throw new DivideByZeroException("Division by zero encountered in NDArray<T> division.");
                result.Data[i] = a.Data[i] / b.Data[i];
            }
            return result;
        }


        /// <summary>
        /// Helper method to compare two shape arrays for equality.
        /// </summary>
        /// <param name="shapeA">The first shape array.</param>
        /// <param name="shapeB">The second shape array.</param>
        /// <returns><c>true</c> if the two shapes are identical; otherwise, <c>false</c>.</returns>
        private static bool AreShapesEqual(int[] shapeA, int[] shapeB)
        {
            if (shapeA.Length != shapeB.Length)
                return false;
            for (int i = 0; i < shapeA.Length; i++)
            {
                if (shapeA[i] != shapeB[i])
                    return false;
            }
            return true;
        }



        /* Utility methods (Reshape, Transpose, Copy) */

        /// <summary>
        /// Reshapes the current NDArray<T> to the specified new shape.
        /// The total number of elements must remain unchanged.
        /// </summary>
        /// <param name="newShape">
        /// An array of positive integers representing the new shape.
        /// </param>
        /// <returns>
        /// A new NDArray<T> instance with the updated shape and data copied from the current NDArray<T>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="newShape"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="newShape"/> is empty, contains non-positive integers,
        /// or if the total number of elements does not match.
        /// </exception>
        /// <exception cref="OverflowException">
        /// Thrown if the total number of elements in the new shape exceeds the limits of an integer.
        /// </exception>
        public NDArray<T> Reshape(int[] newShape)
        {
            if (newShape == null)
                throw new ArgumentNullException(nameof(newShape), "New shape cannot be null.");
            if (newShape.Length == 0)
                throw new ArgumentException("New shape must be a non-empty array.", nameof(newShape));

            // Validate each dimension in newShape.
            foreach (var dim in newShape)
            {
                if (dim <= 0)
                    throw new ArgumentException("All dimensions in the new shape must be positive integers.", nameof(newShape));
            }

            // Calculate the total number of elements for newShape using checked arithmetic.
            int totalElements = 1;
            for (int i = 0; i < newShape.Length; i++)
            {
                try
                {
                    totalElements = checked(totalElements * newShape[i]);
                }
                catch (OverflowException ex)
                {
                    throw new OverflowException("The total number of elements in the new shape overflows an integer.", ex);
                }
            }

            if (totalElements != Data.Length)
                throw new ArgumentException("The total number of elements must remain unchanged when reshaping.", nameof(newShape));

            // Create a new NDArray<T> with the new shape (using default order 'C').
            NDArray<T> reshapedArray = new NDArray<T>(newShape, order: 'C');

            // Copy the data from the current NDArray<T> to the reshaped NDArray<T>.
            Array.Copy(this.Data, reshapedArray.Data, Data.Length);

            return reshapedArray;
        }



        /// <summary>
        /// Transposes the NDArray<T>.
        /// This method is currently implemented only for 2D arrays.
        /// It returns a new NDArray<T> with the row and column axes swapped.
        /// </summary>
        /// <returns>A new NDArray<T> that is the transpose of this array.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the NDArray<T> is not 2-dimensional.
        /// </exception>
        public NDArray<T> Transpose()
        {
            if (Shape.Length != 2)
                throw new InvalidOperationException("Transpose is only implemented for 2D arrays.");

            // The new shape for a transposed 2D array.
            int[] newShape = new int[] { Shape[1], Shape[0] };

            // Create a new NDArray<T> with the transposed shape.
            NDArray<T> transposed = new NDArray<T>(newShape, order: 'C');

            // Swap rows and columns: element at (i, j) becomes element at (j, i).
            for (int i = 0; i < Shape[0]; i++)
            {
                for (int j = 0; j < Shape[1]; j++)
                {
                    transposed[j, i] = this[i, j];
                }
            }

            return transposed;
        }



        /// <summary>
        /// Creates a deep copy of the current NDArray<T>.
        /// </summary>
        /// <returns>
        /// A new NDArray<T> that is an exact copy of the current array, including its shape and data.
        /// </returns>
        public NDArray<T> Copy()
        {
            NDArray<T> copy = new((int[])this.Shape.Clone(), order: 'C');
            Array.Copy(this.Data, copy.Data, this.Data.Length);
            return copy;
        }





        /* Iteration Support */
        /// <summary>
        /// Returns an enumerator that iterates through the elements of the NDArray (the underlying data).
        /// </summary>
        /// <returns>An enumerator for the NDArray.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Data.Length; i++)
            {
                yield return Data[i];
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the elements of the NDArray (non-generic).
        /// </summary>
        /// <returns>An enumerator for the NDArray.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}



/* Implemented */
/*
    NDArray implementation now covers a wide range of core features:

Robust Error Handling: Checks for valid shapes, bounds, and overflow conditions.

Generic Support: Using NDArray<T> constrained with INumber<T> to support various numeric types.

Multi-dimensional Indexing: Indexer that translates multi‑dimensional indices into a flat index.

Slicing: Capability to extract subarrays with robust recursive copy operations.

Operator Overloading: Element-wise addition, subtraction, multiplication, and division (with proper equality comparisons and error checking).

Utility Methods: Reshape, Transpose (for 2D), and Copy for deep duplication.

Iteration Support: Implementation of IEnumerable<T> for natural foreach looping over the array's elements.
*/




/* Need Further Development */
/*
    • Advanced Slicing/Views: Instead of returning a new deep-copied subarray, consider implementing views that reference the original data (this is how NumPy typically works in many cases).

    • Broadcasting: Support for broadcasting rules when performing operations on arrays of different but compatible shapes.

    • ToString/Debugging: A custom ToString() override to provide a more human‑readable representation of the array can help with debugging and interactive sessions.

    • Performance Optimizations: Internal caching, vectorized operations, or integration with high-performance libraries for common numerical tasks might be added as the library scales.

    • Enhanced Operator Support: You might also extend support for scalar operations (e.g., adding a scalar to an array) and more advanced arithmetic functions.
*/
