using UnityEngine;
using System;

namespace DRE.Mathematics
{
	/// Signed long version of Vector3
	public struct Vector3L : IEquatable<Vector3L>
	{
		public static Vector3L zero    = new Vector3L( 0, 0, 0);
		public static Vector3L one     = new Vector3L( 1, 1, 1);
		public static Vector3L left    = new Vector3L(-1, 0, 0);
		public static Vector3L right   = new Vector3L( 1, 0, 0);
		public static Vector3L up      = new Vector3L( 0, 1, 0);
		public static Vector3L down    = new Vector3L( 0,-1, 0);
		public static Vector3L forward = new Vector3L( 0, 0, 1);
		public static Vector3L back    = new Vector3L( 0, 0,-1);

		public long x;
		public long y;
		public long z;


		#region Lifecycle

		public Vector3L(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public Vector3L(long x, long y, long z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		#endregion


		public override string ToString()
		{
			return x + ", " + y + ", " + z;
		}


		#region Comparer

		public bool Equals(Vector3L v)
		{
			return this == v;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector3L)
			{
				return this == (Vector3L) obj;
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return (int)((((x * 397) ^ y) * 397) ^ z);
		}

		#endregion


		#region Operators

		// -> Vector3l

		public static bool operator ==(Vector3L a, Vector3L b)
		{
			return a.x == b.x && a.y == b.y && a.z == b.z;
		}

		public static bool operator !=(Vector3L a, Vector3L b)
		{
			return !(a == b);
		}

		public static Vector3L operator +(Vector3L a, Vector3L b)
		{
			return new Vector3L(a.x + b.x, a.y + b.y, a.z + b.z);
		}

		public static Vector3L operator -(Vector3L a, Vector3L b)
		{
			return new Vector3L(a.x - b.x, a.y - b.y, a.z - b.z);
		}

		public static Vector3L operator *(Vector3L a, Vector3L b)
		{
			return new Vector3L(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		public static Vector3L operator /(Vector3L a, Vector3L b)
		{
			return new Vector3L(a.x / b.x, a.y / b.y, a.z / b.z);
		}

		public static Vector3L operator -(Vector3L a)
		{
			return new Vector3L(-a.x, -a.y, -a.z);
		}

		public static Vector3L operator ~(Vector3L v)
		{
			return new Vector3L(~v.x, ~v.y, ~v.z);
		}

		// int -> Vector3l

		public static Vector3L operator /(Vector3L a, int num)
		{
			return new Vector3L(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3L operator %(Vector3L a, int num)
		{
			return new Vector3L(a.x % num, a.y % num, a.z % num);
		}

		public static Vector3L operator >>(Vector3L v, int shift)
		{
			return new Vector3L(v.x >> shift, v.y >> shift, v.z >> shift);
		}

		public static Vector3L operator <<(Vector3L v, int shift)
		{
			return new Vector3L(v.x << shift, v.y << shift, v.z << shift);
		}

		public static Vector3L operator *(int num, Vector3L b)
		{
			return new Vector3L(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3L operator *(Vector3L a, int num)
		{
			return new Vector3L(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3L operator +(Vector3L a, int b)
		{
			return new Vector3L(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3L operator -(Vector3L a, int b)
		{
			return new Vector3L(a.x - b, a.y - b, a.z - b);
		}

		// long -> Vector3l

		public static Vector3L operator /(Vector3L a, long num)
		{
			return new Vector3L(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3L operator %(Vector3L a, long num)
		{
			return new Vector3L(a.x % num, a.y % num, a.z % num);
		}

		public static Vector3L operator &(Vector3L v, long mask)
		{
			return new Vector3L(v.x & mask, v.y & mask, v.z & mask);
		}

		public static Vector3L operator |(Vector3L v, long mask)
		{
			return new Vector3L(v.x | mask, v.y | mask, v.z | mask);
		}

		public static Vector3L operator ^(Vector3L v, long mask)
		{
			return new Vector3L(v.x ^ mask, v.y ^ mask, v.z ^ mask);
		}

		public static Vector3L operator *(long num, Vector3L b)
		{
			return new Vector3L(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3L operator *(Vector3L a, long num)
		{
			return new Vector3L(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3L operator +(Vector3L a, long b)
		{
			return new Vector3L(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3L operator -(Vector3L a, long b)
		{
			return new Vector3L(a.x - b, a.y - b, a.z - b);
		}

		// Vector3 -> Vector3

		public static Vector3 operator *(Vector3L a, Vector3 b)
		{
			return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		public static Vector3 operator *(Vector3 a, Vector3L b)
		{
			return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		// float -> Vector3

		public static Vector3 operator +(Vector3L a, float b)
		{
			return new Vector3(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3 operator *(float num, Vector3L b)
		{
			return new Vector3(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3 operator *(Vector3L a, float num)
		{
			return new Vector3(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3 operator /(Vector3L a, float num)
		{
			return new Vector3(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3 operator /(float num, Vector3L a)
		{
			return new Vector3(num / a.x, num / a.y, num / a.z);
		}

		// double -> Vector3d

		public static Vector3D operator +(Vector3L a, double b)
		{
			return new Vector3D(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3D operator *(double num, Vector3L b)
		{
			return new Vector3D(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3D operator *(Vector3L a, double num)
		{
			return new Vector3D(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3D operator /(Vector3L a, double num)
		{
			return new Vector3D(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3D operator /(double num, Vector3L a)
		{
			return new Vector3D(num / a.x, num / a.y, num / a.z);
		}

		#endregion
	}
}
