using System.Numerics;

/// <summary>
/// The FactorialForge namespace contains classes and logic for advanced factorial calculations,
/// digit statistics analysis, and user interface components for displaying and exporting results.
/// </summary>
namespace FactorialForge
{
	/// <summary>
	/// Provides static methods for calculating various types of factorials and related mathematical functions.
	/// Includes support for standard, odd, even, prime, subfactorial, double, rising, falling, multi, super, and hyperfactorials.
	/// Offers both long and BigInteger variants for handling large results.
	/// </summary>
	internal class Factorializer
	{
		/// <summary>
		/// Computes all prime numbers up to a given limit n.
		/// </summary>
		/// <param name="n">The upper limit (inclusive) for finding prime numbers.</param>
		/// <returns>A list of all prime numbers less than or equal to n.</returns>
		private static List<long> PrimesUpTo(long n)
		{
			if (n < 2)
			{
				return [];
			}
			bool[] isPrime = new bool[n + 1];
			for (long i = 2; i <= n; i++)
			{
				isPrime[i] = true;
			}
			for (long i = 2; i * i <= n; i++)
			{
				if (isPrime[i])
				{
					for (long j = i * i; j <= n; j += i)
					{
						isPrime[j] = false;
					}
				}
			}
			List<long> primes = [];
			for (long i = 2; i <= n; i++)
			{
				if (isPrime[i])
				{
					primes.Add(item: i);
				}
			}
			return primes;
		}

		/// <summary>
		/// Checks if a given number is non-negative.
		/// </summary>
		/// <param name="n">The number to check.</param>
		/// <exception cref="OverflowException">Thrown if n is negative.</exception>
		/// <remarks>
		/// This method is used to validate that the input is a non-negative integer.
		/// </remarks>
		private static void CheckNonNegative(long n)
		{
			if (n < 0)
			{
				throw new OverflowException(message: "The number is only defined for non-negative integers.");
			}
		}

		/// <summary>
		/// Computes integer exponentiation: base^exp for non-negative exp.
		/// </summary>
		/// <param name="baseValue">The base value.</param>
		/// <param name="exp">The exponent (must be non-negative).</param>
		/// <returns>The result of baseValue raised to the power of exp.</returns>
		private static long PowInt(long baseValue, long exp)
		{
			if (exp < 0)
			{
				throw new ArgumentOutOfRangeException(paramName: nameof(exp), message: "Exponent must be non-negative.");
			}
			long result = 1;
			for (long j = 0; j < exp; j++)
			{
				result *= baseValue;
			}
			return result;
		}

		/// <summary>
		/// Computes the factorial of a non-negative integer n.
		/// </summary>
		/// <param name="n">The non-negative integer for which to compute the factorial.</param>
		/// <returns>
		/// The factorial of <paramref name="n"/> as a <see cref="long"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="FactorialBig"/> when the result is known to be within the range of <see cref="long"/>.
		/// </remarks>
		public static long Factorial(long n)
		{
			CheckNonNegative(n: n);

			long result = 1;
			for (long i = 2; i <= n; i++)
			{
				result *= i;
			}
			return result;
		}

		/// <summary>
		/// Computes the factorial of a non-negative integer n using arbitrary-precision arithmetic.
		/// </summary>
		/// <param name="n">The non-negative integer for which to compute the factorial.</param>
		/// <returns>
		/// The factorial of <paramref name="n"/> as a <see cref="BigInteger"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="Factorial"/> when the result may exceed the range of <see cref="long"/>.
		/// </remarks>
		public static BigInteger FactorialBig(long n)
		{
			CheckNonNegative(n: n);

			BigInteger result = BigInteger.One;
			for (long i = 2; i <= n; i++)
			{
				result *= i;
			}
			return result;
		}

		/// <summary>
		/// Computes the odd factorial of a non-negative integer n.
		/// </summary>
		/// <param name="n">The non-negative integer for which to compute the odd factorial.</param>
		/// <returns>
		/// The odd factorial of <paramref name="n"/> as a <see cref="long"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="OddFactorialBig"/> when the result is known to be within the range of <see cref="long"/>.
		/// </remarks>
		public static long OddFactorial(long n)
		{
			CheckNonNegative(n: n);

			long result = 1;
			for (long i = 1; i <= n; i += 2)
			{
				result *= i;
			}
			return result;
		}

		/// <summary>
		/// Computes the odd factorial of a non-negative integer n using arbitrary-precision arithmetic.
		/// </summary>
		/// <param name="n">The non-negative integer for which to compute the odd factorial.</param>
		/// <returns>
		/// The odd factorial of <paramref name="n"/> as a <see cref="BigInteger"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="OddFactorial"/> when the result may exceed the range of <see cref="long"/>.
		/// </remarks>
		public static BigInteger OddFactorialBig(long n)
		{
			CheckNonNegative(n: n);

			BigInteger result = BigInteger.One;
			for (long i = 1; i <= n; i += 2)
			{
				result *= i;
			}
			return result;
		}

		/// <summary>
		/// Computes the even factorial of a non-negative integer n.
		/// </summary>
		/// <param name="n">The non-negative integer for which to compute the even factorial.</param>
		/// <returns>
		/// The even factorial of <paramref name="n"/> as a <see cref="long"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="EvenFactorialBig"/> when the result is known to be within the range of <see cref="long"/>.
		/// </remarks>
		public static long EvenFactorial(long n)
		{
			CheckNonNegative(n: n);

			long result = 1;
			for (long i = 2; i <= n; i += 2)
			{
				result *= i;
			}
			return result;
		}

		/// <summary>
		/// Computes the even factorial of a non-negative integer n using arbitrary-precision arithmetic.
		/// </summary>
		/// <param name="n">The non-negative integer for which to compute the even factorial.</param>
		/// <returns>
		/// The even factorial of <paramref name="n"/> as a <see cref="BigInteger"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="EvenFactorial"/> when the result may exceed the range of <see cref="long"/>.
		/// </remarks>
		public static BigInteger EvenFactorialBig(long n)
		{
			CheckNonNegative(n: n);

			BigInteger result = BigInteger.One;
			for (long i = 2; i <= n; i += 2)
			{
				result *= i;
			}
			return result;
		}

		/// <summary>
		/// Returns the product of all prime numbers up to n.
		/// WARNING: The result will overflow for relatively small values of n (e.g., n > 43).
		/// For larger n, use PrimeFactorialBig instead.
		/// Throws OverflowException if the result exceeds the range of a long.
		/// </summary>
		/// <param name="n">The non-negative integer for which to compute the prime factorial.</param>
		/// <returns>
		/// The prime factorial of <paramref name="n"/> as a <see cref="long"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="PrimeFactorialBig"/> when the result is known to be within the range of <see cref="long"/>.
		/// </remarks>
		public static long PrimeFactorial(long n)
		{
			CheckNonNegative(n: n);

			if (n < 2)
			{
				return 1;
			}

			long result = 1;
			foreach (long prime in PrimesUpTo(n: n))
			{
				result *= prime;
			}

			return result;
		}

		/// <summary>
		/// Computes the prime factorial of a non-negative integer n using arbitrary-precision arithmetic.
		/// </summary>
		/// <param name="n">The non-negative integer for which to compute the prime factorial.</param>
		/// <returns>
		/// The prime factorial of <paramref name="n"/> as a <see cref="BigInteger"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="PrimeFactorial"/> when the result may exceed the range of <see cref="long"/>.
		/// </remarks>
		public static BigInteger PrimeFactorialBig(long n)
		{
			CheckNonNegative(n: n);

			if (n < 2)
			{
				return BigInteger.One;
			}

			BigInteger result = BigInteger.One;
			foreach (long prime in PrimesUpTo(n: n))
			{
				result *= prime;
			}

			return result;
		}

		/// <summary>
		/// Computes the subfactorial (!n) of a non-negative integer n.
		/// </summary>
		/// <param name="n">The non-negative integer for which to compute the subfactorial.</param>
		/// <returns>
		/// The subfactorial of <paramref name="n"/> as a <see cref="long"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="SubfactorialBig"/> when the result is known to be within the range of <see cref="long"/>.
		/// </remarks>
		public static long Subfactorial(long n)
		{
			CheckNonNegative(n: n);

			if (n == 0)
			{
				return 1; // !0 = 1
			}

			if (n == 1)
			{
				return 0; // !1 = 0
			}

			long a = 1;  // !0
			long b = 0; // !1
			long result = 0;

			for (long i = 2; i <= n; i++)
			{
				result = (i - 1) * (a + b); // !n = (n-1)(!(n-1) + !(n-2))
				a = b;
				b = result;
			}

			return result;
		}

		/// <summary>
		/// Computes the subfactorial (!n) of a non-negative integer n using arbitrary-precision arithmetic.
		/// </summary>
		/// <param name="n">The non-negative integer for which to compute the subfactorial.</param>
		/// <returns>
		/// The subfactorial of <paramref name="n"/> as a <see cref="BigInteger"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="Subfactorial"/> when the result may exceed the range of <see cref="long"/>.
		/// </remarks>
		public static BigInteger SubfactorialBig(long n)
		{
			CheckNonNegative(n: n);

			if (n == 0)
			{
				return BigInteger.One; // !0 = 1
			}

			if (n == 1)
			{
				return BigInteger.Zero; // !1 = 0
			}

			BigInteger a = BigInteger.One;  // !0
			BigInteger b = BigInteger.Zero; // !1
			BigInteger result = BigInteger.Zero;

			for (long i = 2; i <= n; i++)
			{
				result = (i - 1) * (a + b); // !n = (n-1)(!(n-1) + !(n-2))
				a = b;
				b = result;
			}

			return result;
		}

		/// <summary>
		/// Computes the double factorial of a non-negative integer n.
		/// </summary>
		/// <param name="n">The non-negative integer for which to compute the double factorial.</param>
		/// <returns>
		/// The double factorial of <paramref name="n"/> as a <see cref="long"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="DoubleFactorialBig"/> when the result is known to be within the range of <see cref="long"/>.
		/// </remarks>
		public static long DoubleFactorial(long n)
		{
			CheckNonNegative(n: n);

			if (n == 0)
			{
				return 1;
			}

			long result = 1;
			for (long i = n; i > 1; i -= 2)
			{
				result *= i;
			}

			return result;
		}

		/// <summary>
		/// Computes the double factorial of a non-negative integer n using arbitrary-precision arithmetic.
		/// </summary>
		/// <param name="n">The non-negative integer for which to compute the double factorial.</param>
		/// <returns>
		/// The double factorial of <paramref name="n"/> as a <see cref="BigInteger"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="DoubleFactorial"/> when the result may exceed the range of <see cref="long"/>.
		/// </remarks>
		public static BigInteger DoubleFactorialBig(long n)
		{
			CheckNonNegative(n: n);

			if (n == 0)
			{
				return BigInteger.One;
			}

			BigInteger result = BigInteger.One;
			for (long i = n; i > 1; i -= 2)
			{
				result *= i;
			}

			return result;
		}

		/// <summary>
		/// Computes the rising factorial (x)_n = x * (x+1) * ... * (x+n-1) as a long.
		/// Throws OverflowException if the result exceeds the range of a long.
		/// For large values, use RisingFactorialBig.
		/// </summary>
		/// <param name="x">The base value for the rising factorial.</param>
		/// <param name="n">The number of terms in the product.</param>
		/// <returns>
		/// The rising factorial (x)_n as a <see cref="long"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="RisingFactorialBig"/> when the result is known to be within the range of <see cref="long"/>.
		/// </remarks>
		public static long RisingFactorial(long x, long n)
		{
			CheckNonNegative(n: n);

			if (n == 0)
			{
				return 1;
			}

			long result = 1;
			for (long i = 0; i < n; i++)
			{
				result *= x + i;
			}

			return result;
		}

		/// <summary>
		/// Computes the rising factorial (x)_n = x * (x+1) * ... * (x+n-1) as a <see cref="BigInteger"/>.
		/// </summary>
		/// <param name="x">The base value for the rising factorial.</param>
		/// <param name="n">The number of terms in the product.</param>
		/// <returns>
		/// The rising factorial (x)_n as a <see cref="BigInteger"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="RisingFactorial"/> when the result may exceed the range of <see cref="long"/>.
		/// </remarks>
		public static BigInteger RisingFactorialBig(long x, long n)
		{
			CheckNonNegative(n: n);

			if (n == 0)
			{
				return 1;
			}

			BigInteger result = 1;
			for (long i = 0; i < n; i++)
			{
				result *= x + i;
			}

			return result;
		}

		/// <summary>
		/// Computes the falling factorial (x)_n = x * (x-1) * ... * (x-n+1) as a long.
		/// Throws OverflowException if the result exceeds the range of a long.
		/// For large values, use FallingFactorialBig.
		/// </summary>
		/// <param name="x">The base value for the falling factorial.</param>
		/// <param name="n">The number of terms in the product.</param>
		/// <returns>
		/// The falling factorial (x)_n as a <see cref="long"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="FallingFactorialBig"/> when the result is known to be within the range of <see cref="long"/>.
		/// </remarks>
		public static long FallingFactorial(long x, long n)
		{
			CheckNonNegative(n: n);

			if (n == 0)
			{
				return 1;
			}

			long result = 1;
			for (long i = 0; i < n; i++)
			{
				result *= x - i;
			}

			return result;
		}

		/// <summary>
		/// Computes the falling factorial (x)_n = x * (x-1) * ... * (x-n+1) as a <see cref="BigInteger"/>.
		/// </summary>
		/// <param name="x">The base value for the falling factorial.</param>
		/// <param name="n">The number of terms in the product.</param>
		/// <returns>
		/// The falling factorial (x)_n as a <see cref="BigInteger"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="FallingFactorial"/> when the result may exceed the range of <see cref="long"/>.
		/// </remarks>
		public static BigInteger FallingFactorialBig(long x, long n)
		{
			CheckNonNegative(n: n);

			if (n == 0)
			{
				return 1;
			}

			BigInteger result = 1;
			for (long i = 0; i < n; i++)
			{
				result *= x - i;
			}

			return result;
		}

		/// <summary>
		/// Computes the multi-factorial of a number.
		/// The multi-factorial of x with step n is defined as the product x * (x - n) * (x - 2n) * ...,
		/// continuing until the next term would be less than or equal to zero.
		/// </summary>
		/// <param name="x">The starting integer for the product. Must be greater than or equal to zero.</param>
		/// <param name="n">The decrement step for each term in the product. Must be positive (greater than zero).</param>
		/// <returns>
		/// The multi-factorial of x with step n. Returns 1 if x is less than or equal to zero.
		/// </returns>
		public static long MultiFactorial(long x, long n)
		{
			if (n <= 0)
			{
				throw new ArgumentOutOfRangeException(paramName: nameof(n), message: "n must be greater than 0 for multi-factorial.");
			}

			if (x <= 0)
			{
				return 1;
			}

			long result = 1;
			for (long i = x; i > 0; i -= n)
			{
				result *= i;
			}

			return result;
		}

		/// <summary>
		/// Calculates the multi-factorial of <paramref name="x"/> with step size <paramref name="n"/> using <see cref="BigInteger"/> for large results.
		/// The multi-factorial of x with step n is defined as x * (x - n) * (x - 2n) * ... until the term is &gt; 0.
		/// </summary>
		/// <param name="x">The starting integer for the multi-factorial calculation.</param>
		/// <param name="n">The decrement step size for each term in the product. Must be positive.</param>
		/// <returns>
		/// The multi-factorial of x with step n as a <see cref="BigInteger"/>. Returns 1 if x &lt;= 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="MultiFactorial"/> when the result may exceed the range of <see cref="long"/>.
		/// </remarks>
		public static BigInteger MultiFactorialBig(long x, long n)
		{
			if (n <= 0)
			{
				throw new ArgumentOutOfRangeException(paramName: nameof(n), message: "n must be greater than 0 for multi-factorial.");
			}

			if (x <= 0)
			{
				return BigInteger.One;
			}

			BigInteger result = BigInteger.One;
			for (long i = x; i > 0; i -= n)
			{
				result *= i;
			}

			return result;
		}

		/// <summary>
		/// Calculates the superfactorial of <paramref name="n"/> as a <see cref="long"/>.
		/// The superfactorial of n is defined as the product of the first n factorials: 1! * 2! * ... * n!.
		/// </summary>
		/// <param name="n">The upper bound integer for the superfactorial calculation. Must be non-negative.</param>
		/// <returns>
		/// The superfactorial of <paramref name="n"/> as a <see cref="long"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// The result may overflow for relatively small values of <paramref name="n"/>. Use <see cref="SuperfactorialBig"/> for large n.
		/// </remarks>
		public static long Superfactorial(long n)
		{
			long result = 1;

			for (long i = 1; i <= n; i++)
			{
				result *= Factorial(n: i);
			}

			return result;
		}

		/// <summary>
		/// Calculates the superfactorial of <paramref name="n"/> as a <see cref="BigInteger"/>.
		/// The superfactorial of n is defined as the product of the first n factorials: 1! * 2! * ... * n!.
		/// </summary>
		/// <param name="n">The upper bound integer for the superfactorial calculation. Must be non-negative.</param>
		/// <returns>
		/// The superfactorial of <paramref name="n"/> as a <see cref="BigInteger"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="Superfactorial"/> when the result may exceed the range of <see cref="long"/>.
		/// </remarks>
		public static BigInteger SuperfactorialBig(long n)
		{
			BigInteger result = 1;

			for (long i = 1; i <= n; i++)
			{
				result *= FactorialBig(n: i);
			}

			return result;
		}

		/// <summary>
		/// Calculates the hyperfactorial of a non-negative integer n, defined as the product of i^i for i from 1 to n.
		/// </summary>
		/// <param name="n">The non-negative integer for which to compute the hyperfactorial.</param>
		/// <returns>
		/// The hyperfactorial of <paramref name="n"/> as a <see cref="long"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method for values of n where the result fits within the range of <see cref="long"/>.
		/// For larger values, use <see cref="HyperfactorialBig"/>.
		/// </remarks>
		public static long Hyperfactorial(long n)
		{
			long result = 1;

			for (long i = 1; i <= n; i++)
			{
				result *= PowInt(baseValue: i, exp: i); // i^i
			}

			return result;
		}

		/// <summary>
		/// Calculates the hyperfactorial of a non-negative integer n, defined as the product of i^i for i from 1 to n, using arbitrary-precision arithmetic.
		/// </summary>
		/// <param name="n">The non-negative integer for which to compute the hyperfactorial.</param>
		/// <returns>
		/// The hyperfactorial of <paramref name="n"/> as a <see cref="BigInteger"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="Hyperfactorial"/> when the result may exceed the range of <see cref="long"/>.
		/// </remarks>
		public static BigInteger HyperfactorialBig(long n)
		{
			BigInteger result = 1;

			for (long i = 1; i <= n; i++)
			{
				result *= BigInteger.Pow(value: i, exponent: (int)i); // i^i
			}

			return result;
		}
	}
}