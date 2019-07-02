using UnityEngine;
using System;

namespace DRE.Mathematics
{
	/// Signed integer version of Vector4
	public struct Vector4D : IEquatable<Vector4D>
	{
		public static Vector4D zero = new Vector4D( 0, 0, 0, 0);
		public static Vector4D one  = new Vector4D( 1, 1, 1, 1);

		public double x;
		public double y;
		public double z;
		public double w;


		#region Lifecycle

		public Vector4D(int x, int y, int z, int w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		public Vector4D(float x, float y, float z, float w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		public Vector4D(double x, double y, double z, double w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		#endregion


		public override string ToString()
		{
			return x + ", " + y + ", " + z + ", " + w;
		}


		#region Comparer

		public bool Equals(Vector4D v)
		{
			return this == v;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector4D)
			{
				return this == (Vector4D) obj;
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			int hash = (int)(x * 997);
			hash = (hash * 397) ^ (int)(y * 997);
			hash = (hash * 397) ^ (int)(z * 997);
			hash = (hash * 397) ^ (int)(w * 997);
			return hash;
		}

		#endregion


		#region Operators

		public static bool operator ==(Vector4D a, Vector4D b)
		{
			return a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
		}

		public static bool operator !=(Vector4D a, Vector4D b)
		{
			return !(a == b);
		}

		public static Vector4D operator *(Vector4D a, Vector4D b)
		{
			return new Vector4D(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
		}

		#endregion
	}
}
