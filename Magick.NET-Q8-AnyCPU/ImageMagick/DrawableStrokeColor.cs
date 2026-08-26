using System.Drawing;

namespace ImageMagick;

public sealed class DrawableStrokeColor : IDrawable, IDrawingWand
{
	public MagickColor Color { get; set; }

	public DrawableStrokeColor(Color color)
	{
		Color = color;
	}

	public DrawableStrokeColor(MagickColor color)
	{
		Throw.IfNull("color", color);
		Color = color;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.StrokeColor(Color);
	}
}
