using UnityEngine;
using System;

namespace DRE.Mathematics
{
	/// Unsigned byte version of Vector3
	public struct Vector3UB : IEquatable<Vector3UB>, IComparable<Vector3UB>
	{
		public static Vector3UB zero = new Vector3UB( 0, 0, 0);
		public static Vector3UB one  = new Vector3UB( 1, 1, 1);

		public byte x;
		public byte y;
		public byte z;


		#region Lifecycle

		public Vector3UB(byte x, byte y, byte z)
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

		public bool Equals(Vector3UB v)
		{
			return this == v;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector3UB)
			{
				return this == (Vector3UB) obj;
			}
			else
			{
				return false;
			}
		}

		public int CompareTo(Vector3UB v)
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

		// -> Vector3ub

		public static bool operator ==(Vector3UB a, Vector3UB b)
		{
			return a.x == b.x && a.y == b.y && a.z == b.z;
		}

		public static bool operator !=(Vector3UB a, Vector3UB b)
		{
			return !(a == b);
		}

		// -> Vector3ub

		public static Vector3UB operator ~(Vector3UB v)
		{
			return new Vector3UB((byte)~v.x, (byte)~v.y, (byte)~v.z);
		}

		// -> Vector3ui

		public static Vector3UI operator /(Vector3UB a, Vector3UB b)
		{
			return new Vector3UI((uint)(a.x / b.x), (uint)(a.y / b.y), (uint)(a.z / b.z));
		}

		public static Vector3UI operator +(Vector3UB a, Vector3UB b)
		{
			return new Vector3UI((uint)(a.x + b.x), (uint)(a.y + b.y), (uint)(a.z + b.z));
		}

		public static Vector3UI operator -(Vector3UB a, Vector3UB b)
		{
			return new Vector3UI((uint)(a.x - b.x), (uint)(a.y - b.y), (uint)(a.z - b.z));
		}

		public static Vector3UI operator *(Vector3UB a, Vector3UB b)
		{
			return new Vector3UI((uint)(a.x * b.x), (uint)(a.y * b.y), (uint)(a.z * b.z));
		}

		// byte -> Vector3ub

		public static Vector3UB operator %(Vector3UB a, byte num)
		{
			return new Vector3UB((byte)(a.x % num), (byte)(a.y % num), (byte)(a.z % num));
		}

		public static Vector3UB operator &(Vector3UB v, byte mask)
		{
			return new Vector3UB((byte)(v.x & mask), (byte)(v.y & mask), (byte)(v.z & mask));
		}

		public static Vector3UB operator |(Vector3UB v, byte mask)
		{
			return new Vector3UB((byte)(v.x | mask), (byte)(v.y | mask), (byte)(v.z | mask));
		}

		public static Vector3UB operator ^(Vector3UB v, byte mask)
		{
			return new Vector3UB((byte)(v.x ^ mask), (byte)(v.y ^ mask), (byte)(v.z ^ mask));
		}

		// byte -> Vector3ui

		public static Vector3UI operator /(Vector3UB a, byte num)
		{
			return new Vector3UI((uint)(a.x / num), (uint)(a.y / num), (uint)(a.z / num));
		}

		public static Vector3UI operator *(byte num, Vector3UB b)
		{
			return new Vector3UI((uint)(num * b.x), (uint)(num * b.y), (uint)(num * b.z));
		}

		public static Vector3UI operator *(Vector3UB a, byte num)
		{
			return new Vector3UI((uint)(num * a.x), (uint)(num * a.y), (uint)(num * a.z));
		}

		public static Vector3UI operator +(Vector3UB a, byte b)
		{
			return new Vector3UI((uint)(a.x + b), (uint)(a.y + b), (uint)(a.z + b));
		}

		// byte -> Vector3i

		public static Vector3I operator -(Vector3UB a, byte b)
		{
			return new Vector3I(a.x - b, a.y - b, a.z - b);
		}

		// Vector3 -> Vector3

		public static Vector3 operator *(Vector3UB a, Vector3 b)
		{
			return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		public static Vector3 operator *(Vector3 a, Vector3UB b)
		{
			return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		// float -> Vector3

		public static Vector3 operator +(Vector3UB a, float b)
		{
			return new Vector3(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3 operator *(float num, Vector3UB b)
		{
			return new Vector3(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3 operator *(Vector3UB a, float num)
		{
			return new Vector3(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3 operator /(Vector3UB a, float num)
		{
			return new Vector3(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3 operator /(float num, Vector3UB a)
		{
			return new Vector3(num / a.x, num / a.y, num / a.z);
		}

		#endregion
	}
}
