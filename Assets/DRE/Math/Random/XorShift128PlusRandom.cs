namespace DRE.Mathematics
{
    /** This is the fastest generator passing BigCrush without systematic failures, but due to the relatively short period
	 * it is acceptable only for applications with a mild amount of parallelism. Otherwise, use a xorshift1024* generator.
	 * 
     * The state must be seeded so that it is not everywhere zero.
     * If you have a 64-bit seed, we suggest to seed a splitmix64 generator and use its output to fill the seed.
	 * 
     * Based on Java code published by Sebastiano Vigna at http://xorshift.di.unimi.it
     * 
	 * An unbelievably fast, top-quality pseudorandom number generator that
	 * returns the sum of consecutive outputs of a Marsaglia Xorshift generator 
	 * (described in <a href="http://www.jstatsoft.org/v08/i14/paper/">&ldquo;Xorshift RNGs&rdquo;</a>,
	 * <i>Journal of Statistical Software</i>, 8:1&minus;6, 2003) with 128 bits of state. 
	 * 
	 * <p>More details can be found in paper &ldquo;<a href="http://vigna.di.unimi.it/papers.php#VigFSMXG">
	 * Further scramblings of Marsaglia's <code>xorshift</code> generators&rdquo;</a>, 2015,
	 * and on the <a href="http://xorshift.di.unimi.it/"><code>xorshift*</code>/<code>xorshift+</code> 
	 * generators and the PRNG shootout</a> page.
	 * The basic idea is taken from Mutsuo Saito and Makuto Matsumoto's 
	 * <a href="http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/XSADD/"><code>XSadd</code></a> generator,
	 * which is however based on 32-bit shifts and fails several statistical tests when reversed.
	 * 
	 * <p>Note that this is NOT a cryptographic-strength pseudorandom number generator, but its quality is
	 * preposterously higher than {@link Random}'s, and its cycle length is
	 * 2<sup>128</sup>&nbsp;&minus;&nbsp;1, which is more than enough for any single-thread application.
	 * 
	 * @see http://xoshiro.di.unimi.it/xorshift.php    
	 * @see http://xorshift.di.unimi.it
	 * @see it.unimi.dsi.util
	 */
    public class XorShift128PlusRandom : IRandom
	{
		#region Instance Fields

        // TODO: Verify these numbers

		// The +1 ensures NextDouble doesn't generate 1.0. +129 (0x81) is the equivalent value for NextFloat.
		private const double DOUBLE_UNIT_LONG = 1.0 / (long.MaxValue + 1.0);   //  int.max = 2147483647   = 0,000000000465661287307739
		private const double DOUBLE_UNIT_ULONG = 1.0 / (ulong.MaxValue + 1.0); // uint.max = 2147483648   = 0,00000000023283064365387
		private const double DOUBLE_UNIT_ULONG_INCLUSIVE = 1.0 / ulong.MaxValue;
		// Floating-point numbers sacrifice precision and accuracy for range.
		private const float FLOAT_UNIT_ULONG = 1f / (ulong.MaxValue + 129f);
		private const float FLOAT_UNIT_ULONG_INCLUSIVE = 1f / (ulong.MaxValue + 128f);

		/** The internal state of the algorithm. */
		private ulong s0, s1; // unsigned 64bit values

		#endregion


		#region Constructors

		/// Initialises new instance.
		/// System tick count will be used as a seed.
		public XorShift128PlusRandom()
		{
			SetSeed((ulong)System.Environment.TickCount);
		}


		/// Initialises new instance using given seed.
		public XorShift128PlusRandom(ulong seed)
		{
			SetSeed(seed);
		}

		#endregion


		#region Initialisation

		/**
		 * Sets the seed of this generator.
		 * 
		 * See SetSeed(ulong seed) for details.
		 * 
		 * @param seed a nonzero seed for this generator. If zero is passed, an internal non-zero constant will be used.
		 */
		public void SetSeed(uint seed)
		{
			SetSeed((ulong)seed);
		}


		/**
		 * Sets the seed of this generator.
		 * 
		 * The argument will be used to seed a SplitMix64Random,
		 * whose output will in turn be used to seed this generator.
		 * This approach makes warmup unnecessary and makes the possibility of starting from a state 
		 * with a large fraction of bits set to zero astronomically small.
		 * 
		 * @param seed a nonzero seed for this generator. If zero is passed, an internal non-zero constant will be used.
		 */
		public void SetSeed(ulong seed)
		{
			if (seed == 0) {
				// The magic constant is combination of four large primes each with bits distributed over the full length of a 32bit value
				seed = 3575866506U;
			}

			SplitMix64Random r = new SplitMix64Random(seed);
			s0 = r.nextULong();
			s1 = r.nextULong();
		}


		/**
		 * Sets the state of this generator.
		 * 
		 * The internal state of the generator will be reset, and the state array filled with the provided values.
		 * 
		 * @param state of 2 ulongs. At least one must be nonzero (but there is no check for that).
		 */
		public void SetState(ulong s0, ulong s1)
		{
			this.s0 = s0;
			this.s1 = s1;
		}

		#endregion


		#region Random numbers

		/**
		 * This is the core of the algorithm.
		 * 
		 * Returns a pseudorandom uniformly distributed unsigned long 64bit value
		 * between 0 (inclusive) and ulong.MaxValue (inclusive),
		 * drawn from this random number generator's sequence.
		 * The algorithm used to generate the value guarantees that the result is uniform,
		 * provided that the sequence of 64-bit values produced by this generator is.
		 */
		public ulong NextULongInclusive()
		{
			// The current constants are theoretically better than the previous set of numbers 23, 17, 26 (which were correct as well).
			// http://stackoverflow.com/questions/34426499/what-is-the-real-definition-of-the-xorshift128-algorithm
			ulong a = s0;
			ulong b = s1;
			s0 = b;
			a ^= a << 23;
			s1 = a ^ b ^ (a >> 18) ^ (b >> 5);
			return s1 + b;
		}


		// ULONG

		/// Returns a pseudo random value in range from zero (inclusive) to ulong.MaxValue (exclusive).
		public ulong NextULong()
		{
			return NextULongInclusive() % ulong.MaxValue;
		}


		/// Returns a pseudo random value in range from zero (inclusive) to upperBound (exclusive).
		public ulong NextULong(ulong upperBound)
		{
			if (upperBound == 0) {
				return 0;
			}
			return NextULongInclusive() % upperBound;
		}


        /// Returns a pseudo random value in range from lowerBound (inclusive) to upperBound (exclusive).
        public ulong NextULong(ulong lowerBound, ulong upperBound)
        {
            ulong range = (ulong)(upperBound - lowerBound);
            if (range == 0) {
                return lowerBound;
            }
            return lowerBound + NextULongInclusive() % range;
        }


        /// Returns a pseudo random value in range from lowerBound (inclusive) to upperBound (exclusive).
        /// It verifies that lowerBound < upperBound
        public ulong NextULongSafe(ulong lowerBound, ulong upperBound)
		{
            // Swap lower and upper bound if necessary
            if (lowerBound > upperBound) {
                return NextULong(upperBound, lowerBound);
            } else {
                return NextULong(lowerBound, upperBound);
            }
        }


		// LONG

		/// Returns a pseudo random value in range from zero (inclusive) to long.MaxValue (exclusive).
		public long NextLong()
		{
			return (long)(NextULongInclusive() % long.MaxValue);
		}


		/// Returns a pseudo random value in range from zero (inclusive) to upperBound (exclusive).
		/// If upperBound is negative, it returns a negative value.
		public long NextLong(long upperBound)
		{
			return NextLong(0, upperBound);
		}

        /// Returns a pseudo random value in range from lowerBound (inclusive) to upperBound (exclusive).
        public long NextLong(long lowerBound, long upperBound)
        {
            ulong range = (ulong)(upperBound - lowerBound);
            if (range == 0) {
                return lowerBound;
            }
            return lowerBound + (long)(NextULongInclusive() % range);
        }

        /// Returns a pseudo random value in range from lowerBound (inclusive) to upperBound (exclusive).
        /// It verifies that lowerBound < upperBound
        public long NextLongSafe(long lowerBound, long upperBound)
		{
            // Swap lower and upper bound if necessary
            if (lowerBound > upperBound) {
                return NextLong(upperBound, lowerBound);
            } else {
                return NextLong(lowerBound, upperBound);
            }
		}


		// UINT

		/// Returns a pseudo random value in range from zero (inclusive) to uint.MaxValue (exclusive).
		public uint NextUInt()
		{
			return unchecked((uint)NextULong(uint.MaxValue));
		}


		/// Returns a pseudo random value in range from zero (inclusive) to upperBound (exclusive).
		public uint NextUInt(uint upperBound)
		{
			return unchecked((uint)NextULong(upperBound));
		}

		/// Returns a pseudo random value in range from lowerBound (inclusive) to upperBound (exclusive).
		public uint NextUInt(uint lowerBound, uint upperBound)
		{
			return unchecked((uint)NextULong(lowerBound, upperBound));
		}

        /// Returns a pseudo random value in range from lowerBound (inclusive) to upperBound (exclusive).
        /// It verifies that lowerBound < upperBound
        public uint NextUIntSafe(uint lowerBound, uint upperBound)
        {
            // Swap lower and upper bound if necessary
            if (lowerBound > upperBound) {
                return unchecked((uint)NextULong(upperBound, lowerBound));
            } else {
                return unchecked((uint)NextULong(lowerBound, upperBound));
            }
        }

        // INT

        /// Returns a pseudo random value in range from zero (inclusive) to int.MaxValue (exclusive).
        public int NextInt()
		{
			return (int)NextLong(0, int.MaxValue);
		}


		/// Returns a pseudo random value in range from zero (inclusive) to upperBound (exclusive).
		/// If upperBound is negative, it returns a negative value.
		public int NextInt(int upperBound)
		{
			return (int)NextLong(0, upperBound);
		}


		/// Returns a pseudo random value in range from lowerBound (inclusive) to upperBound (exclusive).
		public int NextInt(int lowerBound, int upperBound)
		{
			return (int)NextLong(lowerBound, upperBound);
		}

        /// Returns a pseudo random value in range from lowerBound (inclusive) to upperBound (exclusive).
        /// It verifies that lowerBound < upperBound
        public int NextIntSafe(int lowerBound, int upperBound)
        {
            // Swap lower and upper bound if necessary
            if (lowerBound > upperBound) {
                return (int)NextLong(upperBound, lowerBound);
            } else {
                return (int)NextLong(lowerBound, upperBound);
            }
        }

        // FLOAT

        /// Returns a pseudo random value in range from 0.0 (inclusive) to 1.0 (exclusive).
        public float NextFloat()
		{
			// N.B. Here we're using the full 32 bits of randomness, whereas System.Random uses 31 bits.
			return NextULongInclusive() * FLOAT_UNIT_ULONG;
		}


		/// Returns a pseudo random value in range from 0.0 (inclusive) to 1.0 (inclusive).
		public float NextFloatInclusive()
		{
			// N.B. Here we're using the full 32 bits of randomness, whereas System.Random uses 31 bits.
			return NextULongInclusive() * FLOAT_UNIT_ULONG_INCLUSIVE;
		}


		// DOUBLE

		/// Returns a pseudo random value in range from 0.0 (inclusive) to 1.0 (exclusive).
		public double NextDouble()
		{
			// N.B. Here we're using the full 64 bits of randomness.
			return NextULongInclusive() * DOUBLE_UNIT_ULONG;
		}


		/// Returns a pseudo random value in range from 0.0 (inclusive) to 1.0 (inclusive).
		public double NextDoubleInclusive()
		{
			// N.B. Here we're using the full 64 bits of randomness.
			return NextULongInclusive() * DOUBLE_UNIT_ULONG_INCLUSIVE;
		}


		// BOOL

		/// Returns true or false.
		public bool NextBool()
		{
			return (NextULongInclusive() & 0x1) == 0x1;
		}


		// BYTE

		/// Fills given array of (unsigned) bytes with (random) values from zero to byte.MaxValue (both incluseve).
		/// Throws exception if the parameter is null/
		public void NextBytes(byte[] bytes)
		{
			UnityEngine.Debug.Assert(bytes != null, "bytes[] cannot be null");
			if (bytes == null) {
				return;
			}

			int i = bytes.Length, n = 0;
			while (i != 0) {
				n = FastMath.Min(i, 8);
				for ( ulong bits = NextULongInclusive(); n-- != 0; bits >>= 8 ) {
					bytes[--i] = (byte)bits;
				}
			}
		}

		#endregion
	}
}