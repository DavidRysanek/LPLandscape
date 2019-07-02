
/*
 * Noise class types:
 * 
 * NOISE
 * SimplexNoise: A real 'simple' noise provider. The core class.
 * 
 * GENERATORS
 * _NoiseGenerator: Noise generating algorithms. Combines multiple noise values with different amplitude or frequency for example.
 * 
 * COMBINERS
 * NoiseAdd: Adds values from two noise sources
 * 
 * PATTERNS
 * CheckerBoardNoise: 
 * 
 * */

 namespace DRE.Noise
{
	public interface INoise
	{
		/// Returns value at 1D point
		double GetValue(double x);
		/// Returns value at 2D point
		double GetValue(double x, double y);
		/// Returns value at 3D point
		double GetValue(double x, double y, double z);
		/// Returns value at 4D point
		double GetValue(double x, double y, double z, double w);
	}
}