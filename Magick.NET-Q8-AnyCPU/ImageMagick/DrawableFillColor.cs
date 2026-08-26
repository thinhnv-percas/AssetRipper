using System.Drawing;

namespace ImageMagick;

public sealed class DrawableFillColor : IDrawable, IDrawingWand
{
	public MagickColor Color { get; set; }

	public DrawableFillColor(Color color)
	{
		Color = color;
	}

	public DrawableFillColor(MagickColor color)
	{
		Throw.IfNull("color", color);
		Color = color;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.FillColor(Color);
	}
}
