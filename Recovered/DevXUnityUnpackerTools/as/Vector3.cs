namespace @as
{
	internal struct Vector3
	{
		internal float x;

		internal float y;

		internal float z;

		internal string xVal => CultureFormatter.Foramt(x);

		internal string yVal => CultureFormatter.Foramt(y);

		internal string zVal => CultureFormatter.Foramt(z);

		internal bool IsZero
		{
			get
			{
				if (x == 0f && y == 0f)
				{
					return z == 0f;
				}
				return false;
			}
		}

		internal Vector3(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		internal void _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020(_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020 _0020)
		{
			x = _0020._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A();
			y = _0020._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A();
			z = _0020._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A();
		}

		public override string ToString()
		{
			return "{x: " + x._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020() + ", y: " + y._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020() + ", z: " + z._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020() + "}";
		}

		internal static Vector3 _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A(Vector3 _0020, float _0020_000A)
		{
			Vector3 result = default(Vector3);
			result.x = _0020.x * _0020_000A;
			result.y = _0020.y * _0020_000A;
			result.z = _0020.z * _0020_000A;
			return result;
		}

		internal static Vector3 _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A(Vector3 _0020, Vector3 _0020_000A)
		{
			Vector3 result = default(Vector3);
			result.x = _0020.x * _0020_000A.x;
			result.y = _0020.y * _0020_000A.y;
			result.z = _0020.z * _0020_000A.z;
			return result;
		}

		public static Vector3 operator +(Vector3 m1, Vector3 m2)
		{
			return new Vector3(m1.x + m2.x, m1.y + m2.y, m1.z + m2.z);
		}

		public static Vector3 operator -(Vector3 m1, Vector3 m2)
		{
			return new Vector3(m1.x - m2.x, m1.y - m2.y, m1.z - m2.z);
		}

		public static Vector3 operator *(Vector3 m1, float f)
		{
			return new Vector3(m1.x * f, m1.y * f, m1.z * f);
		}
	}
}
