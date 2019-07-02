using DRE.Mathematics;

namespace DRE.Noise
{
	public class CheckerBoardNoise : INoise
	{
		
		public double GetValue(double x)
		{
			var xi = FastMath.Floor(x) & 0x1;

			return (xi == 0x1) ? -1.0 : 1.0;
		}


		public double GetValue(double x, double y)
		{
			var xi = FastMath.Floor(x) & 0x1;
			var yi = FastMath.Floor(y) & 0x1;

			return ((xi ^ yi) == 0x1) ? -1.0 : 1.0;
		}


		public double GetValue(double x, double y, double z)
		{
			var xi = FastMath.Floor(x) & 0x1;
			var yi = FastMath.Floor(y) & 0x1;
			var zi = FastMath.Floor(z) & 0x1;

			return ((xi ^ yi ^ zi) == 0x1) ? -1.0 : 1.0;
		}


		public double GetValue(double x, double y, double z, double w)
		{
			var xi = FastMath.Floor(x) & 0x1;
			var yi = FastMath.Floor(y) & 0x1;
			var zi = FastMath.Floor(z) & 0x1;
			var wi = FastMath.Floor(z) & 0x1;

			return ((xi ^ yi ^ zi ^ wi) == 0x1) ? -1.0 : 1.0;
		}
	}
}
