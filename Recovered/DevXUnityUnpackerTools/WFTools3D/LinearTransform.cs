namespace WFTools3D
{
	public class LinearTransform
	{
		private double _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020;

		private double _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A;

		public double Slope
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020 = value;
			}
		}

		public double Offset
		{
			get
			{
				return _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A;
			}
			set
			{
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A = value;
			}
		}

		public LinearTransform()
		{
			Init(0.0, 1.0, 0.0, 1.0);
		}

		public LinearTransform(double from1, double from2, double to1, double to2)
		{
			Init(from1, from2, to1, to2);
		}

		public void Init(double from1, double from2, double to1, double to2)
		{
			double num = from2 - from1;
			if (num == 0.0)
			{
				num = 1E-100;
			}
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020 = (to2 - to1) / num;
			_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A = to1 - _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020 * from1;
		}

		public double Transform(double value)
		{
			return _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020 * value + _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A;
		}

		public double BackTransform(double value)
		{
			return (value - _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A) / _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020;
		}
	}
}
