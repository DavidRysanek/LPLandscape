namespace DRE.Mathematics
{
	public interface IRandom32
	{
		void SetSeed(uint seed);

		bool NextBool();

		void NextBytes(byte[] bytes);

		uint NextUInt();
		uint NextUInt(uint upperBound);
		uint NextUInt(uint lowerBound, uint upperBound);
        uint NextUIntSafe(uint lowerBound, uint upperBound);

        int NextInt();
		int NextInt(int upperBound);
		int NextInt(int lowerBound, int upperBound);
        int NextIntSafe(int lowerBound, int upperBound);

        float NextFloat();
		float NextFloatInclusive();
	}


	public interface IRandom : IRandom32
	{
		void SetSeed(ulong seed);

		ulong NextULongInclusive();
		ulong NextULong();
		ulong NextULong(ulong upperBound);
		ulong NextULong(ulong lowerBound, ulong upperBound);
        ulong NextULongSafe(ulong lowerBound, ulong upperBound);


        long NextLong();
		long NextLong(long upperBound);
		long NextLong(long lowerBound, long upperBound);
        long NextLongSafe(long lowerBound, long upperBound);

        double NextDouble();
		double NextDoubleInclusive();
	}
}