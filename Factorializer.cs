using System.Numerics;

namespace FactorialForge
{
	internal class Factorializer
	{
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

		private static void CheckNonNegative(long n)
		{
			if (n < 0)
			{
				throw new OverflowException(message: "The number is only defined for non-negative integers.");
			}
		}

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
	}
}