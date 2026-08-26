namespace ImageMagick;

public sealed class DrawableSkewX : IDrawable, IDrawingWand
{
	public double Angle { get; set; }

	public DrawableSkewX(double angle)
	{
		Angle = angle;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.SkewX(Angle);
	}
}
