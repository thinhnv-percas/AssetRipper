namespace ImageMagick;

public sealed class DrawableTextInterlineSpacing : IDrawable, IDrawingWand
{
	public double Spacing { get; set; }

	public DrawableTextInterlineSpacing(double spacing)
	{
		Spacing = spacing;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.TextInterlineSpacing(Spacing);
	}
}
