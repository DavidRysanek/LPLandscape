using System;

namespace DRE.Noise
{
	/** Returns noise value at given point
	 * 
	 * <p> http://libnoise.sourceforge.net/glossary/
	 * 
	 * @param x,y,x,w Point for which we want to calculate the noise value
	 * @param octaves One of the coherent-noise functions in a series of coherent-noise functions that are added together to form Perlin/Simplex noise. The number of octaves control the amount of detail of the noise.
	 * @param amplitude The maximum absolute value that a specific coherent-noise function can output.
	 * @param persistence A multiplier that determines how quickly the amplitudes diminish for each successive octave. Increasing the persistence produces "rougher" noise.
	 * @param frequency The number of cycles per unit length that a specific coherent-noise function outputs.
	 * @param lacunarity A multiplier that determines how quickly the frequency increases for each successive octave.
	 * 
	 * @return Noise value in range <-1,1>
	 */
	public class LinearSimplexNoiseGenerator : INoise
	{
		private INoise noise;

		public uint octaves = 3;
		public double amplitude = 1;
		public double persistence = 0.5; // Value of 0.5 will half the amplitude in each successive octave
		public double frequency = 1;
		public double lacunarity = 2; // Value of 2 will double the frequency in each successive octave


		#region Constructors

		public LinearSimplexNoiseGenerator(INoise noise)
		{
			this.noise = noise;
		}


		public LinearSimplexNoiseGenerator(INoise noise, uint octaves)
		{
			this.noise = noise;
			this.octaves = octaves;
		}


		public LinearSimplexNoiseGenerator(INoise noise, uint octaves, double amplitude, double persistence, double frequency, double lacunarity)
		{
			this.noise = noise;
			this.octaves = octaves;
			this.amplitude = amplitude;
			this.persistence = persistence;
			this.frequency = frequency;
			this.lacunarity = lacunarity;
		}

		#endregion


		#region 2D noise

		public double GetValue(double x)
		{
			double a = amplitude;
			double f = frequency;
			double valueSum = 0;
			double amplitudeSum = 0;

			for (uint o = 0; o < octaves; o++)
			{
				x *= f;

				valueSum += noise.GetValue(x) * a;
				amplitudeSum += a;

				// Linear change
				a *= persistence;
				f *= lacunarity;
			}

			// Normalise value to range <-1,1>
			return valueSum / amplitudeSum;
		}

		#endregion


		#region 2D noise

		public double GetValue(double x, double y)
		{
			double a = amplitude;
			double f = frequency;
			double valueSum = 0;
			double amplitudeSum = 0;

			for (uint o = 0; o < octaves; o++)
			{
				x *= f;
				y *= f;

				valueSum += noise.GetValue(x, y) * a;
				amplitudeSum += a;

				// Linear change
				a *= persistence;
				f *= lacunarity;
			}

			// Normalise value to range <-1,1>
			return valueSum / amplitudeSum;
		}

		#endregion


		#region 3D noise

		public double GetValue(double x, double y, double z)
		{
			double a = amplitude;
			double f = frequency;
			double valueSum = 0;
			double amplitudeSum = 0;

			for (uint o = 0; o < octaves; o++)
			{
				x *= f;
				y *= f;
				z *= f;

				valueSum += noise.GetValue(x, y, z) * a;
				amplitudeSum += a;

				// Linear change
				a *= persistence;
				f *= lacunarity;
			}

			// Normalise value to range <-1,1>
			return valueSum / amplitudeSum;
		}

		#endregion


		#region 4D noise

		public double GetValue(double x, double y, double z, double w)
		{
			double a = amplitude;
			double f = frequency;
			double valueSum = 0;
			double amplitudeSum = 0;

			for (uint o = 0; o < octaves; o++)
			{
				x *= f;
				y *= f;
				z *= f;
				w *= f;

				valueSum += noise.GetValue(x, y, z, w) * a;
				amplitudeSum += a;

				// Linear change
				a *= persistence;
				f *= lacunarity;
			}

			// Normalise value to range <-1,1>
			return valueSum / amplitudeSum;
			// For range <0,1> use:
			// return (1 + valueSum / amplitudeSum) * 0.5;
		}

		#endregion
	}
}