namespace DRE.Mathematics
{
	public class Hash
	{
		/**
		 * Avalanches the bits of an integer by applying the finalisation step of MurmurHash3.
		 * 
		 * <p>This method implements the finalisation step of Austin Appleby's <a href="http://code.google.com/p/smhasher/">MurmurHash3</a>.
		 * Its purpose is to avalanche the bits of the argument to within 0.25% bias.
		 * 
		 * @param x an unsigned integer.
		 * @return a hash value with good avalanching properties.
		 */	
		public static uint MurmurHash3(uint x)
		{
			x ^= x >> 16;
			x *= 0x85ebca6b;
			x ^= x >> 13;
			x *= 0xc2b2ae35;
			x ^= x >> 16;
			return x;
		}


		/**
		 * Avalanches the bits of a unsigned long integer by applying the finalisation step of MurmurHash3.
		 * 
		 * <p>This method implements the finalisation step of Austin Appleby's <a href="http://code.google.com/p/smhasher/">MurmurHash3</a>.
		 * Its purpose is to avalanche the bits of the argument to within 0.25% bias.
		 * 
		 * @param x a unsigned long integer.
		 * @return a hash value with good avalanching properties.
		 */	
		public static ulong MurmurHash3(ulong x)
		{
			x ^= x >> 33;
			x *= 0xff51afd7ed558ccdL;
			x ^= x >> 33;
			x *= 0xc4ceb9fe1a85ec53L;
			x ^= x >> 33;
			return x;
		}
	}
}