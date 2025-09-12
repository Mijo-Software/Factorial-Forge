using System.Numerics;

namespace FactorialForge
{
	internal class Factorializer
	{
		public static long Factorial(int n)
		{
			if (n < 0)
			{
				throw new ArgumentException(message: "Factorial is only defined for non-negative integers.");
			}

			long result = 1;
			for (int i = 2; i <= n; i++)
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
	}
}
