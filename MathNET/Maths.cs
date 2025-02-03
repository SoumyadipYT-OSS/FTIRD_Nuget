namespace MathNET
{

    public class Maths
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
            if (n < 0 || k < 0)
                throw new ArgumentException("Arguments must be non-negative integers.");
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
            if (n < 0)
                throw new ArgumentException("It must be positive integer value.");
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
                    throw new ArgumentException("All arguments must be integers.");
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
            if (n < 0)
                throw new ArgumentException("It should be a positive integer.");
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
            for (int i = 1; i < numbers.Length; i++)
                lcm = LCM(lcm, numbers[i]);

            return lcm;
        }

        /// <summary>
        /// Returns the least common multiple (LCM) of two integers.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The least common multiple of the two integers.</returns>





        /// <summary>
        /// Returns the number of ways to choose k items from n items without repetition and with order.
        /// Evaluates to n! / (n - k)! when k <= n and evaluates to zero when k > n.
        /// If k is not specified or is None, then k defaults to n and the function returns n!.
        /// Raises ArgumentException if either of the arguments are negative.
        /// </summary>
        /// <param name="n">The total number of items.</param>
        /// <param name="k">The number of items to choose. Defaults to n if not specified.</param>
        /// <returns>The number of ways to choose k items from n items.</returns>
        /// <exception cref="ArgumentException">Thrown when the arguments are negative integers.</exception>
        public static long Perm(int n, int? k = null)
        {
            if (n < 0 || (k.HasValue && k.Value < 0))
                throw new ArgumentException("Arguments must be non-negative integers.");

            if (!k.HasValue || k.Value == n)
                return Factorial(n);

            if (k.Value > n)
                return 0;

            return Factorial(n) / Factorial(n - k.Value);
        }




        /// <summary>
        /// Returns the ceiling of x, the smallest integer greater than or equal to x.
        /// If x is not a float, delegates to x.__ceil__, which should return an Integral value.
        /// </summary>
        /// <param name="x">The number to find the ceiling of.</param>
        /// <returns>The smallest integer greater than or equal to x.</returns>
        public static int Ceil(double x)
        {
            return (int)Math.Ceiling(x);
        }




        /// <summary>
        /// Returns the absolute value of x.
        /// </summary>
        /// <param name="x">The number to find the absolute value of.</param>
        /// <returns>The absolute value of x.</returns>
        public static double Fabs(double x)
        {
            return Math.Abs(x);
        }




        /// <summary>
        /// Returns the floor of x, the largest integer less than or equal to x.
        /// If x is not a float, delegates to x.__floor__, which should return an Integral value.
        /// </summary>
        /// <param name="x">The number to find the floor of.</param>
        /// <returns>The largest integer less than or equal to x.</returns>
        public static int Floor(double x)
        {
            return (int)Math.Floor(x);
        }




        /// <summary>
        /// Fused multiply-add operation. Returns (x * y) + z, computed as though with infinite precision and range followed by a single round to the float format.
        /// This operation often provides better accuracy than the direct expression (x * y) + z.
        /// Follows the specification of the fusedMultiplyAdd operation described in the IEEE 754 standard.
        /// Returns NaN for fma(0, inf, nan) and fma(inf, 0, nan) without raising any exception.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        /// <param name="z">The addend.</param>
        /// <returns>The result of (x * y) + z.</returns>
        public static double Fma(double x, double y, double z)
        {
            return Math.FusedMultiplyAdd(x, y, z);
        }




        /// <summary>
        /// Returns the floating-point remainder of x / y, as defined by the platform C library function fmod(x, y).
        /// Note that the Python expression x % y may not return the same result.
        /// The intent of the C standard is that fmod(x, y) be exactly (mathematically; to infinite precision) equal to x - n*y
        /// for some integer n such that the result has the same sign as x and magnitude less than abs(y).
        /// </summary>
        /// <param name="x">The dividend.</param>
        /// <param name="y">The divisor.</param>
        /// <returns>The floating-point remainder of x / y.</returns>
        public static double Fmod(double x, double y)
        {
            return Math.IEEERemainder(x, y);
        }




        /// <summary>
        /// Returns the fractional and integer parts of x.
        /// Both results carry the sign of x and are floats.
        /// </summary>
        /// <param name="x">The number to split into fractional and integer parts.</param>
        /// <returns>A tuple containing the fractional and integer parts of x.</returns>
        public static (double Fractional, double Integer) Modf(double x)
        {
            double integerPart = Math.Floor(x);
            double fractionalPart = x - integerPart;
            return (fractionalPart, integerPart);
        }




        /// <summary>
        /// Returns the IEEE 754-style remainder of x with respect to y.
        /// For finite x and finite nonzero y, this is the difference x - n*y, where n is the closest integer to the exact value of the quotient x / y.
        /// If x / y is exactly halfway between two consecutive integers, the nearest even integer is used for n.
        /// The remainder r = remainder(x, y) thus always satisfies abs(r) <= 0.5 * abs(y).
        /// Special cases follow IEEE 754: in particular, remainder(x, double.PositiveInfinity) is x for any finite x,
        /// and remainder(x, 0) and remainder(double.PositiveInfinity, x) raise ArgumentException for any non-NaN x.
        /// If the result of the remainder operation is zero, that zero will have the same sign as x.
        /// </summary>
        /// <param name="x">The dividend.</param>
        /// <param name="y">The divisor.</param>
        /// <returns>The IEEE 754-style remainder of x with respect to y.</returns>
        /// <exception cref="ArgumentException">Thrown when y is zero or x is infinity.</exception>
        public static double Remainder(double x, double y)
        {
            if (double.IsInfinity(x) || y == 0)
                throw new ArgumentException("Invalid operation: x is infinity or y is zero.");

            double quotient = x / y;
            double n = Math.Round(quotient);
            return x - n * y;
        }




        /// <summary>
        /// Returns x with the fractional part removed, leaving the integer part.
        /// This rounds toward 0: trunc() is equivalent to floor() for positive x, and equivalent to ceil() for negative x.
        /// If x is not a float, delegates to x.__trunc__, which should return an Integral value.
        /// </summary>
        /// <param name="x">The number to truncate.</param>
        /// <returns>The integer part of x.</returns>
        public static int Trunc(double x)
        {
            return (int)x;
        }




        /// <summary>
        /// Returns a float with the magnitude (absolute value) of x but the sign of y.
        /// On platforms that support signed zeros, copysign(1.0, -0.0) returns -1.0.
        /// </summary>
        /// <param name="x">The value whose magnitude is to be used.</param>
        /// <param name="y">The value whose sign is to be used.</param>
        /// <returns>A float with the magnitude of x and the sign of y.</returns>
        public static double Copysign(double x, double y)
        {
            return Math.CopySign(x, y);
        }




        /// <summary>
        /// Returns the mantissa and exponent of x as the pair (m, e).
        /// m is a float and e is an integer such that x == m * 2**e exactly.
        /// If x is zero, returns (0.0, 0), otherwise 0.5 <= abs(m) < 1.
        /// This is used to “pick apart” the internal representation of a float in a portable way.
        /// </summary>
        /// <param name="x">The number to split into mantissa and exponent.</param>
        /// <returns>A tuple containing the mantissa and exponent of x.</returns>
        public static (double Mantissa, int Exponent) Frexp(double x)
        {
            if (x == 0.0)
                return (0.0, 0);

            int exponent = (int)Math.Floor(Math.Log(x, 2)) + 1;
            double mantissa = x / Math.Pow(2, exponent);
            return (mantissa, exponent);
        }




        /// <summary>
        /// Returns True if the values a and b are close to each other and False otherwise.
        /// Whether or not two values are considered close is determined according to given absolute and relative tolerances.
        /// If no errors occur, the result will be: abs(a-b) <= max(rel_tol * max(abs(a), abs(b)), abs_tol).
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="rel_tol">The relative tolerance – the maximum allowed difference between a and b, relative to the larger absolute value of a or b. Defaults to 1e-09.</param>
        /// <param name="abs_tol">The absolute tolerance; defaults to 0.0 and must be nonnegative.</param>
        /// <returns>True if the values a and b are close to each other, False otherwise.</returns>
        public static bool IsClose(double a, double b, double rel_tol = 1e-09, double abs_tol = 0.0)
        {
            if (rel_tol < 0 || rel_tol >= 1.0)
                throw new ArgumentException("rel_tol must be nonnegative and less than 1.0.");
            if (abs_tol < 0)
                throw new ArgumentException("abs_tol must be nonnegative.");

            return Math.Abs(a - b) <= Math.Max(rel_tol * Math.Max(Math.Abs(a), Math.Abs(b)), abs_tol);
        }




        /// <summary>
        /// Returns True if x is neither an infinity nor a NaN, and False otherwise.
        /// Note that 0.0 is considered finite.
        /// </summary>
        /// <param name="x">The number to check.</param>
        /// <returns>True if x is finite, False otherwise.</returns>
        public static bool IsFinite(double x)
        {
            return !double.IsInfinity(x) && !double.IsNaN(x);
        }




        /// <summary>
        /// Returns True if x is a positive or negative infinity, and False otherwise.
        /// </summary>
        /// <param name="x">The number to check.</param>
        /// <returns>True if x is a positive or negative infinity, False otherwise.</returns>
        public static bool IsInf(double x)
        {
            return double.IsInfinity(x);
        }




        /// <summary>
        /// Returns True if x is a NaN (not a number), and False otherwise.
        /// </summary>
        /// <param name="x">The number to check.</param>
        /// <returns>True if x is a NaN, False otherwise.</returns>
        public static bool IsNan(double x)
        {
            return double.IsNaN(x);
        }




        /// <summary>
        /// Returns x * (2**i). This is essentially the inverse of function frexp().
        /// </summary>
        /// <param name="x">The floating-point number.</param>
        /// <param name="i">The exponent.</param>
        /// <returns>The result of x * (2**i).</returns>
        public static double Ldexp(double x, int i)
        {
            return x * Math.Pow(2, i);
        }




        /// <summary>
        /// Returns the floating-point value steps steps after x towards y.
        /// If x is equal to y, return y, unless steps is zero.
        /// </summary>
        /// <param name="x">The starting value.</param>
        /// <param name="y">The target value.</param>
        /// <param name="steps">The number of steps to move from x towards y. Defaults to 1.</param>
        /// <returns>The floating-point value steps steps after x towards y.</returns>
        public static double NextAfter(double x, double y, int steps = 1)
        {
            if (steps == 0 || x == y)
                return y;

            double direction = Math.Sign(y - x);
            double stepSize = Math.Pow(2, -52); // Smallest step size for double precision
            return x + direction * steps * stepSize;
        }




        /// <summary>
        /// Returns the value of the least significant bit of the float x.
        /// If x is a NaN (not a number), return x.
        /// If x is negative, return ulp(-x).
        /// If x is a positive infinity, return x.
        /// If x is equal to zero, return the smallest positive denormalized representable float.
        /// If x is equal to the largest positive representable float, return the value of the least significant bit of x, such that the first float smaller than x is x - ulp(x).
        /// Otherwise (x is a positive finite number), return the value of the least significant bit of x, such that the first float bigger than x is x + ulp(x).
        /// </summary>
        /// <param name="x">The floating-point number.</param>
        /// <returns>The value of the least significant bit of the float x.</returns>
        public static double Ulp(double x)
        {
            if (double.IsNaN(x) || x == double.PositiveInfinity)
                return x;
            if (x == 0.0)
                return double.Epsilon;
            if (x == double.MaxValue)
                return BitConverter.Int64BitsToDouble(BitConverter.DoubleToInt64Bits(x) - 1) - x;

            long bits = BitConverter.DoubleToInt64Bits(x);
            bits = bits < 0 ? -bits : bits;
            return BitConverter.Int64BitsToDouble(bits + 1) - x;
        }




        /// <summary>
        /// Returns the cube root of x.
        /// </summary>
        /// <param name="x">The number to find the cube root of.</param>
        /// <returns>The cube root of x.</returns>
        public static double Cbrt(double x)
        {
            return Math.Pow(x, 1.0 / 3.0);
        }




        /// <summary>
        /// Returns e raised to the power x, where e = 2.718281… is the base of natural logarithms.
        /// This is usually more accurate than Math.E ** x or Math.Pow(Math.E, x).
        /// </summary>
        /// <param name="x">The exponent to raise e to.</param>
        /// <returns>The value of e raised to the power x.</returns>
        public static double Exp(double x)
        {
            return Math.Exp(x);
        }




        /// <summary>
        /// Returns 2 raised to the power x.
        /// </summary>
        /// <param name="x">The exponent to raise 2 to.</param>
        /// <returns>The value of 2 raised to the power x.</returns>
        public static double Exp2(double x)
        {
            return Math.Pow(2, x);
        }




        /// <summary>
        /// Returns e raised to the power x, minus 1. Here e is the base of natural logarithms.
        /// For small floats x, the subtraction in exp(x) - 1 can result in a significant loss of precision;
        /// the expm1() function provides a way to compute this quantity to full precision.
        /// </summary>
        /// <param name="x">The exponent to raise e to, minus 1.</param>
        /// <returns>The value of e raised to the power x, minus 1.</returns>
        public static double Expm1(double x)
        {
            if (Math.Abs(x) < 1e-5)
            {
                // Use a Taylor series expansion for small x to avoid precision loss
                return x + 0.5 * x * x;
            }
            else
            {
                return Math.Exp(x) - 1;
            }
        }




        /// <summary>
        /// Returns the natural logarithm of x (to base e) if only one argument is provided.
        /// With two arguments, returns the logarithm of x to the given base, calculated as log(x)/log(base).
        /// </summary>
        /// <param name="x">The number to find the logarithm of.</param>
        /// <param name="base">The base of the logarithm. Defaults to e if not provided.</param>
        /// <returns>The logarithm of x to the given base.</returns>
        public static double Log(double x, double baseVal = Math.E)
        {
            return Math.Log(x) / Math.Log(baseVal);
        }




        /// <summary>
        /// Returns the natural logarithm of 1+x (base e).
        /// The result is calculated in a way which is accurate for x near zero.
        /// </summary>
        /// <param name="x">The number to find the natural logarithm of 1+x.</param>
        /// <returns>The natural logarithm of 1+x.</returns>
        public static double Log1p(double x)
        {
            return Math.Log(1 + x);
        }




        /// <summary>
        /// Returns the base-2 logarithm of x. This is usually more accurate than log(x, 2).
        /// </summary>
        /// <param name="x">The number to find the base-2 logarithm of.</param>
        /// <returns>The base-2 logarithm of x.</returns>
        public static double Log2(double x)
        {
            return Math.Log2(x);
        }




        /// <summary>
        /// Returns the base-10 logarithm of x. This is usually more accurate than log(x, 10).
        /// </summary>
        /// <param name="x">The number to find the base-10 logarithm of.</param>
        /// <returns>The base-10 logarithm of x.</returns>
        public static double Log10(double x)
        {
            return Math.Log10(x);
        }




        /// <summary>
        /// Returns x raised to the power y. Exceptional cases follow the IEEE 754 standard as far as possible.
        /// In particular, pow(1.0, x) and pow(x, 0.0) always return 1.0, even when x is a zero or a NaN.
        /// If both x and y are finite, x is negative, and y is not an integer then pow(x, y) is undefined, and raises ValueError.
        /// Unlike the built-in ** operator, math.pow() converts both its arguments to type float.
        /// Use ** or the built-in pow() function for computing exact integer powers.
        /// </summary>
        /// <param name="x">The base.</param>
        /// <param name="y">The exponent.</param>
        /// <returns>The value of x raised to the power y.</returns>
        public static double Pow(double x, double y)
        {
            return Math.Pow(x, y);
        }




        /// <summary>
        /// Returns the square root of x.
        /// </summary>
        /// <param name="x">The number to find the square root of.</param>
        /// <returns>The square root of x.</returns>
        public static double Sqrt(double x)
        {
            return Math.Sqrt(x);
        }




        /// <summary>
        /// Returns the Euclidean distance between two points p and q, each given as a sequence (or iterable) of coordinates.
        /// The two points must have the same dimension.
        /// </summary>
        /// <param name="p">The first point as a sequence of coordinates.</param>
        /// <param name="q">The second point as a sequence of coordinates.</param>
        /// <returns>The Euclidean distance between the two points.</returns>
        public static double Dist(double[] p, double[] q)
        {
            if (p.Length != q.Length)
                throw new ArgumentException("The two points must have the same dimension.");

            double sum = 0;
            for (int i = 0; i < p.Length; i++)
            {
                double diff = p[i] - q[i];
                sum += diff * diff;
            }

            return Math.Sqrt(sum);
        }




        /// <summary>
        /// Returns an accurate floating-point sum of values in the iterable.
        /// Avoids loss of precision by tracking multiple intermediate partial sums.
        /// </summary>
        /// <param name="values">The iterable of values to sum.</param>
        /// <returns>The accurate floating-point sum of the values.</returns>
        public static double FSum(IEnumerable<double> values)
        {
            double sum = 0.0;
            double c = 0.0; // A running compensation for lost low-order bits.

            foreach (double value in values)
            {
                double y = value - c; // So far, so good: c is zero.
                double t = sum + y; // Alas, sum is big, y small, so low-order digits of y are lost.
                c = (t - sum) - y; // (t - sum) cancels the high-order part of y; subtracting y recovers negative (low part of y)
                sum = t; // Algebraically, c should always be zero. Beware overly-aggressive optimizing compilers!
            }

            return sum;
        }




        /// <summary>
        /// Returns the Euclidean norm, sqrt(sum(x**2 for x in coordinates)).
        /// This is the length of the vector from the origin to the point given by the coordinates.
        /// </summary>
        /// <param name="coordinates">The coordinates of the point.</param>
        /// <returns>The Euclidean norm of the point.</returns>
        public static double Hypot(params double[] coordinates)
        {
            double sum = 0;
            foreach (double coord in coordinates)
            {
                sum += coord * coord;
            }
            return Math.Sqrt(sum);
        }




        /// <summary>
        /// Calculates the product of all the elements in the input iterable.
        /// The default start value for the product is 1.
        /// When the iterable is empty, returns the start value.
        /// This function is intended specifically for use with numeric values and may reject non-numeric types.
        /// </summary>
        /// <param name="values">The iterable of values to multiply.</param>
        /// <param name="start">The initial value for the product. Defaults to 1.</param>
        /// <returns>The product of all the elements in the input iterable.</returns>
        public static double Prod(IEnumerable<double> values, double start = 1)
        {
            double product = start;
            foreach (double value in values)
            {
                product *= value;
            }
            return product;
        }




        /// <summary>
        /// Returns the sum of products of values from two iterables p and q.
        /// Raises ValueError if the inputs do not have the same length.
        /// </summary>
        /// <param name="p">The first iterable of values.</param>
        /// <param name="q">The second iterable of values.</param>
        /// <returns>The sum of products of values from the two iterables.</returns>
        public static double SumProd(IEnumerable<double> p, IEnumerable<double> q)
        {
            if (p.Count() != q.Count())
                throw new ArgumentException("The inputs do not have the same length.");

            double sum = 0;
            using (var enumeratorP = p.GetEnumerator())
            using (var enumeratorQ = q.GetEnumerator())
            {
                while (enumeratorP.MoveNext() && enumeratorQ.MoveNext())
                {
                    sum += enumeratorP.Current * enumeratorQ.Current;
                }
            }

            return sum;
        }




        /// <summary>
        /// Converts angle x from radians to degrees.
        /// </summary>
        /// <param name="x">The angle in radians.</param>
        /// <returns>The angle in degrees.</returns>
        public static double Degrees(double x)
        {
            return x * (180.0 / Math.PI);
        }




        /// <summary>
        /// Converts angle x from degrees to radians.
        /// </summary>
        /// <param name="x">The angle in degrees.</param>
        /// <returns>The angle in radians.</returns>
        public static double Radians(double x)
        {
            return x * (Math.PI / 180.0);
        }




        /// <summary>
        /// Returns the arc cosine of x, in radians. The result is between 0 and pi.
        /// </summary>
        /// <param name="x">The value to find the arc cosine of.</param>
        /// <returns>The arc cosine of x, in radians.</returns>
        public static double Acos(double x)
        {
            return Math.Acos(x);
        }




        /// <summary>
        /// Returns the arc sine of x, in radians. The result is between -pi/2 and pi/2.
        /// </summary>
        /// <param name="x">The value to find the arc sine of.</param>
        /// <returns>The arc sine of x, in radians.</returns>
        public static double Asin(double x)
        {
            return Math.Asin(x);
        }




        /// <summary>
        /// Returns the arc tangent of x, in radians. The result is between -pi/2 and pi/2.
        /// </summary>
        /// <param name="x">The value to find the arc tangent of.</param>
        /// <returns>The arc tangent of x, in radians.</returns>
        public static double Atan(double x)
        {
            return Math.Atan(x);
        }




        /// <summary>
        /// Returns atan(y / x), in radians. The result is between -pi and pi.
        /// The vector in the plane from the origin to point (x, y) makes this angle with the positive X axis.
        /// The point of atan2() is that the signs of both inputs are known to it, so it can compute the correct quadrant for the angle.
        /// </summary>
        /// <param name="y">The y-coordinate of the point.</param>
        /// <param name="x">The x-coordinate of the point.</param>
        /// <returns>The angle in radians between -pi and pi.</returns>
        public static double Atan2(double y, double x)
        {
            return Math.Atan2(y, x);
        }




        /// <summary>
        /// Returns the cosine of x radians.
        /// </summary>
        /// <param name="x">The angle in radians.</param>
        /// <returns>The cosine of x.</returns>
        public static double Cos(double x)
        {
            return Math.Cos(x);
        }




        /// <summary>
        /// Returns the sine of x radians.
        /// </summary>
        /// <param name="x">The angle in radians.</param>
        /// <returns>The sine of x.</returns>
        public static double Sin(double x)
        {
            return Math.Sin(x);
        }




        /// <summary>
        /// Returns the tangent of x radians.
        /// </summary>
        /// <param name="x">The angle in radians.</param>
        /// <returns>The tangent of x.</returns>
        public static double Tan(double x)
        {
            return Math.Tan(x);
        }




        /// <summary>
        /// Returns the inverse hyperbolic cosine of x.
        /// </summary>
        /// <param name="x">The value to find the inverse hyperbolic cosine of.</param>
        /// <returns>The inverse hyperbolic cosine of x.</returns>
        public static double Acosh(double x)
        {
            return Math.Acosh(x);
        }




        /// <summary>
        /// Returns the inverse hyperbolic sine of x.
        /// </summary>
        /// <param name="x">The value to find the inverse hyperbolic sine of.</param>
        /// <returns>The inverse hyperbolic sine of x.</returns>
        public static double Asinh(double x)
        {
            return Math.Asinh(x);
        }




        /// <summary>
        /// Returns the inverse hyperbolic tangent of x.
        /// </summary>
        /// <param name="x">The value to find the inverse hyperbolic tangent of.</param>
        /// <returns>The inverse hyperbolic tangent of x.</returns>
        public static double Atanh(double x)
        {
            return Math.Atanh(x);
        }




        /// <summary>
        /// Returns the hyperbolic cosine of x.
        /// </summary>
        /// <param name="x">The value to find the hyperbolic cosine of.</param>
        /// <returns>The hyperbolic cosine of x.</returns>
        public static double Cosh(double x)
        {
            return Math.Cosh(x);
        }




        /// <summary>
        /// Returns the hyperbolic sine of x.
        /// </summary>
        /// <param name="x">The value to find the hyperbolic sine of.</param>
        /// <returns>The hyperbolic sine of x.</returns>
        public static double Sinh(double x)
        {
            return Math.Sinh(x);
        }




        /// <summary>
        /// Returns the hyperbolic tangent of x.
        /// </summary>
        /// <param name="x">The value to find the hyperbolic tangent of.</param>
        /// <returns>The hyperbolic tangent of x.</returns>
        public static double Tanh(double x)
        {
            return Math.Tanh(x);
        }




        /// <summary>
        /// Returns the error function at x.
        /// </summary>
        /// <param name="x">The value to find the error function of.</param>
        /// <returns>The error function at x.</returns>
        public static double Erf(double x)
        {
            // Constants used in the approximation
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = x < 0 ? -1 : 1;
            x = Math.Abs(x);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return sign * y;
        }




        /// <summary>
        /// Returns the complementary error function at x.
        /// The complementary error function is defined as 1.0 - erf(x).
        /// It is used for large values of x where a subtraction from one would cause a loss of significance.
        /// </summary>
        /// <param name="x">The value to find the complementary error function of.</param>
        /// <returns>The complementary error function at x.</returns>
        public static double Erfc(double x)
        {
            // Constants used in the approximation
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = x < 0 ? -1 : 1;
            x = Math.Abs(x);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return sign * (1.0 - y);
        }




        /// <summary>
        /// Returns the Gamma function at x.
        /// </summary>
        /// <param name="x">The value to find the Gamma function of.</param>
        /// <returns>The Gamma function at x.</returns>
        public static double Gamma(double x)
        {
            // Lanczos approximation coefficients
            double[] p = {
                676.5203681218851,
                -1259.1392167224028,
                771.32342877765313,
                -176.61502916214059,
                12.507343278686905,
                -0.13857109526572012,
                9.9843695780195716e-6,
                1.5056327351493116e-7
            };

            int g = 7;
            if (x < 0.5)
            {
                return Math.PI / (Math.Sin(Math.PI * x) * Gamma(1 - x));
            }
            else
            {
                x -= 1;
                double a = 0.99999999999980993;
                double t = x + g + 0.5;
                for (int i = 0; i < p.Length; i++)
                {
                    a += p[i] / (x + i + 1);
                }
                return Math.Sqrt(2 * Math.PI) * Math.Pow(t, x + 0.5) * Math.Exp(-t) * a;
            }
        }




        /// <summary>
        /// Returns the natural logarithm of the absolute value of the Gamma function at x.
        /// </summary>
        /// <param name="x">The value to find the natural logarithm of the absolute value of the Gamma function of.</param>
        /// <returns>The natural logarithm of the absolute value of the Gamma function at x.</returns>
        public static double LGamma(double x)
        {
            // Lanczos approximation coefficients
            double[] p = {
                676.5203681218851,
                -1259.1392167224028,
                771.32342877765313,
                -176.61502916214059,
                12.507343278686905,
                -0.13857109526572012,
                9.9843695780195716e-6,
                1.5056327351493116e-7
            };

            int g = 7;
            if (x < 0.5)
            {
                return Math.Log(Math.PI / (Math.Sin(Math.PI * x) * Gamma(1 - x)));
            }
            else
            {
                x -= 1;
                double a = 0.99999999999980993;
                double t = x + g + 0.5;
                for (int i = 0; i < p.Length; i++)
                {
                    a += p[i] / (x + i + 1);
                }
                return Math.Log(Math.Sqrt(2 * Math.PI) * Math.Pow(t, x + 0.5) * Math.Exp(-t) * a);
            }
        }

















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
            return (a / GCD(a, b)) * b;
        }
    }
}