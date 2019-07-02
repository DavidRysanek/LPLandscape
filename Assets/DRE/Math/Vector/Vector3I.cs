using UnityEngine;
using System;

namespace DRE.Mathematics
{
	/// Signed integer version of Vector3
	public struct Vector3I : IEquatable<Vector3I>, IComparable<Vector3I>
	{
		public static Vector3I zero    = new Vector3I( 0, 0, 0);
		public static Vector3I one     = new Vector3I( 1, 1, 1);
		public static Vector3I left    = new Vector3I(-1, 0, 0);
		public static Vector3I right   = new Vector3I( 1, 0, 0);
		public static Vector3I up      = new Vector3I( 0, 1, 0);
		public static Vector3I down    = new Vector3I( 0,-1, 0);
		public static Vector3I forward = new Vector3I( 0, 0, 1);
		public static Vector3I back    = new Vector3I( 0, 0,-1);

		public int x;
		public int y;
		public int z;


		#region Lifecycle

		public Vector3I(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public Vector3I(float x, float y, float z)
		{
			this.x = (int)x;
			this.y = (int)y;
			this.z = (int)z;
		}

		public Vector3I(double x, double y, double z)
		{
			this.x = (int)x;
			this.y = (int)y;
			this.z = (int)z;
		}

		public Vector3I(Vector3 v)
		{
			this.x = (int)v.x;
			this.y = (int)v.y;
			this.z = (int)v.z;
		}

		#endregion


		public override string ToString()
		{
			return x + ", " + y + ", " + z;
		}


		#region Comparer

		public bool Equals(Vector3I v)
		{
			return this == v;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector3I)
			{
				return this == (Vector3I) obj;
			}
			else
			{
				return false;
			}
		}

		public int CompareTo(Vector3I v)
		{
			int x = this.x - v.x;
			int y = this.y - v.y;
			int z = this.z - v.z;
			return x != 0 ? x : (y != 0 ? y : z);
		}

		public override int GetHashCode()
		{
			return (((x * 397) ^ y) * 397) ^ z;
		}

		#endregion


		#region Operators

		// -> Vector3i

		public static bool operator ==(Vector3I a, Vector3I b)
		{
			return a.x == b.x && a.y == b.y && a.z == b.z;
		}

		public static bool operator !=(Vector3I a, Vector3I b)
		{
			return !(a == b);
		}

		public static Vector3I operator +(Vector3I a, Vector3I b)
		{
			return new Vector3I(a.x + b.x, a.y + b.y, a.z + b.z);
		}

		public static Vector3I operator -(Vector3I a, Vector3I b)
		{
			return new Vector3I(a.x - b.x, a.y - b.y, a.z - b.z);
		}

		public static Vector3I operator *(Vector3I a, Vector3I b)
		{
			return new Vector3I(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		public static Vector3I operator /(Vector3I a, Vector3I b)
		{
			return new Vector3I(a.x / b.x, a.y / b.y, a.z / b.z);
		}

		public static Vector3I operator -(Vector3I a)
		{
			return new Vector3I(-a.x, -a.y, -a.z);
		}

		public static Vector3I operator ~(Vector3I v)
		{
			return new Vector3I(~v.x, ~v.y, ~v.z);
		}

		// int -> Vector3i

		public static Vector3I operator /(Vector3I a, int num)
		{
			return new Vector3I(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3I operator %(Vector3I a, int num)
		{
			return new Vector3I(a.x % num, a.y % num, a.z % num);
		}

		public static Vector3I operator >>(Vector3I v, int shift)
		{
			return new Vector3I(v.x >> shift, v.y >> shift, v.z >> shift);
		}

		public static Vector3I operator <<(Vector3I v, int shift)
		{
			return new Vector3I(v.x << shift, v.y << shift, v.z << shift);
		}

		public static Vector3I operator &(Vector3I v, int mask)
		{
			return new Vector3I(v.x & mask, v.y & mask, v.z & mask);
		}

		public static Vector3I operator |(Vector3I v, int mask)
		{
			return new Vector3I(v.x | mask, v.y | mask, v.z | mask);
		}

		public static Vector3I operator ^(Vector3I v, int mask)
		{
			return new Vector3I(v.x ^ mask, v.y ^ mask, v.z ^ mask);
		}

		public static Vector3I operator *(int num, Vector3I b)
		{
			return new Vector3I(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3I operator *(Vector3I a, int num)
		{
			return new Vector3I(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3I operator +(Vector3I a, int b)
		{
			return new Vector3I(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3I operator -(Vector3I a, int b)
		{
			return new Vector3I(a.x - b, a.y - b, a.z - b);
		}

		// Vector3 -> Vector3

		public static Vector3 operator *(Vector3I a, Vector3 b)
		{
			return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		public static Vector3 operator *(Vector3 a, Vector3I b)
		{
			return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		// float -> Vector3

		public static Vector3 operator +(Vector3I a, float b)
		{
			return new Vector3(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3 operator *(float num, Vector3I b)
		{
			return new Vector3(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3 operator *(Vector3I a, float num)
		{
			return new Vector3(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3 operator /(Vector3I a, float num)
		{
			return new Vector3(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3 operator /(float num, Vector3I a)
		{
			return new Vector3(num / a.x, num / a.y, num / a.z);
		}

		#endregion
	}
}
