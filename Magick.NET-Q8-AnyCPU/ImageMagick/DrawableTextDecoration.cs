namespace ImageMagick;

public sealed class DrawableTextDecoration : IDrawable, IDrawingWand
{
	public TextDecoration Decoration { get; set; }

	public DrawableTextDecoration(TextDecoration decoration)
	{
		Decoration = decoration;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.TextDecoration(Decoration);
	}
}
