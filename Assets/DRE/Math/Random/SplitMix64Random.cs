namespace DRE.Mathematics
{
	/** A non-splittable version of the <span style="font-variant: small-caps">SplitMix</span> pseudorandom number generator used by Java 8's 
	 * <a href="http://docs.oracle.com/javase/8/docs/api/java/util/SplittableRandom.html"><code>SplittableRandom</code></a>. Due to 
	 * the fixed increment constant and to different strategies in generating finite ranges, the methods of this generator
	 * are faster than those of <code>SplittableRandom</code>. Indeed, this is the fastest generator of the collection that
	 * passes the BigCrush battery of tests.
	 * 
	 * Modified version of Java code published by Sebastiano Vigna at <it.unimi.dsi.util>
	 * The modification insist of using unsigned numbers instead of signed ones.
	 *
	 * @see it.unimi.dsi.util
	 */
	public class SplitMix64Random
	{

		#region Instance Fields

		/** 2<sup>64</sup> &middot; &phi;, &phi; = (&#x221A;5 &minus; 1)/2. */
		private const ulong PHI = 0x9E3779B97F4A7C15L;

		/** The internal state of the algorithm (a Weyl generator using the {@link #PHI} as increment). */
		private ulong x;

		#endregion


		#region Constructors

		/** Initialises a new instance.
		 * 
		 * <p>The seed will be taken from system tick count and passed through {@link HashCommon#MurmurHash3(ulong)}.
		 * 
		 * @param seed a seed for this generator.
		 */
		public SplitMix64Random()
		{
			SetSeed((ulong)System.Environment.TickCount);
		}


		/** Initialises a new instance using a seed.
		 * 
		 * <p>The seed will be passed through {@link HashCommon#MurmurHash3(ulong)}.
		 * 
		 * @param seed a seed for this generator.
		 */
		public SplitMix64Random(ulong seed)
		{
			SetSeed(seed);
		}

		#endregion


		#region Public Methods [Reinitialisation]

		/** Sets the seed of this generator.
		 * 
		 * <p>The seed will be passed through {@link HashCommon#MurmurHash3(ulong)}.
		 * 
		 * @param seed a seed for this generator.
		 */
		public void SetSeed(ulong seed)
		{
			x = Hash.MurmurHash3(seed);
		}


		/** Sets the state of this generator.
		 * 
		 * @param state the new state for this generator (must be nonzero).
		 */
		public void setState(ulong state)
		{
			x = state;
		}

		#endregion


		#region Private Methods

		/* David Stafford's (http://zimbry.blogspot.com/2011/09/better-bit-mixing-improving-on.html)
    	 * "Mix13" variant of the 64-bit finalizer in Austin Appleby's MurmurHash3 algorithm.
		 */
		private ulong StaffordMix13(ulong z)
		{
			z = ( z ^ ( z >> 30 ) ) * 0xBF58476D1CE4E5B9L; 
			z = ( z ^ ( z >> 27 ) ) * 0x94D049BB133111EBL;
			return z ^ ( z >> 31 );
		}


		/* David Stafford's (http://zimbry.blogspot.com/2011/09/better-bit-mixing-improving-on.html)
	     * "Mix4" variant of the 64-bit finalizer in Austin Appleby's MurmurHash3 algorithm.
		 */
		private uint StaffordMix4Upper32(ulong z)
		{
			z = ( z ^ ( z >> 33 ) ) * 0x62A9D9ED799705F5L;
			return (uint)( ( ( z ^ ( z >> 28 ) ) * 0xCB24D0A5C88C35B3L ) >> 32 );
		}

		#endregion


		#region Public Methods

		/** Returns a pseudorandom, approximately uniformly distributed {@code uint} value
	     * between 0 (inclusive) and uint.MaxValue value (exclusive), drawn from
	     * this random number generator's sequence.
	     * 
	     * @return the next pseudorandom {@code uint} value between {@code 0} (inclusive) and {@code uint.MaxValue} (exclusive).
	     */
		public uint nextUInt()
		{
			return StaffordMix4Upper32( x += PHI );
		}


		/** Returns a pseudorandom, approximately uniformly distributed {@code uint} value
	     * between 0 (inclusive) and the specified value (exclusive), drawn from
	     * this random number generator's sequence.
	     * 
	     * <p>The hedge &ldquo;approximately&rdquo; is due to the fact that to be always
	     * faster than <a href="http://docs.oracle.com/javase/7/docs/api/java/util/concurrent/ThreadLocalRandom.html"><code>ThreadLocalRandom</code></a>
	     * we return
	     * the upper 63 bits of {@link #nextLong()} modulo {@code n} instead of using
	     * {@link Random}'s fancy algorithm (which {@link #nextLong(long)} uses though).
	     * This choice introduces a bias: the numbers from 0 to 2<sup>63</sup> mod {@code n}
	     * are slightly more likely than the other ones. In the worst case, &ldquo;more likely&rdquo;
	     * means 1.00000000023 times more likely, which is in practice undetectable. If for some reason you
	     * need truly uniform generation, just use {@link #nextULong(ulong)}.
	     * 
	     * @param n the positive bound on the random number to be returned.
	     * @return the next pseudorandom {@code uint} value between {@code 0} (inclusive) and {@code upperBound} (exclusive).
	     */
		public uint nextUInt(uint upperBound)
		{
			if (upperBound == 0) {
				return 0;
			}
			return (uint)( (StaffordMix13(x += PHI) >> 1) % upperBound );
		}


		/** Returns a pseudorandom, approximately uniformly distributed {@code ulong} value
	     * between 0 (inclusive) and ulong.MaxValue value (exclusive), drawn from
	     * this random number generator's sequence.
	     * 
	     * @return the next pseudorandom {@code ulong} value between {@code 0} (inclusive) and {@code ulong.MaxValue} (exclusive).
	     */
		public ulong nextULong()
		{
			return StaffordMix13( x += PHI );
		}


		/** Returns a pseudorandom uniformly distributed {@code ulong} value
	     * between 0 (inclusive) and the specified value (exclusive), drawn from
	     * this random number generator's sequence. The algorithm used to generate
	     * the value guarantees that the result is uniform, provided that the
	     * sequence of 64-bit values produced by this generator is. 
	     * 
	     * @param n the positive bound on the random number to be returned.
	     * @return the next pseudorandom {@code ulong} value between {@code 0} (inclusive) and {@code upperBound} (exclusive).
	     */
		public ulong nextULong(ulong upperBound)
		{
			if (upperBound == 0) {
				return 0;
			}
			return (ulong)( (StaffordMix13(x += PHI) >> 1) % upperBound );
		}	

		#endregion
	}
}