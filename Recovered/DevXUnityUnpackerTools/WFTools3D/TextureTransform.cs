using System.Windows;

namespace WFTools3D
{
	public class TextureTransform
	{
		private LinearTransform _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A = new LinearTransform();

		private LinearTransform _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020 = new LinearTransform();

		public TextureTransform(double from1, double from2, double tx1, double tx2, double ty1, double ty2)
		{
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A.Init(from1, from2, tx1, tx2);
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020.Init(from1, from2, ty1, ty2);
		}

		public Point Transform(double x, double y)
		{
			return new Point(MathUtils.Clamp(_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A.Transform(x), 0.0, 1.0), MathUtils.Clamp(_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020.Transform(y), 0.0, 1.0));
		}
	}
}
