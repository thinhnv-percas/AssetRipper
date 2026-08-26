using System.Runtime.CompilerServices;
using System.Windows.Media.Media3D;

namespace WFTools3D
{
	public class Vector3DTransform
	{
		[CompilerGenerated]
		internal LinearTransform _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020;

		[CompilerGenerated]
		internal LinearTransform _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A;

		[CompilerGenerated]
		internal LinearTransform _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020;

		public LinearTransform TX
		{
			get;
			set;
		}

		public LinearTransform TY
		{
			get;
			set;
		}

		public LinearTransform TZ
		{
			get;
			set;
		}

		public Vector3DTransform()
		{
			TX = new LinearTransform();
			TY = new LinearTransform();
			TZ = new LinearTransform();
		}

		public void Init(Vector3D v0, Vector3D v1, double t0 = 0.0, double t1 = 1.0)
		{
			TX.Init(t0, t1, v0.X, v1.X);
			TY.Init(t0, t1, v0.Y, v1.Y);
			TZ.Init(t0, t1, v0.Z, v1.Z);
		}

		public Vector3D GetVector(double t)
		{
			return new Vector3D(TX.Transform(t), TY.Transform(t), TZ.Transform(t));
		}

		public Vector3D Transform(Vector3D v)
		{
			return new Vector3D(TX.Transform(v.X), TY.Transform(v.Y), TZ.Transform(v.Z));
		}

		public Vector3D BackTransform(Vector3D v)
		{
			return new Vector3D(TX.BackTransform(v.X), TY.BackTransform(v.Y), TZ.BackTransform(v.Z));
		}
	}
}
