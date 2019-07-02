using System;

namespace DRE.Noise
{
	/** Returns noise value at given point
	 * 
	 * <p> http://libnoise.sourceforge.net/glossary/
	 * Amplitude change is steeper than in linear SimplexNoiseGenerator. 
	 * 
	 * @param x,y,x,w Point for which we want to calculate the noise value
	 * @param octaves One of the coherent-noise functions in a series of coherent-noise functions that are added together to form Perlin/Simplex noise. The number of octaves control the amount of detail of the noise.
	 * @param persistence A value that determines how quickly the amplitudes diminish for each successive octave.
	 * @param lacunarity A value that determines how quickly the frequency increases for each successive octave.
	 * 
	 * @return Noise value in range <-1,1>
	 */
	public class ExponentialSimplexNoiseGenerator : INoise
	{
		private INoise noise;

		public uint octaves = 3;
		public double persistence = 0.5; // Value of 0.5 will half the amplitude in each successive octave
		public double lacunarity = 2; // Value of 2 will double the frequency in each successive octave


		#region Constructors

		public ExponentialSimplexNoiseGenerator(INoise noise)
		{
			this.noise = noise;
		}


		public ExponentialSimplexNoiseGenerator(INoise noise, uint octaves)
		{
			this.noise = noise;
			this.octaves = octaves;
		}


		public ExponentialSimplexNoiseGenerator(INoise noise, uint octaves, double persistence, double lacunarity)
		{
			this.noise = noise;
			this.octaves = octaves;
			this.persistence = persistence;
			this.lacunarity = lacunarity;
		}

		#endregion


		#region 1D noise

		public double GetValue(double x)
		{
			double valueSum = 0;
			double amplitudeSum = 0;
			double a = 0;
			double f = 0;

			for (int o = 0; o < octaves; o++)
			{
				a = Math.Pow(persistence, o);
				f = Math.Pow(lacunarity, o);

				x *= f;

				valueSum += noise.GetValue(x) * a;
				amplitudeSum += a;
			}

			return valueSum / amplitudeSum;
		}

		#endregion


		#region 2D noise

		public double GetValue(double x, double y)
		{
			double valueSum = 0;
			double amplitudeSum = 0;
			double a = 0;
			double f = 0;

			for (int o = 0; o < octaves; o++)
			{
				// We can use various functions to get amplitude and frequency
				// lacunarity = 2        f = pow(lacunarity, o) = 1, 2, 4, 8, 16, 32
				// persistence = 1/2;    a = pow(persistence, o) = 1,  1/2,  1/4,  1/8,  1/16,  1/32
				// persistence = 1/4;    a = pow(persistence, o) = 1,  1/4,  1/16,  1/64,  1/256,  1/1024
				// persistence = 1/root2                       a = 1,  1/1.414,  1/2,  1/2.828, 1/4,  1/5.656
				a = Math.Pow(persistence, o);
				f = Math.Pow(lacunarity, o);

				x *= f;
				y *= f;

				valueSum += noise.GetValue(x, y) * a;
				amplitudeSum += a;
			}

			return valueSum / amplitudeSum;
		}

		#endregion


		#region 3D noise

		public double GetValue(double x, double y, double z)
		{
			double valueSum = 0;
			double amplitudeSum = 0;
			double a = 0;
			double f = 0;

			for (int o = 0; o < octaves; o++)
			{
				a = Math.Pow(persistence, o);
				f = Math.Pow(lacunarity, o);

				x *= f;
				y *= f;
				z *= f;

				valueSum += noise.GetValue(x, y, z) * a;
				amplitudeSum += a;
			}

			return valueSum / amplitudeSum;
		}

		#endregion


		#region 4D noise

		public double GetValue(double x, double y, double z, double w)
		{
			double valueSum = 0;
			double amplitudeSum = 0;
			double a = 0;
			double f = 0;

			for (int o = 0; o < octaves; o++)
			{
				a = Math.Pow(persistence, o);
				f = Math.Pow(lacunarity, o);

				x *= f;
				y *= f;
				z *= f;
				w *= f;

				valueSum += noise.GetValue(x, y, z, w) * a;
				amplitudeSum += a;
			}

			return valueSum / amplitudeSum;
		}

		#endregion
	}
}