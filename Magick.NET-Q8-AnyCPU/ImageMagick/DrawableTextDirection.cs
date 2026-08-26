namespace ImageMagick;

public sealed class DrawableTextDirection : IDrawable, IDrawingWand
{
	public TextDirection Direction { get; set; }

	public DrawableTextDirection(TextDirection direction)
	{
		Direction = direction;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.TextDirection(Direction);
	}
}
