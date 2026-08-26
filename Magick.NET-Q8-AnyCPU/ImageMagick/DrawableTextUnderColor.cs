using System.Drawing;

namespace ImageMagick;

public sealed class DrawableTextUnderColor : IDrawable, IDrawingWand
{
	public MagickColor Color { get; set; }

	public DrawableTextUnderColor(Color color)
	{
		Color = color;
	}

	public DrawableTextUnderColor(MagickColor color)
	{
		Throw.IfNull("color", color);
		Color = color;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.TextUnderColor(Color);
	}
}
