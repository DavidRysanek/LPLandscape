using UnityEngine;
using System;

namespace DRE.Mathematics
{
	/// Byte version of Vector2
	public struct Vector2B : IEquatable<Vector2B>, IComparable<Vector2B>
	{
		public static Vector2B zero = new Vector2B( 0, 0);
		public static Vector2B one  = new Vector2B( 1, 1);

		sbyte x, y;


		#region Lifecycle

		public Vector2B(sbyte x, sbyte y)
		{
			this.x = x;
			this.y = y;
		}

		#endregion


		public override string ToString()
		{
			return x + ", " + y;
		}


		#region Comparer

		public bool Equals(Vector2B v)
		{
			return this == v;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector2B)
			{
				return this == (Vector2B) obj;
			}
			else
			{
				return false;
			}
		}

		public int CompareTo(Vector2B v)
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

		public static bool operator ==(Vector2B a, Vector2B b)
		{
			return a.x == b.x && a.y == b.y;
		}

		public static bool operator !=(Vector2B a, Vector2B b)
		{
			return a.x != b.x || a.y != b.y;
		}

		#endregion
	}
}
