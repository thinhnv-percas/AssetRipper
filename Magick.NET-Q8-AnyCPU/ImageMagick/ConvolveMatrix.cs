namespace ImageMagick;

public sealed class ConvolveMatrix : DoubleMatrix
{
	public ConvolveMatrix(int order)
		: base(order, null)
	{
		CheckOrder(order);
	}

	public ConvolveMatrix(int order, params double[] values)
		: base(order, values)
	{
		CheckOrder(order);
	}

	private static void CheckOrder(int order)
	{
		Throw.IfTrue("order", order < 1, "Invalid order specified, value has to be at least 1.");
		Throw.IfTrue("order", order % 2 == 0, "Order must be an odd number.");
	}
}
