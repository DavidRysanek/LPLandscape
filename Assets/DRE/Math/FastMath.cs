namespace DRE.Mathematics
{
	public static class FastMath
	{
		/// Represents the mathematical constant e.
		public const float E = 2.718282f;
		/// Represents the log base two of e.
		public const float Log2E = 1.442695f;
		/// Represents the log base ten of e.
		public const float Log10E = 0.4342945f;
		/// Represents the value of pi.
		public const float Pi = 3.141593f;
		/// Represents the value of pi times two.
		public const float Pi2 = 6.28318530718f;
		/// Represents the value of pi times four.
		public const float Pi4 = 12.5663706144f;
		/// Represents the value of pi divided by two.
		public const float PiHalf = 1.570796f;
		/// Represents the value of pi divided by four.
		public const float PiQuarter = 0.7853982f;
		/// Represents the value of the square root of two
		public const float Sqrt2 = 1.4142135623730951f;
		/// Represents the value of the square root of three
		public const float Sqrt3 = 1.7320508075688773f;

		/// 60 / 2*pi
		public const float RadiansPerSecondToRPM = 9.549296585513720f;
		/// 2*pi / 60
		public const float RPMToRadiansPerSecond = 0.104719755119660f;
		/// 2*pi / 60000
		public const float RPMToRadiansPerMillisecond = 0.00010471975512f;


		#region Arithmetics

		/// Returns nearest smaller integer number
		/// For example: for -0.1 or -0.9 returns -1
		public static int Floor(float x)
		{
			int xi = (int)x;
			return x < xi ? xi - 1 : xi;
		}

		/// Returns nearest smaller integer number
		/// For example: for -0.1 or -0.9 returns -1
		public static int Floor(double x)
		{
			int xi = (int)x;
			return x < xi ? xi - 1 : xi;
		}


		/// Returns lesser of given values
		public static int Min(int value1, int value2)
		{
			return value1 < value2 ? value1 : value2;
		}

		/// Returns greater of given values
		public static int Max(int value1, int value2)
		{
			return value1 > value2 ? value1 : value2;
		}

		/// Returns lesser of given values
		public static float Min(float value1, float value2)
		{
			return value1 < value2 ? value1 : value2;
		}

		/// Returns greater of given values
		public static float Max(float value1, float value2)
		{
			return value1 > value2 ? value1 : value2;
		}

		/// Returns lesser of given values
		public static double Min(double value1, double value2)
		{
			return value1 < value2 ? value1 : value2;
		}

		/// Returns greater of given values
		public static double Max(double value1, double value2)
		{
			return value1 > value2 ? value1 : value2;
		}


		/// Restricts a value to be within a specified range
		public static int Clamp(int value, int min, int max)
		{
			value = value > max ? max : value;
			value = value < min ? min : value;
			return value;
		}

		/// Restricts a value to be within a specified range
		public static float Clamp(float value, float min, float max)
		{
			value = (value > max) ? max : value;
			value = (value < min) ? min : value;
			return value;
		}

		/// Restricts a value to be within a specified range
		public static double Clamp(double value, double min, double max)
		{
			value = value > max ? max : value;
			value = value < min ? min : value;
			return value;
		}

		#endregion


		#region Interpolation

		/// Linearly interpolates between two values.
		public static float Lerp(float value1, float value2, float amount)
		{
			return value1 + (value2 - value1) * amount;
		}

		/// Linearly interpolates between two values.
		public static double Lerp(double value1, double value2, double amount)
		{
			return value1 + (value2 - value1) * amount;
		}

		#endregion


		#region Angles

		/// Converts degrees to radians.
		public static float ToRadians(float degrees)
		{
			return (degrees / 360.0f) * Pi2;
		}

		/// Converts radians to degrees.
		public static float ToDegrees(float radians)
		{
			return radians * 57.29578f;
		}

		/// Converts degrees to radians.
		public static double ToRadians(double degrees)
		{
			return (degrees / 360.0f) * Pi2;
		}

		/// Converts radians to degrees.
		public static double ToDegrees(double radians)
		{
			return radians * 57.29578;
		}


		/// Returns angle in range 0..2*PI
		public static float RadiansInRangePi2(float angle)
		{
			if (angle > Pi2)
			{
				angle = angle % Pi2;
			}
			else if (angle < 0)
			{
				angle = angle % Pi2 + Pi2;
			}
			return angle;
		}

		/// Returns angle in range 0..2*PI
		public static double RadiansInRangePi2(double radians)
		{
			if (radians > Pi2)
			{            
				radians = radians % Pi2;
			}
			else if (radians < 0)
			{
				radians = radians % Pi2 + Pi2;
			}
			return radians;
		}

		/// Returns angle in range -PI..PI
		public static float RadiansInRangePi(float angle)
		{
			if (angle > Pi)
			{
				angle = angle % Pi - Pi;
			}
			else if (angle < Pi)
			{
				angle = angle % Pi + Pi;
			}
			return angle;
		}

		/// Returns angle in range -PI..PI
		public static double RadiansInRangePi(double angle)
		{
			if (angle > Pi)
			{
				angle = angle % Pi - Pi;
			}
			else if (angle < -Pi)
			{
				angle = angle % Pi + Pi;
			}
			return angle;
		}

		#endregion
	}
}