namespace ImageMagick;

public sealed class SparseColorArg
{
	public double X { get; set; }

	public double Y { get; set; }

	public MagickColor Color { get; set; }

	public SparseColorArg(double x, double y, MagickColor color)
	{
		Throw.IfNull("color", color);
		X = x;
		Y = y;
		Color = color;
	}
}
