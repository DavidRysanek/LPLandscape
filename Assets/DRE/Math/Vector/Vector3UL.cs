using UnityEngine;
using System;

namespace DRE.Mathematics
{
	/// Unsigned long version of Vector3
	public struct Vector3UL : IEquatable<Vector3UL>
	{
		public static Vector3UL zero = new Vector3UL( 0, 0, 0);
		public static Vector3UL one  = new Vector3UL( 1, 1, 1);

		public ulong x;
		public ulong y;
		public ulong z;


		#region Lifecycle

		public Vector3UL(uint x, uint y, uint z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public Vector3UL(ulong x, ulong y, ulong z)
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

		public bool Equals(Vector3UL v)
		{
			return this == v;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector3UL)
			{
				return this == (Vector3UL) obj;
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

		// -> Vector3ul

		public static bool operator ==(Vector3UL a, Vector3UL b)
		{
			return a.x == b.x && a.y == b.y && a.z == b.z;
		}

		public static bool operator !=(Vector3UL a, Vector3UL b)
		{
			return !(a == b);
		}

		public static Vector3UL operator +(Vector3UL a, Vector3UL b)
		{
			return new Vector3UL(a.x + b.x, a.y + b.y, a.z + b.z);
		}

		public static Vector3UL operator -(Vector3UL a, Vector3UL b)
		{
			return new Vector3UL(a.x - b.x, a.y - b.y, a.z - b.z);
		}

		public static Vector3UL operator *(Vector3UL a, Vector3UL b)
		{
			return new Vector3UL(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		public static Vector3UL operator /(Vector3UL a, Vector3UL b)
		{
			return new Vector3UL(a.x / b.x, a.y / b.y, a.z / b.z);
		}

		public static Vector3UL operator ~(Vector3UL v)
		{
			return new Vector3UL(~v.x, ~v.y, ~v.z);
		}

		// uint -> Vector3ul

		public static Vector3UL operator /(Vector3UL a, uint num)
		{
			return new Vector3UL(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3UL operator %(Vector3UL a, uint num)
		{
			return new Vector3UL(a.x % num, a.y % num, a.z % num);
		}

		public static Vector3UL operator >>(Vector3UL v, int shift)
		{
			return new Vector3UL(v.x >> shift, v.y >> shift, v.z >> shift);
		}

		public static Vector3UL operator <<(Vector3UL v, int shift)
		{
			return new Vector3UL(v.x << shift, v.y << shift, v.z << shift);
		}

		public static Vector3UL operator *(uint num, Vector3UL b)
		{
			return new Vector3UL(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3UL operator *(Vector3UL a, uint num)
		{
			return new Vector3UL(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3UL operator +(Vector3UL a, uint b)
		{
			return new Vector3UL(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3UL operator -(Vector3UL a, uint b)
		{
			return new Vector3UL(a.x - b, a.y - b, a.z - b);
		}

		// ulong -> Vector3ul

		public static Vector3UL operator /(Vector3UL a, ulong num)
		{
			return new Vector3UL(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3UL operator %(Vector3UL a, ulong num)
		{
			return new Vector3UL(a.x % num, a.y % num, a.z % num);
		}

		public static Vector3UL operator &(Vector3UL v, ulong mask)
		{
			return new Vector3UL(v.x & mask, v.y & mask, v.z & mask);
		}

		public static Vector3UL operator |(Vector3UL v, ulong mask)
		{
			return new Vector3UL(v.x | mask, v.y | mask, v.z | mask);
		}

		public static Vector3UL operator ^(Vector3UL v, ulong mask)
		{
			return new Vector3UL(v.x ^ mask, v.y ^ mask, v.z ^ mask);
		}

		public static Vector3UL operator *(ulong num, Vector3UL b)
		{
			return new Vector3UL(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3UL operator *(Vector3UL a, ulong num)
		{
			return new Vector3UL(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3UL operator +(Vector3UL a, ulong b)
		{
			return new Vector3UL(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3UL operator -(Vector3UL a, ulong b)
		{
			return new Vector3UL(a.x - b, a.y - b, a.z - b);
		}

		// Vector3 -> Vector3

		public static Vector3 operator *(Vector3UL a, Vector3 b)
		{
			return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		public static Vector3 operator *(Vector3 a, Vector3UL b)
		{
			return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		// float -> Vector3

		public static Vector3 operator +(Vector3UL a, float b)
		{
			return new Vector3(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3 operator *(float num, Vector3UL b)
		{
			return new Vector3(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3 operator *(Vector3UL a, float num)
		{
			return new Vector3(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3 operator /(Vector3UL a, float num)
		{
			return new Vector3(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3 operator /(float num, Vector3UL a)
		{
			return new Vector3(num / a.x, num / a.y, num / a.z);
		}

		// double -> Vector3d

		public static Vector3D operator +(Vector3UL a, double b)
		{
			return new Vector3D(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3D operator *(double num, Vector3UL b)
		{
			return new Vector3D(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3D operator *(Vector3UL a, double num)
		{
			return new Vector3D(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3D operator /(Vector3UL a, double num)
		{
			return new Vector3D(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3D operator /(double num, Vector3UL a)
		{
			return new Vector3D(num / a.x, num / a.y, num / a.z);
		}

		#endregion
	}
}
