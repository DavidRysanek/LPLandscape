using UnityEngine;
using System;

namespace DRE.Mathematics
{
	/// Signed integer version of Vector2
	public struct Vector2D : IEquatable<Vector2D>
	{
		public static Vector2D zero  = new Vector2D( 0, 0);
		public static Vector2D one   = new Vector2D( 1, 1);
		public static Vector2D left  = new Vector2D(-1, 0);
		public static Vector2D right = new Vector2D( 1, 0);
		public static Vector2D up    = new Vector2D( 0, 1);
		public static Vector2D down  = new Vector2D( 0,-1);

		public double x;
		public double y;


		#region Lifecycle

		public Vector2D(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public Vector2D(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public Vector2D(double x, double y)
		{
			this.x = x;
			this.y = y;
		}

		public Vector2D(Vector2 v)
		{
			this.x = v.x;
			this.y = v.y;
		}

		#endregion


		public override string ToString()
		{
			return x + ", " + y;
		}


		#region Math

		public bool Between(ref Vector2D a, ref Vector2D b)
		{
			return x >= a.x && x <= b.x || y >= a.y && y <= b.y;
		}

		#endregion


		#region Comparer

		public bool Equals(Vector2D v)
		{
			return this == v;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector2D)
			{
				return this == (Vector2D) obj;
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
			return hash;
		}

		#endregion


		#region Operators

		public static bool operator ==(Vector2D a, Vector2D b)
		{
			return a.x == b.x && a.y == b.y;
		}

		public static bool operator !=(Vector2D a, Vector2D b)
		{
			return a.x != b.x || a.y != b.y;
		}

		public static Vector2D operator +(Vector2D a, Vector2D b)
		{
			return new Vector2D(a.x + b.x, a.y + b.y);
		}

		public static Vector2D operator +(Vector2D a, int b)
		{
			return new Vector2D(a.x + b, a.y + b);
		}

		public static Vector2D operator -(Vector2D a, Vector2D b)
		{
			return new Vector2D(a.x - b.x, a.y - b.y);
		}

		public static Vector2D operator -(Vector2D a, int value)
		{
			return new Vector2D(a.x - value, a.y - value);
		}

		public static Vector2D operator -(Vector2D a)
		{
			return new Vector2D(-a.x, -a.y);
		}

		public static Vector2D operator *(Vector2D v, int multiplier)
		{
			return new Vector2D(v.x * multiplier, v.y * multiplier);
		}

		public static Vector2D operator /(Vector2D v, int divider)
		{
			return new Vector2D(v.x / divider, v.y / divider);
		}

		#endregion
	}
}
