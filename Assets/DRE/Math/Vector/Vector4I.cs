using UnityEngine;
using System;

namespace DRE.Mathematics
{
    /// Signed integer version of Vector4
	public struct Vector4I : IEquatable<Vector4I>, IComparable<Vector4I>
	{
		public static Vector4I zero = new Vector4I( 0, 0, 0, 0);
		public static Vector4I one  = new Vector4I( 1, 1, 1, 1);

        public int x;
        public int y;
        public int z;
        public int w;


		#region Lifecycle

        public Vector4I(int x, int y, int z, int w)
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

		public bool Equals(Vector4I v)
		{
			return this == v;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector4I)
			{
				return this == (Vector4I) obj;
			}
			else
			{
				return false;
			}
		}

        public int CompareTo(Vector4I v)
        {
            int x = this.x - v.x;
			int y = this.y - v.y;
			int z = this.z - v.z;
			int w = this.w - v.w;
            return x != 0 ? x : (y != 0 ? y : (z != 0 ? z : w));
        }

		public override int GetHashCode()
		{
			return (((((x * 397) ^ y) * 397) ^ z) * 397) ^ w;
		}

		#endregion


		#region Operators

		public static bool operator ==(Vector4I a, Vector4I b)
		{
			return a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
		}

		public static bool operator !=(Vector4I a, Vector4I b)
		{
			return !(a == b);
		}

		public static Vector4I operator *(Vector4I a, Vector4I b)
		{
			return new Vector4I(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
		}

		#endregion
    }
}
