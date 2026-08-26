namespace ImageMagick;

public sealed class DrawableText : IDrawable, IDrawingWand
{
	public string Value { get; set; }

	public double X { get; set; }

	public double Y { get; set; }

	public DrawableText(double x, double y, string value)
	{
		Throw.IfNullOrEmpty("value", value);
		X = x;
		Y = y;
		Value = value;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Text(X, Y, Value);
	}
}
