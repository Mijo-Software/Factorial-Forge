using System.Numerics;

namespace FactorialForge
{
	internal class Factorializer
	{
		private static bool IsPrime(long number)
		{
			if (number < 2)
			{
				return false;
			}

			if (number == 2)
			{
				return true;
			}

			if (number % 2 == 0)
			{
				return false;
			}

			long sqrt = (long)Math.Sqrt(d: number);
			for (long i = 3; i <= sqrt; i += 2)
			{
				if (number % i == 0)
				{
					return false;
				}
			}

			return true;
		}

		private static List<long> PrimesUpTo(long n)
		{
			List<long> primes = [];
			for (long i = 2; i <= n; i++)
			{
				if (IsPrime(number: i))
				{
					primes.Add(item: i);
				}
			}
			return primes;
		}


		public static long Factorial(long n)
		{
			if (n < 0)
			{
				throw new ArgumentException(message: "Factorial is only defined for non-negative integers.");
			}

			long result = 1;
			for (long i = 2; i <= n; i++)
			{
				result *= i;
			}
			return result;
		}

		public static BigInteger FactorialBig(long n)
		{
			if (n < 0)
			{
				throw new ArgumentException(message: "Factorial is only defined for non-negative integers.");
			}

			BigInteger result = BigInteger.One;
			for (long i = 2; i <= n; i++)
			{
				result *= i;
			}
			return result;
		}

		public static long OddFactorial(long n)
		{
			if (n < 0)
			{
				throw new ArgumentException(message: "Factorial is only defined for non-negative integers.");
			}

			long result = 1;
			for (long i = 1; i <= n; i += 2)
			{
				result *= i;
			}
			return result;
		}

		public static BigInteger OddFactorialBig(long n)
		{
			if (n < 0)
			{
				throw new ArgumentException(message: "Factorial is only defined for non-negative integers.");
			}

			BigInteger result = BigInteger.One;
			for (long i = 1; i <= n; i += 2)
			{
				result *= i;
			}
			return result;
		}

		public static long EvenFactorial(int n)
		{
			if (n < 0)
			{
				throw new ArgumentException(message: "Factorial is only defined for non-negative integers.");
			}
			long result = 1;
			for (long i = 2; i <= n; i += 2)
			{
				result *= i;
			}
			return result;
		}

		public static BigInteger EvenFactorialBig(long n)
		{
			if (n < 0)
			{
				throw new ArgumentException(message: "Factorial is only defined for non-negative integers.");
			}
			BigInteger result = BigInteger.One;
			for (long i = 2; i <= n; i += 2)
			{
				result *= i;
			}
			return result;
		}

		public static BigInteger PrimeFactorial(long n)
		{
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
	}
}