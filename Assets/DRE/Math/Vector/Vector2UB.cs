using UnityEngine;
using System;

namespace DRE.Mathematics
{
	/// Unsigned byte version of Vector2
	public struct Vector2UB : IEquatable<Vector2UB>, IComparable<Vector2UB>
	{
		public static Vector2UB zero = new Vector2UB( 0, 0);
		public static Vector2UB one  = new Vector2UB( 1, 1);

        byte x, y;


		#region Lifecycle

        public Vector2UB(byte x, byte y)
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

		public bool Equals(Vector2UB v)
		{
			return this == v;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector2UB)
			{
				return this == (Vector2UB) obj;
			}
			else
			{
				return false;
			}
		}

		public int CompareTo(Vector2UB v)
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

		public static bool operator ==(Vector2UB a, Vector2UB b)
		{
			return a.x == b.x && a.y == b.y;
		}

		public static bool operator !=(Vector2UB a, Vector2UB b)
		{
			return a.x != b.x || a.y != b.y;
		}

		#endregion
    }
}
