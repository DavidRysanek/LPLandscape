using UnityEngine;
using System;

namespace DRE.Mathematics
{
	/// Signed integer version of Vector2
	public struct Vector2I : IEquatable<Vector2I>, IComparable<Vector2I>
    {
		public static Vector2I zero  = new Vector2I( 0, 0);
        public static Vector2I one   = new Vector2I( 1, 1);
        public static Vector2I left  = new Vector2I(-1, 0);
		public static Vector2I right = new Vector2I( 1, 0);
		public static Vector2I up    = new Vector2I( 0, 1);
		public static Vector2I down  = new Vector2I( 0,-1);

        public int x;
        public int y;


		#region Lifecycle

        public Vector2I(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2I(Vector2 v)
        {
			this.x = (int)v.x;
            this.y = (int)v.y;
        }

		#endregion


        public override string ToString()
        {
            return x + ", " + y;
        }


		#region Math

        public static Vector2I Floor(Vector2 v)
        {
			return new Vector2I((int)Math.Floor(v.x), (int)Math.Floor(v.y));
        }

        public static Vector2I Round(Vector2 v)
        {
			return new Vector2I((int)Math.Round(v.x), (int)Math.Round(v.y));
        }

        public bool Between(ref Vector2I a, ref Vector2I b)
        {
            return x >= a.x && x <= b.x || y >= a.y && y <= b.y;
        }

		#endregion


		#region Comparer

		public bool Equals(Vector2I v)
		{
			return this == v;
		}

        public override bool Equals(object obj)
        {
            if (obj is Vector2I)
            {
				return this == (Vector2I) obj;
            }
            else
			{
				return false;
            }
        }

		public int CompareTo(Vector2I v)
		{
			int x = this.x - v.x;
			int y = this.y - v.y;
			return x != 0 ? x : y;
		}

        public override int GetHashCode()
        {
            return (x * 397) ^ y;
        }

		#endregion


		#region Operators

		public static implicit operator Vector2(Vector2I v)
		{
			return new Vector2(v.x, v.y);
		}

		public static Vector2I operator +(Vector2I a, Vector2I b)
		{
			return new Vector2I(a.x + b.x, a.y + b.y);
		}

		public static Vector2I operator +(Vector2I a, int b)
		{
			return new Vector2I(a.x + b, a.y + b);
		}

		public static Vector2I operator -(Vector2I a, Vector2I b)
		{
			return new Vector2I(a.x - b.x, a.y - b.y);
		}

		public static Vector2I operator -(Vector2I a, int value)
		{
			return new Vector2I(a.x - value, a.y - value);
		}

		public static Vector2I operator -(Vector2I a)
		{
			return new Vector2I(-a.x, -a.y);
		}

		public static Vector2I operator *(Vector2I v, int multiplier)
		{
			return new Vector2I(v.x * multiplier, v.y * multiplier);
		}

		public static Vector2I operator /(Vector2I v, int divider)
		{
			return new Vector2I(v.x / divider, v.y / divider);
		}

		public static bool operator ==(Vector2I a, Vector2I b)
		{
			return a.x == b.x && a.y == b.y;
		}

		public static bool operator !=(Vector2I a, Vector2I b)
		{
			return a.x != b.x || a.y != b.y;
		}

		#endregion
    }
}
