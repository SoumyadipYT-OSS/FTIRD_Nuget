# FTIRD.NUMIN

**FTIRD.NUMIN** is a powerful numerical library designed to simplify mathematical and scientific computations. With extensive support for linear algebra, matrix operations, and utility functions, this library is your go-to companion for numerical computing in .NET.

## Features

- Matrix Operations: Multiplication, Transpose, Determinant, Inverse, Dot Product, and more.
- Linear Algebra: LU Decomposition, QR Decomposition, Singular Value Decomposition (SVD), Cholesky Decomposition, and Eigenvalues/Eigenvectors.
- Utility Functions: Initialization methods (zeros, ones, identity, etc.).

## Installation

To install FTIRD.NUMIN, use the following NuGet command:

```bash
dotnet add package FTIRD.NUMIN
```


### Creating NDArrays
You can easily create NDArrays of various shapes and initialize them with specific values.

```csharp
using Nm = FTIRD.NUMIN.Core;

class Program
{
    static void Main()
    {
        // Create an NDArray with shape [2, 2]
        Nm.NDArray<double> array = new Nm.NDArray<double>(new int[] { 2, 2 });

        // Initialize the NDArray with zeros
        Nm.NDArray<double> zeros = Nm.NDArrayInitialization.Zeros<double>(2, 2);

        // Print the NDArray
        Console.WriteLine(zeros);
    }
}
```

------

### Performing Linear Algebra Operations
FTIRD.NUMIN offers a variety of linear algebra operations to solve complex mathematical problems.
#### *LU Decomposition*
```csharp
using Nm = FTIRD.NUMIN.Core;
using System;

class Program
{
    static void Main()
    {
        Nm.NDArray<double> array = new Nm.NDArray<double>(new int[] { 2, 2 });
        // Initialize the array with some values
        array[0, 0] = 4;
        array[0, 1] = 3;
        array[1, 0] = 3;
        array[1, 1] = 2;

        // Perform LU Decomposition
        var (L, U) = array.LUDecomposition();

        // Print the results
        Console.WriteLine("L:");
        Console.WriteLine(L);
        Console.WriteLine("U:");
        Console.WriteLine(U);
    }
}
```

#### *QR Decompostion*
```csharp
using Nm = FTIRD.NUMIN.Core;
using System;

class Program
{
    static void Main()
    {
        Nm.NDArray<double> array = new Nm.NDArray<double>(new int[] { 2, 2 });
        // Initialize the array with some values
        array[0, 0] = 1;
        array[0, 1] = 2;
        array[1, 0] = 3;
        array[1, 1] = 4;

        // Perform QR Decomposition
        var (Q, R) = array.QRDecomposition(Math.Sqrt);

        // Print the results
        Console.WriteLine("Q:");
        Console.WriteLine(Q);
        Console.WriteLine("R:");
        Console.WriteLine(R);
    }
}
```

------

#### *Singular Value Decomposition (SVD)*
```csharp
using Nm = FTIRD.NUMIN.Core;
using System;

class Program
{
    static void Main()
    {
        Nm.NDArray<double> array = new Nm.NDArray<double>(new int[] { 2, 2 });
        // Initialize the array with some values
        array[0, 0] = 1;
        array[0, 1] = 0;
        array[1, 0] = 0;
        array[1, 1] = -2;

        // Perform Singular Value Decomposition (SVD)
        var (U, S, V) = array.SVD();

        // Print the results
        Console.WriteLine("U:");
        Console.WriteLine(U);
        Console.WriteLine("S:");
        Console.WriteLine(S);
        Console.WriteLine("V:");
        Console.WriteLine(V);
    }
}
```

------

#### Cholesky Decomposition
```csharp
using Nm = FTIRD.NUMIN.Core;
using System;

class Program
{
    static void Main()
    {
        Nm.NDArray<double> array = new Nm.NDArray<double>(new int[] { 2, 2 });
        // Initialize the array with some values
        array[0, 0] = 4;
        array[0, 1] = 12;
        array[1, 0] = 12;
        array[1, 1] = 37;

        // Perform Cholesky Decomposition
        Nm.NDArray<double> L = array.CholeskyDecomposition_Decompose(Math.Sqrt);

        // Print the result
        Console.WriteLine("L:");
        Console.WriteLine(L);
    }
}
```
------

### Utility Functions
FTIRD.NUMIN also provides useful utility functions for initializing and manipulating NDArrays.
>> Initialization
```csharp
using Nm = FTIRD.NUMIN.Core;
using System;

class Program
{
    static void Main()
    {
        // Create an NDArray filled with zeros
        Nm.NDArray<double> zeros = Nm.NDArrayInitialization.Zeros<double>(3, 3);

        // Create an NDArray filled with ones
        Nm.NDArray<double> ones = Nm.NDArrayInitialization.Ones<double>(3, 3);

        // Print the NDArrays
        Console.WriteLine("Zeros:");
        Console.WriteLine(zeros);
        Console.WriteLine("Ones:");
        Console.WriteLine(ones);
    }
}
```



### Package Version
    - Initial Version: 1.0.0

    Upcoming version will be updated and documentation will come, stay tuned!


Feel free to contact.


Happy Coding!