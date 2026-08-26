namespace ImageMagick;

public sealed class DrawableTextKerning : IDrawable, IDrawingWand
{
	public double Kerning { get; set; }

	public DrawableTextKerning(double kerning)
	{
		Kerning = kerning;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.TextKerning(Kerning);
	}
}
