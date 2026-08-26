namespace ImageMagick;

public sealed class DrawableTextAlignment : IDrawable, IDrawingWand
{
	public TextAlignment Alignment { get; set; }

	public DrawableTextAlignment(TextAlignment alignment)
	{
		Alignment = alignment;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.TextAlignment(Alignment);
	}
}
