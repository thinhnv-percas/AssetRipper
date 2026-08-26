namespace ImageMagick;

public sealed class DrawableTextInterwordSpacing : IDrawable, IDrawingWand
{
	public double Spacing { get; set; }

	public DrawableTextInterwordSpacing(double spacing)
	{
		Spacing = spacing;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.TextInterwordSpacing(Spacing);
	}
}
