namespace ImageMagick;

public sealed class DrawableRotation : IDrawable, IDrawingWand
{
	public double Angle { get; set; }

	public DrawableRotation(double angle)
	{
		Angle = angle;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Rotation(Angle);
	}
}
