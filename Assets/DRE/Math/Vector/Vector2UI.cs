using UnityEngine;
using System;

namespace DRE.Mathematics
{
	/// Unsigned integer version of Vector2
	public struct Vector2UI : IEquatable<Vector2UI>, IComparable<Vector2UI>
	{
		public static Vector2UI zero  = new Vector2UI( 0, 0);
		public static Vector2UI one   = new Vector2UI( 1, 1);

		public uint x;
		public uint y;


		#region Lifecycle

		public Vector2UI(uint x, uint y)
		{
			this.x = x;
			this.y = y;
		}

		#endregion


		public override string ToString()
		{
			return x + ", " + y;
		}


		#region Math

		public bool Between(ref Vector2UI a, ref Vector2UI b)
		{
			return x >= a.x && x <= b.x || y >= a.y && y <= b.y;
		}

		#endregion


		#region Comparer

		public bool Equals(Vector2UI v)
		{
			return this == v;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector2UI)
			{
				return this == (Vector2UI) obj;
			}
			else
			{
				return false;
			}
		}

		public int CompareTo(Vector2UI v)
		{
			int x = (int)(this.x - v.x);
			int y = (int)(this.y - v.y);
			return x != 0 ? x : y;
		}

		public override int GetHashCode()
		{
			return (int)((x * 397) ^ y);
		}

		#endregion


		#region Operators

		public static implicit operator Vector2(Vector2UI v)
		{
			return new Vector2(v.x, v.y);
		}

		public static Vector2UI operator +(Vector2UI a, Vector2UI b)
		{
			return new Vector2UI(a.x + b.x, a.y + b.y);
		}

		public static Vector2UI operator +(Vector2UI a, uint b)
		{
			return new Vector2UI(a.x + b, a.y + b);
		}

		public static Vector2UI operator -(Vector2UI a, Vector2UI b)
		{
			return new Vector2UI(a.x - b.x, a.y - b.y);
		}

		public static Vector2UI operator -(Vector2UI a, uint value)
		{
			return new Vector2UI(a.x - value, a.y - value);
		}

		public static Vector2UI operator *(Vector2UI v, uint multiplier)
		{
			return new Vector2UI(v.x * multiplier, v.y * multiplier);
		}

		public static Vector2UI operator /(Vector2UI v, uint divider)
		{
			return new Vector2UI(v.x / divider, v.y / divider);
		}

		public static bool operator ==(Vector2UI a, Vector2UI b)
		{
			return a.x == b.x && a.y == b.y;
		}

		public static bool operator !=(Vector2UI a, Vector2UI b)
		{
			return a.x != b.x || a.y != b.y;
		}

		#endregion
	}
}
