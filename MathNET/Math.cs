namespace MathNET;


public class Math
{
    /*Math.Comb(n, k)*/
    /// <summary>
    /// Calculates the number of ways to choose k items from n items without repetition and without order.
    /// </summary>
    /// <param name="n">The total number of items.</param>
    /// <param name="k">The number of items to choose.</param>
    /// <returns>The number of ways to choose k items from n items.</returns>
    /// <exception cref="TypeError">Thrown when the arguments are not integers.</exception>
    /// <exception cref="ValueError">Thrown when the arguments are negative integers.</exception>
    public static long Comb(int n, int k)
    {
        if (!IsInteger(n) || !IsInteger(k))
            throw new TypeError("Arguments must be integers.");
        if (n < 0 || k < 0)
            throw new ValueError("Arguments must be non-negative integers.");

        if (k > n)
            return 0;
        if (k == 0 || k == n)
            return 1;

        long result = 1;
        for (int i = 1; i <= k; i++)
        {
            result = result * (n - i + 1) / i;
        }

        return result;
    }
    /// <summary>
    /// Checks if the given value is an integer.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>True if the value is an integer; otherwise, false.</returns>




    /*Math.Factorial(n)*/
    /// <summary>
    /// Calculates the factorial of a non-negative integer n.
    /// </summary>
    /// <param name="n">The non-negative integer.</param>
    /// <returns>The factorial of n.</returns>
    /// <exception cref="TypeError">Thrown when the argument is not an integer.</exception>
    /// <exception cref="ValueError">Thrown when the argument is a negative integer.</exception>
    public static long Factorial(int n)
    {
        if (!IsInteger(n))
            throw new TypeError("Argument must be an integer.");
        if (n < 0)
            throw new ValueError("Argument must be non-negative integer");

        long result = 1;
        for (int i = 1; i <= n; i++)
            result *= i;

        return result;
    }
    /// <summary>
    /// Checks if the given value is an integer.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>True if the value is an integer; otherwise, false.</returns>




    /* Math.GCD(*integers) */
    /// <summary>
    /// Calculates the greatest common divisor (GCD) of the specified integer arguments.
    /// </summary>
    /// <param name="integers">The integers to calculate the GCD for.</param>
    /// <returns>The greatest common divisor of the specified integers.</returns>
    /// <exception cref="TypeError">Thrown when any of the arguments are not integers.</exception>
    public static int GCD(params int[] integers)
    {
        if (integers.Length == 0)
            return 0;

        foreach (var value in integers)
        {
            if (!IsInteger(value))
                throw new TypeError("All arguments must be integers.");
        }

        int gcd = integers[0];
        for (int i = 1; i < integers.Length; i++)
            gcd = GCD(gcd, integers[i]);

        return gcd;
    }

    /// <summary>
    /// Checks if the given value is an integer.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>True if the value is an integer; otherwise, false.</returns>




    /* Math.IsSqrt(n)*/
    /// <summary>
    /// Returns the integer square root of the nonnegative integer n.
    /// </summary>
    /// <param name="n">The nonnegative integer.</param>
    /// <returns>The integer square root of n.</returns>
    /// <exception cref="TypeError">Thrown when the argument is not an integer.</exception>
    /// <exception cref="ValueError">Thrown when the argument is a negative integer.</exception>
    public static int IsSqrt(int n)
    {
        if (IsInteger(n))
            throw new TypeError("Argument must be an integer.");
        if (n < 0)
            throw new ValueError("Argument must be an non-negative integer.");

        int x = n;
        int y = (x + 1 / 2);
        while (y < x)
        {
            x = y;
            y = (x + n / x) / 2;
        }
        return x;
    }

    /// <summary>
    /// Checks if the given value is an integer.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>True if the value is an integer; otherwise, false.</returns>




    /* Math.LCM(*integers) */
    /// <summary>
    /// Returns the least common multiple (LCM) of the specified integer arguments.
    /// If all arguments are nonzero, the returned value is the smallest positive integer that is a multiple of all arguments.
    /// If any of the arguments is zero, the returned value is 0. Calling LCM() without arguments returns 1.
    /// </summary>
    /// <param name="numbers">An array of integers.</param>
    /// <returns>The least common multiple of the specified integers.</returns>
    public static int LCM(params int[] numbers)
    {
        if (numbers.Length == 0)
            return 1;

            int lcm = numbers[0];
            for (int i=1; i<numbers.Length; i++)
                lcm = LCM(lcm, numbers[i]);

        return lcm;
    }

    /// <summary>
    /// Returns the least common multiple (LCM) of two integers.
    /// </summary>
    /// <param name="a">The first integer.</param>
    /// <param name="b">The second integer.</param>
    /// <returns>The least common multiple of the two integers.</returns>
    





    
    



    private static bool IsInteger(object value)
    {
        return value is int;
    }

    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    private static int LCM(int a, int b)
    {
        return (a * b) / GCD(a, b);
    }
}