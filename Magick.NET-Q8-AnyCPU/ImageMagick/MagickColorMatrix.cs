namespace ImageMagick;

public sealed class MagickColorMatrix : DoubleMatrix
{
	public MagickColorMatrix(int order)
		: base(order, null)
	{
		CheckOrder(order);
	}

	public MagickColorMatrix(int order, params double[] values)
		: base(order, values)
	{
		CheckOrder(order);
	}

	private static void CheckOrder(int order)
	{
		Throw.IfTrue("order", order < 1 || order > 6, "Invalid order specified, range 1-6.");
	}
}
