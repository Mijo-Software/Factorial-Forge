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

		private static void CheckOverflow(long n)
		{
			if (n < 0)
			{
				throw new OverflowException(message: "The number is only defined for non-negative integers.");
			}
		}

		public static long Factorial(long n)
		{
			CheckOverflow(n: n);

			long result = 1;
			for (long i = 2; i <= n; i++)
			{
				result *= i;
			}
			return result;
		}

		public static BigInteger FactorialBig(long n)
		{
			CheckOverflow(n: n);

			BigInteger result = BigInteger.One;
			for (long i = 2; i <= n; i++)
			{
				result *= i;
			}
			return result;
		}

		public static long OddFactorial(long n)
		{
			CheckOverflow(n: n);

			long result = 1;
			for (long i = 1; i <= n; i += 2)
			{
				result *= i;
			}
			return result;
		}

		public static BigInteger OddFactorialBig(long n)
		{
			CheckOverflow(n: n);

			BigInteger result = BigInteger.One;
			for (long i = 1; i <= n; i += 2)
			{
				result *= i;
			}
			return result;
		}

		public static long EvenFactorial(int n)
		{
			CheckOverflow(n: n);

			long result = 1;
			for (long i = 2; i <= n; i += 2)
			{
				result *= i;
			}
			return result;
		}

		public static BigInteger EvenFactorialBig(long n)
		{
			CheckOverflow(n: n);

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
			CheckOverflow(n: n);

			if (n < 2)
			{
				return 1;
			}

			long result = 1;
			foreach (long prime in PrimesUpTo(n))
			{
				result *= prime;
			}

			return result;
		}

		public static BigInteger PrimeFactorialBig(long n)
		{
			CheckOverflow(n: n);

			if (n < 2)
			{
				return BigInteger.One;
			}

			BigInteger result = BigInteger.One;
			foreach (long prime in PrimesUpTo(n))
			{
				result *= prime;
			}

			return result;
		}

		public static long Subfactorial(long n)
		{
			CheckOverflow(n: n);

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
			CheckOverflow(n: n);

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
			CheckOverflow(n: n);

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
			CheckOverflow(n: n);

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
	}
}