namespace ImageMagick;

public sealed class DrawableSkewY : IDrawable, IDrawingWand
{
	public double Angle { get; set; }

	public DrawableSkewY(double angle)
	{
		Angle = angle;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.SkewY(Angle);
	}
}
