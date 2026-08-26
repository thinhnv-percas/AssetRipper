using System.Runtime.CompilerServices;
using System.Windows.Media.Media3D;

namespace WFTools3D
{
	public class Point3DTransform
	{
		[CompilerGenerated]
		private LinearTransform _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020;

		[CompilerGenerated]
		private LinearTransform _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A;

		[CompilerGenerated]
		private LinearTransform _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020;

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

		public Point3DTransform()
		{
			TX = new LinearTransform();
			TY = new LinearTransform();
			TZ = new LinearTransform();
		}

		public void Init(Point3D p0, Point3D p1, double t0 = 0.0, double t1 = 1.0)
		{
			TX.Init(t0, t1, p0.X, p1.X);
			TY.Init(t0, t1, p0.Y, p1.Y);
			TZ.Init(t0, t1, p0.Z, p1.Z);
		}

		public Point3D GetPoint(double t)
		{
			return new Point3D(TX.Transform(t), TY.Transform(t), TZ.Transform(t));
		}

		public Point3D Transform(Point3D pt)
		{
			return new Point3D(TX.Transform(pt.X), TY.Transform(pt.Y), TZ.Transform(pt.Z));
		}

		public Point3D BackTransform(Point3D pt)
		{
			return new Point3D(TX.BackTransform(pt.X), TY.BackTransform(pt.Y), TZ.BackTransform(pt.Z));
		}
	}
}
