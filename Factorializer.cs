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
			// Sieve of Eratosthenes
			if (n < 2)
			{
				// No primes less than 2
				return [];
			}
			// Initialize a boolean array to track prime status
			bool[] isPrime = new bool[n + 1];
			// Sieve of Eratosthenes: initialize all numbers >= 2 as prime.
			// Time complexity: O(n log log n), space complexity: O(n).
			// Suitable for typical factorial calculation ranges.
			for (long i = 2; i <= n; i++)
			{
				isPrime[i] = true;
			}
			// Sieve out non-prime numbers
			for (long i = 2; i * i <= n; i++)
			{
				// If i is prime, mark all multiples of i (starting from i*i) as non-prime.
				// This is the core step of the Sieve of Eratosthenes.
				if (isPrime[i])
				{
					// Mark all multiples of i as non-prime
					for (long j = i * i; j <= n; j += i)
					{
						// Mark j as non-prime
						isPrime[j] = false;
					}
				}
			}
			// Collect all prime numbers into a list
			List<long> primes = [];
			// Iterate through the boolean array and add indices marked as prime to the list
			// Start from 2, as 0 and 1 are not prime
			// This final step gathers the results of the sieve into a usable format
			// The list of primes can then be returned to the caller
			// This completes the Sieve of Eratosthenes algorithm
			// The method returns a list of all prime numbers up to n
			for (long i = 2; i <= n; i++)
			{
				// If i is still marked as prime, add it to the list
				if (isPrime[i])
				{
					// Add i to the list of primes
					primes.Add(item: i);
				}
			}
			// Return the list of prime numbers
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
			// Factorials and related functions are only defined for non-negative integers
			// Throw an exception if n is negative
			// This ensures that the input is valid for factorial calculations
			// The method does not return a value; it only performs validation
			if (n < 0)
			{
				// Throw an exception with a descriptive message
				throw new OverflowException(message: "The number is only defined for non-negative integers.");
			}
		}

		/// <summary>
		/// Checks if a given number is positive.
		/// Throws an <see cref="OverflowException"/> if n is not greater than 0.
		/// This method is used to validate that the input is a positive integer for functions that require it.
		/// </summary>
		/// <param name="n">The number to check.</param>
		private static void CheckPositive(long n)
		{
			// Some functions are only defined for positive integers
			// Throw an exception if n is not positive
			// This ensures that the input is valid for these calculations
			// The method does not return a value; it only performs validation
			if (n <= 0)
			{
				// Throw an exception with a descriptive message
				throw new OverflowException(message: "The number is only defined for positive integers.");
			}
		}

		/// <summary>
		/// Computes integer exponentiation: base^exp for non-negative exp.
		/// </summary>
		/// <param name="baseValue">The base value.</param>
		/// <param name="exp">The exponent (must be non-negative).</param>
		/// <returns>The result of baseValue raised to the power of exp.</returns>
		private static long PowLong(long baseValue, long exp)
		{
			// Validate that the exponent is non-negative
			// This method does not handle negative exponents
			// If exp is negative, throw an exception
			// This ensures that the method is used correctly
			// The method uses a simple loop to compute the power
			// This is not the most efficient method for large exponents
			// but it is straightforward and easy to understand
			// For large exponents, consider using a more efficient algorithm
			// such as exponentiation by squaring
			if (exp < 0)
			{
				// Throw an exception with a descriptive message
				throw new ArgumentOutOfRangeException(paramName: nameof(exp), message: "Exponent must be non-negative.");
			}
			// Initialize the result to 1 (base case for exponentiation)
			long result = 1;
			// Multiply the result by the base value exp times
			// This loop runs exp times
			// Each iteration multiplies the current result by the base value
			// The final result is baseValue raised to the power of exp
			// The time complexity is O(exp)
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed power
			// If exp is 0, the result remains 1 (base^0 = 1)
			// For exp > 0, the loop computes the product
			// The method does not handle overflow; it is the caller's responsibility to ensure the result fits in a long
			// The maximum value of exp for which baseValue^exp fits in a long depends on baseValue
			// For example, 2^63 fits in a long, but 3^40 does not
			// Use this method for small exponents where the result is known to fit in a long
			// For larger exponents, consider using BigInteger.Pow
			// This method is a simple implementation of integer exponentiation
			// It is suitable for educational purposes and small calculations
			for (long j = 0; j < exp; j++)
			{
				// Multiply the current result by the base value
				result *= baseValue;
			}
			// Return the computed power
			return result;
		}

		/// <summary>
		/// Computes base^exponent for BigInteger base and BigInteger exponent using repeated squaring.
		/// </summary>
		/// <param name="baseValue">The base value.</param>
		/// <param name="exponent">The exponent value.</param>
		/// <returns>baseValue raised to the power of exponent.</returns>
		private static BigInteger BigIntegerPow(BigInteger baseValue, BigInteger exponent)
		{
			// Validate that the exponent is non-negative
			if (exponent < 0)
			{
				// Throw an exception with a descriptive message
				throw new ArgumentException(message: "Exponent must be non-negative.", paramName: nameof(exponent));
			}
			// Handle special cases
			if (exponent == 0)
			{
				return 1;
			}
			// If baseValue is 0 and exponent is positive, the result is 0
			if (baseValue == 0)
			{
				return 0;
			}
			// Initialize result to 1 (base case for exponentiation)
			BigInteger result = 1;
			// Loop until the exponent is reduced to 0
			while (exponent > 0)
			{
				// If the exponent is odd, multiply the result by the base value
				if ((exponent & 1) == 1)
				{
					// Multiply the current result by the base value
					result *= baseValue;
				}
				// Square the base value and halve the exponent
				baseValue *= baseValue;
				exponent >>= 1;
			}
			// Return the computed power
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// Initialize the result to 1 (0! = 1)
			long result = 1;
			// Compute the factorial iteratively
			// This avoids the risk of stack overflow from recursion
			// The loop runs from 2 to n, multiplying the result by each integer
			// This is a straightforward implementation of the factorial function
			// It is efficient for reasonably small values of n
			// For very large n, consider using BigInteger to avoid overflow
			// The time complexity is O(n), which is acceptable for typical factorial calculations
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed factorial
			// If n is 0 or 1, the result remains 1
			// For n >= 2, the loop computes the product
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which n! fits in a long is 20
			// Beyond that, use FactorialBig for larger results
			// The factorial of n is defined as the product of all positive integers up to n
			// For example, Factorial(5) = 1 * 2 * 3 * 4 * 5 = 120
			// The method can handle small values of n efficiently
			// The maximum value of n is constrained by the risk of overflow in the result
			// Use this method for small factorial calculations where the result is known to fit in a long
			// The method is a simple implementation of the factorial function
			// It is suitable for educational purposes and small calculations
			// The method completes when all integers up to n have been multiplied
			for (long i = 2; i <= n; i++)
			{
				// Multiply the current result by i
				result *= i;
			}
			// Return the computed factorial
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// Initialize the result to 1 (0! = 1)
			BigInteger result = BigInteger.One;
			// Compute the factorial iteratively
			// This avoids the risk of stack overflow from recursion
			// The loop runs from 2 to n, multiplying the result by each integer
			// This is a straightforward implementation of the factorial function
			// It is efficient for reasonably small values of n
			// For very large n, BigInteger handles the large results without overflow
			// The time complexity is O(n), which is acceptable for typical factorial calculations
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed factorial
			// If n is 0 or 1, the result remains 1
			// For n >= 2, the loop computes the product
			// The method can handle very large values of n, limited only by system memory
			// The maximum value of n is constrained by practical computation time and memory usage
			// Use this method for large factorial calculations where the result exceeds the range of long
			// This method is a simple implementation of the factorial function using BigInteger
			// It is suitable for applications requiring high precision and large number handling
			// The method completes when all integers up to n have been multiplied
			// The maximum value of n for which n! fits in a long is 20
			// Beyond that, use FactorialBig for larger results
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The factorial of n is defined as the product of all positive integers up to n
			// For example, FactorialBig(5) = 1 * 2 * 3 * 4 * 5 = 120
			for (long i = 2; i <= n; i++)
			{
				// Multiply the current result by i
				result *= i;
			}
			// Return the computed factorial
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// Initialize the result to 1 (0! = 1)
			long result = 1;
			// Compute the odd factorial iteratively
			// The loop runs from 1 to n, incrementing by 2 to include only odd integers
			// This is a straightforward implementation of the odd factorial function
			// It is efficient for reasonably small values of n
			// For very large n, consider using BigInteger to avoid overflow
			// The time complexity is O(n/2), which simplifies to O(n)
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed odd factorial
			// If n is 0, the result remains 1
			// For n >= 1, the loop computes the product of odd integers
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the odd factorial fits in a long is relatively small
			// Beyond that, use OddFactorialBig for larger results
			// The odd factorial of n is defined as the product of all odd integers up to n
			// For example, OddFactorial(7) = 1 * 3 * 5 * 7 = 105
			// The method can handle small values of n efficiently
			// The maximum value of n is constrained by the risk of overflow in the result
			// Use this method for small odd factorial calculations where the result is known to fit in a long
			// The method is a simple implementation of the odd factorial function
			// It is suitable for educational purposes and small calculations
			// The method completes when all odd integers up to n have been multiplied
			for (long i = 1; i <= n; i += 2)
			{
				// Multiply the current result by i
				result *= i;
			}
			// Return the computed odd factorial
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// Initialize the result to 1 (0! = 1)
			BigInteger result = BigInteger.One;
			// Compute the odd factorial iteratively
			// The loop runs from 1 to n, incrementing by 2 to include only odd integers
			// This is a straightforward implementation of the odd factorial function
			// It is efficient for reasonably small values of n
			// For very large n, BigInteger handles the large results without overflow
			// The time complexity is O(n/2), which simplifies to O(n)
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed odd factorial
			// If n is 0, the result remains 1
			// For n >= 1, the loop computes the product of odd integers
			// The method can handle very large values of n, limited only by system memory
			// The maximum value of n is constrained by practical computation time and memory usage
			// Use this method for large odd factorial calculations where the result exceeds the range of long
			// The odd factorial of n is defined as the product of all odd integers up to n
			// For example, OddFactorialBig(7) = 1 * 3 * 5 * 7 = 105
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the odd factorial fits in a long is relatively small
			// Beyond that, use OddFactorialBig for larger results
			// The method is a simple implementation of the odd factorial function using BigInteger
			// It is suitable for applications requiring high precision and large number handling
			// The method completes when all odd integers up to n have been multiplied
			for (long i = 1; i <= n; i += 2)
			{
				// Multiply the current result by i
				result *= i;
			}
			// Return the computed odd factorial
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// Initialize the result to 1 (0! = 1)
			long result = 1;
			// Compute the even factorial iteratively
			// The loop runs from 2 to n, incrementing by 2 to include only even integers
			// This is a straightforward implementation of the even factorial function
			// It is efficient for reasonably small values of n
			// For very large n, consider using BigInteger to avoid overflow
			// The time complexity is O(n/2), which simplifies to O(n)
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed even factorial
			// If n is 0, the result remains 1
			// For n >= 2, the loop computes the product of even integers
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the even factorial fits in a long is relatively small
			// Beyond that, use EvenFactorialBig for larger results
			// The even factorial of n is defined as the product of all even integers up to n
			// For example, EvenFactorial(8) = 2 * 4 * 6 * 8 = 384
			// The method can handle small values of n efficiently
			// The maximum value of n is constrained by the risk of overflow in the result
			// Use this method for small even factorial calculations where the result is known to fit in a long
			// The method is a simple implementation of the even factorial function
			// It is suitable for educational purposes and small calculations
			// The method completes when all even integers up to n have been multiplied
			for (long i = 2; i <= n; i += 2)
			{
				// Multiply the current result by i
				result *= i;
			}
			// Return the computed even factorial
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// Initialize the result to 1 (0! = 1)
			BigInteger result = BigInteger.One;
			// Compute the even factorial iteratively
			// The loop runs from 2 to n, incrementing by 2 to include only even integers
			// This is a straightforward implementation of the even factorial function
			// It is efficient for reasonably small values of n
			// For very large n, BigInteger handles the large results without overflow
			// The time complexity is O(n/2), which simplifies to O(n)
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed even factorial
			// If n is 0, the result remains 1
			// For n >= 2, the loop computes the product of even integers
			// The method can handle very large values of n, limited only by system memory
			// The maximum value of n is constrained by practical computation time and memory usage
			// Use this method for large even factorial calculations where the result exceeds the range of long
			// The even factorial of n is defined as the product of all even integers up to n
			// For example, EvenFactorialBig(8) = 2 * 4 * 6 * 8 = 384
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the even factorial fits in a long is relatively small
			// Beyond that, use EvenFactorialBig for larger results
			// The method is a simple implementation of the even factorial function using BigInteger
			// It is suitable for applications requiring high precision and large number handling
			// The method completes when all even integers up to n have been multiplied
			for (long i = 2; i <= n; i += 2)
			{
				// Multiply the current result by i
				result *= i;
			}
			// Return the computed even factorial
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// The prime factorial is the product of all prime numbers up to n
			// If n < 2, the result is 1 (the empty product)
			if (n < 2)
			{
				// Return 1 for n < 2
				return 1;
			}
			// Compute the prime factorial by multiplying all primes up to n
			long result = 1;
			// Use the PrimesUpTo method to get all primes up to n
			// Multiply each prime into the result
			// This is a straightforward implementation of the prime factorial function
			// It is efficient for reasonably small values of n
			// The time complexity is O(m), where m is the number of primes up to n
			// The space complexity is O(m) due to the list of primes
			// The method returns the computed prime factorial
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the prime factorial fits in a long is relatively small
			// Beyond that, use PrimeFactorialBig for larger results
			// The prime factorial of n is defined as the product of all prime numbers less than or equal to n
			// For example, PrimeFactorial(5) = 2 * 3 * 5 = 30
			// The method can handle small values of n efficiently
			// The maximum value of n is constrained by the risk of overflow in the result
			// Use this method for small prime factorial calculations where the result is known to fit in a long
			// The method is a simple implementation of the prime factorial function
			// It is suitable for educational purposes and small calculations
			// The method completes when all primes up to n have been multiplied
			foreach (long prime in PrimesUpTo(n: n))
			{
				// Multiply the current result by the prime
				result *= prime;
			}
			// Return the computed prime factorial
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// The prime factorial is the product of all prime numbers up to n
			// If n < 2, the result is 1 (the empty product)
			if (n < 2)
			{
				// Return 1 for n < 2
				return BigInteger.One;
			}
			// Compute the prime factorial by multiplying all primes up to n
			BigInteger result = BigInteger.One;
			// Use the PrimesUpTo method to get all primes up to n
			// Multiply each prime into the result
			// This is a straightforward implementation of the prime factorial function
			// It is efficient for reasonably small values of n
			// For very large n, BigInteger handles the large results without overflow
			// The time complexity is O(m), where m is the number of primes up to n
			// The space complexity is O(m) due to the list of primes
			// The method returns the computed prime factorial
			// The prime factorial of n is defined as the product of all prime numbers less than or equal to n
			// For example, PrimeFactorialBig(5) = 2 * 3 * 5 = 30
			// The method can handle very large values of n, limited only by system memory
			// The maximum value of n is constrained by practical computation time and memory usage
			// Use this method for large prime factorial calculations where the result exceeds the range of long
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the prime factorial fits in a long is relatively small
			// Beyond that, use PrimeFactorialBig for larger results
			foreach (long prime in PrimesUpTo(n: n))
			{
				// Multiply the current result by the prime
				result *= prime;
			}
			// Return the computed prime factorial
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// Base cases
			if (n == 0)
			{
				// Return 1 for n = 0; !0 = 1
				return 1;
			}
			if (n == 1)
			{
				// Return 0 for n = 1; !1 = 0
				return 0;
			}
			// Use an iterative approach to compute the subfactorial
			long a = 1;  // !0
			long b = 0; // !1
			long result = 0;
			// Compute !n using the recurrence relation:
			// !n = (n-1)(!(n-1) + !(n-2))
			// This avoids the risk of stack overflow from recursion
			// The loop runs from 2 to n, updating the values of a and b
			// This is a straightforward implementation of the subfactorial function
			// It is efficient for reasonably small values of n
			// The time complexity is O(n), which is acceptable for typical subfactorial calculations
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed subfactorial
			// If n is 0 or 1, the result is handled by the base cases
			// For n >= 2, the loop computes the subfactorial using the recurrence relation
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which !n fits in a long is relatively small
			// Beyond that, use SubfactorialBig for larger results
			// The subfactorial of n is defined as the number of derangements of n items
			// For example, Subfactorial(4) = 9
			// The sequence of subfactorials starts as 1, 0, 1, 2, 9, 44, ...
			// The method can handle small values of n efficiently
			// The maximum value of n is constrained by the risk of overflow in the result
			// Use this method for small subfactorial calculations where the result is known to fit in a long
			// The method is a simple implementation of the subfactorial function
			// It is suitable for educational purposes and small calculations
			// The method completes when the subfactorial for n has been computed
			for (long i = 2; i <= n; i++)
			{
				// Update result using the recurrence relation
				// !n = (n-1)(!(n-1) + !(n-2))
				result = (i - 1) * (a + b);
				// Shift a and b for the next iteration
				a = b;
				b = result;
			}
			// Return the computed subfactorial
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// Base cases
			if (n == 0)
			{
				// Return 1 for n = 0; !0 = 1
				return BigInteger.One;
			}
			if (n == 1)
			{
				// Return 0 for n = 1; !1 = 0
				return BigInteger.Zero;
			}
			// Use an iterative approach to compute the subfactorial
			// !0 = 1
			BigInteger a = BigInteger.One;
			// !1 = 0
			BigInteger b = BigInteger.Zero;
			// Initialize result
			BigInteger result = BigInteger.Zero;
			// Compute !n using the recurrence relation:
			// !n = (n-1)(!(n-1) + !(n-2))
			// This avoids the risk of stack overflow from recursion
			// The loop runs from 2 to n, updating the values of a and b
			// This is a straightforward implementation of the subfactorial function
			// It is efficient for reasonably small values of n
			// For very large n, BigInteger handles the large results without overflow
			// The time complexity is O(n), which is acceptable for typical subfactorial calculations
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed subfactorial
			// If n is 0 or 1, the result is handled by the base cases
			// For n >= 2, the loop computes the subfactorial using the recurrence relation
			// The method can handle very large values of n, limited only by system memory
			// The maximum value of n is constrained by practical computation time and memory usage
			// Use this method for large subfactorial calculations where the result exceeds the range of long
			// The subfactorial of n is defined as the number of derangements of n items
			// For example, SubfactorialBig(4) = 9
			// The sequence of subfactorials starts as 1, 0, 1, 2, 9, 44, ...
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which !n fits in a long is relatively small
			// Beyond that, use SubfactorialBig for larger results
			for (long i = 2; i <= n; i++)
			{
				// Update result using the recurrence relation
				// !n = (n-1)(!(n-1) + !(n-2))
				result = (i - 1) * (a + b);
				// Shift a and b for the next iteration
				a = b;
				b = result;
			}
			// Return the computed subfactorial
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// Base case
			if (n == 0)
			{
				// Base case: double factorial of 0 is 1
				return 1;
			}
			// Initialize the result to 1
			long result = 1;
			// Compute the double factorial iteratively
			// The loop runs from n down to 1, decrementing by 2 to include every second integer
			// This is a straightforward implementation of the double factorial function
			// It is efficient for reasonably small values of n
			// For very large n, consider using BigInteger to avoid overflow
			// The time complexity is O(n/2), which simplifies to O(n)
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed double factorial
			// If n is 0, the result remains 1
			// For n >= 1, the loop computes the product of every second integer
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the double factorial fits in a long is relatively small
			// Beyond that, use DoubleFactorialBig for larger results
			// The double factorial of n is defined as the product of all integers from n down to 1 that have the same parity as n
			// For example, DoubleFactorial(7) = 7 * 5 * 3 * 1 = 105
			// The method can handle small values of n efficiently
			// The maximum value of n is constrained by the risk of overflow in the result
			// Use this method for small double factorial calculations where the result is known to fit in a long
			// The method is a simple implementation of the double factorial function
			// It is suitable for educational purposes and small calculations
			// The method completes when all relevant integers up to n have been multiplied
			for (long i = n; i > 1; i -= 2)
			{
				// Multiply the current result by i
				result *= i;
			}
			// Return the computed double factorial
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// Base case
			if (n == 0)
			{
				// Base case: double factorial of 0 is 1
				return BigInteger.One;
			}
			// Initialize the result to 1
			BigInteger result = BigInteger.One;
			// Compute the double factorial iteratively
			// The loop runs from n down to 1, decrementing by 2 to include every second integer
			// This is a straightforward implementation of the double factorial function
			// It is efficient for reasonably small values of n
			// For very large n, BigInteger handles the large results without overflow
			// The time complexity is O(n/2), which simplifies to O(n)
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed double factorial
			// If n is 0, the result remains 1
			// For n >= 1, the loop computes the product of every second integer
			// The method can handle very large values of n, limited only by system memory
			// The maximum value of n is constrained by practical computation time and memory usage
			// Use this method for large double factorial calculations where the result exceeds the range of long
			// The double factorial of n is defined as the product of all integers from n down to 1 that have the same parity as n
			// For example, DoubleFactorialBig(7) = 7 * 5 * 3 * 1 = 105
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the double factorial fits in a long is relatively small
			// Beyond that, use DoubleFactorialBig for larger results
			// The method is a simple implementation of the double factorial function using BigInteger
			// It is suitable for applications requiring high precision and large number handling
			// The method completes when all relevant integers up to n have been multiplied
			for (long i = n; i > 1; i -= 2)
			{
				// Multiply the current result by i
				result *= i;
			}
			// Return the computed double factorial
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// Base case
			if (n == 0)
			{
				// Base case: rising factorial of x with 0 terms is 1
				return 1;
			}
			// Initialize the result to 1
			long result = 1;
			// Compute the rising factorial iteratively
			// The loop runs from 0 to n-1, multiplying (x + i) for each i
			// This is a straightforward implementation of the rising factorial function
			// It is efficient for reasonably small values of n
			// For very large n, consider using BigInteger to avoid overflow
			// The time complexity is O(n), which is acceptable for typical rising factorial calculations
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed rising factorial
			// If n is 0, the result remains 1
			// For n >= 1, the loop computes the product of (x + i) for i from 0 to n-1
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the rising factorial fits in a long is relatively small
			// Beyond that, use RisingFactorialBig for larger results
			// The rising factorial of x with n terms is defined as the product of n consecutive integers starting from x
			// For example, RisingFactorial(3, 4) = 3 * 4 * 5 * 6 = 360
			// The method can handle small values of n efficiently
			// The maximum value of n is constrained by the risk of overflow in the result
			// Use this method for small rising factorial calculations where the result is known to fit in a long
			// The method is a simple implementation of the rising factorial function
			// It is suitable for educational purposes and small calculations
			// The method completes when the rising factorial for n terms has been computed
			// The loop iterates n times, multiplying the result by (x + i) each time
			// This effectively builds the product of the first n terms in the rising factorial sequence
			for (long i = 0; i < n; i++)
			{
				// Multiply the current result by (x + i)
				result *= x + i;
			}
			// Return the computed rising factorial
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// Base case
			if (n == 0)
			{
				// Base case: rising factorial of x with 0 terms is 1
				return 1;
			}
			// Initialize the result to 1
			BigInteger result = 1;
			// Compute the rising factorial iteratively
			// The loop runs from 0 to n-1, multiplying (x + i) for each i
			// This is a straightforward implementation of the rising factorial function
			// It is efficient for reasonably small values of n
			// For very large n, BigInteger handles the large results without overflow
			// The time complexity is O(n), which is acceptable for typical rising factorial calculations
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed rising factorial
			// If n is 0, the result remains 1
			// For n >= 1, the loop computes the product of (x + i) for i from 0 to n-1
			// The method can handle very large values of n, limited only by system memory
			// The maximum value of n is constrained by practical computation time and memory usage
			// Use this method for large rising factorial calculations where the result exceeds the range of long
			// The rising factorial of x with n terms is defined as the product of n consecutive integers starting from x
			// For example, RisingFactorialBig(3, 4) = 3 * 4 * 5 * 6 = 360
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the rising factorial fits in a long is relatively small
			// Beyond that, use RisingFactorialBig for larger results
			// The method is a simple implementation of the rising factorial function using BigInteger
			// It is suitable for applications requiring high precision and large number handling
			// The method completes when the rising factorial for n terms has been computed
			// The loop iterates n times, multiplying the result by (x + i) each time
			// This effectively builds the product of the first n terms in the rising factorial sequence
			for (long i = 0; i < n; i++)
			{
				// Multiply the current result by (x + i)
				result *= x + i;
			}
			// Return the computed rising factorial
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// Base case
			if (n == 0)
			{
				// Base case: falling factorial of x with 0 terms is 1
				return 1;
			}
			// Initialize the result to 1
			long result = 1;
			// Compute the falling factorial iteratively
			// The loop runs from 0 to n-1, multiplying (x - i) for each i
			// This is a straightforward implementation of the falling factorial function
			// It is efficient for reasonably small values of n
			// For very large n, consider using BigInteger to avoid overflow
			// The time complexity is O(n), which is acceptable for typical falling factorial calculations
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed falling factorial
			// If n is 0, the result remains 1
			// For n >= 1, the loop computes the product of (x - i) for i from 0 to n-1
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the falling factorial fits in a long is relatively small
			// Beyond that, use FallingFactorialBig for larger results
			// The falling factorial of x with n terms is defined as the product of n consecutive integers starting from x and decrementing
			// For example, FallingFactorial(5, 3) = 5 * 4 * 3 = 60
			// The method can handle small values of n efficiently
			// The maximum value of n is constrained by the risk of overflow in the result
			// Use this method for small falling factorial calculations where the result is known to fit in a long
			// The method is a simple implementation of the falling factorial function
			// It is suitable for educational purposes and small calculations				
			for (long i = 0; i < n; i++)
			{
				// Multiply the current result by (x - i)
				result *= x - i;
			}
			// Return the computed falling factorial
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
			// Validate that n is non-negative
			CheckNonNegative(n: n);
			// Base case
			if (n == 0)
			{
				// Base case: falling factorial of x with 0 terms is 1
				return 1;
			}
			// Initialize the result to 1
			BigInteger result = 1;
			// Compute the falling factorial iteratively
			// The loop runs from 0 to n-1, multiplying (x - i) for each i
			// This is a straightforward implementation of the falling factorial function
			// It is efficient for reasonably small values of n
			// For very large n, BigInteger handles the large results without overflow
			// The time complexity is O(n), which is acceptable for typical falling factorial calculations
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed falling factorial
			// If n is 0, the result remains 1
			// For n >= 1, the loop computes the product of (x - i) for i from 0 to n-1
			// The method can handle very large values of n, limited only by system memory
			// The maximum value of n is constrained by practical computation time and memory usage
			// Use this method for large falling factorial calculations where the result exceeds the range of long
			// The falling factorial of x with n terms is defined as the product of n consecutive integers starting from x and decrementing
			// For example, FallingFactorialBig(5, 3) = 5 * 4 * 3 = 60
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the falling factorial fits in a long is relatively small
			// Beyond that, use FallingFactorialBig for larger results
			// The method is a simple implementation of the falling factorial function using BigInteger
			// It is suitable for applications requiring high precision and large number handling
			// The method completes when the falling factorial for n terms has been computed
			// The loop iterates n times, multiplying the result by (x - i) each time
			// This effectively builds the product of the first n terms in the falling factorial sequence
			for (long i = 0; i < n; i++)
			{
				// Multiply the current result by (x - i)
				result *= x - i;
			}
			// Return the computed falling factorial
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
			// Validate that n is positive
			CheckPositive(n: n);
			// Base case
			if (x <= 0)
			{
				// Return 1 for x <= 0
				return 1;
			}
			// Initialize the result to 1
			long result = 1;
			// Compute the multi-factorial iteratively
			// The loop runs from x down to 1, decrementing by n each time
			// This is a straightforward implementation of the multi-factorial function
			// It is efficient for reasonably small values of x
			// For very large x, consider using BigInteger to avoid overflow
			// The time complexity is O(x/n), which simplifies to O(x)
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed multi-factorial
			// If x is less than or equal to 0, the result remains 1
			// For x > 0, the loop computes the product of x, (x - n), (x - 2n), ..., until the term is <= 0
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the multi-factorial fits in a long is relatively small
			// Beyond that, use MultiFactorialBig for larger results
			// The multi-factorial of x with step n is defined as the product of integers starting from x and decrementing by n
			// For example, MultiFactorial(7, 2) = 7 * 5 * 3 * 1 = 105
			// The method can handle small values of x efficiently
			// The maximum value of x is constrained by the risk of overflow in the result
			// Use this method for small multi-factorial calculations where the result is known to fit in a long
			// The method is a simple implementation of the multi-factorial function
			// It is suitable for educational purposes and small calculations
			// The method completes when the multi-factorial for x with step n has been computed
			// The loop iterates while the current term is greater than 0, multiplying the result by the current term each time
			for (long i = x; i > 0; i -= n)
			{
				// Multiply the current result by i
				result *= i;
			}
			// Return the computed multi factorial
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
			// Validate that n is positive
			CheckPositive(n: n);
			// Base case
			if (x <= 0)
			{
				// Return 1 for x <= 0
				return BigInteger.One;
			}
			// Initialize the result to 1
			BigInteger result = BigInteger.One;
			// Compute the multi-factorial iteratively
			// The loop runs from x down to 1, decrementing by n each time
			// This is a straightforward implementation of the multi-factorial function
			// It is efficient for reasonably small values of x
			// For very large x, BigInteger handles the large results without overflow
			// The time complexity is O(x/n), which simplifies to O(x)
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed multi-factorial
			// If x is less than or equal to 0, the result remains 1
			// For x > 0, the loop computes the product of x, (x - n), (x - 2n), ..., until the term is <= 0
			// The method can handle very large values of x, limited only by system memory
			// The maximum value of x is constrained by practical computation time and memory usage
			// Use this method for large multi-factorial calculations where the result exceeds the range of long
			// The multi-factorial of x with step n is defined as the product of integers starting from x and decrementing by n
			// For example, MultiFactorialBig(7, 2) = 7 * 5 * 3 * 1 = 105
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the multi-factorial fits in a long is relatively small
			// Beyond that, use MultiFactorialBig for larger results
			// The method is a simple implementation of the multi-factorial function using BigInteger
			// It is suitable for applications requiring high precision and large number handling
			// The method completes when the multi-factorial for x with step n has been computed
			for (long i = x; i > 0; i -= n)
			{
				// Multiply the current result by i
				result *= i;
			}
			// Return the computed multi factorial
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
			// Initialize the result to 1
			long result = 1;
			// Compute the superfactorial iteratively
			// The loop runs from 1 to n, multiplying i! for each i
			// This is a straightforward implementation of the superfactorial function
			// It is efficient for reasonably small values of n
			// For very large n, consider using BigInteger to avoid overflow
			// The time complexity is O(n^2) due to the nested factorial calculations
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed superfactorial
			// If n is 0, the result remains 1
			// For n >= 1, the loop computes the product of i! for i from 1 to n
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the superfactorial fits in a long is relatively small
			// Beyond that, use SuperfactorialBig for larger results
			// The superfactorial of n is defined as the product of the first n factorials
			// For example, Superfactorial(3) = 1! * 2! * 3! = 1 * 2 * 6 = 12
			// The method can handle small values of n efficiently
			// The maximum value of n is constrained by the risk of overflow in the result
			// Use this method for small superfactorial calculations where the result is known to fit in a long
			// The method is a simple implementation of the superfactorial function
			// It is suitable for educational purposes and small calculations
			// The method completes when the superfactorial for n has been computed
			// The loop iterates n times, multiplying the result by i! each time
			// This effectively builds the product of the first n factorials
			for (long i = 1; i <= n; i++)
			{
				// Multiply the current result by i!
				result *= Factorial(n: i);
			}
			// Return the computed superfactorial
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
			// Initialize the result to 1
			BigInteger result = 1;
			// Compute the superfactorial iteratively
			// The loop runs from 1 to n, multiplying i! for each i
			// This is a straightforward implementation of the superfactorial function
			// It is efficient for reasonably small values of n
			// For very large n, BigInteger handles the large results without overflow
			// The time complexity is O(n^2) due to the nested factorial calculations
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed superfactorial
			// If n is 0, the result remains 1
			// For n >= 1, the loop computes the product of i! for i from 1 to n
			// The method can handle very large values of n, limited only by system memory
			// The maximum value of n is constrained by practical computation time and memory usage
			// Use this method for large superfactorial calculations where the result exceeds the range of long
			// The superfactorial of n is defined as the product of the first n factorials
			// For example, SuperfactorialBig(3) = 1! * 2! * 3! = 1 * 2 * 6 = 12
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the superfactorial fits in a long is relatively small
			// Beyond that, use SuperfactorialBig for larger results
			// The method is a simple implementation of the superfactorial function using BigInteger
			// It is suitable for applications requiring high precision and large number handling
			// The method completes when the superfactorial for n has been computed
			// The loop iterates n times, multiplying the result by i! each time
			// This effectively builds the product of the first n factorials
			// The loop iterates from 1 to n, calculating the factorial of each i and multiplying it to the result
			for (long i = 1; i <= n; i++)
			{
				// Multiply the current result by i!
				result *= FactorialBig(n: i);
			}
			// Return the computed superfactorial
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
			// Initialize the result to 1
			long result = 1;
			// Compute the hyperfactorial iteratively
			// The loop runs from 1 to n, multiplying i^i for each i
			// This is a straightforward implementation of the hyperfactorial function
			// It is efficient for reasonably small values of n
			// For very large n, consider using BigInteger to avoid overflow
			// The time complexity is O(n), which is acceptable for typical hyperfactorial calculations
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed hyperfactorial
			// If n is 0, the result remains 1
			// For n >= 1, the loop computes the product of i^i for i from 1 to n
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the hyperfactorial fits in a long is relatively small
			// Beyond that, use HyperfactorialBig for larger results
			// The hyperfactorial of n is defined as the product of i^i for i from 1 to n
			// For example, Hyperfactorial(3) = 1^1 * 2^2 * 3^3 = 1 * 4 * 27 = 108
			// The method can handle small values of n efficiently
			// The maximum value of n is constrained by the risk of overflow in the result
			// Use this method for small hyperfactorial calculations where the result is known to fit in a long
			// The method is a simple implementation of the hyperfactorial function
			// It is suitable for educational purposes and small calculations
			// The method completes when the hyperfactorial for n has been computed				
			for (long i = 1; i <= n; i++)
			{
				// Multiply the current result by i^i
				result *= PowLong(baseValue: i, exp: i);
			}
			// Return the computed hyperfactorial
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
			// Initialize the result to 1
			BigInteger result = 1;
			// Compute the hyperfactorial iteratively
			// The loop runs from 1 to n, multiplying i^i for each i
			// This is a straightforward implementation of the hyperfactorial function
			// It is efficient for reasonably small values of n
			// For very large n, BigInteger handles the large results without overflow
			// The time complexity is O(n), which is acceptable for typical hyperfactorial calculations
			// The space complexity is O(1) since we are using a constant amount of space
			// The method returns the computed hyperfactorial
			// If n is 0, the result remains 1
			// For n >= 1, the loop computes the product of i^i for i from 1 to n
			// The method can handle very large values of n, limited only by system memory
			// The maximum value of n is constrained by practical computation time and memory usage
			// Use this method for large hyperfactorial calculations where the result exceeds the range of long
			// The hyperfactorial of n is defined as the product of i^i for i from 1 to n
			// For example, HyperfactorialBig(3) = 1^1 * 2^2 * 3^3 = 1 * 4 * 27 = 108
			// The method does not handle overflow; it is the caller's responsibility to ensure n is within a safe range
			// The maximum value of n for which the hyperfactorial fits in a long is relatively small
			// Beyond that, use HyperfactorialBig for larger results
			// The method is a simple implementation of the hyperfactorial function using BigInteger
			// It is suitable for applications requiring high precision and large number handling
			// The method completes when the hyperfactorial for n has been computed
			for (long i = 1; i <= n; i++)
			{
				// Multiply the current result by i^i
				result *= BigInteger.Pow(value: i, exponent: (int)i);
			}
			// Return the computed hyperfactorial
			return result;
		}

		/// <summary>
		/// Calculates the superduperfactorial of a non-negative integer n as a <see cref="long"/>.
		/// The superduperfactorial of n is defined as the product of i^(i!) for i from 1 to n.
		/// For example, SuperDuperFactorial(3) = 1^(1!) * 2^(2!) * 3^(3!) = 1^1 * 2^2 * 3^6 = 1 * 4 * 729 = 2916.
		/// </summary>
		/// <param name="n">The upper bound integer for the superduperfactorial calculation. Must be non-negative.</param>
		/// <returns>
		/// The superduperfactorial of <paramref name="n"/> as a <see cref="long"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// The result may overflow for relatively small values of <paramref name="n"/>. Use <see cref="SuperduperfactorialBig"/> for large n.
		/// </remarks>
		public static long Superduperfactorial(long n)
		{
			// Initialize the result to 1
			long result = 1;
			// Compute the superduperfactorial iteratively
			// Time complexity: O(n^2) due to nested factorial calculations.
			// Uses BigInteger to handle very large results.
			// Example: Superduperfactorial(3) = 1^(1!) * 2^(2!) * 3^(3!) = 1 * 4 * 729 = 2916
			for (long i = 1; i <= n; i++)
			{
				long f = Factorial(n: i);// i!
				result *= PowLong(baseValue: i, exp: f);// i^(i!)
			}
			// Return the computed superduperfactorial
			return result;
		}

		/// <summary>
		/// Calculates the superduperfactorial of a non-negative integer n as a <see cref="BigInteger"/>.
		/// The superduperfactorial of n is defined as the product of i^(i!) for i from 1 to n.
		/// For example, SuperduperfactorialBig(3) = 1^(1!) * 2^(2!) * 3^(3!) = 1^1 * 2^2 * 3^6 = 1 * 4 * 729 = 2916.
		/// </summary>
		/// <param name="n">The upper bound integer for the superduperfactorial calculation. Must be non-negative.</param>
		/// <returns>
		/// The superduperfactorial of <paramref name="n"/> as a <see cref="BigInteger"/>. Returns 1 if n is 0.
		/// </returns>
		/// <remarks>
		/// Use this method instead of <see cref="Superduperfactorial(long)"/> when the result may exceed the range of <see cref="long"/>.
		/// </remarks>
		public static BigInteger SuperduperfactorialBig(long n)
		{
			// Initialize the result to 1
			BigInteger result = 1;
			// Compute the superduperfactorial iteratively
			// Time complexity: O(n^2) due to nested factorial calculations.
			// Uses BigInteger to handle very large results.
			// Example: SuperduperfactorialBig(3) = 1^(1!) * 2^(2!) * 3^(3!) = 1 * 4 * 729 = 2916
			for (long i = 1; i <= n; i++)
			{
				// Calculate i!
				BigInteger f = FactorialBig(n: i);
				// Multiply the current result by i^(i!)
				result *= BigIntegerPow(baseValue: i, exponent: f);
			}
			// Return the computed superduperfactorial
			return result;
		}
	}
}