using DRE.Mathematics;

namespace DRE.Noise
{
	public class NoiseAdd : INoise
	{
		INoise source1;
		INoise source2;
		double source1Ratio = 0.5;

		/// Sums values from two noise sources in ratio: (source1 * source1Ratio + source2 * (1 - source1Ratio))
		/// Ratio value must be in range <0,1>
		public NoiseAdd(INoise source1, INoise source2, double source1Ratio = 0.5)
		{
			this.source1 = source1;
			this.source2 = source2;

			this.source1Ratio = FastMath.Clamp(source1Ratio, 0, 1);
		}


		public double GetValue(double x)
		{
			return source1.GetValue(x) * source1Ratio + source2.GetValue(x) * (1 - source1Ratio);
		}


		public double GetValue(double x, double y)
		{
			return source1.GetValue(x, y) * source1Ratio + source2.GetValue(x, y) * (1 - source1Ratio);
		}


		public double GetValue(double x, double y, double z)
		{
			return source1.GetValue(x, y, z) * source1Ratio + source2.GetValue(x, y, z) * (1 - source1Ratio);
		}


		public double GetValue(double x, double y, double z, double w)
		{
			return source1.GetValue(x, y, z, w) * source1Ratio + source2.GetValue(x, y, z, w) * (1 - source1Ratio);
		}
	}
}
