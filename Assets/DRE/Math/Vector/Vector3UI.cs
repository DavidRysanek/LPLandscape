using UnityEngine;
using System;

namespace DRE.Mathematics
{
	/// Signed integer version of Vector3
	public struct Vector3UI : IEquatable<Vector3UI>, IComparable<Vector3UI>
	{
		public static Vector3UI zero = new Vector3UI( 0, 0, 0);
		public static Vector3UI one  = new Vector3UI( 1, 1, 1);

		public uint x;
		public uint y;
		public uint z;


		#region Lifecycle

		public Vector3UI(uint x, uint y, uint z)
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

		public bool Equals(Vector3UI v)
		{
			return this == v;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector3UI)
			{
				return this == (Vector3UI) obj;
			}
			else
			{
				return false;
			}
		}

		public int CompareTo(Vector3UI v)
		{
			int x = (int)(this.x - v.x);
			int y = (int)(this.y - v.y);
			int z = (int)(this.z - v.z);
			return x != 0 ? x : (y != 0 ? y : z);
		}

		public override int GetHashCode()
		{
			return (int)((((x * 397) ^ y) * 397) ^ z);
		}

		#endregion


		#region Operators

		// -> Vector3ui

		public static bool operator ==(Vector3UI a, Vector3UI b)
		{
			return a.x == b.x && a.y == b.y && a.z == b.z;
		}

		public static bool operator !=(Vector3UI a, Vector3UI b)
		{
			return !(a == b);
		}

		public static Vector3UI operator +(Vector3UI a, Vector3UI b)
		{
			return new Vector3UI(a.x + b.x, a.y + b.y, a.z + b.z);
		}

		public static Vector3UI operator -(Vector3UI a, Vector3UI b)
		{
			return new Vector3UI(a.x - b.x, a.y - b.y, a.z - b.z);
		}

		public static Vector3UI operator *(Vector3UI a, Vector3UI b)
		{
			return new Vector3UI(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		public static Vector3UI operator /(Vector3UI a, Vector3UI b)
		{
			return new Vector3UI(a.x / b.x, a.y / b.y, a.z / b.z);
		}

		public static Vector3UI operator ~(Vector3UI v)
		{
			return new Vector3UI(~v.x, ~v.y, ~v.z);
		}

		// uint -> Vector3ui

		public static Vector3UI operator /(Vector3UI a, uint num)
		{
			return new Vector3UI(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3UI operator %(Vector3UI a, uint num)
		{
			return new Vector3UI(a.x % num, a.y % num, a.z % num);
		}

		public static Vector3UI operator >>(Vector3UI v, int shift)
		{
			return new Vector3UI(v.x >> shift, v.y >> shift, v.z >> shift);
		}

		public static Vector3UI operator <<(Vector3UI v, int shift)
		{
			return new Vector3UI(v.x << shift, v.y << shift, v.z << shift);
		}

		public static Vector3UI operator &(Vector3UI v, uint mask)
		{
			return new Vector3UI(v.x & mask, v.y & mask, v.z & mask);
		}

		public static Vector3UI operator |(Vector3UI v, uint mask)
		{
			return new Vector3UI(v.x | mask, v.y | mask, v.z | mask);
		}

		public static Vector3UI operator ^(Vector3UI v, uint mask)
		{
			return new Vector3UI(v.x ^ mask, v.y ^ mask, v.z ^ mask);
		}

		public static Vector3UI operator *(uint num, Vector3UI b)
		{
			return new Vector3UI(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3UI operator *(Vector3UI a, uint num)
		{
			return new Vector3UI(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3UI operator +(Vector3UI a, uint b)
		{
			return new Vector3UI(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3UI operator -(Vector3UI a, uint b)
		{
			return new Vector3UI(a.x - b, a.y - b, a.z - b);
		}

		// Vector3 -> Vector3

		public static Vector3 operator *(Vector3UI a, Vector3 b)
		{
			return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		public static Vector3 operator *(Vector3 a, Vector3UI b)
		{
			return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		// float -> Vector3

		public static Vector3 operator +(Vector3UI a, float b)
		{
			return new Vector3(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3 operator *(float num, Vector3UI b)
		{
			return new Vector3(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3 operator *(Vector3UI a, float num)
		{
			return new Vector3(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3 operator /(Vector3UI a, float num)
		{
			return new Vector3(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3 operator /(float num, Vector3UI a)
		{
			return new Vector3(num / a.x, num / a.y, num / a.z);
		}

		#endregion
	}
}
