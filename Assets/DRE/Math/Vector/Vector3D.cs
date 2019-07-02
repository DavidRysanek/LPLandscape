using UnityEngine;
using System;

namespace DRE.Mathematics
{
	/// Double version of Vector3
	public struct Vector3D : IEquatable<Vector3D>
	{
		public static Vector3D zero    = new Vector3D( 0, 0, 0);
		public static Vector3D one     = new Vector3D( 1, 1, 1);
		public static Vector3D left    = new Vector3D(-1, 0, 0);
		public static Vector3D right   = new Vector3D( 1, 0, 0);
		public static Vector3D up      = new Vector3D( 0, 1, 0);
		public static Vector3D down    = new Vector3D( 0,-1, 0);
		public static Vector3D forward = new Vector3D( 0, 0, 1);
		public static Vector3D back    = new Vector3D( 0, 0,-1);

		public double x;
		public double y;
		public double z;


		#region Lifecycle

		public Vector3D(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public Vector3D(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public Vector3D(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public Vector3D(Vector3 v)
		{
			this.x = v.x;
			this.y = v.y;
			this.z = v.z;
		}

		#endregion


		public override string ToString()
		{
			return x + ", " + y + ", " + z;
		}


		#region Comparer

		public bool Equals(Vector3D v)
		{
			return this == v;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector3D)
			{
				return this == (Vector3D) obj;
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
			return hash;
		}

		#endregion


		#region Operators

		public static bool operator ==(Vector3D a, Vector3D b)
		{
			return a.x == b.x && a.y == b.y && a.z == b.z;
		}

		public static bool operator !=(Vector3D a, Vector3D b)
		{
			return !(a == b);
		}

		public static Vector3D operator -(Vector3D a)
		{
			return new Vector3D(-a.x, -a.y, -a.z);
		}

		public static Vector3D operator +(Vector3D a, Vector3D b)
		{
			return new Vector3D(a.x + b.x, a.y + b.y, a.z + b.z);
		}

		public static Vector3D operator -(Vector3D a, Vector3D b)
		{
			return new Vector3D(a.x - b.x, a.y - b.y, a.z - b.z);
		}

		public static Vector3D operator *(Vector3D a, Vector3D b)
		{
			return new Vector3D(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		public static Vector3D operator /(Vector3D a, Vector3D b)
		{
			return new Vector3D(a.x / b.x, a.y / b.y, a.z / b.z);
		}

		// Vector3 operands

		public static Vector3D operator *(Vector3D a, Vector3 b)
		{
			return new Vector3D(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		public static Vector3D operator *(Vector3 a, Vector3D b)
		{
			return new Vector3D(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		// Integer operands

		public static Vector3D operator +(Vector3D a, int b)
		{
			return new Vector3D(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3D operator -(Vector3D a, int b)
		{
			return new Vector3D(a.x - b, a.y - b, a.z - b);
		}

		public static Vector3D operator *(int num, Vector3D b)
		{
			return new Vector3D(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3D operator *(Vector3D a, int num)
		{
			return new Vector3D(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3D operator /(Vector3D a, int num)
		{
			return new Vector3D(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3D operator %(Vector3D a, int num)
		{
			return new Vector3D(a.x % num, a.y % num, a.z % num);
		}

		// Float operands

		public static Vector3D operator +(Vector3D a, float b)
		{
			return new Vector3D(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3D operator -(Vector3D a, float b)
		{
			return new Vector3D(a.x - b, a.y - b, a.z - b);
		}

		public static Vector3D operator *(float num, Vector3D b)
		{
			return new Vector3D(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3D operator *(Vector3D a, float num)
		{
			return new Vector3D(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3D operator /(Vector3D a, float num)
		{
			return new Vector3D(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3D operator /(float num, Vector3D a)
		{
			return new Vector3D(num / a.x, num / a.y, num / a.z);
		}

		// Double operands

		public static Vector3D operator +(Vector3D a, double b)
		{
			return new Vector3D(a.x + b, a.y + b, a.z + b);
		}

		public static Vector3D operator -(Vector3D a, double b)
		{
			return new Vector3D(a.x - b, a.y - b, a.z - b);
		}

		public static Vector3D operator *(double num, Vector3D b)
		{
			return new Vector3D(num * b.x, num * b.y, num * b.z);
		}

		public static Vector3D operator *(Vector3D a, double num)
		{
			return new Vector3D(num * a.x, num * a.y, num * a.z);
		}

		public static Vector3D operator /(Vector3D a, double num)
		{
			return new Vector3D(a.x / num, a.y / num, a.z / num);
		}

		public static Vector3D operator /(double num, Vector3D a)
		{
			return new Vector3D(num / a.x, num / a.y, num / a.z);
		}

		#endregion
	}
}
