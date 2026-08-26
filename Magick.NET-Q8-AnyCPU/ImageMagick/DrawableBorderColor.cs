using System.Drawing;

namespace ImageMagick;

public sealed class DrawableBorderColor : IDrawable, IDrawingWand
{
	public MagickColor Color { get; set; }

	public DrawableBorderColor(Color color)
		: this(new MagickColor(color))
	{
	}

	public DrawableBorderColor(MagickColor color)
	{
		Throw.IfNull("color", color);
		Color = color;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.BorderColor(Color);
	}
}
