using UnityEngine;
using System;

namespace DRE.Mathematics
{
	/// Signed integer version of Vector4
	public struct Vector4UI : IEquatable<Vector4UI>, IComparable<Vector4UI>
	{
		public static Vector4UI zero = new Vector4UI( 0, 0, 0, 0);
		public static Vector4UI one  = new Vector4UI( 1, 1, 1, 1);

		public uint x;
		public uint y;
		public uint z;
		public uint w;


		#region Lifecycle

		public Vector4UI(uint x, uint y, uint z, uint w)
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

		public bool Equals(Vector4UI v)
		{
			return this == v;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector4UI)
			{
				return this == (Vector4UI) obj;
			}
			else
			{
				return false;
			}
		}

		public int CompareTo(Vector4UI v)
		{
			int x = (int)(this.x - v.x);
			int y = (int)(this.y - v.y);
			int z = (int)(this.z - v.z);
			int w = (int)(this.w - v.w);
			return x != 0 ? x : (y != 0 ? y : (z != 0 ? z : w));
		}

		public override int GetHashCode()
		{
			return (int)((((((x * 397) ^ y) * 397) ^ z) * 397) ^ w);
		}

		#endregion


		#region Operators

		public static bool operator ==(Vector4UI a, Vector4UI b)
		{
			return a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
		}

		public static bool operator !=(Vector4UI a, Vector4UI b)
		{
			return !(a == b);
		}

		public static Vector4UI operator *(Vector4UI a, Vector4UI b)
		{
			return new Vector4UI(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
		}

		#endregion
	}
}
